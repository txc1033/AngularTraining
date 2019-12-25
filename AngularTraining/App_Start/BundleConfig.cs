using System.Web;
using System.Web.Optimization;

namespace AngularTraining
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Mains").Include(
                        "~/Scripts/Mains/jquery-3.4.1.min.js",
                        "~/Scripts/Mains/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/FormsControls").Include(
                        "~/Scripts/FormsControls/jquery.validate*",
                        "~/Scripts/FormsControls/jquery.validate.min.js",
                        "~/Scripts/FormsControls/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Desingers").Include(
                      "~/Scripts/Desingers/bootstrap-min.js",
                      "~/Scripts/Desingers/bootstrap.bundle.min.js",
                      "~/Scripts/Desingers/sweetalert2.all.min.js",
                      "~/Scripts/Desingers/modernizr-*",
                      "~/Scripts/Desingers/datatables.min.js",
                      "~/Scripts/Desingers/DtSkinsJs/dataTables.semanticui.min.js",
                      "~/Scripts/Desingers/DtSkinsJs/semantic.min.js",
                      "~/Scripts/Desingers/DtSkinsJs/toastr.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-*",
                      "~/Content/site.css",
                      "~/Content/DtSkinsCss/semantic.min.css",
                      "~/Content/DtSkinsCss/dataTables.semanticui.min.css",
                      "~/Content/DtSkinsCss/db.boostrap4Icons.css",
                      "~/Content/toastr.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                              "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/EscuelaNg").Include(
                              "~/Scripts/app/Modulo.js",
                              "~/Scripts/app/Servicios.js",
                              "~/Scripts/app/Controlador.js"));

            bundles.Add(new ScriptBundle("~/bundles/Estudiantes").Include(
                    "~/Scripts/FormsControls/Estudiantes/estudiante*"
                      ));


        }
    }
}
