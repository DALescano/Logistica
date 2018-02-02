using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Logistica.Presentacion
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Components/JQuery").Include(
                        "~/Components/JQuery/jquery-3.1.1.js",
                        "~/Components/JQuery/jquery-ui-1.12.1.custom.js",
                        "~/Components/JQuery/jquery.validate.js",
                        "~/Components/JQuery/jquery.validate.additional-methods.js",
                        "~/Components/JQuery/jquery.mask.js",
                        "~/Components/JQuery/jquery.formatCurrency-1.4.0.min.js",
                        "~/Components/JQuery/jquery.formatCurrency-1.4.0.js",
                        "~/Components/JQuery/jquery.tokeninput.js",
                        "~/Components/JQuery/jshashset-3.0.js",
                        "~/Components/JQuery/jshashtable-3.0.js",
                        "~/Components/JQuery/jquery.numberformatter-1.2.4.js"
            ));

            bundles.Add(new ScriptBundle("~/Components/DataTables").Include(
                        "~/Components/DataTables/js/jquery.dataTables.js",
                        "~/Components/DataTables/js/dataTables.responsive.js"
                        , "~/Components/DataTables/js/dataTables.bootstrap.js"
            ));

            bundles.Add(new ScriptBundle("~/Components/Codemaleon").Include(
                        "~/Components/Codemaleon/ns.js"
            ));

            bundles.Add(new StyleBundle("~/Components/TinyMCE").Include(
            "~/Components/TinyMCE/tiny_mce.js",
            "~/Components/TinyMCE/tiny_mce_popup.js",
            "~/Components/TinyMCE/tiny_mce_src.js"
            ));

            bundles.Add(new StyleBundle("~/Components/SumoSelect").Include(
            "~/Components/SumoSelect/jquery.sumoselect.js",
            "~/Components/SumoSelect/jquery.sumoselect.min.js"
            ));

            bundles.Add(new StyleBundle("~/Components/ckeditor").Include(
            "~/Components/ckeditor/ckeditor.js",
            "~/Components/ckeditor/adapters/jquery.js"
            ));

            bundles.Add(new ScriptBundle("~/Components/GmdUtil").Include(
                "~/Scripts/Base/Layout/Util.js"
            ));

            bundles.Add(new ScriptBundle("~/Components/Gmd").Include(
                      "~/Components/Librerias/Dialog/Dialog.js",
                      "~/Components/Librerias/FragmentView/FragmentView.js",
                        "~/Components/Librerias/Message/Message.js",
                        "~/Components/Librerias/Ajax/Ajax.js",
                        "~/Components/Librerias/ProgressBar/ProgressBar.js",
                        "~/Components/Librerias/Validator/Validator.js",
                        "~/Components/Librerias/Storage/Storage.js",
                        "~/Components/Librerias/TextBox/TextBox.js",
                        "~/Components/Librerias/Calendar/Calendar.js",
                        "~/Components/Librerias/Grid/Grid.js",
                        "~/Components/Librerias/TokenInput/TokenField.js",
                        "~/Components/Librerias/TinyMCE/TinyMCE.js",
                        "~/Components/Librerias/TabControl/TabControl.js",
                        "~/Components/Librerias/Calendar/Calendar.js",
                        "~/Components/Librerias/Autocomplete/Autocomplete.js",
                        "~/Components/Librerias/SumoSelect/SumoSelect.js",
                        "~/Components/Librerias/Upload/Upload.js",
                        "~/Components/Librerias/AjaxUpload/AjaxUpload.js",
                        "~/Components/Librerias/AjaxUpload/jquery.ajax_upload.js"
            ));

            bundles.Add(new ScriptBundle("~/FrameworkStyle/js").Include(
                        "~/Components/Bootstrap/js/bootstrap.js",
                        "~/Components/Bootstrap/js/bootstrap-dialog.js",
                        "~/Components/Bootstrap/js/bootstrap-confirmation.min.js"
            ));

            bundles.Add(new StyleBundle("~/Components/GmdCss").Include(
                        "~/Components/Librerias/ProgressBar/ProgressBar.css",
                        "~/Components/Librerias/Dialog/Dialog.css",
                        "~/Components/Librerias/Message/Message.css"
            ));

            bundles.Add(new StyleBundle("~/Components/SelectCustomCss").Include(
                        "~/Components/SelectCustom/css/bootstrap-select.min.css"
            ));

            bundles.Add(new ScriptBundle("~/Components/SelectCustomJs").Include(
                        "~/Components/SelectCustom/js/bootstrap-select.js"
            ));

            bundles.Add(new StyleBundle("~/Components/FancyBoxCss").Include(
                        "~/Components/FancyBox/css/jquery.fancybox.css"
            ));

            bundles.Add(new ScriptBundle("~/Components/FancyBoxJs").Include(
                        "~/Components/FancyBox/js/jquery.fancybox.pack.js"
            ));


            bundles.Add(new StyleBundle("~/Components/JQueryCss").Include(
            "~/Components/JQuery/jquery-ui-1.10.0.custom.css",
            "~/Components/JQuery/TokenInput-facebook.css",
            "~/Components/JQuery/TokenInput.css",
            "~/Components/JQuery/sumoselect.css"
            ));

            bundles.Add(new ScriptBundle("~/Components/DataTablesCss").Include(
                        "~/Components/DataTables/css/jquery.dataTables.css"
                        , "~/Components/DataTables/css/dataTables.bootstrap.css"
                        , "~/Components/DataTables/css/dataTables.responsive.css"
            ));
            

            bundles.Add(new StyleBundle("~/FrameworkStyle/css").Include(
                        "~/Components/Bootstrap/css/bootstrap.css",
                        "~/Components/font-awesome/css/font-awesome.css"
            ));

            var directoryScripts = HttpContext.Current.Server.MapPath("~/Scripts");
            GenerateDynamicScriptBundle(bundles, new DirectoryInfo(directoryScripts));

            /*Custom page css*/

            bundles.Add(new StyleBundle("~/Login/css").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/signin.css"));
        }

        private static void GenerateDynamicScriptBundle(BundleCollection bundles, DirectoryInfo directory, string pathDirectories = "")
        {
            var files = directory.EnumerateFiles();
            if (files != null && files.Any())
            {
                bundles.Add(new ScriptBundle("~/Scripts/" + pathDirectories.Replace("/", "").ToLower()).Include(
                                        "~/Scripts/" + pathDirectories + "*.js"));
            }
            var directories = directory.EnumerateDirectories().ToList();
            if (directories != null && directories.Any())
            {
                directories.ForEach(d =>
                {
                    GenerateDynamicScriptBundle(bundles, d, (pathDirectories + d.Name + "/"));
                });
            }
        }
    }
}
