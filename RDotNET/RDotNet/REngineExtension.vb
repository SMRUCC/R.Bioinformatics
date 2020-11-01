﻿Imports RDotNet.Internals
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Numerics
Imports System.Runtime.CompilerServices


    ''' <summary>
    ''' Provides extension methods for <seecref="REngine"/>.
    ''' </summary>
    Public Module REngineExtension
        ''' <summary>
        ''' Creates a new empty CharacterVector with the specified length.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="length">The length.</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateCharacterVector(ByVal engine As REngine, ByVal length As Integer) As CharacterVector
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New CharacterVector(engine, length)
        End Function

        ''' <summary>
        ''' Creates a new empty ComplexVector with the specified length.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="length">The length.</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateComplexVector(ByVal engine As REngine, ByVal length As Integer) As ComplexVector
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New ComplexVector(engine, length)
        End Function

        ''' <summary>
        ''' Creates a new empty IntegerVector with the specified length.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="length">The length.</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateIntegerVector(ByVal engine As REngine, ByVal length As Integer) As IntegerVector
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New IntegerVector(engine, length)
        End Function

        ''' <summary>
        ''' Creates a new empty LogicalVector with the specified length.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="length">The length.</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateLogicalVector(ByVal engine As REngine, ByVal length As Integer) As LogicalVector
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New LogicalVector(engine, length)
        End Function

        ''' <summary>
        ''' Creates a new empty NumericVector with the specified length.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="length">The length.</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateNumericVector(ByVal engine As REngine, ByVal length As Integer) As NumericVector
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New NumericVector(engine, length)
        End Function

        ''' <summary>
        ''' Creates a new empty RawVector with the specified length.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="length">The length.</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateRawVector(ByVal engine As REngine, ByVal length As Integer) As RawVector
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New RawVector(engine, length)
        End Function

        ''' <summary>
        ''' Creates a new CharacterVector with the specified values.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="vector">The values.</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateCharacterVector(ByVal engine As REngine, ByVal vector As IEnumerable(Of String)) As CharacterVector
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New CharacterVector(engine, vector)
        End Function

        ''' <summary>
        ''' Creates a new ComplexVector with the specified values.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="vector">The values.</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateComplexVector(ByVal engine As REngine, ByVal vector As IEnumerable(Of Complex)) As ComplexVector
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New ComplexVector(engine, vector)
        End Function

        ''' <summary>
        ''' Creates a new IntegerVector with the specified values.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="vector">The values.</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateIntegerVector(ByVal engine As REngine, ByVal vector As IEnumerable(Of Integer)) As IntegerVector
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New IntegerVector(engine, vector)
        End Function

        ''' <summary>
        ''' Creates a new LogicalVector with the specified values.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="vector">The values.</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateLogicalVector(ByVal engine As REngine, ByVal vector As IEnumerable(Of Boolean)) As LogicalVector
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New LogicalVector(engine, vector)
        End Function

        ''' <summary>
        ''' Creates a new NumericVector with the specified values.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="vector">The values.</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateNumericVector(ByVal engine As REngine, ByVal vector As IEnumerable(Of Double)) As NumericVector
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New NumericVector(engine, vector)
        End Function

        ''' <summary>
        ''' Creates a new RawVector with the specified values.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="vector">The values.</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateRawVector(ByVal engine As REngine, ByVal vector As IEnumerable(Of Byte)) As RawVector
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New RawVector(engine, vector)
        End Function

        ''' <summary>
        ''' Create a vector with a single value
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="value">The value</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateCharacter(ByVal engine As REngine, ByVal value As String) As CharacterVector
            Return engine.CreateCharacterVector({value})
        End Function

        ''' <summary>
        ''' Create a vector with a single value
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="value">The value</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateComplex(ByVal engine As REngine, ByVal value As Complex) As ComplexVector
            Return engine.CreateComplexVector({value})
        End Function

        ''' <summary>
        ''' Create a vector with a single value
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="value">The value</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateLogical(ByVal engine As REngine, ByVal value As Boolean) As LogicalVector
            Return engine.CreateLogicalVector({value})
        End Function

        ''' <summary>
        ''' Create a vector with a single value
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="value">The value</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateNumeric(ByVal engine As REngine, ByVal value As Double) As NumericVector
            Return engine.CreateNumericVector({value})
        End Function

        ''' <summary>
        ''' Create an integer vector with a single value
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="value">The value</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateInteger(ByVal engine As REngine, ByVal value As Integer) As IntegerVector
            Return engine.CreateIntegerVector({value})
        End Function

        ''' <summary>
        ''' Create a vector with a single value
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="value">The value</param>
        ''' <returns>The new vector.</returns>
        <Extension()>
        Public Function CreateRaw(ByVal engine As REngine, ByVal value As Byte) As RawVector
            Return engine.CreateRawVector({value})
        End Function

        ''' <summary>
        ''' Creates a new empty CharacterMatrix with the specified size.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="rowCount">The row size.</param>
        ''' <paramname="columnCount">The column size.</param>
        ''' <returns>The new matrix.</returns>
        <Extension()>
        Public Function CreateCharacterMatrix(ByVal engine As REngine, ByVal rowCount As Integer, ByVal columnCount As Integer) As CharacterMatrix
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New CharacterMatrix(engine, rowCount, columnCount)
        End Function

        ''' <summary>
        ''' Creates a new empty ComplexMatrix with the specified size.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="rowCount">The row size.</param>
        ''' <paramname="columnCount">The column size.</param>
        ''' <returns>The new matrix.</returns>
        <Extension()>
        Public Function CreateComplexMatrix(ByVal engine As REngine, ByVal rowCount As Integer, ByVal columnCount As Integer) As ComplexMatrix
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New ComplexMatrix(engine, rowCount, columnCount)
        End Function

        ''' <summary>
        ''' Creates a new empty IntegerMatrix with the specified size.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="rowCount">The row size.</param>
        ''' <paramname="columnCount">The column size.</param>
        ''' <returns>The new matrix.</returns>
        <Extension()>
        Public Function CreateIntegerMatrix(ByVal engine As REngine, ByVal rowCount As Integer, ByVal columnCount As Integer) As IntegerMatrix
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New IntegerMatrix(engine, rowCount, columnCount)
        End Function

        ''' <summary>
        ''' Creates a new empty LogicalMatrix with the specified size.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="rowCount">The row size.</param>
        ''' <paramname="columnCount">The column size.</param>
        ''' <returns>The new matrix.</returns>
        <Extension()>
        Public Function CreateLogicalMatrix(ByVal engine As REngine, ByVal rowCount As Integer, ByVal columnCount As Integer) As LogicalMatrix
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New LogicalMatrix(engine, rowCount, columnCount)
        End Function

        ''' <summary>
        ''' Creates a new empty NumericMatrix with the specified size.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="rowCount">The row size.</param>
        ''' <paramname="columnCount">The column size.</param>
        ''' <returns>The new matrix.</returns>
        <Extension()>
        Public Function CreateNumericMatrix(ByVal engine As REngine, ByVal rowCount As Integer, ByVal columnCount As Integer) As NumericMatrix
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New NumericMatrix(engine, rowCount, columnCount)
        End Function

        ''' <summary>
        ''' Creates a new empty RawMatrix with the specified size.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="rowCount">The row size.</param>
        ''' <paramname="columnCount">The column size.</param>
        ''' <returns>The new matrix.</returns>
        <Extension()>
        Public Function CreateRawMatrix(ByVal engine As REngine, ByVal rowCount As Integer, ByVal columnCount As Integer) As RawMatrix
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New RawMatrix(engine, rowCount, columnCount)
        End Function

        ''' <summary>
        ''' Creates a new CharacterMatrix with the specified values.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="matrix">The values.</param>
        ''' <returns>The new matrix.</returns>
        <Extension()>
        Public Function CreateCharacterMatrix(ByVal engine As REngine, ByVal matrix As String(,)) As CharacterMatrix
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New CharacterMatrix(engine, matrix)
        End Function

        ''' <summary>
        ''' Creates a new ComplexMatrix with the specified values.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="matrix">The values.</param>
        ''' <returns>The new matrix.</returns>
        <Extension()>
        Public Function CreateComplexMatrix(ByVal engine As REngine, ByVal matrix As Complex(,)) As ComplexMatrix
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New ComplexMatrix(engine, matrix)
        End Function

        ''' <summary>
        ''' Creates a new IntegerMatrix with the specified values.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="matrix">The values.</param>
        ''' <returns>The new matrix.</returns>
        <Extension()>
        Public Function CreateIntegerMatrix(ByVal engine As REngine, ByVal matrix As Integer(,)) As IntegerMatrix
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New IntegerMatrix(engine, matrix)
        End Function

        ''' <summary>
        ''' Creates a new LogicalMatrix with the specified values.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="matrix">The values.</param>
        ''' <returns>The new matrix.</returns>
        <Extension()>
        Public Function CreateLogicalMatrix(ByVal engine As REngine, ByVal matrix As Boolean(,)) As LogicalMatrix
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New LogicalMatrix(engine, matrix)
        End Function

        ''' <summary>
        ''' Creates a new NumericMatrix with the specified values.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="matrix">The values.</param>
        ''' <returns>The new matrix.</returns>
        <Extension()>
        Public Function CreateNumericMatrix(ByVal engine As REngine, ByVal matrix As Double(,)) As NumericMatrix
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New NumericMatrix(engine, matrix)
        End Function

        ''' <summary>
        ''' Creates a new RawMatrix with the specified values.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="matrix">The values.</param>
        ''' <returns>The new matrix.</returns>
        <Extension()>
        Public Function CreateRawMatrix(ByVal engine As REngine, ByVal matrix As Byte(,)) As RawMatrix
            If engine Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New RawMatrix(engine, matrix)
        End Function

        ''' <summary>
        ''' Create an R data frame from managed arrays and objects.
        ''' </summary>
        ''' <paramname="engine">R engine</param>
        ''' <paramname="columns">The columns with the values for the data frame. These must be array of supported types (double, string, bool, integer, byte)</param>
        ''' <paramname="columnNames">Column names. default: null.</param>
        ''' <paramname="rowNames">Row names. Default null.</param>
        ''' <paramname="checkRows">Check rows. See data.frame R documentation</param>
        ''' <paramname="checkNames">See data.frame R documentation</param>
        ''' <paramname="stringsAsFactors">Should columns of strings be considered as factors (categories). See data.frame R documentation</param>
        ''' <returns></returns>
        <Extension()>
        Public Function CreateDataFrame(ByVal engine As REngine, ByVal columns As IEnumerable(), ByVal Optional columnNames As String() = Nothing, ByVal Optional rowNames As String() = Nothing, ByVal Optional checkRows As Boolean = False, ByVal Optional checkNames As Boolean = True, ByVal Optional stringsAsFactors As Boolean = True) As DataFrame
            Dim df = engine.GetSymbol("data.frame").AsFunction()
            Dim colVectors = ToVectors(engine, columns)
            Dim namedColArgs = CreateNamedArgs(colVectors, columnNames)
            Dim args = New List(Of Tuple(Of String, SymbolicExpression))(namedColArgs)
            If rowNames IsNot Nothing Then args.Add(Tuple.Create("row.names", CType(engine.CreateCharacterVector(rowNames), SymbolicExpression)))
            args.Add(Tuple.Create("check.rows", CType(engine.CreateLogical(checkRows), SymbolicExpression)))
            args.Add(Tuple.Create("check.names", CType(engine.CreateLogical(checkNames), SymbolicExpression)))
            args.Add(Tuple.Create("stringsAsFactors", CType(engine.CreateLogical(stringsAsFactors), SymbolicExpression)))
            Dim result = df.InvokeNamed(args.ToArray()).AsDataFrame()
            Return result
        End Function

        Private Function CreateNamedArgs(ByVal colVectors As SymbolicExpression(), ByVal columnNames As String()) As Tuple(Of String, SymbolicExpression)()
            If columnNames IsNot Nothing AndAlso colVectors.Length <> columnNames.Length Then Throw New ArgumentException("columnNames", "when not null, the number of column names must match the number of SEXP")
            Dim args = New List(Of Tuple(Of String, SymbolicExpression))()

            For i = 0 To colVectors.Length - 1
                args.Add(Tuple.Create(If(columnNames IsNot Nothing, columnNames(i), ""), colVectors(i)))
            Next

            Return args.ToArray()
        End Function

        Friend Function ToVectors(ByVal engine As REngine, ByVal columns As IEnumerable()) As SymbolicExpression()
            Return Array.ConvertAll(columns, Function(x) ToVector(engine, x))
        End Function

        Friend Function ToVector(ByVal engine As REngine, ByVal values As IEnumerable) As SymbolicExpression
            If values Is Nothing Then Throw New ArgumentNullException("values", "values to transform to an R vector must not be null")
            Dim ints = TryCast(values, IEnumerable(Of Integer))
            Dim chars = TryCast(values, IEnumerable(Of String))
            Dim cplxs = TryCast(values, IEnumerable(Of Complex))
            Dim logicals = TryCast(values, IEnumerable(Of Boolean))
            Dim nums = TryCast(values, IEnumerable(Of Double))
            Dim raws = TryCast(values, IEnumerable(Of Byte))
            Dim sexpVec = TryCast(values, SymbolicExpression)
            If sexpVec IsNot Nothing AndAlso sexpVec.IsVector() Then Return sexpVec
            If ints IsNot Nothing Then Return engine.CreateIntegerVector(ints)
            If chars IsNot Nothing Then Return engine.CreateCharacterVector(chars)
            If cplxs IsNot Nothing Then Return engine.CreateComplexVector(cplxs)
            If logicals IsNot Nothing Then Return engine.CreateLogicalVector(logicals)
            If nums IsNot Nothing Then Return engine.CreateNumericVector(nums)
            If raws IsNot Nothing Then Return engine.CreateRawVector(raws)
            Throw New NotSupportedException(String.Format("Cannot convert type {0} to an R vector", values.GetType()))
        End Function

        ''' <summary>
        ''' Creates a new environment.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <paramname="parent">The parent environment.</param>
        ''' <returns>The newly created environment.</returns>
        <Extension()>
        Public Function CreateEnvironment(ByVal engine As REngine, ByVal parent As REnvironment) As REnvironment
            If engine Is Nothing Then
                Throw New ArgumentNullException("engine")
            End If

            If parent Is Nothing Then
                Throw New ArgumentNullException("parent")
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Return New REnvironment(engine, parent)
        End Function

        ''' <summary>
        ''' Creates a new isolated environment.
        ''' </summary>
        ''' <paramname="engine">The engine.</param>
        ''' <returns>The newly created isolated environment.</returns>
        <Extension()>
        Public Function CreateIsolatedEnvironment(ByVal engine As REngine) As REnvironment
            If engine Is Nothing Then
                Throw New ArgumentNullException("engine")
            End If

            If Not engine.IsRunning Then
                Throw New ArgumentException()
            End If

            Dim pointer = engine.GetFunction(Of Rf_allocSExp)()(SymbolicExpressionType.Environment)
            Return New REnvironment(engine, pointer)
        End Function
    End Module
