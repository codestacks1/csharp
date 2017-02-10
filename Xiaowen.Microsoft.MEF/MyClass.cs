using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.Microsoft.MEF
{
    public class MyClass
    {
        [Import]
        public IMyAddin MyAddin { get; set; }

        [Export("MajorRevision")]
        public int MajorRevision { get; set; }



    }


    public class MyExportClass
    {

    }
}
