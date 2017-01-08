using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Xiaowen.Windows.Video.UserControls
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : UserControl
    {
        /// <summary>
        /// 令牌
        /// bingkey
        /// </summary>
        private string token = string.Empty;

        public Map()
        {
            InitializeComponent();

            string map = ConfigurationManager.AppSettings["InitUsedMap"];
        }

        /// <summary>
        /// 
        /// </summary>
        void IintMap()
        {
            bool isEnable = false;//是否enable
            string map = string.Empty;//当前要启用的地图名称
            string tileLayer = ConfigurationManager.AppSettings["InitUsedMap"];
            switch (tileLayer)
            {
                case "BingMap":
                    map = ConfigurationManager.AppSettings["BingMap"];
                    isEnable = Convert.ToBoolean(map);
                    if (isEnable)
                    {
                        token = ConfigurationManager.AppSettings["BingKey"];
                    }
                    break;
                case "GooleMap":
                    map = ConfigurationManager.AppSettings["GooleMap"];
                    isEnable = Convert.ToBoolean(map);
                    if (isEnable)
                    {
                        //Map = ConfigurationManager.AppSettings["BingKey"];
                    }
                    break;
                case "ArcGISServer":
                    map = ConfigurationManager.AppSettings["ArcGISServer"];
                    isEnable = Convert.ToBoolean(map);
                    if (isEnable)
                    {
                        //Map = ConfigurationManager.AppSettings["BingKey"];
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
