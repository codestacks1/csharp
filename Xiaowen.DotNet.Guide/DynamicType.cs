using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    public class DynamicType : IDynamicMetaObjectProvider
    {

        static dynamic GetValue()
        {
            return new DynamicType();
        }
        
        public void AppMian_Dynamic(int i, string str = null, bool flag = false)
        {
            dynamic obj;
            obj = GetValue();
        }

        public DynamicMetaObject GetMetaObject(Expression parameter)
        {

            this.AppMian_Dynamic(1, str: string.Empty, flag: true);

            throw new NotImplementedException();
        }
    }
}
