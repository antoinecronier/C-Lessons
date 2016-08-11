using System.Web;
using System.Web.Optimization;

namespace WebApplicationMVCSecure
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/my-js").Include(
                        "~/Scripts/my-js.js"));

            bundles.Add(new ScriptBundle("~/bundles/address-item-list-to-item").Include(
                        "~/Scripts/address-item-list-to-item.js"));

            bundles.Add(new ScriptBundle("~/bundles/address-item-create").Include(
                        "~/Scripts/address-item-create.js"));

            bundles.Add(new ScriptBundle("~/bundles/address-item-update").Include(
                        "~/Scripts/address-item-update.js"));

            bundles.Add(new ScriptBundle("~/bundles/address-item-list-drag-drop").Include(
                        "~/Scripts/address-item-list-drag-drop.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-1.12.4").Include(
                        "~/Scripts/jquery-1.12.4.js"));

            bundles.Add(new ScriptBundle("~/bundles/edit-users-to-addresses").Include(
                        "~/Scripts/edit-users-to-addresses.js"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));
        }
    }
}
