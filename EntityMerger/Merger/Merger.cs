using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityMerger.Merger
{
    public class Merger<TInput1, TInput2>
        where TInput1 : class
        where TInput2 : class
    {
        private readonly IEnumerable<TInput1> _first;
        private readonly IEnumerable<TInput2> _second;
        private readonly Func<TInput1, IEnumerable<TInput2>, IEnumerable<TInput2>> _mergeFunc;
        private List<TInput2> _unMergedObjects;
        public List<TInput2> UnMergedObjects
        {
            get
            {
                if (_unMergedObjects == null)
                    Merge();
                return _unMergedObjects;
            }
        }

        public Merger(IEnumerable<TInput1> first, IEnumerable<TInput2> second, Func<TInput1, IEnumerable<TInput2>, IEnumerable<TInput2>> mergeFunc)
        {
            _first = first;
            _second = second;
            _mergeFunc = mergeFunc;
        }

        public List<MergedObject<TInput1, TInput2>> Merge()
        {
            var result = new List<MergedObject<TInput1, TInput2>>();
            foreach (var input1 in _first)
            {
                var temp = _mergeFunc(input1, _second);
                result.Add(new MergedObject<TInput1, TInput2>(input1, temp));
            }
            _unMergedObjects = _second.Except(result.Select(s => s.ConnectedObjects).SelectMany(s => s)).ToList();
            return result;
        }
    }
}
