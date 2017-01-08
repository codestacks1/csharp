using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide.Variance
{
    /// <summary>
    /// 变体
    /// covariance 协变:可以使用比派生类型更小的类型
    /// contravariance 逆变/抗变:可以使用比派生类型更大的类型
    /// </summary>
    public class Variance
    {
        public void func()
        {
            //逆变 使用比起派生程度更大的类型
            Cow inCow = new Cow();
            Animal inAnimal = inCow;
            IInVariance<Cow> inVarianceCow = inCow;
            IInVariance<Cow> inVariance = inAnimal;
            /*
            IInVariance<Animal> inVarianceAnimal = inCow;//error
            IInVariance<Animal> inVarianceCow_in = inAnimal;//error  inAnimal被转换为Cow,这个派生程度更小的类型
            */

            //协变 使用比其派生程度更小的类型
            Cow outCow = new Cow();
            Animal outAnimal = outCow;
            AnimalBase outBase = outAnimal;

            //IOutVariance<Cow> _out = outCow;//error  必须使用比Cow派生程度更大的类型
            IOutVariance<AnimalBase> _outBase = outCow;
            //IOutVariance<Cow> _outCow = outAnimal;//error
            IOutVariance<Animal> _outAnimal = outCow;


            //下面是一个正确的整体,与上面无关
            AnimalBase aBase = new AnimalBase();
            Animal animal = aBase as Animal;

            //IOutVariance<AnimalBase> _outBaseAnimal = animal;

            B b = new B();
            IOutVariance<A> _a = b;

            A a = new A();
            a = b;
            IInVariance<B> _b = a;
            IInVariance<B> _bi = b;


            B bb = new B();
            A aa = new A();
            bb = aa as B;
            aa = bb;
        }
    }

    public class A : IInVariance<A>
    {
        public int NumA { get; set; }
    }//Contravariance

    public class B : A, IOutVariance<B>
    {
        public int NumB { get; set; }
        public B MyProperty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public B GetFirst()
        {
            throw new NotImplementedException();
        }
    }//Covariance


    public class AnimalBase { }

    public class Animal : AnimalBase, IInVariance<Cow>
    {

    }

    public class Cow : Animal, IOutVariance<Animal>
    {
        public Animal MyProperty
        {
            get
            {
                return new Animal();
            }
        }

        public Animal GetFirst()
        {
            throw new NotImplementedException();
        }
    }

    public interface IInVariance<in T>
    {

    }

    public interface IOutVariance<out T>
    {
        T MyProperty { get; }//协变接口中只允许get访问器

        T GetFirst();
    }

    public interface IMyInterface<T>
    {
        T Data { get; set; }
    }


    public class TestMain
    {
        public void MainTest()
        {
            List<Cow> cows = new List<Cow>();
            cows.Add(new Cow());
            cows.Add(new Cow());

            this.ListAnimals(cows);

        }

        public void ListAnimals(IEnumerable<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                Console.Write(animal.ToString());
            }
        }
    }


}
