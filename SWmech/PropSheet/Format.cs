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

        public string FormatName
        { get { return name; } }

        public double Width
        { get { return width; } }

        public double Height
        { get { return height; } }

        public string[] Multiplicity
        { get; set; }

        public bool Orientation
        { get; set; }

        public List<Format> FormatsList()
        {
            string[] A4 = { "1", "2,5", "3", "3,5", "4", "4,5", "5", "5,5", "6", "6,5", "7", "7,5", "8", "8,5", "9" };
            string[] A3 = { "1", "2,5", "3", "3,5", "4", "4,5", "5", "5,5", "6", "6,5", "7" };
            string[] A2 = { "1", "2,5", "3", "3,5", "4", "4,5", "5" };
            string[] A1 = { "1", "2,5", "3", "3,5", "4" };
            string[] A0 = { "1", "2,5", "3" };
            string[] other = { "1"};

            List<Format> FormatList = new List<Format>
            {
             new Format {name = "А4", width = 0.210, height = 0.297, Multiplicity = A4},
             new Format {name = "А3", width = 0.297, height = 0.420, Multiplicity = A3},
             new Format {name = "А2", width = 0.420, height = 0.594, Multiplicity = A2},
             new Format {name = "А1", width = 0.594, height = 0.841, Multiplicity = A1},
             new Format {name = "А0", width = 0.841, height = 1.189, Multiplicity = A0},
             new Format {name = "Інший", width = 0, height = 0, Multiplicity = other},
            };
            return FormatList;
        }
    }
}