using ESRI.ArcGIS.Client.Geometry;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Xiaowen.Web.Silverlight.Bing
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
