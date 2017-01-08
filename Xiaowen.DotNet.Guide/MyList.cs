using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    public class MyList<T>
    {
        private T[] _items;
        [ContractPublicPropertyName("Count")]
        private int _size;
        private int _version { get; set; }

        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private MyList<T> myList;
            private int index;
            private int version;
            private T current;

            internal Enumerator(MyList<T> myList)
            {
                this.myList = myList;
                version = myList._version;
                index = 0;
                current = default(T);
            }





            public T Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public void Dispose()
            {
                throw new NotImplementedException();

            }


            public bool MoveNext()
            {
                MyList<T> localList = myList;
                if (version == localList._version && ((uint)index < (uint)localList._size))
                {
                    current = localList._items[index];
                    index++;
                    return true;
                }
                return MoveNextRare();
            }

            public bool MoveNextRare()
            {
                if (version != myList._version)
                {

                }
                index = myList._size + 1;
                current = default(T);
                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
