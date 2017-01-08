using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.Video.Lib.Init
{
    public partial class InitData<T> where T : class, new()
    {
        public async Task GetUserInfoFromCache()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        public async Task<T> Get()
        {
            return await Task<T>.Run<T>(() =>
              {

                  return new T();
              });
        }


        public async Task Set(T t)
        {
            await Task.Run(() =>
            {

            });
        }



        /// <summary>
        /// 初始化软件启动所需要的数据
        /// </summary>
        /// <returns></returns>
        async Task<object> InitDataDemo()
        {
            //loading data
            await Task.Run(async () =>
            {
                //等待此处的进行执行完成
                await Task.Delay(TimeSpan.FromSeconds(1));

            });

            //异步执行数据加载，并返回操作结果
            return Task<object>.Run<object>(() =>
            {
                return new object();
            });
        }
    }
}
