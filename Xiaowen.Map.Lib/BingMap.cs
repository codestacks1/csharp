using Esri.ArcGISRuntime.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.Map.Lib
{
    public class BingMap
    {
        /// <summary>
        /// BingKey
        /// </summary>
        public static string BingToken { get; set; }

        /// <summary>
        /// 坐标
        /// </summary>
        public static Dictionary<int, MapPoint> Coordinate { get; set; }
    }
}
