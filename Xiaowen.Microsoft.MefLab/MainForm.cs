using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xiaowen.Microsoft.MefLab
{
    public partial class MainForm : Form
    {
        //    [ImportMany]
        //    public Lazy<IMainFormContract, IDictionary<string, object>>[] ImportedMainFormContracts { get; set; }

        //    private CompositionContainer _container;

        public MainForm()
        {
            InitializeComponent();
        }
        
        //private CompositionContainer GetContainerFromDirectory()
        //{
        //    var catalog = new AggregateCatalog();

        //    var thisAssembly = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
        //    catalog.Catalogs.Add(thisAssembly);

        //    catalog.Catalogs.Add(new DirectoryCatalog(_extensionDir));

        //    var container = new CompositionContainer(catalog);
        //    return container;
        //}
    }
}
