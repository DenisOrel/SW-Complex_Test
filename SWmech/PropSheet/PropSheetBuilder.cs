using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SWmech.PropSheet
{
    internal class PropSheetBuilder
    {
        private SldWorks swApp;
        private ModelDoc2 swModel;
        private DrawingDoc swDraw;
        private SelectionMgr swSelMgr;
        private Note swNote;
        private IModelView View;
        private ExportPdfData swExportPDFData;
        private AdvancedSaveAsOptions AdvOptData;
        private int errors, warnings;
        private bool status;
        private bool n;

        public void Build(Format param)
        {
            string Source2 = @"D:\source\temp\Master\Master_Template_Sheet1.SLDDRW";
            string FullFN = @"C:\Temp\A4.SLDDRW";

            #region Лист1

            swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            swModel = swApp.OpenDoc6(Source2, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);

            swModel = (ModelDoc2)swApp.ActiveDoc;

            swDraw = (DrawingDoc)swModel;
            swDraw.ActivateSheet("Лист1");
            swDraw.SetupSheet4("Лист1", 12, 13, 1.0, 1.0, true, "", param.Width, param.Height, "По умолчанию");
            swDraw.EditTemplate();

            //Сохраняем как
            swModel.Extension.SaveAs3(FullFN, 0, 512, swExportPDFData, AdvOptData, ref errors, ref warnings);

            //Устанавливаем размеры листа
            var swDimension = (Dimension)swModel.Parameter("D1@Эскиз1");
            errors = (int)swDimension.SetSystemValue3(param.Height - 0.01, (int)swSetValueInConfiguration_e.swSetValue_InAllConfigurations, null);
            swDimension = (Dimension)swModel.Parameter("D2@Эскиз1");
            errors = (int)swDimension.SetSystemValue3(param.Width - 0.025, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration, null);

            //Проставляем формат
            swModel.Extension.SelectByID2("Format@Формат листа1", "NOTE", 0, 0, 0, false, 0, null, 0);
            swSelMgr = swModel.SelectionManager;
            swNote = swSelMgr.GetSelectedObject2(1);
            swNote.SetText("Формат " + param.FormatName);

            //Удаление лишнего

            if (param.FormatName == "А4" && param.Orientation == true)
            {
                swApp.SendMsgToUser("Ok");
                status = swModel.Extension.SelectByID2("Line159", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swApp.SendMsgToUser(status.ToString());
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line160", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line161", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line162", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line225", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line226", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line227", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line228", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line229", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("MYPRP2@Формат листа1", "NOTE", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
            }
            else
            {
                swModel.Extension.SelectByID2("Line214", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line215", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line216", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line217", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line232", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line233", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line234", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line235", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line236", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("MYPRP1@Формат листа1", "NOTE", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
            }
            if (n)
            {
                swModel.Extension.SelectByID2("Line243", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line244", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line245", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
                swModel.Extension.SelectByID2("Line246", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                swModel.EditDelete();
            }

            #endregion Лист1

            //#region Лист2

            ////Лист2
            ////Открываем файл шаблона
            //swModel = swApp.OpenDoc6(Source2, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
            //swModel = (ModelDoc2)swApp.ActiveDoc;

            ////Сохраняем как
            ////swModel.SaveAs4(FullFN, 0, &H1, nErrors, nWarnings)

            //swDraw = (DrawingDoc)swModel;
            //swDraw.ActivateSheet("Лист2");
            //swDraw.SetupSheet4("Лист2", 12, 13, 1.0, 1.0, true, "", param.Width, param.Height, "По умолчанию");
            //swDraw.EditTemplate();

            ////Устанавливаем размеры листа
            //swDimension = (Dimension)swModel.Parameter("D1@Эскиз1");
            //errors = (int)swDimension.SetSystemValue3(param.Height - 0.01, (int)swSetValueInConfiguration_e.swSetValue_InAllConfigurations, null);
            //swDimension = (Dimension)swModel.Parameter("D2@Эскиз1");
            //errors = (int)swDimension.SetSystemValue3(param.Width - 0.025, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration, null);

            ////Проставляем формат
            //swModel.Extension.SelectByID2("Format@Формат листа2", "NOTE", 0, 0, 0, false, 0, null, 0);
            //swSelMgr = swModel.SelectionManager;
            //swNote = swSelMgr.GetSelectedObject2(1);
            //swNote.SetText("Формат " + param.FormatName);

            ////Удаление лишнего
            //if (param.FormatName == "А4" && param.Orientation == true)
            //{
            //    swModel.Extension.SelectByID2("Line159", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //    swModel.Extension.SelectByID2("Line160", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //    swModel.Extension.SelectByID2("Line161", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //    swModel.Extension.SelectByID2("Line162", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //    swModel.Extension.SelectByID2("MYPRP2@Формат листа2", "NOTE", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //}
            //else
            //{
            //    swModel.Extension.SelectByID2("Line185", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //    swModel.Extension.SelectByID2("Line186", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //    swModel.Extension.SelectByID2("Line187", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //    swModel.Extension.SelectByID2("Line188", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //    swModel.Extension.SelectByID2("MYPRP1@Формат листа2", "NOTE", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //}
            //if (n)
            //{
            //    swModel.Extension.SelectByID2("Line193", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //    swModel.Extension.SelectByID2("Line194", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //    swModel.Extension.SelectByID2("Line195", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //    swModel.Extension.SelectByID2("Line196", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            //    swModel.EditDelete();
            //}

            //#endregion Лист2

            swDraw.EditSheet();
            swModel.Extension.Rebuild((int)swRebuildOptions_e.swCurrentSheetDisp);
            swDraw.EditRebuild();
        }
    }
}