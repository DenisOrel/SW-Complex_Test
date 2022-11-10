namespace Converter
{
    internal class DataToExport
    {
        public string Configuration { get; set; }
        public byte[] DXFByte { get; set; }
        public decimal WorkpieceX { get; set; }
        public decimal WorkpieceY { get; set; }
        public int Bend { get; set; }
        public decimal Thickness { get; set; }
        public int Version { get; set; }
        public int PaintX { get; set; }
        public int PaintY { get; set; }
        public int PaintZ { get; set; }
        public int IdPdm { get; set; }
        public decimal SurfaceArea { get; set; }
        public int? MaterialID { get; set; }
        public decimal BoundingBoxAreaBlank { get; set; }
        public int Density { get; set; }
        public string PCName { get; set; }
        public string UserName { get; set; }
        public System.DateTime DateTime { get; set; }
        public decimal Volume { get; set; }
    }
}
