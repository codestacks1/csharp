using Esri.ArcGISRuntime.Mapping;
using Microsoft.Practices.Prism.Mvvm;

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
