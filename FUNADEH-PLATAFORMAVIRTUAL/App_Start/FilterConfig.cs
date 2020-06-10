using System.Web;
using System.Web.Mvc;

namespace FUNADEH_PLATAFORMAVIRTUAL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
