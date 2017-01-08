using Esri.ArcGISRuntime.Mapping;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.Windows.Video.ViewModels
{
    public class TabMapViewModel : BindableBase
    {
        private Map _map = new Map(Basemap.CreateStreetsNightVector());
        public TabMapViewModel()
        {

        }

        public Map Map
        {
            get { return _map; }
            set { SetProperty(ref _map, value); }
        }
    }
}
