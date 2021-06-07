using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataStructureAndAlgorithm.Core;

namespace DataStructureAndAlgorithm.Solutions {
    public partial class Solution17 : ISolution {

        public void Run() {

            this.ExecuteSolves<InputVoid, ReturnVoid>(null);
        }

        private class First : ISolve<InputVoid, ReturnVoid> {
            public string Description => "First solution";

            public ReturnVoid Implementation(InputVoid input) {
                var ht = new HashTable<string, int>(50);

                ht.Set("grapes", 10000);
                ht.Set("apples", 54);
                ht.Set("oranges", 2);

                Console.WriteLine($"{ht.Get("grapes")}");
                Console.WriteLine($"{ht.Get("apples")}");
                Console.WriteLine($"{ht.Get("oranges")}");

                foreach(var key in ht.Keys()) {
                    Console.WriteLine($"{key}");
                }


                return null;
            }
        }

        private class HashTable<TKey, TValue> {

            List<(TKey Key, TValue Value)>[] _map;

            public HashTable(int size) {
                this._map = new List<(TKey, TValue)>[size];
            }

            public void Set(TKey key, TValue value) {
                int address = HashFunction(key);

                if (_map[address] == null)
                    _map[address] = new List<(TKey, TValue)>();

                _map[address].Add((key, value));

            }

            public object Get(TKey key) {
                int address = HashFunction(key);

                if (_map[address] == null)
                    return null;

                return _map[address].Find(item => item.Key.Equals(key)).Value;
            }

            public List<TKey> Keys(List<TKey> keys = null, List<(TKey Key, TValue Value)> list = null) {
                keys = keys ?? new List<TKey>();

                if (_map.Length == 0)
                    return new List<TKey>();

                if (list == null) {
                    foreach (var item in _map) {
                        if (item != null) {
                            keys = Keys(keys, item);
                        }
                    }
                } else {
                    foreach (var item in list) {
                        keys.Add(item.Key);
                    }
                }                

                return keys;
            }

            private int HashFunction(TKey key) {
                return Math.Abs(key.GetHashCode() % _map.Length);
                //int hash = 0;
                //for(int i = 0; i < key.Length; i++) {
                //    hash = (hash + (int)key[i] * i) % _map.Length;
                //}

                //return hash;
            }


        }
    }
}
