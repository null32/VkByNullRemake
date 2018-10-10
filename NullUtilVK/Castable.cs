using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullUtilVK
{
    public class Castable
    {
        private readonly JToken _token;
		//public string RawJson { get; set; }

        public Castable(JToken token)
		{
			_token = token;
		}

		public bool ContainsKey(string key)
		{
			if (!(_token is JObject)) { return false;}

			var token = _token[key];
			return token != null;
		}

        public Castable this[object key]
		{
			get
			{
				if (_token is JArray && key is string) { return null;}

				var token = _token[key];
                return token != null ? new Castable(_token[key]) : null;
			}
		}

        public override string ToString()
        {
            return _token.ToString();
        }

        public static implicit operator CastableArray(Castable e)
        {
            if (e == null)
                return null;
            if (e._token is JArray)
            {
                var arr = (JArray)e._token;
                return arr == null ? null : new CastableArray(arr);
            }
            else
            {
                var arr = new JArray();
                foreach (var token in e._token)
                {
                    if (token is JProperty)
                        arr.Add((token as JProperty).Value);
                    else
                        arr.Add(token);
                }
                return arr.Count == 0 ? null : new CastableArray(arr);
            }
        }

        public static implicit operator Dictionary<string, Castable>(Castable c)
        {
            var dict = new Dictionary<string, Castable>();
            foreach (var item in c._token)
            {
                dict.Add((item as JProperty).Name, new Castable((item as JProperty).Value));
            }

            return dict;
        }

        #region System types

        public static implicit operator bool(Castable c)
        {
            if (c == null)
                return false;
            return c == 1;
        }
        public static implicit operator bool?(Castable c)
        {
            return c == null ? (bool?)null : c == 1;
        }

        public static implicit operator int(Castable c)
        {
            return (int)c._token;
        }
        public static implicit operator int?(Castable c)
        {
            return c == null ? null : (int?)c._token;
        }

        public static implicit operator string(Castable c)
        {
            return c == null ? null : c.ToString();
        }

        public static implicit operator Uri(Castable c)
        {
            return !String.IsNullOrEmpty(c) ? new Uri(c) : null;
        }

        public static bool operator ==(Castable c1, Castable c2)
        {
            if (ReferenceEquals(c1, c2)) { return true; }
            if (ReferenceEquals(null, c2)) { return false; }
            if (ReferenceEquals(null, c2)) { return false; }

            return c1._token.ToString() == c2._token.ToString();
        }
        public static bool operator !=(Castable c1, Castable c2)
        {
            return !(c1 == c2);
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Castable)
                return (obj as Castable)._token == this._token;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return this._token.GetHashCode();
        }
        #endregion
    }
}
