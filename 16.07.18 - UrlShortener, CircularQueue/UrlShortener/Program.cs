using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener
{
    class Program
    {
        static void Main(string[] args)
        {
            IUrlShortener urlShortener = new UrlShortener();
            UrlManagement urlManagement = new UrlManagement(urlShortener);

            string urlToShort = "https://www.google.kz/search?q=ascii+range&source=lnms&tbm=isch&sa=X&ved=0ahUKEwjW0L3K26LcAhVIjywKHRR9DE0Q_AUICigB&biw=1536&bih=779#imgrc=TjgwqAuaYjYWPM:";

            string key = urlManagement.Short(urlToShort);
            Console.WriteLine(key);

            string getKey = Console.ReadLine();
            Console.WriteLine(urlManagement.Source(getKey));
            Console.ReadLine();
        }
    }
}
