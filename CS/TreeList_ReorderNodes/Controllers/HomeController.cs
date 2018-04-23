using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeList_ReorderNodes.Models;

namespace TreeList_ReorderNodes.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {
            if (Session["model"] == null) {
                DataTable table = new DataTable();
                table = DepartmentsProvider.GetDeparments();
                table.Columns.Add("SortIndex");

                Session["model"] = table;
            }
            return View();
        }

        public ActionResult TreeListPartial() {
            return PartialView(Session["model"]);
        }

        public ActionResult NodeDragDropPartial(int id, int? parentid) {
            DataTable table = Session["model"] as DataTable;

            DataRow[] row1 = table.Select(string.Format("ID = '{0}'", id.ToString()));
            DataRow[] row2 = table.Select(string.Format("ID = '{0}'", parentid.ToString()));
            string sortIndex1 = row1[0]["SortIndex"].ToString();
            string sortIndex2 = row2[0]["SortIndex"].ToString();
            row1[0]["SortIndex"] = sortIndex2;
            row2[0]["SortIndex"] = sortIndex1;

            Session["model"] = table;

            return PartialView("TreeListPartial", Session["model"]);
        }
    }
}