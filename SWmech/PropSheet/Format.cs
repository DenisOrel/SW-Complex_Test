using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWmech
{
    public class Format
    {
        private string name;
        private double width, height;

        public string Name
        { get { return name; } }

        public double Width
        { get { return width; } }

        public double Height
        { get { return height; } }

        public int Multiplicity
        { get; set; }

        public bool Orientation
        { get; set; }

        public List<Format> FormatsList()
        {
            List<Format> A4 = new List<Format>
            {
             new Format { name = "А4", width = 210, height = 297 },
             new Format { name = "А3", width = 297, height = 420 },
             new Format { name = "А2", width = 420, height = 594 },
             new Format { name = "А1", width = 594, height = 841 },
             new Format { name = "А0", width = 841, height = 1189 }
            };
            return A4;
        }
    }
}