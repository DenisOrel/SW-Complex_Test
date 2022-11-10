using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class ExpoerOptions
    {
        /// <summary>
        ///  Compute sheet metal options
        /// </summary>
        /// <param name="ExportGeometry"></param>
        /// <param name="IcnludeHiddenEdges"></param>
        /// <param name="ExportBendLines"></param>
        /// <param name="IncludeScetches"></param>
        /// <param name="MergeCoplanarFaces"></param>
        /// <param name="ExportLibraryFeatures"></param>
        /// <param name="ExportFirmingTools"></param>
        /// <returns></returns>
        public int SheetMetalOptions(bool ExportGeometry, bool IcnludeHiddenEdges, bool ExportBendLines, bool IncludeScetches, bool MergeCoplanarFaces, bool ExportLibraryFeatures, bool ExportFirmingTools)
        {
            return SheetMetalOptions(
                ExportGeometry ? 1 : 0,
                IcnludeHiddenEdges ? 1 : 0,
                ExportBendLines ? 1 : 0,
                IncludeScetches ? 1 : 0,
                MergeCoplanarFaces ? 1 : 0,
                ExportLibraryFeatures ? 1 : 0,
                ExportFirmingTools ? 1 : 0);
        }
        /// <summary>
        /// Compute sheet metal options
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p5"></param>
        /// <param name="p6"></param>
        /// <returns></returns>
        private int SheetMetalOptions(int p0, int p1, int p2, int p3, int p4, int p5, int p6)
        {
            return p0 * 1 + p1 * 2 + p2 * 4 + p3 * 8 + p4 * 16 + p5 * 32 + p6 * 64;
        }

        public object Alignment(double[] dataAlignment)
        {
            dataAlignment = new double[12];

            dataAlignment[0] = 0.0;
            dataAlignment[1] = 0.0;
            dataAlignment[2] = 0.0;
            dataAlignment[3] = 1.0;
            dataAlignment[4] = 0.0;
            dataAlignment[5] = 0.0;
            dataAlignment[6] = 0.0;
            dataAlignment[7] = 1.0;
            dataAlignment[8] = 0.0;
            dataAlignment[9] = 0.0;
            dataAlignment[10] = 0.0;
            dataAlignment[11] = 1.0;

            object varAlignment = dataAlignment;
            return varAlignment;

        }
    }
}
