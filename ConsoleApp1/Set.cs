using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Set<T> : IEnumerable
    {

        private List<T> items = new List<T>();

        public int Count => items.Count;

        public Set() { }

        public Set(T item)
        {
            items.Add(item);

        }

        public Set(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }

        public void Add(T item)
        {
            if (items.Contains(item))
            {
                return;
            }

            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public Set<T> Union(Set<T> set)//объединение
        {
            // return new Set<T>(items.Union(set.items));

            Set<T> result = new Set<T>();


            foreach (var item in items)
            {
                result.Add(item);
            }

            foreach (var item in set.items)
            {
                result.Add(item);
            }

            return result;
        }

        public Set<T> Intersection(Set<T> set)//пересечение
        {

            //return new Set<T>(items.Intersect(set.items));
            var result = new Set<T>();
            Set<T> big;
            Set<T> small;
            if (Count >= set.Count)
            {
                big = this;
                small = set;
            }
            else
            {
                big = set;
                small = this;
            }
            foreach (var item1 in small.items)
            {
                foreach (var item2 in big.items)
                {
                    if (item1.Equals(item2))
                    {
                        result.Add(item1);
                        break;
                    }
                }
            }
            return result;
        }

        public Set<T> Difference(Set<T> set)//разность
        {
            // return new Set<T>(items.Except(set.items));
            var result = new Set<T>(items);

            foreach (var item in set.items)
            {
                result.Remove(item);
            }

            return result;
        }

        public bool Subset(Set<T> set)//подмножество
        {
            // return items.All(i => set.items.Contains(i));

            foreach (var item1 in items)
            {
                var equals = false;
                foreach (var item2 in set.items)
                {
                    if (item1.Equals(item2))
                    {
                        equals = true;
                        break;
                    }
                }

                if (equals == false)
                {
                    return false;
                }
            }
            return true;
        }

        public Set<T> SummetricDifference(Set<T> set)//семмитричная разность
        {
            // return new Set<T>(items.Except(set.items).Union(set.items.Except(items)));

            var result = new Set<T>();

            foreach (var item1 in items)
            {
                var equals = false;

                foreach (var item2 in set.items)
                {

                    if (item1.Equals(item2))
                    {
                        equals = true;
                        break;
                    }

                }

                if (equals == false)
                {
                    result.Add(item1);
                }
            }

            foreach (var item1 in set.items)
            {
                var equals = false;
                foreach (var item2 in items)
                {

                    if (item1.Equals(item2))
                    {
                        equals = true;
                        break;
                    }

                }

                if (equals == false)
                {
                    result.Add(item1);
                }
            }

            return result;
        }


        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }



    }
}
