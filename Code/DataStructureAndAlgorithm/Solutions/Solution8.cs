using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public class Solution8 : ISolution {
        public void Run() {

            this.ExecuteSolves<InputVoid, bool>(null);
        }

        private class First : ISolve<InputVoid, bool> {
            public string Description => "My array implementation";

            public bool Implementation(InputVoid input) {
                MyArray<int> myArray = new MyArray<int>();

                myArray.Add(2);
                myArray.Add(5);
                myArray.Add(6);
                myArray.Add(12);

                foreach (var n in myArray) {
                    Console.WriteLine(n);
                }
                Console.WriteLine();

                Console.WriteLine(myArray.Get(0));
                Console.WriteLine(myArray.Get(2));

                return true;
            }
        }

        private class MyArray<T> : IEnumerable, IEnumerable<T> {
            private int size;
            private T[] items;
            private int defaultSize = 10;

            public T this[int index] {
                get {
                    return Get(index);
                }
                set {
                    Set(index, value);
                }
            }

            public MyArray() {
                this.size = 0;
                this.items = new T[this.size];
            }

            public int Count {
                get {
                    return this.size;
                }
            }

            // O(1)
            public T Get(int index) {
                if (index < 0 || index >= this.size)
                    throw new IndexOutOfRangeException($"The index {index}, is out of range.");
                
                return this.items[index];
            }

            // O(1)
            public void Set(int index, T value) {
                if (index < 0 || index >= this.size)
                    throw new IndexOutOfRangeException($"The index {index}, is out of range.");

                this.items[index] = value;
            }

            // O(n) - Worst Case 
            public void Add(T value) {
                if (this.size < this.items.Length) {
                    Set(this.size, value);
                    this.size += 1;
                } else {
                    ResizeAndAdd(value);
                }
            }

            private void ResizeAndAdd(T value) {
                // Create a new array with an increased capacity
                int newCapacity = this.items.Length == 0? this.defaultSize : this.items.Length * 2;
                T[] newArray = new T[newCapacity];

                // Copy old items to new array
                Array.Copy(this.items, newArray, this.items.Length);
                this.items = newArray;

                this.items[this.size] = value;
                this.size += 1;
            }

            public IEnumerator GetEnumerator() {
                return new Enumerator(this);
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator() {
                return new Enumerator(this);
            }

            public struct Enumerator : IEnumerator<T>, IEnumerator {
                private int index;
                private T current;
                private MyArray<T> items;

                public T Current => this.current;

                object IEnumerator.Current => Current;

                public Enumerator(MyArray<T> items) {
                    this.index = 0;
                    this.current = default;
                    this.items = items;
                }

                public void Dispose() {
                    
                }

                public bool MoveNext() {
                    if (this.index < 0 || this.index >= this.items.Count)
                        return false;

                    this.current = this.items[this.index];
                    this.index += 1;

                    return true;
                }

                public void Reset() {
                    this.index = 0;
                    this.current = default;
                }
            }
        }
    }
}
