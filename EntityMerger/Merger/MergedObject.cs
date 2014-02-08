using System.Collections.Generic;

namespace EntityMerger.Merger
{
    public class MergedObject<TInput1,TInput2>
    {
        private readonly TInput1 _mainObject;
        private readonly IEnumerable<TInput2> _connectedObjects;
        public TInput1 MainObject { get { return _mainObject; } }
        public IEnumerable<TInput2> ConnectedObjects { get { return _connectedObjects; } }

        public MergedObject(TInput1 mainObject, IEnumerable<TInput2> connectedObjects)
        {
            _mainObject = mainObject;
            _connectedObjects = connectedObjects;
        }
    }
}
