using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Xiaowen.Personal.SqlDetach;
using Xiaowen.Personal.SqlDetach.Dbo;

namespace Xiaowen.Service.SqlDetachApi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    [ServiceKnownType(typeof(DboHandler))]
    public interface ISqlDetach
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
        void QueryAuthor(XwDoEnum xwDoWhileEvent, DboHandler sender, params XwWhereClauseSchema[] whereParams);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    //[DataContract]
    //public class SqlDetacher
    //{
    //    private static SqlDetachBase sqlDetach;
    //    [DataMember]
    //    public static SqlDetachBase SqlDetach
    //    {
    //        get
    //        {
    //            if (sqlDetach == null)
    //                sqlDetach = new SqlDetachBase();
    //            return sqlDetach;
    //        }
    //        set { sqlDetach = value; }
    //    }
    //}
}
