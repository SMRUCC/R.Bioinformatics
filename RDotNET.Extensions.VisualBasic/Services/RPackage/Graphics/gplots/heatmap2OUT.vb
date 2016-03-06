﻿Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.ComponentModel.DataStructures
Imports Microsoft.VisualBasic.ComponentModel.DataStructures.BinaryTree
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Serialization

Namespace gplots

    Public Class heatmap2OUT

        Public Property locus As String()
        Public Property samples As String()

        ''' <summary>
        ''' 基因的排列顺序
        ''' </summary>
        ''' <returns></returns>
        Public Property rowInd As Integer()
        Public Property colInd As Integer()

        Public Property [call] As String

        Public Property rowMeans As Double()
        Public Property rowSDs As Double()
        Public Property carpet As Double()
        ''' <summary>
        ''' heatmap.2行聚类的结果，(基因)
        ''' </summary>
        ''' <returns></returns>
        Public Property rowDendrogram As String
        Public Property colDendrogram As String

        ''' <summary>
        ''' 进行<see cref="col"/>映射的数值等级
        ''' </summary>
        ''' <returns></returns>
        Public Property breaks As Double()
        ''' <summary>
        ''' 热图里面的颜色代码
        ''' </summary>
        ''' <returns></returns>
        Public Property col As String()
        Public Property colorTable As colorTable()

        Public Shared Function IndParser(result As String) As Integer()
            Return Regex.Matches(result, "\d+").ToArray(Function(s) Scripting.CastInteger(s))
        End Function

        Public Shared Function MeansParser(result As String) As Double()
            Return Regex.Matches(result, "(-?\d+(\.\d+)?)|(NaN)").ToArray(Function(s) Scripting.CastDouble(s))
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="result"></param>
        ''' <param name="names">{id, name}</param>
        ''' <returns></returns>
        Public Shared Function TreeBuilder(result As String, Optional names As Dictionary(Of String, String) = Nothing) As TreeNode(Of String)
            result = result.Replace("list", "")
            Call result.__DEBUG_ECHO
            Dim node As TreeNode(Of String) = New TreeNode(Of String)
            Call NewickParser.TreeParser(result, New Dictionary(Of String, String), node)
            Return node
        End Function

        Public Shared Function ColorParser(result As String) As String()
            Return Regex.Matches(result, "#[0-9A-Za-z]+").ToArray
        End Function

        Public Function GetRowDendrogram(Optional names As Dictionary(Of String, String) = Nothing) As TreeNode(Of String)
            Return heatmap2OUT.TreeBuilder(rowDendrogram)
        End Function

        Public Function GetColDendrogram(Optional names As Dictionary(Of String, String) = Nothing) As TreeNode(Of String)
            Return heatmap2OUT.TreeBuilder(colDendrogram)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="out">heatmap.2输出结果</param>
        ''' <returns></returns>
        Public Shared Function RParser(out As String()) As heatmap2OUT
            Dim i As Pointer(Of String) = New Pointer(Of String)
            Dim mapResult As New heatmap2OUT With {
                .rowInd = heatmap2OUT.IndParser(out + i),   ' i++
                .colInd = heatmap2OUT.IndParser(out + i),
                .call = out + i,
                .rowMeans = heatmap2OUT.MeansParser(out + i),
                .rowSDs = heatmap2OUT.MeansParser(out + i),
                .carpet = heatmap2OUT.MeansParser(out + i),
                .rowDendrogram = out + i,
                .colDendrogram = out + i,
                .breaks = heatmap2OUT.MeansParser(out + i),
                .col = heatmap2OUT.ColorParser(out + i),
                .colorTable = colorTableParser(out + i)
            }
            Return mapResult
        End Function

        Public Shared Function colorTableParser(result As String) As colorTable()
            Dim vectors As String() = Regex.Matches(result, "c\(.+?\)", RegexOptions.Singleline).ToArray
            Dim i As New Pointer(Of String)
            Dim low As String = vectors + i      ' Pointer operations 
            Dim high As String = vectors + i
            Dim color As String = vectors + i

            low = Mid(low, 3, low.Length - 3)
            high = Mid(high, 3, high.Length - 3)
            color = Mid(color, 3, color.Length - 3)

            Dim lows As Double() = low.Split(","c).ToArray(Function(s) Scripting.CastDouble(s.Trim))
            Dim highs As Double() = high.Split(","c).ToArray(Function(s) Scripting.CastDouble(s.Trim))
            Dim colors As String() = color.Split(","c).ToArray(Function(s) s.Trim)

            Return (From lp As SeqValue(Of String)
                    In colors.SeqIterator
                    Select New colorTable With {
                        .color = lp.obj,
                        .low = lows(lp.Pos),
                        .high = highs(lp.Pos)}).ToArray
        End Function
    End Class

    Public Structure colorTable
        Public Property low As Double
        Public Property high As Double
        Public Property color As String

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Structure
End Namespace