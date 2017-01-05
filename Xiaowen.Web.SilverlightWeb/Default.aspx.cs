using System;
using System.Configuration;

namespace Xiaowen.Web.SilverlightWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected string Map = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
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
                        Map = ConfigurationManager.AppSettings["BingKey"];
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