using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    internal class Bends
    {
        Feature _swSubFeat;
        Feature _swFeat;

        public Feature FixOneBand(ModelDoc2 swModelDoc)
        {

            IPartDoc swPart = (IPartDoc)swModelDoc;
            _swFeat = (Feature)swModelDoc.FirstFeature();
            Feature flatPattern = null;

            while (_swFeat != null)
            {

                if (_swFeat.GetTypeName() == "FlatPattern")
                {
                    flatPattern = _swFeat;
                    flatPattern.Select(true);
                    swPart.EditUnsuppress();
                    flatPattern.DeSelect();

                    _swSubFeat = (Feature)flatPattern.GetFirstSubFeature();

                    while ((_swSubFeat != null))
                    {
                        if (_swSubFeat.GetTypeName() == "UiBend" && _swSubFeat.IsSuppressed())
                        {
                            object[] fisrtParent = _swSubFeat.GetParents();
                            if (fisrtParent != null)
                            {
                                foreach (var item in fisrtParent)
                                {
                                    Feature swFirstParentFeat = (Feature)item;
                                    if (!swFirstParentFeat.GetOwnerFeature().IsSuppressed())
                                    {
                                        _swSubFeat.SetSuppression(1);
                                    }
                                }
                            }
                        }
                        _swSubFeat = (Feature)_swSubFeat.GetNextSubFeature();
                    }
                }
                _swFeat = (Feature)_swFeat.GetNextFeature();
            }
            return flatPattern;
        }

        public void UnFix(ModelDoc2 modelDoc, Feature flatPattern)
        {

            flatPattern.Select(true);
            modelDoc.EditSuppress();
            //int res = modelDoc.SetBendState(2);
            //bool was = modelDoc.EditRebuild3();
        }
    }
}
