using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullUtilVK
{
    public sealed class CastableArray : IEnumerable<Castable>
    {
        private readonly JArray _array;

        public CastableArray(JArray array)
        {
            _array = array;
        }

        public Castable this[object key]
        {
            get
            {
                var token = _array[key];
                return new Castable(token);
            }
        }

        public int Count
        {
            get { return _array.Count; }
        }

        public IEnumerator<Castable> GetEnumerator()
        {
            return _array.Select(i => new Castable(i)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
