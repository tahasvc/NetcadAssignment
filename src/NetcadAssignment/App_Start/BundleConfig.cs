using System.Web;
using System.Web.Optimization;

namespace NetcadAssignment
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/mystyle").Include(
                "~/Assets/Content/site.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Assets/Scripts/jquery-3.4.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/myscripts").Include(
                        "~/Scripts/map-control.js", "~/Scripts/util.js"));
        }
    }
}
