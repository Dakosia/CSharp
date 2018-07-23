using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener
{
    public class UrlManagement
    {
        private Dictionary<string, Url> _storage;
        private IUrlShortener _shortener;

        public string Short(string url)
        {
            var key = _shortener.Short(url);
            _storage.Add(key, new Url() { Body = url });
            return key;
        }

        public string Source(string key)
        {
            if (_storage.ContainsKey(key))
            {
                return _storage[key].Body;
            }
            return "No data found";
        }
        public UrlManagement(IUrlShortener shortener)
        {
            _shortener = shortener;
            _storage = new Dictionary<string, Url>();
        }
    }
}
