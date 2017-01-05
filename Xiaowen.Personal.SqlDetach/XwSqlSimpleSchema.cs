using System.Text;

namespace Xiaowen.Personal.SqlDetach
{
    /// <summary>
    /// author: xiaowen
    /// </summary>
    public class XwSqlSimpleSchema
    {
        /// <summary>
        /// SQL主体
        ///     如：select * from YSB_Table
        ///         select * from YSB_Table where ID = 1
        ///         update YSB_Table set Column = 2 where ID = 1
        /// </summary>
        public string SqlSubject { get; set; }

        private StringBuilder where = new StringBuilder();
        /// <summary>
        /// 条件可选
        ///     条件可空，
        /// </summary>
        public StringBuilder Where { get; set; }
    }
}
