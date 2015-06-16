using System;
using System.Collections;

namespace _03.GenericList
{
    class GenericList<T> : IEnumerable
        where T: IComparable<T>
    {
        private const int DefaultCapacity = 16;

        private T[] elements;
        private int count ;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
            this.count = 0;
        }



        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
