using HtmlAgilityPack;
using PuppeteerSharp;
using PuppeteerSharp.Input;
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
    public static class HtmlHelper
    {
        public static async Task<string> GetHtml(string element)
        {
            HttpClient _HttpClient = new HttpClient();
            using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri(element)))
            {
                request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                request.Headers.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");

                using (var response = await _HttpClient.SendAsync(request).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
                    using (var streamReader = new StreamReader(decompressedStream))
                    {
                        return await streamReader.ReadToEndAsync().ConfigureAwait(false);
                    }
                }
            }
        }



        public static async Task<string> GetHtmlProxy(string element)
        {
            var proxy = new WebProxy
            {
                Address = new Uri($"http://163.172.95.183:3128"),
                //BypassProxyOnLocal = false,
                UseDefaultCredentials = true,
            };

            var httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy,
            };
            var _HttpClient = new HttpClient(handler: httpClientHandler, disposeHandler: true);
            //   HttpClient _HttpClient = new HttpClient();
            using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri(element)))
            {
                request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                request.Headers.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");

                using (var response = await _HttpClient.SendAsync(request).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
                    using (var streamReader = new StreamReader(decompressedStream))
                    {
                        return await streamReader.ReadToEndAsync().ConfigureAwait(false);
                    }
                }
            }
        }






        public static HtmlDocument GetHtmlDocument(string Url)
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


        public static HtmlDocument GetHtmlDocumentProcessed(string Url)
        {
            new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            using (var browser = Puppeteer.LaunchAsync(new LaunchOptions
            {
                //Args = new string[1] { "--proxy-server=163.172.95.183:3128" },
                //Args = new string[1] { "--load-extension=Ext\\zenmate" },
                Headless = true,
            }).GetAwaiter().GetResult())
            {
                var page = browser.NewPageAsync().GetAwaiter().GetResult();
                try
                {
                    page.SetRequestInterceptionAsync(true);
                    page.Request += (sender, e) =>
                    {
                        if (e.Request.ResourceType == ResourceType.Image)
                            e.Request.AbortAsync();
                        else
                            e.Request.ContinueAsync();
                    };
                    page.GoToAsync(Url).GetAwaiter().GetResult();
                   
                    try
                    {
                        page.ClickAsync(".css-fslzaf ").GetAwaiter().GetResult();

                    }
                    catch (Exception ex)
                    {
                    }

                    string html = page.GetContentAsync().GetAwaiter().GetResult();
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);
                    browser.CloseAsync().GetAwaiter().GetResult();
                    browser.Dispose();
                    return htmlDoc;
                }
                catch (Exception ex)
                {
                    string html = page.GetContentAsync().GetAwaiter().GetResult();
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);
                    browser.CloseAsync().GetAwaiter().GetResult();
                    browser.Dispose();
                    return htmlDoc;
                }
            }
        }

        public static HtmlDocument GetHtmlDocumentProcessed(Browser browser, string Url)
        {
            
                var page = browser.NewPageAsync().GetAwaiter().GetResult();
                try
                {
                    page.SetRequestInterceptionAsync(true);
                    page.Request += (sender, e) =>
                    {
                        if (e.Request.ResourceType == ResourceType.Image)
                            e.Request.AbortAsync();
                        else
                            e.Request.ContinueAsync();
                    };
                    page.GoToAsync(Url).GetAwaiter().GetResult();

                    string html = page.GetContentAsync().GetAwaiter().GetResult();
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);
                    //browser.CloseAsync().GetAwaiter().GetResult();
                    //browser.Dispose();
                    return htmlDoc;
                }
                catch (Exception ex)
                {
                    string html = page.GetContentAsync().GetAwaiter().GetResult();
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);
                    //browser.CloseAsync().GetAwaiter().GetResult();
                    //browser.Dispose();
                    return htmlDoc;
                }
            
        }


        public static void DownloadFile(string Url)
        {
         
        }





        public static HtmlDocument GetLazyLoadedPage(string Url, int ClickPageDownCount=0, string PopupCloseID=null)
        {
            new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            using (var browser = Puppeteer.LaunchAsync(new LaunchOptions
            {
                Args = new string[1] { "--proxy-server=1.0.212.5:8080" },
                //Args = new string[1] { "--load-extension=Ext\\zenmate" },
                Headless = false,
            }).GetAwaiter().GetResult())
            {
                var page = browser.NewPageAsync().GetAwaiter().GetResult();
                try
                {
                    page.SetRequestInterceptionAsync(true);
                    page.Request += (sender, e) =>
                    {
                        if (e.Request.Url.Contains("google"))
                        {
                            e.Request.AbortAsync();
                        }
                        if (e.Request.ResourceType == ResourceType.Image)
                            e.Request.AbortAsync();
                        else
                            e.Request.ContinueAsync();
                    };
                    page.GoToAsync(Url, new NavigationOptions { Timeout = 40000}).GetAwaiter().GetResult();

                    if (ClickPageDownCount > 0)
                    {
                        for (int i = 0; i < ClickPageDownCount; i++)
                        {
                            page.Keyboard.PressAsync("PageDown");
                        }
                        
                    }

                    if (!string.IsNullOrWhiteSpace(PopupCloseID))
                    {
                        try
                        {
                            page.ClickAsync(PopupCloseID).GetAwaiter().GetResult();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    

                    string html = page.GetContentAsync().GetAwaiter().GetResult();
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);
                   // browser.CloseAsync().GetAwaiter().GetResult();
                    //browser.Dispose();
                    return htmlDoc;
                }
                catch (Exception ex)
                {
                    string html = page.GetContentAsync().GetAwaiter().GetResult();
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);
                    browser.CloseAsync().GetAwaiter().GetResult();
                    browser.Dispose();
                    return htmlDoc;
                }
            }

        }




    }
}
