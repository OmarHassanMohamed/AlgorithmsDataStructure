using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Helpers
{
    public abstract class SortingMetrics<T> : ISorting<T> where T : IComparable
    {
        public long Swaps { get; private set; }
        public long Comparisons { get; private set; }
        public abstract T[] MetricSort(T[] data);

        private void Reset()
        {
            Swaps = 0;
            Comparisons = 0;
        }
        public T[] Sort(T[] data)
        {
            Reset();
            return MetricSort(data);
        }

        protected int Compare (T leftValue,T rightValue)
        {
            Comparisons++;
            return leftValue.CompareTo(rightValue);
        }

        private int Compare (T[] data, int leftIndex , int rightIndex)
        {
            return Compare(data[leftIndex], data[rightIndex]);
        }

        public bool GreaterThan (T[] data , int leftIndex, int rightIndex)
        {
            return Compare(data, leftIndex, rightIndex) > 0;
        }

        public bool LessThan(T[] data, int leftIndex, int rightIndex)
        {
            return Compare(data, leftIndex, rightIndex) < 0;
        }
        protected void Swap(T[] data, int leftIndex, int rightIndex)
        {
            T temp = data[leftIndex];
            data[leftIndex] = data[rightIndex];
            data[rightIndex] = temp;

            Swaps++;
        }
        protected void Assign(T[] data, int index, T value)
        {
            data[index] = value;
            Swaps++;
        }
        protected bool EqualTo(T[] data, int left, int right)
        {
            return Compare(data, left, right) == 0;
        }
    }
}
