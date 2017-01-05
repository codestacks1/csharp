using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Xiaowen.Web.Silverlight.ViewModels
{
    public class AnchorModel
    {
        public int Row { get; set; }
        /// <summary>
        /// 位置名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 所属国家
        /// </summary>
        public string Country { get; set; }
    }
}
