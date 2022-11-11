using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.IO;
using System.Runtime.InteropServices;

namespace Converter
{
    internal class ConvertToPDF
    {
        private static ISldWorks swApp;
        private ExportPdfData swExportPDFData = default;
        private ModelDoc2 swModel = default;
        private ModelDocExtension swModExt = default;
        private DrawingDoc swDrawDoc = default;
        private Sheet swSheet = default(Sheet);
        private bool boolstatus = false;
        private string[] obj = null;
        private int errors = 0;
        private int warnings = 0;

        public bool SaveToPDF(ISldWorks swApp, string pathDoc, string savePath, string pdfFileName)
        {
            // Open drawing document
            swModel = swApp.OpenDoc6(pathDoc, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
            swModExt = swModel.Extension;
            swExportPDFData = (ExportPdfData)swApp.GetExportFileData((int)swExportDataFileType_e.swExportPdfData);

            if (swModel != null)
            {
                // Get the names of the drawing sheets in the drawing
                // to get the size of the array of drawing sheets
                swDrawDoc = (DrawingDoc)swModel;

                obj = (string[])swDrawDoc.GetSheetNames();
                int count = obj.Length;
                object[] objs = new object[count - 1];
                DispatchWrapper[] arrObjIn = new DispatchWrapper[count - 1];

                // Activate each drawing sheet, except the last drawing sheet, for
                // demonstration purposes only and add each sheet to an array
                // of drawing sheets
                for (int i = 0; i < count - 1; i++)
                {
                    boolstatus = swDrawDoc.ActivateSheet((obj[i]));
                    swSheet = (Sheet)swDrawDoc.GetCurrentSheet();
                    objs[i] = swSheet;
                    arrObjIn[i] = new DispatchWrapper(objs[i]);
                }

                savePath = savePath + "\\" + pdfFileName + ".pdf";

                // Save the drawings sheets to a PDF file
                boolstatus = swExportPDFData.SetSheets((int)swExportDataSheetsToExport_e.swExportData_ExportSpecifiedSheets, (arrObjIn));
                swExportPDFData.ViewPdfAfterSaving = false;
                swExportPDFData.ExportAs3D = false;
                boolstatus = swModExt.SaveAs(savePath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, swExportPDFData, ref errors, ref warnings);

                swApp.CloseDoc(swModel.GetTitle());
            }
            return boolstatus;
        }
    }
}