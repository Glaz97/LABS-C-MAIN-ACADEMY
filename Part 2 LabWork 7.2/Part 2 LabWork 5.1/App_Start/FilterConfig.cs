using System.Web;
using System.Web.Mvc;

namespace Part_2_LabWork_5._1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
