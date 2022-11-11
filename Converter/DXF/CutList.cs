using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Globalization;

namespace Converter.DXF
{
    internal class CutList
    {
        private static ModelDoc2 solidWorksDocument;


        /// <summary>
        /// Returns sheet metal cut list  by configuration name
        /// </summary>
        /// <param name="configuratuinName"></param>
        /// <param name="SwModel"></param>
        /// <returns></returns>
        public static DataToExport GetDataToExport(ModelDoc2 swModel)
        {

            DataToExport dataToExport = new DataToExport();

            solidWorksDocument = swModel;
            string valOut;
            const string BoundingBoxLengthRu = @"Длина граничной рамки";
            const string BoundingBoxLengthEng = @"Bounding Box Length";
            const string BoundingBoxWidthRu = @"Ширина граничной рамки";
            const string BoundingBoxWidthEng = @"Bounding Box Width";
            const string SheetMetalThicknessRu = @"Толщина листового металла";
            const string SheetMetalThicknessEng = @"Sheet Metal Thickness";
            const string BoundingBoxAreaBlankRu = @"Площадь граничной рамки-Общая площадь(без вырезов)";
            const string BoundingBoxAreaBlankEng = @"Bounding Box Area-Blank";
            const string BendsRu = @"Сгибы";
            const string BendsEng = @"Bends";



            Feature swFeat2 = solidWorksDocument.FirstFeature();
            while (swFeat2 != null)
            {
                if (swFeat2.GetTypeName2() == "SolidBodyFolder")
                {
                    BodyFolder swBodyFolder = swFeat2.GetSpecificFeature2();
                    swFeat2.Select2(false, -1);
                    swBodyFolder.SetAutomaticCutList(true);
                    swBodyFolder.UpdateCutList();

                    Feature swSubFeat = swFeat2.GetFirstSubFeature();
                    while (swSubFeat != null)
                    {
                        if (swSubFeat.GetTypeName2() == "CutListFolder")
                        {
                            BodyFolder bodyFolder = swSubFeat.GetSpecificFeature2();
                            if (bodyFolder.GetCutListType() != (int)swCutListType_e.swSheetmetalCutlist)
                            {
                                goto m1;
                            }
                            swSubFeat.Select2(false, -1);
                            bodyFolder.SetAutomaticCutList(true);
                            bodyFolder.UpdateCutList();
                            var swCustProp = swSubFeat.CustomPropertyManager;



                            string tempOutBoundingBoxLength;
                            bool res = swCustProp.Get4(BoundingBoxLengthRu, true, out valOut, out tempOutBoundingBoxLength);
                            if (string.IsNullOrEmpty(tempOutBoundingBoxLength))
                            {
                                swCustProp.Get4(BoundingBoxLengthEng, true, out valOut, out tempOutBoundingBoxLength);
                            }
                            dataToExport.WorkpieceX = SafeConvertToDecemal(tempOutBoundingBoxLength);//Convert.ToDecimal(tempOutBoundingBoxLength.Replace(".", ","));


                            string ширинаГраничнойРамки;
                            swCustProp.Get4(BoundingBoxWidthRu, true, out valOut, out ширинаГраничнойРамки);
                            if (string.IsNullOrEmpty(ширинаГраничнойРамки))
                            {
                                swCustProp.Get4(BoundingBoxWidthEng, true, out valOut, out ширинаГраничнойРамки);
                            }
                            dataToExport.WorkpieceY = SafeConvertToDecemal(ширинаГраничнойРамки);


                            string толщинаЛистовогоМеталла;
                            swCustProp.Get4(SheetMetalThicknessRu, true, out valOut, out толщинаЛистовогоМеталла);
                            if (string.IsNullOrEmpty(толщинаЛистовогоМеталла))
                            {
                                swCustProp.Get4(SheetMetalThicknessEng, true, out valOut, out толщинаЛистовогоМеталла);
                            }
                            dataToExport.Thickness = SafeConvertToDecemal(толщинаЛистовогоМеталла);



                            string сгибы;
                            swCustProp.Get4(BendsRu, true, out valOut, out сгибы);
                            if (string.IsNullOrEmpty(сгибы))
                            {
                                swCustProp.Get4(BendsEng, true, out valOut, out сгибы);
                            }
                            try
                            {
                                dataToExport.Bend = сгибы != string.Empty ? Convert.ToInt32(сгибы) : 0;
                            }
                            catch (Exception e)
                            {
                              dataToExport.Bend = 0;
                            }

                            string ПлощадьГраничнойРамкиОбщаяПлощадь_без_вырезов;

                           swCustProp.Get4(BoundingBoxAreaBlankRu, true, out valOut, out ПлощадьГраничнойРамкиОбщаяПлощадь_без_вырезов);

                            if (string.IsNullOrEmpty(ПлощадьГраничнойРамкиОбщаяПлощадь_без_вырезов))
                            {
                                swCustProp.Get4(BoundingBoxAreaBlankEng, true, out valOut, out ПлощадьГраничнойРамкиОбщаяПлощадь_без_вырезов);
                            }
                            dataToExport.BoundingBoxAreaBlank = SafeConvertToDecemal(ПлощадьГраничнойРамкиОбщаяПлощадь_без_вырезов);


                            dataToExport.PaintX = GetDimentions()[0];
                            dataToExport.PaintY = GetDimentions()[1];
                            dataToExport.PaintZ = GetDimentions()[2];
                            dataToExport.SurfaceArea = GetSurfaceArea();

                            dataToExport.Density = (int)solidWorksDocument.GetUserPreferenceDoubleValue((int)swUserPreferenceDoubleValue_e.swMaterialPropertyDensity);
                            dataToExport.Volume = GetVolume();

                        }
                    m1:
                        swSubFeat = swSubFeat.GetNextFeature();
                    }
                }
                swFeat2 = swFeat2.GetNextFeature();
            }
            solidWorksDocument = null;

            return dataToExport;
        }

        private static decimal GetSurfaceArea()
        {
            var myMassProp = solidWorksDocument.Extension.CreateMassProperty();
            return Convert.ToDecimal(Math.Round(myMassProp.SurfaceArea * 100000) / 100000);
        }
        public static decimal GetSurfaceArea(ModelDoc2 d)
        {
            var myMassProp = d.Extension.CreateMassProperty();
            return Convert.ToDecimal(Math.Round(myMassProp.SurfaceArea * 100000) / 100000);
        }
        private static decimal GetVolume()
        {
            var myMassProp = solidWorksDocument.Extension.CreateMassProperty();

            return Convert.ToDecimal(Math.Round(myMassProp.Volume * 100000) / 100000);
        }

        private static int[] GetDimentions()
        {
            int[] dimentions = new int[3];
            const long valueset = 1000;

            var part = (PartDoc)solidWorksDocument;
            var box = part.GetPartBox(true);
            dimentions[0] = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((long)(Math.Abs(box[0] - box[3]) * valueset))), CultureInfo.InvariantCulture);
            dimentions[1] = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((long)(Math.Abs(box[1] - box[4]) * valueset))), CultureInfo.InvariantCulture);
            dimentions[2] = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((long)(Math.Abs(box[2] - box[5]) * valueset))), CultureInfo.InvariantCulture);
            return dimentions;
        }

        /// <summary>
        /// The safe convert floating-point number from string, regardless of region and separator
        /// </summary>
        /// <param name="stringNumner">floating-point number as string</param>
        /// <returns></returns>
        static decimal SafeConvertToDecemal(string stringNumner)
        {
            if (stringNumner != string.Empty)
            {
                CultureInfo[] cultures = { new CultureInfo("en-US"), new CultureInfo("ru-RU"), new CultureInfo("uk-UA") };

                for (int i = 0; i < cultures.Length - 1; i++)
                {

                    CultureInfo culture = cultures[i];
                    try
                    {
                        var result = Convert.ToDecimal(stringNumner, culture);

                        return result;
                    }
                    catch (Exception p)
                    {
                        //MessageObserver.Instance.SetMessage($"Failed safe convert {stringNumner} to decemal; exception message: {p.Message}");
                        return 0;
                    }
                }
                return 0;
            }
            else
            {
                return new decimal();
            }
        }
    }
}
