using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Helpers
{
    public interface ISorting<T>
    {
        T[] Sort(T[] data);
    }
}
