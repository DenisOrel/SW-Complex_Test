using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using DBDomein;

namespace Test
{
    internal class Program
    {
        private static SldWorks swApp;
        private static ModelDoc2 swModel;
        private static DrawingDoc swDraw;
        private static SelectionMgr swSelMgr;
        private static Note swNote;
        private static int errors, warnings;
        private static double Width, Height;

        private static void Main(string[] args)
        {
            //DBBuilder re = new DBBuilder();

            //re.SettingsForm();

            //swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");

            //string s = @"DXFs\<_FileName_>_<_FeatureName_>_<_ConfName_>_<$CLPRP:Description>.dxf";

            //Regex regex = new Regex(@"<[^>]*>");
            //MatchCollection matches = regex.Matches(s);
            //if (matches.Count > 0)
            //{
            //    foreach (Match match in matches)
            //        Console.WriteLine(match.Value);
            //}
            //else
            //{
            //    Console.WriteLine("Совпадений не найдено");
            //}

            Master();

            // Console.ReadKey();
        }

        private static void Master()
        {
            Height = 0.297; //297×420
            Width = 0.420;
            swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            string Source2 = @"D:\source\temp\Master\Master_Template_Sheet1.SLDDRW";

            swModel = swApp.OpenDoc6(Source2, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);

            swModel = (ModelDoc2)swApp.ActiveDoc;

            swDraw = (DrawingDoc)swModel;
            swDraw.ActivateSheet("Лист1");
            swDraw.SetupSheet4("Лист1", 12, 13, 1.0, 1.0, true, "", Width, Height, "По умолчанию");
            swDraw.EditTemplate();

            swModel.Extension.SelectByID2("Format@Формат листа1", "NOTE", 0, 0, 0, false, 0, null, 0);
            swSelMgr = (SelectionMgr)swModel.SelectionManager;
            swNote = swSelMgr.GetSelectedObject6(1, 0) as Note;

            swNote.SetText("Формат");
        }
    }
}