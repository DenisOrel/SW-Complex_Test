using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Test.DXF;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Test.DXF
{
    internal class DXF
    {
        private SldWorks swApp;
        private ModelDoc2 swModel;
        private AssemblyDoc swAssy;
        private Feature swFeats;
        private Feature swFeat;

        private int errors, warnings;
        private bool status;

        public void main()
        {
            swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");

            swModel = (ModelDoc2)swApp.ActiveDoc;
            if (swModel == null)
            {
                swApp.SendMsgToUser("Please open assembly or part document");
            }

            if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY)
            {
                swAssy = (AssemblyDoc)swModel;
                swAssy.ResolveAllLightWeightComponents(true);
                var vComps;
                vComps = GetDistinctSheetMetalComponents(swAssy);
            }
            else
            {
                if (swModel.GetType() == (int)swDocumentTypes_e.swDocPART)
                {
                    PartDoc swPart;
                    swPart = (PartDoc)swApp.ActiveDoc;
                    
                    ProcessSheetMetalModel(swPart, swPart, swModel.ConfigurationManager.ActiveConfiguration.Name);
                }
            }
        }

        private void GetDistinctSheetMetalComponents(AssemblyDoc assy)
        {
            var vComps = assy.GetComponents(false);
            int i;
            Component2 swSheetMetalComps;

            while (vComps != null)
            {

            }





        }

        private void ExportFlatPattern(PartDoc part, Feature flatPattern, string outFilePath, Test.DXF.SheetMetalOptions_e opts, string conf)
        {
            swModel = (ModelDoc2)part;

            if (swModel.Visible == false)
            {
                swModel.Visible = true;
            }

            swApp.ActivateDoc3(swModel.GetPathName(), false, (int)swRebuildOnActivation_e.swDontRebuildActiveDoc, 0);
            swModel.FeatureManager.EnableFeatureTree = false;
            swModel.FeatureManager.EnableFeatureTreeWindow = false;
            //swModel.ActiveView.EnableGraphicsUpdate = false;

            string curConf = swModel.ConfigurationManager.ActiveConfiguration.Name;

            if (curConf != conf)
            {
                if (!swModel.ShowConfiguration2(conf))
                {
                    swApp.SendMsgToUser("Failed to activate configuration");
                }
            }

            string modelPath = swModel.GetPathName();
            if (modelPath == null)
            {
                swApp.SendMsgToUser("Part document must be saved");
            }

            swModel.ShowConfiguration2(curConf);
        }

        private void ProcessSheetMetalModel(ModelDoc2 rootModel, ModelDoc2 sheetMetalModel, string conf)
        {
            var vCutListFeats = GetCutListFeatures(sheetMetalModel);

            if (vCutListFeats != null)
            {
                var vFlatPatternFeats = GetFlatPatternFeatures(sheetMetalModel);
               
                if (vFlatPatternFeats != null)
                {
                    Feature swProcessedCutListsFeats();





                    Feature swFlatPatternFeat;
                    FlatPatternFeatureData swFlatPattern;

                    swFlatPatternFeat = vFlatPatternFeats(i);

                    swFlatPattern = (FlatPatternFeatureData)swFlatPatternFeat.GetDefinition();



                    Entity swFixedEnt;
                    swFixedEnt = (Entity)swFlatPattern.FixedFace2;
                    Body2 swBody;

                    if (swFixedEnt is Face2)
                    {
                        Face2 swFixedFace;
                        swFixedFace = (Face2)swFixedEnt;
                        swBody = (Body2)swFixedFace.GetBody();
                    }
                    else if (swFixedEnt is Edge)
                    {
                        Edge swFixedEdge;
                        swFixedEdge = (Edge)swFixedEnt;
                        swBody = swFixedEdge.GetBody();
                    }
                    else if (swFixedEnt is Vertex)
                    {
                        Vertex swFixedVert = (Vertex)swFixedEnt;
                        swBody = swFixedVert.GetBody();
                    }
                    Feature swCutListFeat;
                    swCutListFeat = FindCutListFeature(vCutListFeats, swBody);
                }
            }
            
        }
        private Feature FindCutListFeature(Feature vCutListFeats, Body2 body)
        {
            for (int i = 0; i < vCutListFeats.; i++)
            {
                Feature swCutListFeat;
                swCutListFeat = vCutListFeats(i);

                BodyFolder swBodyFolder;
                swBodyFolder = (BodyFolder)swCutListFeat.GetSpecificFeature2();
                object vBodies = swBodyFolder.GetBodies();

                if (ContainsSwObject(vBodies, body))
                {
                    swCutListFeat = FindCutListFeature;
                }

        

            }


        }

        private void swProcessedCutListsFeats()
        { 
            
        }
        private bool ContainsSwObject(Object vArr , Object obj)
        {

            if (vArr != null)
            {
                for (int i = 0; i < vArr; i++)
                {

                }



                For i = 0 To UBound(vArr)


            Object swObj As Object
            Set swObj = vArr(i)


            If swApp.IsSame(swObj, obj) = swObjectEquality.swObjectSame Then
                ContainsSwObject = True
                Exit Function
            End If
        Next
            }
            return true;
        }
        private void GetFlatPatternFeatures(ModelDoc2 model)
        {
            GetFlatPatternFeatures = GetFeaturesByType(model, "FlatPattern");
        }


        private Feature GetCutListFeatures (ModelDoc2 model)
        {
            return GetCutListFeatures = GetFeaturesByType(model, "CutListFolder");
        }

        private Feature GetFeaturesByType(ModelDoc2 model,string typeName)
        {
            Feature swFeat = (Feature)model.FirstFeature();

            while (swFeat !=null)
            {
                if (typeName == "CutListFolder" && swFeat.GetTypeName2() == "SolidBodyFolder")
                {
                    BodyFolder swBodyFolder;
                    swBodyFolder = (BodyFolder)swFeat.GetSpecificFeature2();
                    swBodyFolder.UpdateCutList();
                }

                ProcessFeature(swFeat, swFeats, typeName);

                swFeat = (Feature)swFeat.GetNextFeature();
            }
            
            if (swFeats == null)
            {
                return  null;
            }
            else
            {
                return swFeats;
            }
        }

        private void ProcessFeature(Feature thisFeat, Feature featsArr, string typeName)
        {
            if (thisFeat.GetTypeName2() == typeName)
            {
                while (featsArr !=null)
                {
                    if (swApp.IsSame(featsArr[i], thisFeat) = swObjectEquality.swObjectSame)
                    {

                    }
                }


            }
        }








    }
}