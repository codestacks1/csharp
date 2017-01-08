using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Xiaowen.DotNet.Guide
{
    public class MyGeneric
    {
        public class Animal:IMethaneProducers<Animal> { }

        public class Cow : Animal, IMethaneProducer<Cow> { }

        public class Farm<T> : IEnumerable<T> where T : Animal
        {
            private List<T> animals = new List<T>();

            public List<T> Animals
            {
                get
                {
                    return animals;
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                return animals.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return animals.GetEnumerator();
            }


            public Farm<U> GetSpecies<U>() where U : T
            {
                Farm<U> speciesFarm = new Farm<U>();
                foreach (T animal in animals)
                {
                    if (animal is U)
                    {
                        speciesFarm.Animals.Add(animal as U);
                    }
                }
                return speciesFarm;

            }

            public Farm<Cow> GetCows()
            {
                Farm<Cow> cowFarm = new Farm<Cow>();
                foreach (T animal in animals)
                {
                    if (animal is Cow)
                    {
                        cowFarm.Animals.Add(animal as Cow);
                    }
                }
                return cowFarm;
            }
        }


        public delegate int MyDelegate(int op1, int op2);
        public delegate T1 MyDelegate<T1, T2>(T2 op1, T2 op2) where T1 : T2;



        public void Variance()
        {


            Cow myCow = new Cow();
            Animal myAnimal = myCow;


            IMethaneProducer<Cow> cowMethaneProducer = myCow;
            IMethaneProducer<Animal> animalMethaneProducer = cowMethaneProducer;

            
            Animal a = new Animal();


            IMethaneProducers<Animal> _animal = a;
            //IMethaneProducers<Cow> c = a;
            

            Func<int, string> func = FuncB;

        }

        public interface IMethaneProducers<out T> { }
        public interface IMethaneProducer<out T> { }

        public string FuncB(int i)
        {
            return string.Empty;
        }

        public class Cl
        {

            public void Func()
            {
                Farm<Animal> farm = new Farm<Animal>();
                farm.Animals.Add(new Cow());
                farm.Animals.Add(new Cow());

                Farm<Cow> dairyFarm = new Farm<Cow>();
                dairyFarm.GetCows();


            }
        }










        public void FunC()
        {
            SSS s = new SSS();
            s = s[1];
        }


        public class SSS
        {

            SSS[] ss = new SSS[100];

            public SSS this[int index] { get { return ss[index]; } }



            public class Animal
            {
                public Animal() { }
            }
            public class Data<T> where T : new()
            {
                public List<T> Datas { get; set; }

                public bool isExist { get; set; }
            }


            public class MyGenericClass<T1, T2> where T1 : new() where T2 : IMyGeneric
            {
                public void Func()
                {
                    Data<Animal> d = new Data<Animal>();
                }
            }

            public class MyGenericClass2
            {
                public MyGenericClass2()
                {
                    MyGenericClass2 m = new MyGenericClass2();
                }
                public MyGenericClass2(string s)
                {

                }
            }

            public void Func()
            {
                MyGenericClass2 mc = new MyGenericClass2();

                MyGenericClass<MyGenericClass2, IMyGeneric> obj = new MyGenericClass<MyGenericClass2, IMyGeneric>();


            }

            public int Add(object value)
            {
                throw new NotImplementedException();
            }

            public bool Contains(object value)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public int IndexOf(object value)
            {
                throw new NotImplementedException();
            }

            public void Insert(int index, object value)
            {
                throw new NotImplementedException();
            }

            public void Remove(object value)
            {
                throw new NotImplementedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }


        public interface IMyGeneric
        {

        }
    }
}