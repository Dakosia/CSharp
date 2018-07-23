using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener
{
    public class Url
    {
        public string FromUserId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Body { get; set; }
    }
}
