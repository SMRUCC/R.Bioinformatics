﻿#Region "Microsoft.VisualBasic::37b003216bc1bedb8ad3dc3957531738, RDotNET\NativeLibrary\DynamicInterop\PlatformUtility.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.



    ' /********************************************************************************/

    ' Summaries:

    '     Class PlatformUtility
    ' 
    '         Properties: IsUnix
    ' 
    '         Constructor: (+1 Overloads) Sub New
    '         Function: CreateLibraryFileName, ExecCommand, findFirstFullPath, FindFirstFullPath, FindFullPath
    '                   FindFullPathEnvVar, GetPlatform, GetPlatformNotSupportedMsg
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports System.IO

Namespace NativeLibrary.DynamicInterop
    ''' <summary>
    ''' Helper class with functions whose behavior may be depending on the platform 
    ''' </summary>
    Public NotInheritable Class PlatformUtility
        Private Sub New()
        End Sub
        ''' <summary>
        ''' Is the platform unix-like (Unix or MacOX)
        ''' </summary>
        Public Shared ReadOnly Property IsUnix() As Boolean
            Get
                Dim p = GetPlatform()
                Return p = PlatformID.MacOSX OrElse p = PlatformID.Unix
            End Get
        End Property

        ''' <summary>
        ''' Gets the platform on which the current process runs.
        ''' </summary>
        ''' <remarks>
        ''' <see cref="Environment.OSVersion"/>'s platform is not <see cref="PlatformID.MacOSX"/> even on Mac OS X.
        ''' This method returns <see cref="PlatformID.MacOSX"/> when the current process runs on Mac OS X.
        ''' This method uses UNIX's uname command to check the operating system,
        ''' so this method cannot check the OS correctly if the PATH environment variable is changed (will returns <see cref="PlatformID.Unix"/>).
        ''' </remarks>
        ''' <returns>The current platform.</returns>
        Public Shared Function GetPlatform() As PlatformID
            If Not curPlatform.HasValue Then
                Dim platform = Environment.OSVersion.Platform
                If platform <> PlatformID.Unix Then
                    curPlatform = platform
                Else
                    Try
                        Dim kernelName = ExecCommand("uname", "-s")
                        curPlatform = (If(kernelName = "Darwin", PlatformID.MacOSX, platform))
                    Catch generatedExceptionName As Win32Exception
                        ' probably no PATH to uname.
                        curPlatform = platform
                    End Try
                End If
            End If
            Return curPlatform.Value
        End Function

        Private Shared curPlatform As System.Nullable(Of PlatformID) = Nothing

        ''' <summary>
        ''' Execute a command in a new process
        ''' </summary>
        ''' <param name="processName">Process name e.g. "uname"</param>
        ''' <param name="arguments">Arguments e.g. "-s"</param>
        ''' <returns>The output of the command to the standard output stream</returns>
        Public Shared Function ExecCommand(processName As String, arguments As String) As String
            Using proc = New Process()
                proc.StartInfo.FileName = processName
                proc.StartInfo.Arguments = arguments
                proc.StartInfo.RedirectStandardOutput = True
                proc.StartInfo.UseShellExecute = False
                proc.StartInfo.CreateNoWindow = True
                proc.Start()
                Dim kernelName = proc.StandardOutput.ReadLine()
                proc.WaitForExit()
                Return kernelName
            End Using
        End Function

        ''' <summary>
        ''' Gets a message saying the current platform is not supported
        ''' </summary>
        ''' <returns>The platform not supported message.</returns>
        Public Shared Function GetPlatformNotSupportedMsg() As String
            Return String.Format("Platform {0} is not supported.", Environment.OSVersion.Platform.ToString())
        End Function

        ''' <summary>
        ''' Given a DLL short file name, find all the matching occurences in directories as stored in an environment variable such as the PATH.
        ''' </summary>
        ''' <returns>One or more full file names found to exist</returns>
        ''' <param name="dllName">short file name.</param>
        ''' <param name="envVarName">Environment variable name - default PATH</param>
        Public Shared Function FindFullPathEnvVar(dllName As String, Optional envVarName As String = "PATH") As String()
            Dim searchPaths = (If(Environment.GetEnvironmentVariable(envVarName), "")).Split(Path.PathSeparator)
            Return FindFullPath(dllName, searchPaths)
        End Function

        ''' <summary>
        ''' Given a DLL short file name, find all the matching occurences in directories.
        ''' </summary>
        ''' <returns>One or more full file names found to exist</returns>
        ''' <param name="dllName">short file name.</param>
        ''' <param name="directories">Directories in which to search for matching file names</param>
        Public Shared Function FindFullPath(dllName As String, ParamArray directories As String()) As String()
            Return directories.[Select](Function(directory) Path.Combine(directory, dllName)).Where(AddressOf File.Exists).ToArray()
        End Function

        ''' <summary> Given a DLL short file name, short or otherwise, searches for the first full path.</summary>
        '''
        ''' <exception cref="DllNotFoundException"> Thrown when a DLL Not Found error condition occurs.</exception>
        '''
        ''' <param name="nativeLibFilename"> Filename of the native library file.</param>
        ''' <param name="libname">           (Optional) human-readable name of the library.</param>
        ''' <param name="envVarName">        (Optional)
        '''                                  Environment variable to use for search path(s) - 
        '''                                  defaults according to platform to PATH or LD_LIBRARY_PATH if empty.</param>
        ''' <returns> The found full path.</returns>
        Public Shared Function FindFirstFullPath(nativeLibFilename As String, Optional libname As String = "native library", Optional envVarName As String = "") As String
            If String.IsNullOrEmpty(nativeLibFilename) OrElse Not Path.IsPathRooted(nativeLibFilename) Then
                nativeLibFilename = findFirstFullPath(nativeLibFilename, envVarName)
            ElseIf Not File.Exists(nativeLibFilename) Then
                Throw New DllNotFoundException(String.Format("Could not find specified file {0} to load as {1}", nativeLibFilename, libname))
            End If
            Return nativeLibFilename
        End Function

        Private Shared Function findFirstFullPath(shortFileName As String, Optional envVarName As String = "") As String
            If String.IsNullOrEmpty(shortFileName) Then
                Throw New ArgumentNullException("shortFileName")
            End If

            Dim libSearchPathEnvVar As String = envVarName
            If String.IsNullOrEmpty(libSearchPathEnvVar) Then
                libSearchPathEnvVar = (If(Environment.OSVersion.Platform = PlatformID.Win32NT, "PATH", "LD_LIBRARY_PATH"))
            End If
            Dim candidates = PlatformUtility.FindFullPathEnvVar(shortFileName, libSearchPathEnvVar)
            If (candidates.Length = 0) AndAlso (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
                If File.Exists(shortFileName) Then
                    candidates = New String() {shortFileName}
                End If
            End If
            If candidates.Length = 0 Then
                Throw New DllNotFoundException(String.Format("Could not find native library named '{0}' within the directories specified in the '{1}' environment variable", shortFileName, libSearchPathEnvVar))
            Else
                Return candidates(0)
            End If
        End Function

        ''' <summary> Given the stub name for a library get the likely platform specific file name</summary>
        '''
        ''' <exception cref="ArgumentNullException"> Thrown when one or more required arguments are null.</exception>
        '''
        ''' <param name="libraryName"> Name of the library.</param>
        '''
        ''' <returns> The likely file name for the shared library.</returns>
        Public Shared Function CreateLibraryFileName(libraryName As String) As String
            If String.IsNullOrEmpty(libraryName) Then
                Throw New ArgumentNullException("libraryName")
            End If
            Return (If(Environment.OSVersion.Platform = PlatformID.Win32NT, libraryName & ".dll", "lib" & libraryName & ".so"))
        End Function
    End Class
End Namespace

