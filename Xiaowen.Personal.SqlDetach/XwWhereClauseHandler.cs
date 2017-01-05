using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Xiaowen.Personal.SqlDetach
{
    public class XwWhereClauseHandler
    {

        /// <summary>
        /// 条件处理器
        ///     快速、统一处理查询条件
        /// </summary>
        /// <param name="dataParameter"></param>
        /// <param name="param">此处有约束，前两个参数一定只允许是日期或时间</param>
        /// <returns></returns>
        private static StringBuilder WhereColumnKeyHandler(ref ArrayList dataParameter, params XwWhereClauseSchema[] param)
        {
            StringBuilder where = new StringBuilder();
            IDataParameter beginDate = null;

            foreach (XwWhereClauseSchema item in param == null ? new XwWhereClauseSchema[] { } : param)
            {
                //是否存在窗口函数等特殊的转换类型函数
                if (item.IsSpecialField == true)
                {
                    //是否单日
                    if (item.IsSingleDay == null)
                    {
                        where.AppendFormat(" AND {0}={1}", item.ColumnKey, "@" + item.ColumnKey);
                        dataParameter.Add(new SqlParameter("@" + item.ColumnKey, item.ColumnValue));
                    }
                    else
                    {
                        //单日
                        if (item.IsSingleDay == true)
                        {
                            //+code
                            //判断ColumnValue是否有值

                            //单日，并且单日需要使用窗口函数：即：需要日期转换
                            if (item.IsSpecialHandler == true)
                            {
                                where.AppendFormat(" AND {0}={1}", item.ColumnKey, "@" + item.SpecialHandler);
                                dataParameter.Add(new SqlParameter("@" + item.SpecialHandler, item.ColumnValue));
                            }
                            else
                            {
                                where.AppendFormat(" AND {0}={1}", item.ColumnKey, "@" + item.ColumnKey);
                                dataParameter.Add(new SqlParameter("@" + item.ColumnKey, item.ColumnValue));
                            }
                        }
                        //日期区间
                        else
                        {
                            if (beginDate == null)
                            {
                                beginDate = new SqlParameter("@" + item.SpecialHandler, item.ColumnValue);
                                where.AppendFormat(" AND {0}>={1}", item.ColumnKey, "@" + item.SpecialHandler);
                                dataParameter.Add(new SqlParameter("@" + item.SpecialHandler, item.ColumnValue));
                            }
                            else
                            {
                                where.AppendFormat(" AND {0}<={1}", item.ColumnKey, "@End" + item.SpecialHandler);
                                dataParameter.Add(new SqlParameter("@End" + item.SpecialHandler, item.ColumnValue));
                            }
                        }
                    }
                }
                //为null或 false
                else
                {
                    if (item.IsSingleDay == null)
                    {
                        where.AppendFormat(" AND {0}={1}", item.ColumnKey, "@" + item.ColumnKey);
                        dataParameter.Add(new SqlParameter("@" + item.ColumnKey, item.ColumnValue));
                    }
                    else
                    {
                        if (item.IsSingleDay == true)
                        {
                            //+code 判断条件ColumnValue是否有值 

                            where.AppendFormat(" AND {0}={1}", item.ColumnKey, "@" + item.ColumnKey);
                            dataParameter.Add(new SqlParameter("@" + item.ColumnKey, item.ColumnValue));
                        }
                        else
                        {
                            if (beginDate == null)
                            {
                                beginDate = new SqlParameter("@" + item.SpecialHandler, item.ColumnValue);
                                where.AppendFormat(" AND {0}>={1}", item.ColumnKey, "@" + item.SpecialHandler);
                                dataParameter.Add(beginDate);
                            }
                            else
                            {
                                where.AppendFormat(" AND {0}<={1}", item.ColumnKey, "@End" + item.SpecialHandler);
                                dataParameter.Add(new SqlParameter("@End" + item.SpecialHandler, item.ColumnValue));
                            }
                        }
                    }
                }
            }
            return where;
        }


        #region Backup

        ///// <summary>
        ///// 条件处理器
        /////     快速、统一处理查询条件
        ///// </summary>
        ///// <param name="dataParameter"></param>
        ///// <param name="param">此处有约束，前两个参数一定只允许是日期或时间</param>
        ///// <returns></returns>
        //private static StringBuilder WhereColumnKeyHandler(ref ArrayList dataParameter, params XwWhereClauseSchema[] param)
        //{
        //    StringBuilder where = new StringBuilder();
        //    IDataParameter beingDate = null;

        //    if (param != null)
        //        foreach (XwWhereClauseSchema item in param)
        //        {
        //            //是否存在窗口函数等特殊的转换类型函数
        //            if (item.IsSpecialField == true)
        //            {
        //                if (item.IsSingleDate != null)
        //                {
        //                    if (item.IsSingleDate == true)
        //                    {
        //                        if (item.ColumnValue != null)
        //                        {
        //                            if (item.IsSpecialHandler == true)
        //                            {
        //                                where.AppendFormat(" AND {0}={1}", item.ColumnKey, "@" + item.SpecialHandler);
        //                                dataParameter.Add(new SqlParameter("@" + item.SpecialHandler, item.ColumnValue));
        //                            }
        //                            else
        //                            {
        //                                where.AppendFormat(" AND {0}={1}", item.ColumnKey, "@" + item.ColumnKey);
        //                                dataParameter.Add(new SqlParameter("@" + item.ColumnKey, item.ColumnValue));
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (item.ColumnValue != null)
        //                        {
        //                            if (beingDate == null)
        //                            {
        //                                beingDate = new SqlParameter("@" + item.SpecialHandler, item.ColumnValue);
        //                                where.AppendFormat(" AND {0}>={1}", item.ColumnKey, "@" + item.SpecialHandler);
        //                                dataParameter.Add(new SqlParameter("@" + item.SpecialHandler, item.ColumnValue));
        //                            }
        //                            else
        //                            {
        //                                where.AppendFormat(" AND {0}<={1}", item.ColumnKey, "@End" + item.SpecialHandler);
        //                                dataParameter.Add(new SqlParameter("@End" + item.SpecialHandler, item.ColumnValue));
        //                            }
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    where.AppendFormat(" AND {0}={1}", item.ColumnKey, "@" + item.ColumnKey);
        //                    dataParameter.Add(new SqlParameter("@" + item.ColumnKey, item.ColumnValue));
        //                }
        //            }
        //            else
        //            if (item.IsSingleDate != null)
        //            {
        //                if (item.IsSingleDate == true)
        //                {
        //                    if (item.ColumnValue != null)
        //                    {
        //                        where.AppendFormat(" AND {0}={1}", item.ColumnKey, "@" + item.ColumnKey);
        //                        dataParameter.Add(new SqlParameter("@" + item.ColumnKey, item.ColumnValue));
        //                    }
        //                }
        //                else
        //                {
        //                    if (item.ColumnValue != null)
        //                    {
        //                        if (beingDate == null)
        //                        {
        //                            beingDate = new SqlParameter("@" + item.SpecialHandler, item.ColumnValue);
        //                            where.AppendFormat(" AND {0}>={1}", item.ColumnKey, "@" + item.SpecialHandler);
        //                            dataParameter.Add(beingDate);
        //                        }
        //                        else
        //                        {
        //                            where.AppendFormat(" AND {0}<={1}", item.ColumnKey, "@End" + item.SpecialHandler);
        //                            dataParameter.Add(new SqlParameter("@End" + item.SpecialHandler, item.ColumnValue));
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                where.AppendFormat(" AND {0}={1}", item.ColumnKey, "@" + item.ColumnKey);
        //                dataParameter.Add(new SqlParameter("@" + item.ColumnKey, item.ColumnValue));
        //            }

        //        }
        //    return where;
        //}

        #endregion

    }
}
