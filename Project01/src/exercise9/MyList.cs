using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class MyList<T> : IEnumerable<T>
{
    private T[] array_;
    public int Count { get; private set;}
    public int Capacity { get; private set; }

    public MyList()
    {
        Count = 0;
        Capacity= 0;
        array_ = new T[0];
    }

    public void Add(T item)
    {
        if(Capacity == 0) Resize(1);
        else if(Capacity == Count) Resize(Capacity * 2);

        array_[Count] = item;
        Count++;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            return array_[index];
        }
    }

    public void Remove(T item)
    {
        int index = 0;
        for(; index < Count; index++)
        {
        //     Console.WriteLine($"array_[{index}] = {array_[index]} item = { item}");
            if(array_[index].Equals(item))
            {
                T[] newArray = new T[Capacity];
                Array.Copy(array_, newArray, index + 1);
                for(; index < Count -  1; index++)
                {
                    newArray[index] = array_[index + 1];
                }
                // Console.WriteLine("AAAAA");
                array_ = newArray;
                Count--;
                break;
            } 
        }
    }

    private void Resize(int newCapacity)
    {
        T[] newArray = new T[newCapacity];
        Array.Copy(array_, newArray, Count);
        array_ = newArray;
        Capacity = newCapacity;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return array_[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}