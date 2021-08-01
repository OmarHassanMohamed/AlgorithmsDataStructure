using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearching.NaiveStringSearch
{
    public class NaiveStringSearch : IStringSearchAlgorithm
    {
        public IEnumerable<ISearchMatch> Search(string toFind, string toSearch)
        {
            if (string.IsNullOrWhiteSpace(toFind))
            {
                throw new ArgumentNullException(nameof(toFind));

            }

            if (string.IsNullOrWhiteSpace(toSearch))
            {
                throw new ArgumentNullException(nameof(toSearch));
            }

            if (toFind.Length >= toSearch.Length)
            {
                for (int startIndex = 0; startIndex <= toSearch.Length - toFind.Length; startIndex++)
                {
                    int matchCount = 0;

                    while (toFind[matchCount] == toSearch[startIndex + matchCount])
                    {
                        matchCount++;

                        if (toFind.Length == matchCount)
                        {
                            yield return new StringSearchMatch(startIndex, matchCount);

                            startIndex += matchCount - 1;
                            break;
                        }
                    }
                }
            }
        }
    }
}
