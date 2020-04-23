using System.Web;
using System.Web.Mvc;

namespace CSharp_Net_module3_2_1_lab_MVCcl
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
