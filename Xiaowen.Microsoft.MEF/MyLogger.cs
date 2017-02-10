using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.Microsoft.MEF
{
    /**
     * 到出是部件向容器中的其他部件提供的一个值，
     * 而导入是部件向要通过可用导出填充的容器的要求。
     * 特性化编程模型中，导入和导出由使用Import和Export特性的修饰类或成员声明。
     * Export可修饰类、字段、属性或方法，Import特性可修饰字段、属性或构造函数参数。
     * 
     * 为了使导入与导出相匹配，该导入和该导出必须具有相同的协定。该协定由一个字符串（*称为协定名称）和已导出或已导入对象的类型（*称为协定类型）组成。
     * 只有在协定名称和协定类型均匹配时，才会认为导出能够满足特定导入。
     * **/
    [Export(typeof(IMyAddin))]
    public class MyLogger : IMyAddin
    {
        //导出到IMyAddin类型的对象中
        //上面的特性若为：[Export] 导出则为MyLogger

        public int MyProperty { get; set; }
    }
}
