﻿
namespace StringSearching
{
    public class StringSearchMatch : ISearchMatch
    {
        public StringSearchMatch(int start, int length)
        {
            Start = start;
            Length = length;
        }
        public int Start
        {
            get;
            private set;
        }

        public int Length
        {
            get;
            private set;
        }
    }
}
