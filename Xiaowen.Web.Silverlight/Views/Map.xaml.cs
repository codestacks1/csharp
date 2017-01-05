using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Bing;
using ESRI.ArcGIS.Client.Projection;
using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Xiaowen.Web.Silverlight.Bing;

namespace Xiaowen.Web.Silverlight.Views
{
    public partial class Map : Page
    {
        private GraphicsLayer _waypointGraphicsLayer = null;
        private GraphicsLayer _geocodeResultsGraphicsLayer = null;
        private static readonly WebMercator Mercator = new WebMercator();

        private readonly List<Graphic> _stops = new List<Graphic>();

        public Map()
        {
            InitializeComponent();

            InitTileLayer();
            InitGraphicLayer();
        }

        /// <summary>
        /// 初始化底图
        /// </summary>
        private void InitTileLayer()
        {
            WebClient webClient = new WebClient();
            string uri = string.Format("http://dev.virtualearth.net/REST/v1/Imagery/Metadata/Aerial?supressStatus=true&key={0}", BingMap.BingToken);

            webClient.OpenReadCompleted += (s, e) =>
            {
                if (e.Error == null)
                {
                    JsonValue jsonResponse = JsonObject.Load(e.Result);
                    ESRI.ArcGIS.Client.Bing.TileLayer tileLayer = new ESRI.ArcGIS.Client.Bing.TileLayer()
                    {
                        ID = "BingLayer",
                        LayerStyle = TileLayer.LayerType.Road,
                        ServerType = ServerType.Production,
                        Token = BingMap.BingToken
                    };
                    MyMap.Layers.Insert(0, tileLayer);
                }
            };
            webClient.OpenReadAsync(new Uri(uri));
        }

        /// <summary>
        /// 初始化GraphicLayer
        /// </summary>
        public void InitGraphicLayer()
        {
            _geocodeResultsGraphicsLayer = MyMap.Layers["GeocodeResultsGraphicsLayer"] as GraphicsLayer;
            _waypointGraphicsLayer = MyMap.Layers["WaypointGraphicsLayer"] as GraphicsLayer;
        }
    }
}
