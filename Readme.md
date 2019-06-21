<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/TreeList_ReorderNodes/Controllers/HomeController.cs)
* [DepartmentsProvider.cs](./CS/TreeList_ReorderNodes/Models/DepartmentsProvider.cs)
* **[Index.cshtml](./CS/TreeList_ReorderNodes/Views/Home/Index.cshtml)**
* [TreeListPartial.cshtml](./CS/TreeList_ReorderNodes/Views/Home/TreeListPartial.cshtml)
<!-- default file list end -->
# TreeList - How to reorder sibling nodes
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t462559)**
<!-- run online end -->


<p>This example demonstrates how to move TreeList sibling nodes using Drag&Drop.</p>
<p>To preserve the node order, it is necessary to set up an extra column to store node order indexes. Then, sort TreeList nodes by this column and deny sorting by other columns. This example stores this information in a dynamically created column and the logic of swap nodes is implemented in the action method from <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcMVCxTreeListSettingsEditing_NodeDragDropRouteValuestopic">TreeList.SettingsEditing.NodeDragDropRouteValues</a>. We have implemented this approach only for demo purposes. You can store this information in your DataSource.<br><br>See also: <a href="https://www.devexpress.com/Support/Center/p/E3850">E3850: How to reorder ASPxTreeList sibling nodes, using buttons or drag-and-drop</a></p>

<br/>


