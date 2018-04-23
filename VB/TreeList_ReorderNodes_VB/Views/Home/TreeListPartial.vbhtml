@Imports DevExpress.Web.ASPxTreeList
@Imports DevExpress.Data

@Html.DevExpress().TreeList(
    Sub(settings)
        settings.Name = "tlData"
        settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "TreeListPartial"}
        settings.SettingsEditing.NodeDragDropRouteValues = New With {Key .Controller = "Home", Key .Action = "NodeDragDropPartial"}
        settings.Width = Unit.Pixel(800)

        settings.AutoGenerateColumns = False
        settings.KeyFieldName = "ID"
        settings.ParentFieldName = "PARENTID"

        settings.Columns.Add("DEPARTMENT").AllowSort = DefaultBoolean.False
        settings.Columns.Add("BUDGET").AllowSort = DefaultBoolean.False
        settings.Columns.Add("LOCATION").AllowSort = DefaultBoolean.False
        settings.Columns.Add("SortIndex").Visible = False

        settings.Columns.Add(Sub(c)
                c.FieldName = "SortIndex"
                c.Visible = False
                c.SortOrder = ColumnSortOrder.Ascending
                c.SortIndex = 0
        End Sub)

        settings.SettingsBehavior.AutoExpandAllNodes = True
        settings.SettingsBehavior.AllowDragDrop = True
        settings.SettingsEditing.AllowNodeDragDrop = True

        settings.ClientSideEvents.StartDragNode = "tlData_StartDragNode"

        settings.DataBound = Sub(s, e)
                Dim treeList As ASPxTreeList = TryCast(s, ASPxTreeList)

                Dim defaultNodes As Boolean = (Session(treeList.UniqueID & "_Sort") Is Nothing)
                Dim allNodes As ICollection(Of TreeListNode) = treeList.GetAllNodes()

                If defaultNodes Then
                    Dim nodeOrder As New Dictionary(Of String, Integer)()
                    For Each node As TreeListNode In allNodes
                        Dim parentKey As String = If(node.ParentNode Is Nothing, String.Empty, node.ParentNode.Key)
                        Dim order As Integer = 0
                        If nodeOrder.ContainsKey(parentKey) Then
                            nodeOrder(parentKey) += 1
                            order = nodeOrder(parentKey)
                        Else
                            nodeOrder(parentKey) = order
                        End If
                        node.SetValue("SortIndex", order)
                    Next node
                    Session(treeList.UniqueID & "_Sort") = True
                    treeList.DataBind()
                End If
        End Sub

        settings.HtmlRowPrepared = Sub(s, e)
                Dim treeList As ASPxTreeList = TryCast(s, ASPxTreeList)
                If (e.RowKind = TreeListRowKind.Data) Then
                    Dim parent As TreeListNode = treeList.FindNodeByKeyValue(e.NodeKey).ParentNode
                    e.Row.Attributes.Add("nodeParent", If(parent Is Nothing, String.Empty, parent.Key))
                End If
        End Sub

End Sub).Bind(Model).GetHtml()