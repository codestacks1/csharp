using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Xiaowen.Concurrency.Demo
{
    /**
     * 异步编程简介
     * **/
    public class Chapter01
    {
        //起步
        public class C01
        {
            public void C01Main()
            {
                Task task = this.DoSomethingAsync();
                Console.WriteLine(task.Status);
                Console.WriteLine(this.GetInputContent("how are you doing").Result);

                Task task1 = this.DoSomething();
                Console.WriteLine(task1.Status);
            }

            /// <summary>
            /// 简单异步任务
            /// </summary>
            /// <returns></returns>
            async Task<int> DoSomethingAsync()
            {
                int val = 3;
                await Task.Delay(TimeSpan.FromSeconds(1));
                val *= 2 + 9 / 2;//计算方式  3*(2+9/2)
                await Task.Delay(TimeSpan.FromSeconds(1));
                return val;
            }

            /// <summary>
            /// Task<TResult>线程任务委托
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            async Task<string> GetInputContent(string str)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                return await Task.FromResult<string>(str);
            }

            /// <summary>
            /// 注意从在是参数重载
            /// 无论返回值类型是否相同，方法名一致是不允许的
            /// </summary>
            /// <returns></returns>
            async Task DoSomething()
            {
                TaskFactory tf = Task.Factory;
                await Task.Delay(TimeSpan.FromSeconds(2));
                //OuputTaskResult(tf.StartNew<string>(Do));
                await tf.StartNew<string>(Do).ContinueWith(OuputTaskResult);
            }

            void OuputTaskResult(Task<string> task)
            {
                Console.WriteLine("Oupt task Result (reuslt from Do Func): {0}", task.Result);
            }

            string Do()
            {
                return "Hello, you can call me async programing";
            }

        }

        public class C02
        {
            public delegate void MyAction<out Task>();
            /// <summary>
            /// 启动函数
            /// </summary>
            public void C02Main()
            {
                //Action act = DoSomething;
                DoSomething();
                Task task = this.DoTaskFactory();
                Console.WriteLine("TaskFactory task.status: {0}", task.Status);
            }

            private async void DoSomething()
            {
                Console.WriteLine("DoSomething");
                Task task = this.DoSomethingAsync();
                await task;
                Console.WriteLine("Await current thread {0},{1},{2}", task.Id, task.Status, task.AsyncState);
            }

            /// <summary>
            /// 当前异步线程
            /// </summary>
            /// <returns></returns>
            async Task DoSomethingAsync()
            {
                Console.WriteLine("DoSomethingAsync");
                int val = 3;
                await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);//该线程任务将在

                //线程池中运行
                val *= 3 + 9 / 6;
                await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

                Console.WriteLine("value:{0}", val);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            private async Task DoTaskFactory()
            {
                TaskFactory tf = new TaskFactory();
                //线程池新启一个下称来完成任务
                await tf.StartNew(() =>
                {
                    Task task = Task.Delay(TimeSpan.FromSeconds(1));
                    Console.WriteLine("TaskFactory new task: 1,task.id = {0}", task.Id);
                });

                await Task.Delay(TimeSpan.FromSeconds(6));

                Console.WriteLine("current task id = {0}", Task.Yield().GetAwaiter().IsCompleted);

                await tf.StartNew(() =>
                {
                    Task task = Task.Delay(TimeSpan.FromSeconds(1));
                    Console.WriteLine("TaskFactory new task: 2,task.id = {0}", task.Id);
                });
            }
        }

        /// <summary>
        /// 处理异步线程异常
        /// </summary>
        public class C03
        {
            public async void C03Main()
            {
                Task task = this.TrySomethingAsync();
                await Task.Delay(TimeSpan.FromSeconds(4));//阻塞当前线程
                await task;
                Console.WriteLine("task.Status : {0}", task.Status);

                Deadlock();
            }

            async Task TrySomethingAsync()
            {
                Task task = PossibaleExceptionAsync();
                try
                {
                    await task;
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            async Task PossibaleExceptionAsync()
            {
                string s = "str123";

                TaskFactory tf = new TaskFactory();
                await tf.StartNew(() =>
                {
                    try
                    {
                        int i = int.Parse(s);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error: {0}", ex.Message);
                    }
                });
            }

            async Task WaitAsync()
            {
                //await会捕获当前上下文
                await Task.Delay(TimeSpan.FromSeconds(2));
                //试图用上面捕获的上下文继续执行
                Console.WriteLine("deadlock");
            }

            void Deadlock()
            {
                Task task = WaitAsync();
                task.Wait();//如果从UI或Asp.Net的上下文调用这段代码，就会发生死锁
            }
        }

        /// <summary>
        /// 并行编程
        /// 并行编程不太适合服务器系统，因为服务器本身具有并行处理能力
        /// 但是在某些情况下，在服务器系统中编写并行代码仍然有用
        /// </summary>
        public class C04
        {
            public void C04Main()
            {
                Console.Title = "Parallel programing";

                IEnumerable<int> intlist = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
                //this.RotateNumber(intlist);
                this.ParallelAmount(intlist);
                this.ParallelErrorHandler();
            }
            void RotateNumber(IEnumerable<int> matrices)
            {
                Console.WriteLine("Parallel computing tasks.");
                ParallelLoopResult result = Parallel.ForEach(matrices, (i) =>
                {
                    Console.WriteLine("Parallel execution result ： {0}", i);
                });
                Console.WriteLine("result.IsCompleted : {0}", result.IsCompleted);
            }


            void ParallelAmount(IEnumerable<int> num)
            {
                //并行计算能被2整出的所有数字
                num.AsParallel().ForAll((val) =>
                {
                    if (val % 2 == 0)
                        Console.WriteLine(val);
                });
            }
            /// <summary>
            /// 并行操作的错误处理
            /// </summary>
            void ParallelErrorHandler()
            {
                try
                {
                    Parallel.Invoke(
                        () => { throw new Exception(); },
                        () => { throw new Exception(); }
                        );
                }
                catch (AggregateException ex)
                {
                    //void AggregateException.Handle(Func<in Exception,out bool> predicate);
                    ex.Handle(exception =>
                    {
                        Console.WriteLine(exception);
                        return true;
                    });
                }
            }
        }

        /// <summary>
        /// Reactive programing
        /// used Microsoft Reactive Extensions
        /// </summary>
        public class C05
        {
            /// <summary>
            /// 第5小节入口
            /// </summary>
            public void C05Main()
            {
                this.ReactiveProgramDatetime();
            }
            /// <summary>
            /// 响应式编程
            /// 当时间戳被2整除时，打印时间
            /// </summary>
            void ReactiveProgramDatetime()
            {
                IObservable<DateTimeOffset> timestamps = Observable.Interval(TimeSpan.FromSeconds(1)).Timestamp().Where(x => x.Value % 2 == 0).Select(x => x.Timestamp);

                timestamps.Subscribe(x => Console.WriteLine(x));
            }

            void ReactiveProgramReadKey()
            {
                List<int> i = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            }

            int ReactiveProgramSum(int i)
            {
                return i;
            }
        }

        /// <summary>
        /// DataFlows
        /// TPL数据流
        /// </summary>
        public class C06
        {
            public void C06Main()
            {

            }

            void TPLDataFlowException()
            {
                try
                {
                    var multiplyBlock = new TransformBlock<int, int>(item =>
                    {
                        if (item == 1)
                            throw new InvalidOperationException("Blech.");
                        return item * 2;
                    });
                }
                catch (AggregateException ex)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 线程同步相关知识点
        /// </summary>
        public class ExternalC01
        {
            public int MyLocak { get; set; }
            //object obj = new object();//改引用类型对象，用来定义锁的范围
            /// <summary>
            /// 扩展小节，调试入口
            /// </summary>
            public void C01Main()
            {
                //this.ResetEvent();
                //this.MResetEvent();
                this.ThreadPoolFunc();
            }

            /// <summary>
            /// 线程同步
            /// </summary>
            void ThreadSync(int i)
            {
                //此函数中,锁定该对象
                lock (this)//给锁的必须为引用类型对象
                {
                    Console.WriteLine("lock {0}", i);
                }

                //上面的lock等效于下面的代码块
                Monitor.Enter(this);
                try
                {
                    Console.WriteLine("monitor {0}", i);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("exit the lock on the object !!!!!!!!!!!!!!!!!!!");
                    // Monitor.Exit(this);
                }
            }

            public async void NotLock(int i)
            {
                try
                {
                    int res = 0;
                    await Task.Delay(TimeSpan.FromSeconds(3));
                    res = i;
                    MyLocak = res;
                    Console.WriteLine("not lock {0}", i);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("will exit.");
                }
            }

            #region AutoResetEvent

            AutoResetEvent autoEvent;//ManulaResetEvent
            void ResetEvent()
            {
                autoEvent = new AutoResetEvent(false);

                Console.WriteLine("1");
                Thread t = new Thread(DoWork);
                t.Start();

                Thread t1 = new Thread(DoWork);
                t1.Start();

                Console.WriteLine("4");
                Thread.Sleep(TimeSpan.FromSeconds(1));

                Console.WriteLine("5");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                autoEvent.Reset();
                //autoEvent.Set();//t线程恢复

                /**
                 * Output
                 * 1
                 * 4
                 * 2
                 * 5
                 * 3
                 * **/
            }

            void DoWork()
            {
                Console.WriteLine("2");
                autoEvent.WaitOne();
                Console.WriteLine("reset 3");
            }
            #endregion

            #region ManualResetEvent

            ManualResetEvent manualEvent;
            void MResetEvent()
            {
                manualEvent = new ManualResetEvent(false);

                Console.WriteLine("1");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Thread t = new Thread(MDoWork);
                t.Start();

                //Thread.Sleep(TimeSpan.FromSeconds(1));
                //Console.WriteLine("3");
                Thread t1 = new Thread(MDoWork);
                t1.Start();

                Thread.Sleep(TimeSpan.FromSeconds(2));
                manualEvent.Set();
            }

            void MDoWork()
            {
                Console.WriteLine("2");
                manualEvent.WaitOne();
                Console.WriteLine("reset 4");
            }
            #endregion





            void ThreadPoolFunc()
            {
                MyStruct m = new MyStruct();
                m.Key = 1;
                m.value = "-1";

                WaitCallback wc = SomeLongTask;
                wc(m);

                WaitCallback owc = SomeLongOtherTask;
                owc(m);

                ThreadPool.QueueUserWorkItem(wc);
                ThreadPool.QueueUserWorkItem(owc);

                ThreadPool.QueueUserWorkItem(wc, m);
                ThreadPool.QueueUserWorkItem(owc, m);

                object obj = wc.Target;
                Console.WriteLine(obj);
            }

            void SomeLongTask(object state)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Action res = null;
                MyStruct ms;
                if (state != null)
                    lock (state)
                    {
                        res = delegate ()
                        {
                            ms = (MyStruct)state;//拆箱
                            Console.WriteLine("1->> {0} - {1}", ms.Key, ms.value);
                        };
                    }
                else
                    res = delegate ()
                    {
                        //装箱
                        state = (object)new MyStruct() { Key = 911, value = "Dangerous" };
                        ms = (MyStruct)state;//拆箱
                        Console.WriteLine("1->> {0} - {1}", ms.Key, ms.value);
                    };
                res();
            }
            void SomeLongOtherTask(object state)
            {
                MyStruct ms = new MyStruct();

                if (state != null)
                    lock (state)
                    {
                        ms = (MyStruct)state;//拆箱
                        Console.WriteLine("2->> {0} - {1}", ms.Key, ms.value);
                    }
                else
                {
                    Action a = new Action(delegate ()
                    {
                        state = new MyStruct() { Key = 911, value = "Dangerous" };
                        ms = (MyStruct)state;
                        Console.WriteLine("2->> {0} - {1}", ms.Key, ms.value);
                    });
                    a();
                }
            }
        }

        public struct MyStruct
        {
            public int Key { get; set; }
            public string value { get; set; }
        }

    }



    namespace xiaowen.sony.interview
    {
        public class A
        {
            public static int Y { get; set; }
            static A()
            {
                Y = B.X + 1;
            }
        }

        public class B
        {
            public static int X { get; set; }

            static B()
            {
                X = A.Y + 1;
                Console.WriteLine(X);//Output: 2
            }

            public void F()
            {
                Console.WriteLine(X);//Output: 2
            }
        }
    }
}
