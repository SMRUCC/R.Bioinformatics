﻿Imports System.Text
Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic
Imports RDotNET.Extensions.VisualBasic
Imports RDotNET.Extensions.VisualBasic.Services.ScriptBuilder
Imports RDotNET.Extensions.VisualBasic.Services.ScriptBuilder.RTypes

''' <summary>
''' 一个提供脚本语句的最基本的抽象对象
''' </summary>
''' <remarks>就只通过一个函数来提供脚本执行语句</remarks>
Public MustInherit Class IRProvider
    Implements IScriptProvider

    Protected __requires As List(Of String)

    ''' <summary>
    ''' The package names that required of this script file.
    ''' (需要加载的R的包的列表)
    ''' </summary>
    ''' <returns></returns>
    <Ignored> Public Overridable Property Requires As String()
        Get
            Return __requires.ToArray
        End Get
        Protected Set(value As String())
            __requires = value.ToList
        End Set
    End Property

    ''' <summary>
    ''' Get R Script text from this R script object build model.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Function RScript() As String Implements IScriptProvider.RScript

    Public Overrides Function ToString() As String
        Return RScript()
    End Function

    Public Shared Narrowing Operator CType(R As IRProvider) As String
        Return R.RScript
    End Operator
End Class

Public Interface IScriptProvider
    Function RScript() As String
End Interface