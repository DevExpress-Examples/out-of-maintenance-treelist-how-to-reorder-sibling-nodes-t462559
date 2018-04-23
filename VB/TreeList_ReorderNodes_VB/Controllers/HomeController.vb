Imports System.Web.Mvc

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            If Session("model") Is Nothing Then
                Dim table As New DataTable()
                table = DepartmentsProvider.GetDeparments()
                table.Columns.Add("SortIndex")

                Session("model") = table
            End If
            Return View()
        End Function

        Public Function TreeListPartial() As ActionResult
            Return PartialView(Session("model"))
        End Function

        Public Function NodeDragDropPartial(ByVal id As Integer, ByVal parentid? As Integer) As ActionResult
            Dim table As DataTable = TryCast(Session("model"), DataTable)

            Dim row1() As DataRow = table.Select(String.Format("ID = '{0}'", id.ToString()))
            Dim row2() As DataRow = table.Select(String.Format("ID = '{0}'", parentid.ToString()))
            Dim sortIndex1 As String = row1(0)("SortIndex").ToString()
            Dim sortIndex2 As String = row2(0)("SortIndex").ToString()
            row1(0)("SortIndex") = sortIndex2
            row2(0)("SortIndex") = sortIndex1

            Session("model") = table

            Return PartialView("TreeListPartial", Session("model"))
        End Function
    End Class
End Namespace