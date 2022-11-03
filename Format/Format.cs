using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Format
{
    public class Format
    {
        private int multiplicity;
        private string name;
        private double width;

        private List<Format> rr = new List<Format>();

        public string Name
        { get { return name; } }

        public double Width
        { get { return width; } }

        public double Height { get; }

        public int Multiplicity
        { set { multiplicity = value; } }

        private void dd()
        {
            Format A4 = new Format();
            A4.name = "A4";
        }
    }
}