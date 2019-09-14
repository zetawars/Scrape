using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scrape
{

    [Table("Twitter")]
    class TwitterList
    {
        [DontInsert]
        [DontUpdate]
        public int ElID { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public string Website { get; set; }
        public string Twitter { get; set; }
        public int Processed { get; set; }
        public string Exception { get; set; }
        public string Description { get; set; }
    }
    class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            return request;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<TwitterList> twitterList = DBHelper.GetList<TwitterList>();
            int k = twitterList.Where(x => x.Processed == 0).ToList().Count;
            twitterList = twitterList.Where(x => x.Processed == 0).ToList();
            int m = 0;
            Parallel.ForEach(twitterList, new ParallelOptions { MaxDegreeOfParallelism = 16 }, element =>
            {
                try
                {

                    Console.WriteLine($"Iteration {m}");
                    HtmlDocument htmldoc = GetHtmlDocument(element.Website);
                    var document = htmldoc.DocumentNode;
                    var Link = document.QuerySelectorAll("a").Where(x => x.Attributes.Where(y => y.Name == "href" && y.Value.Contains("twitter")).ToList().Count > 0).FirstOrDefault();
                    var contactPage = document.QuerySelectorAll("a").Where(x => x.Attributes.Where(y => y.Name == "href" && y.Value.Contains("contact")).ToList().Count > 0).FirstOrDefault();

                    if (Link != null)
                    {
                        element.Twitter = Link.Attributes.Where(x => x.Name == "href").FirstOrDefault().Value;
                    }
                    else if (contactPage != null)
                    {
                        string Url = string.Empty;
                        try
                        {
                            string contactpageurl = contactPage.Attributes.Where(x => x.Name == "href").FirstOrDefault().Value;
                            Url = new Uri(new Uri(element.Website), contactpageurl).ToString();
                            HtmlDocument chtmldoc = GetHtmlDocument(Url);
                            var cdocument = htmldoc.DocumentNode;
                            var cLink = document.QuerySelectorAll("a").Where(x => x.Attributes.Where(y => y.Name == "href" && y.Value.Contains("twitter")).ToList().Count > 0).FirstOrDefault();
                            if (cLink != null)
                            {
                                element.Twitter = cLink.Attributes.Where(x => x.Name == "href").FirstOrDefault().Value;
                            }
                        }
                        catch (Exception ex)
                        {
                            element.Exception = ex.ToString();
                            element.Description = $"Exception in Contact Page : URL = {Url}";
                        }
                        
                    }

                    element.Exception = null;
                    element.Processed += 1;
                    DBHelper.Update(element, $"Where ElID = {element.ElID}", null);

                    Console.WriteLine($"Completed Iteration: {m}");
                    m++;

                   
                }
                catch (Exception ex)
                {
                    element.Exception = ex.ToString();
                    element.Processed += 1;
                    element.Description = $"Exception in Home Page : URL = {element.Website}";
                    DBHelper.Update(element, $"Where ElID = {element.ElID}", null);

                }

            });
            Console.WriteLine("Processing Complete. Press any key to continue");
            Console.ReadLine();
        }

        private static HtmlDocument GetHtmlDocument(string Url)
        {
            var htmldoc = new HtmlDocument();
            if (!Url.StartsWith("http"))
            {
                if (Url.StartsWith("www"))
                {
                    Url = "http://" + Url;
                }
                else
                {
                    Url = "http://www." + Url;
                }
            }


            if (Url.StartsWith("https"))
            {
                var web = new HtmlWeb()
                {
                    PreRequest = request =>
                    {
                        // Make any changes to the request object that will be used.
                        request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                        return true;
                    }
                };
                return web.Load(Url);
            }
            else 
            {
                var web = new HtmlWeb();
                return web.Load(Url);
            }
        }
    }
}
