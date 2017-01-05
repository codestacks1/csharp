using System.Text;

namespace Xiaowen.Personal.SqlDetach
{
    /// <summary>
    /// author: xiaowen
    /// </summary>
    public class XwSqlComplexSchema
    {
        //private string selectFrom;
        //private string selectShow;
        //private string orderBy;
        //private string groupBy;

        public string SelectShow { get; set; }

        public string SelectFrom { get; set; }
        private StringBuilder where;

        public StringBuilder Where { get; set; }

        public string GroupBy { get; set; }

        public string OrderBy { get; set; }
    }
}
