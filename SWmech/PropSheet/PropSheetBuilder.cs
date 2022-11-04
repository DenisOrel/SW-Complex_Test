using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWmech.PropSheet
{
    internal class PropSheetBuilder
    {
        private SldWorks swApp;
        private ModelDoc2 swModel;
        private DrawingDoc swDraw;
        private int errors, warnings;

        public void Build(Format param)
        {
            string Source2 = @"D:\source\temp\Master\Master_Template_Sheet1.SLDDRW";

            swModel = swApp.OpenDoc6(Source2, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);

            swModel = (ModelDoc2)swApp.ActiveDoc;

            swDraw = (DrawingDoc)swModel;
            swDraw.ActivateSheet("Лист1");
            swDraw.SetupSheet4("Лист1", 12, 13, 1.0, 1.0, true, "", param.Width, param.Height, "По умолчанию");
            swDraw.EditTemplate();

            //Устанавливаем размеры листа
            var swDimension = (Dimension)swModel.Parameter("D1@Эскиз1");
            errors = (int)swDimension.SetSystemValue3(param.Height - 0.01, (int)swSetValueInConfiguration_e.swSetValue_InAllConfigurations, null);
            swDimension = (Dimension)swModel.Parameter("D2@Эскиз1");
            errors = (int)swDimension.SetSystemValue3(param.Width - 0.025, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration, null);
        }
    }
}