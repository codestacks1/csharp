using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.Personal.SqlDetach
{
    /// <summary>
    /// author: xiaowen
    /// </summary>
    public struct XwWhereClauseSchema
    {
        private Nullable<bool> isSpecialField;//是否包含需要特殊处理的字段内容
        private Nullable<bool> isSingleDay;
        /// <summary>
        /// 该字段也用于处理包含特殊字符的情况
        /// </summary>
        private string specialHandler;
        private string columnKey;//查询条件 字段名
        private object columnValue;//查询条件 字段对应值
        private Nullable<bool> isSpecialHandler;

        /// <summary>
        /// 既有函数 又有单双日
        /// </summary>
        /// <param name="isSpecialField">是否包含需要特殊处理的字段</param>
        /// <param name="isSingleDay">是否单日查询  即：2017-1-1 or 2017-1-1 至 2017-12-12</param>
        /// <param name="columnKey">查询条件字段名</param>
        /// <param name="columnValue">查询条件对应字段内容</param>
        public XwWhereClauseSchema(Nullable<bool> isSpecialField, string columnKey, object columnValue, Nullable<bool> isSingleDay)
        {
            this.isSpecialField = isSpecialField;
            this.isSingleDay = isSingleDay;
            this.columnKey = columnKey;
            this.columnValue = columnValue;
            this.specialHandler = string.Empty;
            this.isSpecialHandler = null;
        }

        /// <summary>
        /// 有窗口函数（聚合、等等）
        /// </summary>
        /// <param name="isSpecialField"></param>
        /// <param name="columnKey"></param>
        /// <param name="columnValue"></param>
        public XwWhereClauseSchema(Nullable<bool> isSpecialField, string columnKey, object columnValue)
        {
            this.isSpecialField = isSpecialField;
            this.columnKey = columnKey;
            this.columnValue = columnValue;
            this.isSingleDay = null;
            this.specialHandler = string.Empty;
            this.isSpecialHandler = null;
        }

        /// <summary>
        /// 有单双日，无特殊窗口函数需要处理
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="conditionContent"></param>
        /// <param name="isSingleDay">是否单日 false：为日期区间</param>
        public XwWhereClauseSchema(string columnKey, object columnValue, Nullable<bool> isSingleDay)
        {
            this.isSingleDay = isSingleDay;
            this.columnKey = columnKey;
            this.columnValue = columnValue;
            isSpecialField = null;
            this.specialHandler = string.Empty;
            this.isSpecialHandler = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnKey"></param>
        /// <param name="columnValue"></param>
        public XwWhereClauseSchema(string columnKey, object columnValue)
        {
            this.columnKey = columnKey;
            this.columnValue = columnValue;
            isSingleDay = null;
            isSpecialField = null;
            this.specialHandler = string.Empty;
            this.isSpecialHandler = null;
        }

        /// <summary>
        /// SQL条件中是否存在特殊的标签
        ///     如：CAST CONVERT 等Keyword
        /// </summary>
        public Nullable<bool> IsSpecialField
        {
            get { return isSpecialField; }
            set { isSpecialField = value; }
        }

        public Nullable<bool> IsSingleDay
        {
            get { return isSingleDay; }
            set { isSingleDay = value; }
        }

        /// <summary>
        /// 主要过滤条件之一，所属当前登录账户的数据，而非其账户的信息
        /// 账户之间是否共享数据，这取决于业务需求
        /// </summary>
        public string SpecialHandler
        {
            get { return specialHandler; }
            set { specialHandler = value; }
        }

        /// <summary>
        /// 表字段名
        /// </summary>
        public string ColumnKey
        {
            get { return columnKey; }
            set { columnKey = value; }
        }

        /// <summary>
        /// 表字段内容
        /// </summary>
        public object ColumnValue
        {
            get { return columnValue; }
            set { columnValue = value; }
        }

        public Nullable<bool> IsSpecialHandler
        {
            get { return isSpecialHandler; }
            set { isSpecialHandler = value; }
        }
    }
}
