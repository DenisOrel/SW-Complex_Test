namespace Converter.DXF
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