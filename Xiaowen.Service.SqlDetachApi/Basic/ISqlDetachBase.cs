using System.Collections;
using System.ServiceModel;

namespace Xiaowen.Service.SqlDetachApi.Basic
{
    [System.ServiceModel.ServiceContract]
    public interface ISqlDetachBase
    {
        [OperationContract]
        void GetSqlDetachBase();
    }
}
