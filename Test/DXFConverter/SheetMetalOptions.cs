using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DXF
{
    public enum SheetMetalOptions_e
    {
        ExportFlatPatternGeometry = 1,
        IncludeHiddenEdges = 2,
        ExportBendLines = 4,
        IncludeSketches = 8,
        MergeCoplanarFaces = 16,
        ExportLibraryFeatures = 32,
        ExportFormingTools = 64,
        ExportBoundingBox = 2048
    }
}