using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Interactive<T> : IEnumerable
    {
        
        public string mess = "Interactive";
        private List<T> items = new List<T>();

        public int Count => items.Count;

        public Interactive(){ }

            public Interactive(T item)
            {
                items.Add(item);

            }

        public Interactive(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }

        public void Add(T item) {
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

        public Interactive<T> Union(Interactive<T> set)//объединение
        {
           // return new Interactive<T>(items.Union(set.items));

            Interactive<T> result = new Interactive<T>();


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

        public Interactive<T> Intersection(Interactive<T> set)//пересечение
        {

            //return new Interactive<T>(items.Intersect(set.items));
            var result = new Interactive<T>();
            Interactive<T> big;
            Interactive<T> small;
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

        public Interactive<T> Difference(Interactive<T> set)//разность
        {
          // return new Interactive<T>(items.Except(set.items));
            var result = new Interactive<T>(items);

            foreach(var item in set.items)
            {
                result.Remove(item);
            }

            return result;
        }

        public bool Subset(Interactive<T> set)//подмножество
        {
            // return items.All(i => set.items.Contains(i));

            foreach (var item1 in items)
            {
                var equals = false;
                foreach (var item2 in set.items) {
                    if (item1.Equals(item2)){
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

        public Interactive<T> SummetricDifference(Interactive<T> set)//семмитричная разность
        {
           // return new Interactive<T>(items.Except(set.items).Union(set.items.Except(items)));

            var result = new Interactive<T>();

            foreach (var item1 in items)
            {
                var equals = false;

                foreach (var item2 in set.items)
                {

                    if (item1.Equals(item2)) {
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
