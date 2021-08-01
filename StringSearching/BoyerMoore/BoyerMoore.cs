using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearching.BoyerMoore
{
    public class BoyerMooreHorspool : IStringSearchAlgorithm
    {
        public IEnumerable<ISearchMatch> Search(string pattern, string toSearch)
        {
            if (string.IsNullOrWhiteSpace(pattern))
            {
                throw new ArgumentNullException(nameof(pattern));

            }

            if (string.IsNullOrWhiteSpace(toSearch))
            {
                throw new ArgumentNullException(nameof(toSearch));
            }

            if (pattern.Length > 0 && toSearch.Length > 0)
            {
                var badMatchTable = new BadMatchTable(pattern);

                int currentStartIndex = 0;

                while (currentStartIndex <= toSearch.Length - pattern.Length)
                {
                    int charactersLeftToMatch = pattern.Length - 1;

                    while (charactersLeftToMatch >= 0 && 
                           pattern[charactersLeftToMatch] == toSearch[currentStartIndex + charactersLeftToMatch])
                    {
                        charactersLeftToMatch--;
                    }

                    if (charactersLeftToMatch < 0)
                    {
                        yield return new StringSearchMatch(currentStartIndex, pattern.Length);
                        currentStartIndex += pattern.Length;
                    }
                    else
                    {
                        currentStartIndex += badMatchTable[toSearch[currentStartIndex + pattern.Length - 1]];
                    }
                }
            }
        }
    }
}
