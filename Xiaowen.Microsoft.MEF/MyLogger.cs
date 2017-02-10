using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.Microsoft.MEF
{
    [Export(typeof(IMyAddin))]
    public class MyLogger : IMyAddin
    {

    }
}
