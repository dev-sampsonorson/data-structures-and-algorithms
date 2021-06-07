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
                var ht = new HashTable(50);

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

        private class HashTable {

            List<object[]>[] _map;

            public HashTable(int size) {
                this._map = new List<object[]>[size];
            }

            public void Set(string key, object value) {
                int address = HashFunction(key);

                if (_map[address] == null)
                    _map[address] = new List<object[]>();

                _map[address].Add(new[] { key, value });

            }

            public object Get(string key) {
                int address = HashFunction(key);

                if (_map[address] == null)
                    return null;

                return _map[address].Find(item => (string)item[0] == key).ElementAt(1);
            }

            public List<string> Keys(List<string> keys = null, List<object[]> list = null) {
                keys = keys ?? new List<string>();

                if (_map.Length == 0)
                    return new List<string>();

                if (list == null) {
                    Console.WriteLine("null");
                    foreach (var item in _map) {
                        if (item != null) {
                            keys = Keys(keys, item);
                        }
                    }
                } else {
                    foreach (var item in list) {
                        keys.Add((string)item[0]);
                    }
                }                

                return keys;
            }

            private int HashFunction(string key) {
                int hash = 0;
                for(int i = 0; i < key.Length; i++) {
                    hash = (hash + (int)key[i] * i) % _map.Length;
                }

                return hash;
            }


        }
    }
}
