using System.Web;
using System.Web.Mvc;

namespace TreeList_ReorderNodes {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}