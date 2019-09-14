using HtmlAgilityPack;
using Newtonsoft.Json;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Scrape
{

    [Table("Categories")]
    public class Category
    {
        [DontInsert]
        [DontUpdate]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }


        public bool Processed { get; set; }
        public bool GenderProcessed { get; set; }
    }

    [Table("Products")]
    public class Product
    {
        [DontInsert]
        [DontUpdate]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int CategoryID { get; set; }

        public bool Processed { get; set; }
        public string ProductCategory { get; set; }
        public string BrandName { get; set; }
        public string Size { get; set; }
        public string Price { get; set; }
        public string UnitPrice { get; set; }
        public string Ingredients { get; set; }
        public string Exception { get; set; }
        public string SizeInML { get; set; }
    }





    public class ChannelAvailabilityPrdCard
    {
        public bool addToCart { get; set; }
        public bool findAtStore { get; set; }
        public string deliveryOption { get; set; }
        public bool? notSoldInStores { get; set; }
        public bool? outOfStockOnline { get; set; }
    }

    public class AvailableSkus
    {
    }

    public class RuleMessage
    {
        public string code { get; set; }
        public string type { get; set; }
        public string prefix { get; set; }
    }

    public class LoyaltyMessage
    {
        public string displayBRImgLink { get; set; }
        public string loyaltyCode { get; set; }
    }

    public class PriceInfo
    {
        [DontInsert]
        [DontUpdate]
        public RuleMessage ruleMessage { get; set; }
        public string regularPrice { get; set; }
        public string regularPriceHtml { get; set; }
        public string unitPrice { get; set; }
        public string unitPriceSize { get; set; }
        public bool onSale { get; set; }
        public string salePrice { get; set; }
        public string salePriceHtml { get; set; }
        [DontInsert]
        [DontUpdate]
        public LoyaltyMessage loyaltyMessage { get; set; }
    }

    public class Concern
    {
        [JsonIgnore]
        public int ProductID { get; set; }
        public string concern_message { get; set; }
    }


    public class ProductInfo
    {

        [DontInsert]
        [DontUpdate]
        public int Id { get; set; }
        public string form { get; set; }
        public string hairToolType { get; set; }
        public string skinType { get; set; }
        public string bogoCode { get; set; }
        public string pluCode { get; set; }
        public string familyCodeValue { get; set; }
        public int familyCodeQuantity { get; set; }
        public string familyCodeRule { get; set; }
        public string storeInv { get; set; }
        public string fulfillerType { get; set; }
        public string webExclusive { get; set; }
        public string wic { get; set; }

        [DontLoad]
        [DontInsert]
        [DontUpdate]
        public Dictionary<string, string> skuInvAvailMap { get; set; }
        public string prodId { get; set; }
        public string skuId { get; set; }
        public string imageUrl { get; set; }
        public string upc { get; set; }
        public string productURL { get; set; }
        public string reviewCount { get; set; }
        public string productSize { get; set; }
        public string newItem { get; set; }
        public string autoReorder { get; set; }
        public string unitPrice { get; set; }
        public string unitPriceSize { get; set; }
        public string loyaltyEligible { get; set; }
        public string reviewURL { get; set; }
        public string ingredientName { get; set; }
        public string inactiveIngredients { get; set; }
        public string pln { get; set; }
        public string productName { get; set; }
        public string imageUrl50 { get; set; }
        public string beautyCategoryName { get; set; }

        [DontLoad]
        [DontInsert]
        [DontUpdate]
        public ChannelAvailabilityPrdCard channelAvailabilityPrdCard { get; set; }
        public string retailUnitQty { get; set; }
        public string clearance { get; set; }
        public string quicklookURL { get; set; }
        public string productDisplayName { get; set; }
        public string productDisplayType { get; set; }
        public string reviewHoverMessage { get; set; }
        public bool autoReorderAvailable { get; set; }

        [DontLoad]
        [DontInsert]
        [DontUpdate]
        public AvailableSkus availableSkus { get; set; }

        [DontLoad]
        [DontInsert]
        [DontUpdate]
        public PriceInfo priceInfo { get; set; }

        public int CategoryID { get; set; }
        public int priceInfoID { get; set; }

        public string averageRating { get; set; }
        public string subBrandName { get; set; }
        public string pluCodeLinkText { get; set; }
        public string fsa_cd { get; set; }
        public string couponClipText { get; set; }
        public string badge { get; set; }
        public string hairType { get; set; }
        public string loyaltyMessage { get; set; }
        public string eventCodeLinkText { get; set; }
        public string eventCode { get; set; }

        public DateTime? inventoryAvilDate { get; set; }
        public string estShipDate { get; set; }
        public bool? prestigeBrand { get; set; }

        [DontLoad]
        [DontInsert]
        [DontUpdate]
        public List<Concern> concern { get; set; }

        public string couponCode { get; set; }
        public bool? couponAvailable { get; set; }
        public string couponId { get; set; }
        public string brandName { get; set; }
        public string tier2Category { get; set; }
        public string tier1Category { get; set; }
        public string tier3Category { get; set; }
        public string color { get; set; }
        public bool Processed { get; set; }
        public string SkinType_Filter { get; set; }
        public string ProductType_Filter { get; set; }
        public string ScentFamily_Filter { get; set; }
        public string ColorFamily_Filter { get; set; }
        public string Form_Filter { get; set; }
        public string Price_Filter { get; set; }
        public string Use_Filter { get; set; }
        public string Brand_Filter { get; set; }
        public string Age_Filter { get; set; }
        public string Gender_Filter { get; set; }
        public string SpecialFeature_Filter { get; set; }
        public string Count_Filter { get; set; }
        public string Fragrance_Filter { get; set; }
        public string HairType_Filter { get; set; }
        public string DealsAndPromotions_Filter { get; set; }
        public string HairColorFamily_Filter { get; set; }
        public string MoreOptions_Filter { get; set; }
        public string Concern_Filter { get; set; }
        public string DaysSupply_Filter { get; set; }
        public string FoundationColor_Filter { get; set; }
        public string SPF_Filter { get; set; }



    }

    public class RootObject
    {
        public ProductInfo productInfo { get; set; }
    }


    public class FilmStripUrl
    {
        public string stripUrl1 { get; set; }
        public string zoomImageUrl1 { get; set; }
        public string largeImageUrl1 { get; set; }
        public string stripUrl2 { get; set; }
        public string zoomImageUrl2 { get; set; }
        public string largeImageUrl2 { get; set; }
        public string stripUrl3 { get; set; }
        public string zoomImageUrl3 { get; set; }
        public string largeImageUrl3 { get; set; }
        public string stripUrl4 { get; set; }
        public string zoomImageUrl4 { get; set; }
        public string largeImageUrl4 { get; set; }
    }

    public class RootObjectDetails
    {
        public string title { get; set; }
        public string sizeCount { get; set; }
        public string productImageUrl { get; set; }
        public string zoomImageUrl { get; set; }
        public string productId { get; set; }
        public bool hasIngredients { get; set; }
        public string brandName { get; set; }
        public string brandPageUrl { get; set; }
        public string tier2Category { get; set; }
        public string tier2url { get; set; }
        public string tier2CategoryId { get; set; }
        public string tier1Category { get; set; }
        public string tier1CategoryId { get; set; }
        public string tier1url { get; set; }
        public string tier3CategoryId { get; set; }
        public string tier3url { get; set; }
        public string tier3Category { get; set; }
        public string color { get; set; }
        public bool isFsa { get; set; }
        public string detailsType { get; set; }
        public string primaryAttribute { get; set; }
        public List<FilmStripUrl> filmStripUrl { get; set; }
        public string skuId { get; set; }
        public string skuType { get; set; }
        public string dsSkuId { get; set; }
        public string addToCartEnable { get; set; }
        public string metaDescription { get; set; }
        public string metaImage { get; set; }
        public bool displayApplePay { get; set; }
        public bool changeProductURL { get; set; }
    }


    public class Value
    {
        public string count { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Refinement
    {
        public List<Value> values { get; set; }
        public string type { get; set; }
        public string attrName { get; set; }
    }

    public class FilterRoot
    {
        public List<Refinement> refinements { get; set; }
    }


    public class MultiFilterValue
    {
        public string count { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string url { get; set; }
    }


    public class MultiFilterObject
    {
        public List<Value> values { get; set; }
        public string type { get; set; }
        public string attrName { get; set; }
    }

    public class FilterValue
    {
        [DontInsert]
        [DontUpdate]
        public int UniqueID { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int? CategoryID { get; set; }
        public string FilterName { get; set; }
        public string type { get; set; }
        public string Count { get; set; }
        [DontInsert]
        [DontUpdate]
        public bool Processed { get; set; }
    }

    class Program
    {


        public static void Main(string[] args)
        {
            Console.WriteLine("Scrapping");
            new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            using (var browser = Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false,
            }).GetAwaiter().GetResult())
            {
                for (int i = 1; i <= 48; i++)
                {
                    var html = HtmlHelper.GetHtmlDocumentProcessed(browser, "https://www.monstercat.com/catalog?page="+i);
                    var audiolinks = html.QuerySelectorAll(".one-line tr td:last-child a:first-child");
                    var links = audiolinks.Select(x => x.Attributes.Where(y => y.Name == "href").FirstOrDefault().Value).ToList();
                    foreach (var item in links)
                    {
                        var page = browser.NewPageAsync().GetAwaiter().GetResult();
                        try
                        {
                            page.GoToAsync(HttpUtility.HtmlDecode(item)).GetAwaiter().GetResult();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                
            }


            

            //foreach (var item in links)
            //    HtmlHelper.DownloadFile(item);


            //while (DBHelper.GetList<FilterValue>("", "Where Processed = 0", null).Count > 0)
            //{
            //    try
            //    {
            //        ScrapFilters();
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //}
            
            //ScrapeCategoryFilter();
            //ScrapeGenderAndFragrance();
        }

     

        public static void ScrapFilters()
        {
            var categories = DBHelper.GetList<Category>("", "Where ID NOT IN (7, 13)");
            foreach (var category in categories)
            {
                var filters = DBHelper.GetList<FilterValue>("", "Where Processed = 0 AND CategoryID =" + category.ID);

                Parallel.ForEach(filters, new ParallelOptions {  MaxDegreeOfParallelism = 6} , filter => {
                    string u = category.Link;
                    var k = u.Split(new string[] { "&Eon=" }, StringSplitOptions.None)[0];
                    k += "+" + filter.Id + "&Eon=" + u.Split(new string[] { "&Eon=" }, StringSplitOptions.None)[1];
                    string h = HtmlHelper.GetHtml(k).GetAwaiter().GetResult();
                    int pageCount = 0;
                    try
                    {
                        string PageCount = h.Split(new string[] { "\"totalNumPages\":" }, StringSplitOptions.None)[1].Split(',')[0].Replace("\"", "");
                        pageCount = int.Parse(PageCount);
                    }
                    catch (Exception ex)
                    {
                    }

                    Console.WriteLine("Total Pages :" + pageCount);
                    for (int i = 0; i <= pageCount; i++)
                    {
                        Console.WriteLine("Scrapping For Page: " + i);
                        string url, html;
                        try
                        {
                            url = string.Empty;
                            if (i == 0)
                            {
                                url = k.Replace("No=24&", "");
                            }
                            else
                            {
                                url = k.Replace("No=24&", $"No={i * 24}");
                            }
                            html = HtmlHelper.GetHtml(url).GetAwaiter().GetResult();
                            try
                            {
                                html = html.Split(new string[] { "\"productList\":" }, StringSplitOptions.None)[1].Split(new string[] { ",\"filters\"" }, StringSplitOptions.None)[0];
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                url = k.Replace("No=24&", "") + $"&No={i * 24}";
                                html = HtmlHelper.GetHtml(url).GetAwaiter().GetResult();
                                html = html.Split(new string[] { "\"productList\":" }, StringSplitOptions.None)[1].Split(new string[] { ",\"filters\"" }, StringSplitOptions.None)[0];
                            }
                            System.Threading.Thread.Sleep(1000);
                        }
                        catch (Exception ex)
                        {
                            url = string.Empty;
                            if (i == 0)
                            {
                                url = k.Replace("No=24&", "");
                            }
                            else
                            {
                                url = k.Replace("No=24&", $"No={i * 24}&");
                            }
                            html = HtmlHelper.GetHtml(url).GetAwaiter().GetResult();
                            try
                            {
                                html = html.Split(new string[] { "\"productList\":" }, StringSplitOptions.None)[1].Split(new string[] { ",\"filters\"" }, StringSplitOptions.None)[0];
                            }
                            catch (IndexOutOfRangeException exe)
                            {
                                url = k.Replace("No=24&", "") + $"&No={i * 24}";
                                html = HtmlHelper.GetHtml(url).GetAwaiter().GetResult();
                                html = html.Split(new string[] { "\"productList\":" }, StringSplitOptions.None)[1].Split(new string[] { ",\"filters\"" }, StringSplitOptions.None)[0];
                            }
                        }
                        Console.WriteLine("Url : " + url);
                        var Products = JsonConvert.DeserializeObject<List<RootObject>>(html);
                        Console.WriteLine("Products Count : " + Products.Count);
                        foreach (var element in Products)
                        {
                            string colName = filter.FilterName.Replace(" ", "").Replace("&", "And") + "_Filter";
                            string query = $"UPDATE ProductInfo SET [{colName}] = '{filter.Name.Replace("'", "")}' Where productURL = '" + element.productInfo.productURL.Replace("'", "''") + "'";
                            DBHelper.ExecuteQuery(query);

                        }
                    }

                    DBHelper.ExecuteQuery("UPDATE FilterValue SET Processed = 1 Where UniqueID = " + filter.UniqueID);

                });

                //foreach (var filter in filters)
                //{

          
                //}

                category.GenderProcessed = true;
                DBHelper.Update(category, "Where ID =" + category.ID, null);
            }

            //element.productInfo.CategoryID = category.ID;
            //var priceInfo = element.productInfo.priceInfo;
            //int priceInfoID = DBHelper.GetScaler((QueryMaker.InsertQuery(priceInfo) + ";SELECT SCOPE_IDENTITY();"));
            //element.productInfo.priceInfoID = priceInfoID;
            //int ProductID = DBHelper.GetScaler(QueryMaker.InsertQuery(element.productInfo) + ";SELECT SCOPE_IDENTITY();");
            //if (element.productInfo.concern != null)
            //{
            //    foreach (var c in element.productInfo.concern)
            //    {
            //        c.ProductID = ProductID;
            //        DBHelper.Insert(c);
            //    }
            //}


        }

        private static void Category2Filter()
        {
            var categories = DBHelper.GetList<Category>();

            foreach (var cat in categories)
            {
                if (cat.ID == 1 || cat.ID == 12 || cat.ID == 7 || cat.ID == 13)
                {
                    continue;
                }
                else
                {
                    string html = File.ReadAllText($"D:/Tempp/Category{cat.ID}.html");
                    var doc = new HtmlDocument();
                    doc.LoadHtml(html);

                    var ulLsit = doc.QuerySelectorAll(".wag-buyagain-filter");

                    List<FilterValue> list = new List<FilterValue>();

                    foreach (var item in ulLsit)
                    {
                        string FilterName = item.QuerySelectorAll("a").FirstOrDefault().InnerText;
                        var filteritems = item.QuerySelectorAll("ul").LastOrDefault();
                        if (FilterName.ToLower().Contains("color"))
                        {
                            var colordivs = filteritems.QuerySelectorAll(".colorswatchproductcard");
                            foreach (var f in colordivs)
                            {
                                var div = f.QuerySelectorAll("div a").FirstOrDefault();
                                var attribs = div.Attributes;
                                var idAttrib = attribs.Where(x => x.Name.ToLower() == "id").FirstOrDefault();
                                var id = idAttrib.Value;
                                if (id.Contains("_"))
                                {
                                    id = id.Split('_')[1];
                                }

                                var name = HttpUtility.HtmlDecode(f.InnerText.Trim(' '));
                                list.Add(new FilterValue
                                {
                                    CategoryID = cat.ID,
                                    Count = "",
                                    FilterName = FilterName,
                                    Id = id,
                                    Name = name,
                                    type = ""
                                });
                            }
                        }
                        else
                        {
                            foreach (var f in filteritems.QuerySelectorAll("li"))
                            {
                                string count = string.Empty;
                                var id = f.QuerySelectorAll("input").FirstOrDefault().Attributes.Where(x => x.Name == "value").FirstOrDefault().Value;
                                var name = Regex.Replace(f.InnerText, "<!--[^>]*-->", ""); //f.InnerText;
                                if (name.Contains("("))
                                {
                                    count = name.Split('(')[1].Replace(")", "");
                                    name = name.Split('(')[0];
                                }
                                name = HttpUtility.HtmlDecode(name);

                                list.Add(new FilterValue
                                {
                                    CategoryID = cat.ID,
                                    Count = count,
                                    FilterName = FilterName,
                                    Id = id,
                                    Name = name,
                                    type = ""
                                });
                            }
                        }
                    }

                    foreach (var element in list)
                    {
                        DBHelper.Insert(element);
                    }
                }
            }



            Console.ReadLine();

        }


        private static void Category1Filter()
        {
            int CategoryID = 1;
            string Category1ProductTypes = @"{""refinements"":[{""values"":[{""count"":""1"",""name"":""All Purpose Cleaner"",""id"":""2000012460""},{""count"":""4"",""name"":""Backpacks & Messenger Bags"",""id"":""2000013239""},{""count"":""1"",""name"":""Bath Bombs"",""id"":""2000014812""},{""count"":""9"",""name"":""BB Cream"",""id"":""2000014853""},{""count"":""187"",""name"":""Blush"",""id"":""2000012057""},{""count"":""14"",""name"":""Body Wash"",""id"":""2000012032""},{""count"":""58"",""name"":""Bronzer"",""id"":""2000014347""},{""count"":""1"",""name"":""Children's Beauty Sets"",""id"":""2000014689""},{""count"":""362"",""name"":""Concealers"",""id"":""2000014351""},{""count"":""59"",""name"":""Contours"",""id"":""2000014783""},{""count"":""3"",""name"":""Cotton Balls"",""id"":""2000014785""},{""count"":""6"",""name"":""Cotton Pads"",""id"":""2000014784""},{""count"":""1"",""name"":""Cotton Swabs"",""id"":""2000014786""},{""count"":""7"",""name"":""Dark Spot Corrector"",""id"":""2000014730""},{""count"":""13"",""name"":""Emery Boards & Files"",""id"":""2000010963""},{""count"":""3"",""name"":""Eye Creams & Gels"",""id"":""2000014854""},{""count"":""330"",""name"":""Eyebrow Makeup"",""id"":""2000014838""},{""count"":""3"",""name"":""Eyelash Adhesive"",""id"":""2000015050""},{""count"":""18"",""name"":""Eyelash Curlers"",""id"":""2000014380""},{""count"":""15"",""name"":""Eyelash Enhancers"",""id"":""2000014837""},{""count"":""402"",""name"":""Eyeliner"",""id"":""2000014235""},{""count"":""466"",""name"":""Eyeshadow"",""id"":""2000014352""},{""count"":""15"",""name"":""Eyeshadow Primer"",""id"":""2000014198""},{""count"":""1"",""name"":""Face Masks"",""id"":""2000010548""},{""count"":""2"",""name"":""Face Oil"",""id"":""2000014484""},{""count"":""300"",""name"":""Face Powder"",""id"":""2000014363""},{""count"":""90"",""name"":""Face Primer"",""id"":""2000014369""},{""count"":""1"",""name"":""Face Serum"",""id"":""2000014756""},{""count"":""5"",""name"":""Face Wash"",""id"":""2000013767""},{""count"":""13"",""name"":""Face Wipes"",""id"":""2000014816""},{""count"":""1"",""name"":""Facial Cleansing Pads"",""id"":""2000014840""},{""count"":""2"",""name"":""Facial Moisturizers"",""id"":""2000010255""},{""count"":""1"",""name"":""Facial Treatments"",""id"":""2000014916""},{""count"":""101"",""name"":""False Eyelashes"",""id"":""2000014415""},{""count"":""1229"",""name"":""Foundation"",""id"":""2000011352""},{""count"":""5"",""name"":""Gift Sets"",""id"":""2000010614""},{""count"":""2"",""name"":""Hair Scissors"",""id"":""2000014789""},{""count"":""2"",""name"":""Hand & Body Lotions"",""id"":""2000010185""},{""count"":""1"",""name"":""Heating Pads - Electric"",""id"":""2000010041""},{""count"":""59"",""name"":""Highlighters"",""id"":""2000014921""},{""count"":""1"",""name"":""Kits"",""id"":""2000012598""},{""count"":""92"",""name"":""Lip Balm"",""id"":""2000011247""},{""count"":""447"",""name"":""Lip Gloss"",""id"":""2000013653""},{""count"":""199"",""name"":""Lip Liner"",""id"":""2000013650""},{""count"":""21"",""name"":""Lip Plumpers"",""id"":""2000010570""},{""count"":""3"",""name"":""Lip Treatments"",""id"":""2000010957""},{""count"":""1410"",""name"":""Lipstick"",""id"":""2000010601""},{""count"":""39"",""name"":""Makeup Bags"",""id"":""2000014457""},{""count"":""3"",""name"":""Makeup Brush Cleaner"",""id"":""2000015034""},{""count"":""194"",""name"":""Makeup Brushes"",""id"":""2000014928""},{""count"":""34"",""name"":""Makeup Remover"",""id"":""2000013637""},{""count"":""17"",""name"":""Makeup Sets"",""id"":""2000014691""},{""count"":""9"",""name"":""Manicure & Pedicure Tools"",""id"":""2000014406""},{""count"":""381"",""name"":""Mascara"",""id"":""2000010173""},{""count"":""3"",""name"":""Mirrors"",""id"":""2000011221""},{""count"":""2"",""name"":""Nail Clippers & Nippers"",""id"":""2000014939""},{""count"":""1"",""name"":""Nail Polish Remover"",""id"":""2000014370""},{""count"":""1"",""name"":""Nail Sets"",""id"":""2000014935""},{""count"":""7"",""name"":""Pencil Sharpeners"",""id"":""2000014376""},{""count"":""2"",""name"":""Self-Tanners"",""id"":""2000014803""},{""count"":""30"",""name"":""Setting Spray"",""id"":""2000014739""},{""count"":""2"",""name"":""Shower & Bath Accessories"",""id"":""2000011016""},{""count"":""5"",""name"":""Skin Care Tools"",""id"":""2000014818""},{""count"":""1"",""name"":""Skin Treatments"",""id"":""2000014774""},{""count"":""48"",""name"":""Sponges & Applicators"",""id"":""2000014769""},{""count"":""56"",""name"":""Tinted Moisturizer"",""id"":""2000010270""},{""count"":""51"",""name"":""Tweezers & Eyebrow Tools"",""id"":""2000014377""}],""type"":""multi-select"",""attrName"":""Product Type""}]}";
            string Category1Brands = @"{""refinements"":[{""values"":[{""count"":""4"",""name"":""Allegro"",""id"":""359024""},{""count"":""86"",""name"":""Almay"",""id"":""73""},{""count"":""1"",""name"":""Andrea"",""id"":""523""},{""count"":""43"",""name"":""Ardell"",""id"":""510""},{""count"":""1"",""name"":""Asepxia"",""id"":""376412""},{""count"":""4"",""name"":""Aveeno"",""id"":""219""},{""count"":""4"",""name"":""Avene"",""id"":""358764""},{""count"":""1"",""name"":""Badger"",""id"":""358781""},{""count"":""2"",""name"":""BIODERMA"",""id"":""521930""},{""count"":""62"",""name"":""Black Radiance"",""id"":""1459""},{""count"":""6"",""name"":""Bonne Bell"",""id"":""543""},{""count"":""16"",""name"":""Burt's Bees"",""id"":""301573""},{""count"":""2"",""name"":""CeraVe"",""id"":""303414""},{""count"":""6"",""name"":""ChapStick"",""id"":""644""},{""count"":""27"",""name"":""Circa Beauty"",""id"":""436370""},{""count"":""2"",""name"":""Clean & Clear"",""id"":""2149""},{""count"":""25"",""name"":""Colour Prevails"",""id"":""436025""},{""count"":""1"",""name"":""Conair"",""id"":""309768""},{""count"":""1"",""name"":""Coty"",""id"":""462""},{""count"":""197"",""name"":""CoverGirl"",""id"":""303253""},{""count"":""1"",""name"":""CR Gibson"",""id"":""375684""},{""count"":""64"",""name"":""CYO"",""id"":""520855""},{""count"":""6"",""name"":""Duo"",""id"":""2295""},{""count"":""139"",""name"":""e.l.f."",""id"":""369905""},{""count"":""29"",""name"":""EcoTools"",""id"":""308445""},{""count"":""1"",""name"":""ELF Brands"",""id"":""521409""},{""count"":""15"",""name"":""Eylure"",""id"":""363752""},{""count"":""2"",""name"":""Garnier"",""id"":""2443""},{""count"":""10"",""name"":""Godefroy"",""id"":""374993""},{""count"":""12"",""name"":""Honest"",""id"":""522272""},{""count"":""24"",""name"":""IMAN"",""id"":""309459""},{""count"":""2"",""name"":""INSTYLE"",""id"":""520449""},{""count"":""41"",""name"":""IsaDora"",""id"":""521054""},{""count"":""5"",""name"":""ItsJudyTime"",""id"":""521257""},{""count"":""37"",""name"":""Japonesque"",""id"":""375056""},{""count"":""2"",""name"":""Jerdon"",""id"":""364589""},{""count"":""25"",""name"":""Jordana"",""id"":""2590""},{""count"":""19"",""name"":""Kiss"",""id"":""538""},{""count"":""150"",""name"":""L'Oreal Paris"",""id"":""359425""},{""count"":""34"",""name"":""L.A. Colors"",""id"":""375075""},{""count"":""2"",""name"":""L.A. Girl"",""id"":""375228""},{""count"":""2"",""name"":""La Roche-Posay"",""id"":""354201""},{""count"":""1"",""name"":""LashPRO"",""id"":""372540""},{""count"":""2"",""name"":""LED Technologies"",""id"":""359798""},{""count"":""26"",""name"":""Lip Smacker"",""id"":""438314""},{""count"":""4"",""name"":""London Soho New York"",""id"":""358750""},{""count"":""19"",""name"":""MASQD"",""id"":""522176""},{""count"":""1"",""name"":""Max Factor"",""id"":""304408""},{""count"":""204"",""name"":""Maybelline"",""id"":""263""},{""count"":""2"",""name"":""Maybelline New York FaceStudio"",""id"":""520701""},{""count"":""1"",""name"":""Maybelline New York Lash Sensational"",""id"":""520690""},{""count"":""87"",""name"":""Milani"",""id"":""537""},{""count"":""84"",""name"":""Neutrogena"",""id"":""189""},{""count"":""56"",""name"":""No7"",""id"":""519896""},{""count"":""126"",""name"":""NYX Professional Makeup"",""id"":""520604""},{""count"":""2"",""name"":""OH K!"",""id"":""520450""},{""count"":""2"",""name"":""Olay"",""id"":""3064""},{""count"":""2"",""name"":""Ology"",""id"":""371981""},{""count"":""92"",""name"":""Physicians Formula"",""id"":""362938""},{""count"":""1"",""name"":""POND'S"",""id"":""3440""},{""count"":""98"",""name"":""POP Beauty"",""id"":""373673""},{""count"":""1"",""name"":""Q-tips"",""id"":""2031""},{""count"":""1"",""name"":""Rapid Brow"",""id"":""520491""},{""count"":""1"",""name"":""RapidLash"",""id"":""351152""},{""count"":""1"",""name"":""RapidShield"",""id"":""522319""},{""count"":""46"",""name"":""Real Techniques"",""id"":""370601""},{""count"":""2"",""name"":""RevitaLash"",""id"":""354246""},{""count"":""176"",""name"":""Revlon"",""id"":""72""},{""count"":""1"",""name"":""Revlon Hair Appliances"",""id"":""371680""},{""count"":""105"",""name"":""Rimmel"",""id"":""302807""},{""count"":""1"",""name"":""Sally Hansen"",""id"":""160""},{""count"":""2"",""name"":""Simple"",""id"":""365020""},{""count"":""58"",""name"":""Sleek MakeUP"",""id"":""520860""},{""count"":""52"",""name"":""Soap & Glory"",""id"":""467464""},{""count"":""2"",""name"":""Spa Sciences"",""id"":""303949""},{""count"":""14"",""name"":""Studio 35"",""id"":""305327""},{""count"":""1"",""name"":""Swissco"",""id"":""305186""},{""count"":""10"",""name"":""Swisspers"",""id"":""369780""},{""count"":""114"",""name"":""theBalm"",""id"":""520894""},{""count"":""5"",""name"":""Trim"",""id"":""369848""},{""count"":""22"",""name"":""Tweezerman"",""id"":""3110""},{""count"":""4"",""name"":""Vaseline"",""id"":""1255""},{""count"":""7"",""name"":""Vichy"",""id"":""304160""},{""count"":""1"",""name"":""Village Naturals"",""id"":""1953""},{""count"":""102"",""name"":""Walgreens"",""id"":""118""},{""count"":""133"",""name"":""Wet n Wild"",""id"":""351354""}],""type"":""multi-select"",""attrName"":""Brand""}]}";
            string Category1DealsandPromotions = @"{""values"":[{""count"":""25"",""name"":""Bonus Points"",""id"":""4294815983""},{""count"":""189"",""name"":""Gift With Purchase"",""id"":""2999952744""},{""count"":""371"",""name"":""Coupon Available"",""id"":""2999952769""},{""count"":""3585"",""name"":""Sales & Offers"",""id"":""4294896499""}],""type"":""multi-select"",""attrName"":""Deals & Promotions""}";
            string Category1ColorFamily = @"{""values"":[{""count"":""3"",""name"":""Yellow"",""id"":""5000015137"",""url"":""/images/adaptive/colorfamily/Yellow.png""},{""count"":""8"",""name"":""Multi"",""id"":""5000015130"",""url"":""/images/adaptive/colorfamily/Multi.png""},{""count"":""20"",""name"":""Green"",""id"":""5000015129"",""url"":""/images/adaptive/colorfamily/Green.png""},{""count"":""40"",""name"":""Turquoise"",""id"":""5000015134"",""url"":""/images/adaptive/colorfamily/Turquoise.png""},{""count"":""55"",""name"":""Blue"",""id"":""5000015124"",""url"":""/images/adaptive/colorfamily/Blue.png""},{""count"":""77"",""name"":""Gold"",""id"":""5000015127"",""url"":""/images/adaptive/colorfamily/Gold.png""},{""count"":""80"",""name"":""White"",""id"":""5000015136"",""url"":""/images/adaptive/colorfamily/White.png""},{""count"":""104"",""name"":""Gray"",""id"":""5000015128"",""url"":""/images/adaptive/colorfamily/Gray.png""},{""count"":""188"",""name"":""Violet"",""id"":""5000015135"",""url"":""/images/adaptive/colorfamily/Violet.png""},{""count"":""192"",""name"":""Berry"",""id"":""5000015122"",""url"":""/images/adaptive/colorfamily/Berry.png""},{""count"":""226"",""name"":""Red"",""id"":""5000015133"",""url"":""/images/adaptive/colorfamily/Red.png""},{""count"":""263"",""name"":""Coral"",""id"":""5000015126"",""url"":""/images/adaptive/colorfamily/Coral.png""},{""count"":""411"",""name"":""Black"",""id"":""5000015123"",""url"":""/images/adaptive/colorfamily/Black.png""},{""count"":""491"",""name"":""Brown"",""id"":""5000015125"",""url"":""/images/adaptive/colorfamily/Brown.png""},{""count"":""685"",""name"":""Neutral"",""id"":""5000015131"",""url"":""/images/adaptive/colorfamily/Neutral.png""},{""count"":""766"",""name"":""Pink"",""id"":""5000015132"",""url"":""/images/adaptive/colorfamily/Pink.png""}],""type"":""multi-select"",""attrName"":""Color Family""}";
            string Cat1SkinTypes = @"{""refinements"":[{""values"":[{""count"":""93"",""name"":""All Skin Types"",""id"":""2999951146""},{""count"":""13"",""name"":""Combination"",""id"":""2999951147""},{""count"":""5"",""name"":""Dry"",""id"":""2999951152""},{""count"":""384"",""name"":""Normal"",""id"":""2999951154""},{""count"":""82"",""name"":""Oily"",""id"":""2999951144""},{""count"":""56"",""name"":""Sensitive"",""id"":""2999951148""}],""type"":""multi-select"",""attrName"":""Skin Type""}]}";
            string Cat1Concern = @"{""refinements"":[{""values"":[{""count"":""1"",""name"":""Chapped Lips"",""id"":""5000017948""},{""count"":""2"",""name"":""Clogged Pores"",""id"":""2999951132""},{""count"":""1"",""name"":""Dull"",""id"":""5000017952""},{""count"":""10"",""name"":""Fine Lines & Wrinkles"",""id"":""5000000741""},{""count"":""1"",""name"":""Hypersensitive Skin"",""id"":""5000017954""},{""count"":""2"",""name"":""Oiliness"",""id"":""5000017956""},{""count"":""8"",""name"":""Uneven"",""id"":""5000017959""}],""type"":""multi-select"",""attrName"":""Concern""}]}";
            string Cat1SPF = @"{""refinements"":[{""values"":[{""count"":""9"",""name"":""0"",""id"":""5000026335""},{""count"":""10"",""name"":""10"",""id"":""5000011102""},{""count"":""33"",""name"":""15"",""id"":""5000011104""},{""count"":""66"",""name"":""20"",""id"":""5000011105""},{""count"":""13"",""name"":""25"",""id"":""5000011106""},{""count"":""5"",""name"":""30"",""id"":""5000011107""},{""count"":""6"",""name"":""50"",""id"":""5000011109""},{""count"":""4"",""name"":""55"",""id"":""5000011110""}],""type"":""multi-select"",""attrName"":""SPF""}]}";
            string Cat1Form = @"{""refinements"":[{""values"":[{""count"":""6"",""name"":""Cream"",""id"":""3000007703""},{""count"":""1"",""name"":""Gels"",""id"":""2999951500""},{""count"":""92"",""name"":""Liquid"",""id"":""5000000970""},{""count"":""5"",""name"":""Lotion"",""id"":""3000007714""},{""count"":""8"",""name"":""Pads"",""id"":""3000007631""},{""count"":""5"",""name"":""Pencil"",""id"":""3000007699""},{""count"":""29"",""name"":""Powder"",""id"":""3000007696""},{""count"":""1"",""name"":""Serum"",""id"":""3000007688""},{""count"":""8"",""name"":""Solid"",""id"":""5000001542""},{""count"":""1"",""name"":""Spray"",""id"":""3000007707""},{""count"":""7"",""name"":""Stick"",""id"":""3000007690""}],""type"":""multi-select"",""attrName"":""Form""}]}";
            string Cat1Fragrance = @"{""values"":[{""count"":""3"",""name"":""Fragrance Free"",""id"":""2999951328""},{""count"":""1"",""name"":""Unscented"",""id"":""2999951359""}],""type"":""multi-select"",""attrName"":""Fragrance""}";
            string Cat1DaysSupply = @"{""refinements"":[{""values"":[{""count"":""132"",""name"":""0"",""id"":""5000024415""},{""count"":""12"",""name"":""10"",""id"":""4294836805""},{""count"":""1"",""name"":""12"",""id"":""5000022175""},{""count"":""23"",""name"":""120"",""id"":""5000022555""},{""count"":""3"",""name"":""14"",""id"":""5000022856""},{""count"":""15"",""name"":""15"",""id"":""2999951510""},{""count"":""9"",""name"":""180"",""id"":""4294838626""},{""count"":""1"",""name"":""26"",""id"":""5000024615""},{""count"":""178"",""name"":""30"",""id"":""4294838623""},{""count"":""2"",""name"":""45"",""id"":""5000017162""},{""count"":""17"",""name"":""60"",""id"":""2999952467""},{""count"":""2"",""name"":""7"",""id"":""5000006476""},{""count"":""413"",""name"":""90"",""id"":""4294838625""}],""type"":""multi-select"",""attrName"":""Days Supply""}]}";
            string Cat1Gender = @"{""values"":[{""count"":""2"",""name"":""Unisex"",""id"":""5000017705""},{""count"":""19"",""name"":""Women"",""id"":""2999951153""}],""type"":""multi-select"",""attrName"":""Gender""}";
            string Cat1SpecialFeature = @"{""refinements"":[{""values"":[{""count"":""12"",""name"":""Alcohol-Free"",""id"":""2999951474""},{""count"":""1"",""name"":""Battery Operated"",""id"":""2999951482""},{""count"":""1"",""name"":""Clinically Proven"",""id"":""5000017703""},{""count"":""115"",""name"":""Cruelty Free"",""id"":""2999951423""},{""count"":""18"",""name"":""Dermatologist Recommended"",""id"":""5000017950""},{""count"":""10"",""name"":""Dye-Free"",""id"":""2999951449""},{""count"":""35"",""name"":""Gluten Free"",""id"":""2999951492""},{""count"":""172"",""name"":""Hypoallergenic"",""id"":""2999951481""},{""count"":""4"",""name"":""Latex-Free"",""id"":""2999951498""},{""count"":""8"",""name"":""Natural"",""id"":""2999951488""},{""count"":""76"",""name"":""No Animal Testing"",""id"":""2999951495""},{""count"":""29"",""name"":""No Phthalates"",""id"":""2999951422""},{""count"":""1"",""name"":""No Preservatives"",""id"":""2999951480""},{""count"":""10"",""name"":""Non-Acnegenic"",""id"":""2999951161""},{""count"":""160"",""name"":""Non-Comedogenic/Won't Clog Pores"",""id"":""2999951430""},{""count"":""189"",""name"":""Oil-Free"",""id"":""2999951479""},{""count"":""2"",""name"":""Organic"",""id"":""2999951417""},{""count"":""145"",""name"":""Paraben Free"",""id"":""2999951426""},{""count"":""2"",""name"":""PH Balance"",""id"":""5000017957""},{""count"":""2"",""name"":""PVC and Lead Free"",""id"":""2999951357""},{""count"":""8"",""name"":""Sulfate Free"",""id"":""2999951167""},{""count"":""24"",""name"":""Talc Free"",""id"":""2999951273""},{""count"":""25"",""name"":""Vegan"",""id"":""2999951405""},{""count"":""30"",""name"":""Water Resistant"",""id"":""2999951165""}],""type"":""multi-select"",""attrName"":""Special Feature""}]}";
            string Cat1FoundationColor = @"{""values"":[{""count"":""8"",""name"":""Deep"",""id"":""5000014618"",""url"":""/images/adaptive/foundationcolor/Deep.png"",""Under Tone"":[{""count"":""4"",""name"":""Neutral"",""id"":""5000016582""},{""count"":""3"",""name"":""Cool"",""id"":""5000017542""},{""count"":""1"",""name"":""Warm"",""id"":""5000014644""}]},{""count"":""13"",""name"":""Deep Dark"",""id"":""5000014617"",""url"":""/images/adaptive/foundationcolor/DeepDark.png"",""Under Tone"":[{""count"":""9"",""name"":""Neutral"",""id"":""5000015422""},{""count"":""4"",""name"":""Cool"",""id"":""5000021854""}]},{""count"":""40"",""name"":""Medium Dark"",""id"":""5000014621"",""url"":""/images/adaptive/foundationcolor/MediumDark.png"",""Under Tone"":[{""count"":""25"",""name"":""Neutral"",""id"":""5000014639""},{""count"":""12"",""name"":""Warm"",""id"":""5000014648""},{""count"":""2"",""name"":""Cool"",""id"":""5000014630""},{""count"":""1"",""name"":""Neutral"",""id"":""5000014640""}]},{""count"":""47"",""name"":""Porcelain"",""id"":""5000014624"",""url"":""/images/adaptive/foundationcolor/Porcelain.png"",""Under Tone"":[{""count"":""27"",""name"":""Neutral"",""id"":""5000014641""},{""count"":""14"",""name"":""Warm"",""id"":""5000014650""},{""count"":""6"",""name"":""Cool"",""id"":""5000014632""}]},{""count"":""64"",""name"":""Dark"",""id"":""5000014616"",""url"":""/images/adaptive/foundationcolor/Dark.png"",""Under Tone"":[{""count"":""45"",""name"":""Warm"",""id"":""5000014643""},{""count"":""12"",""name"":""Neutral"",""id"":""5000014635""},{""count"":""2"",""name"":""Warm"",""id"":""5000014647""},{""count"":""1"",""name"":""Cool"",""id"":""5000014626""},{""count"":""1"",""name"":""Cool"",""id"":""5000017542""},{""count"":""1"",""name"":""Warm"",""id"":""5000014635""},{""count"":""1"",""name"":""Warm"",""id"":""5000014640""},{""count"":""1"",""name"":""Warm"",""id"":""5000014641""}]},{""count"":""140"",""name"":""Olive"",""id"":""5000014623"",""url"":""/images/adaptive/foundationcolor/Olive.png"",""Under Tone"":[{""count"":""107"",""name"":""Warm"",""id"":""5000014649""},{""count"":""30"",""name"":""Neutral"",""id"":""5000014640""},{""count"":""3"",""name"":""Cool"",""id"":""5000014631""}]},{""count"":""152"",""name"":""Fair"",""id"":""5000014619"",""url"":""/images/adaptive/foundationcolor/Fair.png"",""Under Tone"":[{""count"":""74"",""name"":""Neutral"",""id"":""5000014636""},{""count"":""61"",""name"":""Cool"",""id"":""5000014627""},{""count"":""15"",""name"":""Warm"",""id"":""5000014645""},{""count"":""1"",""name"":""Neutral"",""id"":""5000014641""},{""count"":""1"",""name"":""Warm"",""id"":""5000014636""}]},{""count"":""259"",""name"":""Light"",""id"":""5000014620"",""url"":""/images/adaptive/foundationcolor/Light.png"",""Under Tone"":[{""count"":""154"",""name"":""Warm"",""id"":""5000014646""},{""count"":""71"",""name"":""Neutral"",""id"":""5000014637""},{""count"":""25"",""name"":""Cool"",""id"":""5000014628""},{""count"":""3"",""name"":""Warm"",""id"":""5000014647""},{""count"":""1"",""name"":""Neutral"",""id"":""5000014628""},{""count"":""1"",""name"":""Neutral"",""id"":""5000014636""},{""count"":""1"",""name"":""Neutral"",""id"":""5000014638""},{""count"":""1"",""name"":""Neutral"",""id"":""5000014641""},{""count"":""1"",""name"":""Neutral"",""id"":""5000014646""},{""count"":""1"",""name"":""Warm"",""id"":""5000014637""}]},{""count"":""287"",""name"":""Medium"",""id"":""5000014622"",""url"":""/images/adaptive/foundationcolor/Medium.png"",""Under Tone"":[{""count"":""167"",""name"":""Warm"",""id"":""5000014647""},{""count"":""89"",""name"":""Neutral"",""id"":""5000014638""},{""count"":""18"",""name"":""Cool"",""id"":""5000014629""},{""count"":""4"",""name"":""Neutral"",""id"":""5000014640""},{""count"":""4"",""name"":""Warm"",""id"":""5000014649""},{""count"":""1"",""name"":""Cool"",""id"":""5000014638""},{""count"":""1"",""name"":""Cool"",""id"":""5000014647""},{""count"":""1"",""name"":""Neutral"",""id"":""5000014636""},{""count"":""1"",""name"":""Neutral"",""id"":""5000014641""},{""count"":""1"",""name"":""Warm"",""id"":""5000014638""}]}],""type"":""foundation"",""attrName"":""Foundation Color""}";
            //string Cat12HairType = @"{""refinements"":[{""values"":[{""count"":""3"",""name"":""Chemically Treated hair"",""id"":""2999951395""},{""count"":""1"",""name"":""Coarse"",""id"":""2999951384""},{""count"":""3"",""name"":""Curly"",""id"":""2999951408""},{""count"":""30"",""name"":""Damaged"",""id"":""2999951403""},{""count"":""19"",""name"":""Dry"",""id"":""2999951497""},{""count"":""3"",""name"":""Fine"",""id"":""2999951368""},{""count"":""12"",""name"":""Frizzy"",""id"":""2999951383""},{""count"":""39"",""name"":""Normal"",""id"":""2999951393""},{""count"":""6"",""name"":""Thick"",""id"":""2999951385""},{""count"":""1"",""name"":""Thin"",""id"":""2999951361""}],""type"":""multi-select"",""attrName"":""Hair Type""}]}";
            //string Cat12MultipleFilters = @"[{""values"":[{""count"":""10"",""name"":""Body"",""id"":""5000017702""},{""count"":""2"",""name"":""Face"",""id"":""5000017953""}],""type"":""multi-select"",""attrName"":""Use""},{""values"":[{""count"":""5"",""name"":""Fragrance Free"",""id"":""2999951328""},{""count"":""48"",""name"":""Scented"",""id"":""2999951399""},{""count"":""4"",""name"":""Unscented"",""id"":""2999951359""}],""type"":""multi-select"",""attrName"":""Fragrance""},{""values"":[{""count"":""4"",""name"":""Floral"",""id"":""2999951145""},{""count"":""1"",""name"":""Fruit"",""id"":""2999951129""}],""type"":""multi-select"",""attrName"":""Scent Family""},{""values"":[{""count"":""32"",""name"":""0"",""id"":""5000024415""}],""type"":""multi-select"",""attrName"":""Days Supply""},{""values"":[{""count"":""1"",""name"":""Men"",""id"":""2999951505""},{""count"":""27"",""name"":""Unisex"",""id"":""5000017705""},{""count"":""162"",""name"":""Women"",""id"":""2999951153""}],""type"":""multi-select"",""attrName"":""Gender""},{""values"":[{""count"":""1"",""name"":""Red"",""id"":""5000013778"",""url"":""/images/adaptive/haircolorswatches/Red.png""},{""count"":""1"",""name"":""Brown"",""id"":""5000013770"",""url"":""/images/adaptive/haircolorswatches/Brown.png""}],""type"":""multi-select"",""attrName"":""Hair Color Family""}]";
            string Cat1MoreOptions = @"{""values"":[{""count"":""6534"",""name"":""Ship to Store"",""id"":""2999951740""},{""count"":""1746"",""name"":""Auto-Reorder & Save"",""id"":""3000009396""},{""count"":""387"",""name"":""Luxury Brand"",""id"":""5000019582""},{""count"":""219"",""name"":""New Item"",""id"":""4294838977""},{""count"":""2"",""name"":""FSA Item"",""id"":""4294840275""}],""type"":""multi-select"",""attrName"":""More Options""}";

            FullFilter(Cat1DaysSupply, CategoryID);
            FullFilter(Category1ProductTypes, CategoryID);
            FullFilter(Category1Brands, CategoryID);
            FullFilter(Cat1SkinTypes, CategoryID);
            //    FullFilter(Cat1HairType);
            FullFilter(Cat1Concern, CategoryID);
            FullFilter(Cat1SPF, CategoryID);
            FullFilter(Cat1Form, CategoryID);
            FullFilter(Cat1SpecialFeature, CategoryID);

            //   MultipleItemFilter(Cat1MultipleFilters);

            SingleItemFilter(Cat1FoundationColor, CategoryID);
            SingleItemFilter(Cat1Gender, CategoryID);
            SingleItemFilter(Cat1Fragrance, CategoryID);
            SingleItemFilter(Category1ColorFamily, CategoryID);
            SingleItemFilter(Cat1MoreOptions, CategoryID);
            SingleItemFilter(Category1DealsandPromotions, CategoryID);
        }


        private static void Category12Filter()
        {
            int CategoryID = 12;
            string Category12ProductTypes = @"{""refinements"":[{""values"":[{""count"":""5"",""name"":""Acne Treatments"",""id"":""2000011389""},{""count"":""1"",""name"":""Antiseptics & Topical Antibiotics"",""id"":""2000012304""},{""count"":""2"",""name"":""Bar Soap"",""id"":""2000012040""},{""count"":""9"",""name"":""Body Oils"",""id"":""2000014463""},{""count"":""33"",""name"":""Body Wash"",""id"":""2000012032""},{""count"":""52"",""name"":""Conditioner"",""id"":""2000010114""},{""count"":""1"",""name"":""Cotton Pads"",""id"":""2000014784""},{""count"":""1"",""name"":""Dark Spot Corrector"",""id"":""2000014730""},{""count"":""1"",""name"":""Detanglers"",""id"":""2000011268""},{""count"":""3"",""name"":""Dry Shampoo"",""id"":""2000014486""},{""count"":""8"",""name"":""Essential Oils"",""id"":""2000014901""},{""count"":""5"",""name"":""Eye Creams &Gels"",""id"":""2000014854""},{""count"":""4"",""name"":""Face & Body Scrubs"",""id"":""2000014814""},{""count"":""1"",""name"":""Face Masks"",""id"":""2000010548""},{""count"":""3"",""name"":""Face Oil"",""id"":""2000014484""},{""count"":""2"",""name"":""Face Serum"",""id"":""2000014756""},{""count"":""14"",""name"":""Face Wash"",""id"":""2000013767""},{""count"":""3"",""name"":""Face Wipes"",""id"":""2000014816""},{""count"":""1"",""name"":""Facial Cleansing Pads"",""id"":""2000014840""},{""count"":""13"",""name"":""Facial Moisturizers"",""id"":""2000010255""},{""count"":""1"",""name"":""Facial Treatments"",""id"":""2000014916""},{""count"":""25"",""name"":""Hair & Scalp Treatments"",""id"":""2000012849""},{""count"":""4"",""name"":""Hair Color"",""id"":""2000013322""},{""count"":""3"",""name"":""Hair Gel"",""id"":""2000014732""},{""count"":""6"",""name"":""Hair Mask"",""id"":""2000014802""},{""count"":""6"",""name"":""Hair Oils"",""id"":""2000014926""},{""count"":""3"",""name"":""Hair Relaxers"",""id"":""2000014799""},{""count"":""3"",""name"":""Hair Spray"",""id"":""2000013766""},{""count"":""20"",""name"":""Hand & Body Lotions"",""id"":""2000010185""},{""count"":""2"",""name"":""Heat Protectant"",""id"":""2000014800""},{""count"":""7"",""name"":""Leave - In Conditioner"",""id"":""2000011195""},{""count"":""6"",""name"":""Lip Balm"",""id"":""2000011247""},{""count"":""1"",""name"":""Makeup Brushes"",""id"":""2000014928""},{""count"":""12"",""name"":""Massage Equipment"",""id"":""2000014944""},{""count"":""1"",""name"":""Massage Oils &Lotions"",""id"":""2000010624""},{""count"":""2"",""name"":""Moisturizers"",""id"":""2000010878""},{""count"":""1"",""name"":""Multivitamins"",""id"":""2000012000""},{""count"":""1"",""name"":""Self - Tanners"",""id"":""2000014803""},{""count"":""58"",""name"":""Shampoo"",""id"":""2000011070""},{""count"":""1"",""name"":""Stretch Mark Cream"",""id"":""2000012589""},{""count"":""9"",""name"":""Styling Products"",""id"":""2000011164""},{""count"":""13"",""name"":""Sunscreen"",""id"":""2000013179""},{""count"":""1"",""name"":""Tea Tree Oil"",""id"":""2000012223""},{""count"":""5"",""name"":""Toners"",""id"":""2000014465""},{""count"":""1"",""name"":""Vein Treatments"",""id"":""2000014833""}],""type"":""multi - select"",""attrName"":""Product Type""}]}";
            string Category12Brands = @"{""refinements"":[{""values"":[{""count"":""1"",""name"":""Acure Organics"",""id"":""372167""},{""count"":""5"",""name"":""Africa's Best"",""id"":""468""},{""count"":""11"",""name"":""Alba"",""id"":""306757""},{""count"":""1"",""name"":""American Crew"",""id"":""3339""},{""count"":""2"",""name"":""Aura Cacia"",""id"":""357522""},{""count"":""8"",""name"":""Avalon Organics"",""id"":""307118""},{""count"":""2"",""name"":""Aveda"",""id"":""350735""},{""count"":""8"",""name"":""Aveeno"",""id"":""219""},{""count"":""1"",""name"":""Avena"",""id"":""303691""},{""count"":""4"",""name"":""Badger"",""id"":""358781""},{""count"":""1"",""name"":""Beauty Without Cruelty"",""id"":""358909""},{""count"":""2"",""name"":""Boots Botanics"",""id"":""374092""},{""count"":""5"",""name"":""Botanics"",""id"":""519898""},{""count"":""24"",""name"":""Burt's Bees"",""id"":""301573""},{""count"":""3"",""name"":""c. Booth"",""id"":""307957""},{""count"":""8"",""name"":""Creme Of Nature"",""id"":""305633""},{""count"":""13"",""name"":""Derma E"",""id"":""307112""},{""count"":""8"",""name"":""Desert Essence"",""id"":""357525""},{""count"":""13"",""name"":""Dr. Bronner's"",""id"":""364706""},{""count"":""2"",""name"":""Earth Science"",""id"":""357633""},{""count"":""2"",""name"":""eco styler"",""id"":""305426""},{""count"":""1"",""name"":""EcoTools"",""id"":""308445""},{""count"":""2"",""name"":""EO"",""id"":""357526""},{""count"":""30"",""name"":""Garnier"",""id"":""2443""},{""count"":""1"",""name"":""Gena Laboratories"",""id"":""4486""},{""count"":""6"",""name"":""Giovanni"",""id"":""306976""},{""count"":""2"",""name"":""Goddess Garden"",""id"":""372509""},{""count"":""1"",""name"":""GuruNanda"",""id"":""519511""},{""count"":""33"",""name"":""Hask"",""id"":""797""},{""count"":""3"",""name"":""Herbacin"",""id"":""353636""},{""count"":""13"",""name"":""JASON"",""id"":""305434""},{""count"":""1"",""name"":""L'Oreal Paris"",""id"":""359425""},{""count"":""22"",""name"":""Love, Beauty & Planet"",""id"":""521138""},{""count"":""25"",""name"":""Maui Moisture"",""id"":""520197""},{""count"":""3"",""name"":""Nature's Gate"",""id"":""357534""},{""count"":""3"",""name"":""Nature's Truth"",""id"":""457718""},{""count"":""14"",""name"":""OGX"",""id"":""377466""},{""count"":""4"",""name"":""ORS"",""id"":""454121""},{""count"":""4"",""name"":""Out Of Africa"",""id"":""368826""},{""count"":""1"",""name"":""Rainbow Light"",""id"":""308068""},{""count"":""2"",""name"":""Renpure"",""id"":""369758""},{""count"":""20"",""name"":""SheaMoisture"",""id"":""375906""},{""count"":""4"",""name"":""ShiKai"",""id"":""371815""},{""count"":""6"",""name"":""Simple"",""id"":""365020""},{""count"":""1"",""name"":""Swisspers"",""id"":""369780""},{""count"":""3"",""name"":""Yardley of London"",""id"":""367315""},{""count"":""3"",""name"":""Yes to Cucumbers"",""id"":""308318""},{""count"":""1"",""name"":""Yes to Tomatoes"",""id"":""308317""}],""type"":""multi-select"",""attrName"":""Brand""}]}";
            string Cat12SkinTypes = @"{""refinements"":[{""values"":[{""count"":""11"",""name"":""All Skin Types"",""id"":""2999951146""},{""count"":""1"",""name"":""Combination"",""id"":""2999951147""},{""count"":""18"",""name"":""Dry"",""id"":""2999951152""},{""count"":""81"",""name"":""Normal"",""id"":""2999951154""},{""count"":""2"",""name"":""Oily"",""id"":""2999951144""},{""count"":""14"",""name"":""Sensitive"",""id"":""2999951148""}],""type"":""multi-select"",""attrName"":""Skin Type""}]}";
            string Cat12HairType = @"{""refinements"":[{""values"":[{""count"":""3"",""name"":""Chemically Treated hair"",""id"":""2999951395""},{""count"":""1"",""name"":""Coarse"",""id"":""2999951384""},{""count"":""3"",""name"":""Curly"",""id"":""2999951408""},{""count"":""30"",""name"":""Damaged"",""id"":""2999951403""},{""count"":""19"",""name"":""Dry"",""id"":""2999951497""},{""count"":""3"",""name"":""Fine"",""id"":""2999951368""},{""count"":""12"",""name"":""Frizzy"",""id"":""2999951383""},{""count"":""39"",""name"":""Normal"",""id"":""2999951393""},{""count"":""6"",""name"":""Thick"",""id"":""2999951385""},{""count"":""1"",""name"":""Thin"",""id"":""2999951361""}],""type"":""multi-select"",""attrName"":""Hair Type""}]}";
            string Cat12Concern = @"{""refinements"":[{""values"":[{""count"":""3"",""name"":""Acne"",""id"":""2999951124""},{""count"":""1"",""name"":""Cellulite"",""id"":""2999951141""},{""count"":""4"",""name"":""Clogged Pores"",""id"":""2999951132""},{""count"":""1"",""name"":""Digestive Support"",""id"":""2999951443""},{""count"":""4"",""name"":""Dull"",""id"":""5000017952""},{""count"":""1"",""name"":""Energy Support"",""id"":""2999951452""},{""count"":""6"",""name"":""Fine Lines & Wrinkles"",""id"":""5000000741""},{""count"":""1"",""name"":""Heart Health"",""id"":""2999951490""},{""count"":""1"",""name"":""Hyperpigmentation"",""id"":""5000017971""},{""count"":""1"",""name"":""Immune Support"",""id"":""2999951489""},{""count"":""1"",""name"":""Itchy Skin"",""id"":""5000017962""},{""count"":""6"",""name"":""Loss of Firmness"",""id"":""2999951139""},{""count"":""1"",""name"":""Prostate Health"",""id"":""2999951382""},{""count"":""1"",""name"":""Redness & Sensitivity"",""id"":""5000001322""},{""count"":""1"",""name"":""Rosacea"",""id"":""5000017976""},{""count"":""2"",""name"":""Scars"",""id"":""2999951151""},{""count"":""1"",""name"":""Sun Protection"",""id"":""2999951149""},{""count"":""3"",""name"":""Uneven"",""id"":""5000017959""}],""type"":""multi-select"",""attrName"":""Concern""}]}";
            string Cat12SPF = @"{""refinements"":[{""values"":[{""count"":""1"",""name"":""15"",""id"":""5000011104""},{""count"":""6"",""name"":""30"",""id"":""5000011107""},{""count"":""2"",""name"":""35"",""id"":""5000011108""},{""count"":""1"",""name"":""45"",""id"":""5000017967""},{""count"":""2"",""name"":""50"",""id"":""5000011109""},{""count"":""1"",""name"":""70"",""id"":""5000011111""}],""type"":""multi-select"",""attrName"":""SPF""}]}";
            string Cat12Form = @"{""refinements"":[{""values"":[{""count"":""3"",""name"":""Balm"",""id"":""3000007572""},{""count"":""19"",""name"":""Bars"",""id"":""3000007661""},{""count"":""30"",""name"":""Cream"",""id"":""3000007703""},{""count"":""8"",""name"":""Gels"",""id"":""2999951500""},{""count"":""8"",""name"":""Liquid"",""id"":""5000000970""},{""count"":""21"",""name"":""Lotion"",""id"":""3000007714""},{""count"":""19"",""name"":""Oils"",""id"":""2999951453""},{""count"":""4"",""name"":""Roll-on"",""id"":""2999951380""},{""count"":""4"",""name"":""Serum"",""id"":""3000007688""},{""count"":""8"",""name"":""Spray"",""id"":""3000007707""},{""count"":""3"",""name"":""Stick"",""id"":""3000007690""},{""count"":""1"",""name"":""Tablets"",""id"":""3000007709""}],""type"":""multi-select"",""attrName"":""Form""}]}";
            string Cat12MultipleFilters = @"[{""values"":[{""count"":""10"",""name"":""Body"",""id"":""5000017702""},{""count"":""2"",""name"":""Face"",""id"":""5000017953""}],""type"":""multi-select"",""attrName"":""Use""},{""values"":[{""count"":""5"",""name"":""Fragrance Free"",""id"":""2999951328""},{""count"":""48"",""name"":""Scented"",""id"":""2999951399""},{""count"":""4"",""name"":""Unscented"",""id"":""2999951359""}],""type"":""multi-select"",""attrName"":""Fragrance""},{""values"":[{""count"":""4"",""name"":""Floral"",""id"":""2999951145""},{""count"":""1"",""name"":""Fruit"",""id"":""2999951129""}],""type"":""multi-select"",""attrName"":""Scent Family""},{""values"":[{""count"":""32"",""name"":""0"",""id"":""5000024415""}],""type"":""multi-select"",""attrName"":""Days Supply""},{""values"":[{""count"":""1"",""name"":""Men"",""id"":""2999951505""},{""count"":""27"",""name"":""Unisex"",""id"":""5000017705""},{""count"":""162"",""name"":""Women"",""id"":""2999951153""}],""type"":""multi-select"",""attrName"":""Gender""},{""values"":[{""count"":""1"",""name"":""Red"",""id"":""5000013778"",""url"":""/images/adaptive/haircolorswatches/Red.png""},{""count"":""1"",""name"":""Brown"",""id"":""5000013770"",""url"":""/images/adaptive/haircolorswatches/Brown.png""}],""type"":""multi-select"",""attrName"":""Hair Color Family""}]";
            string Cat12SpecialFeature = @"{""refinements"":[{""values"":[{""count"":""16"",""name"":""Alcohol-Free"",""id"":""2999951474""},{""count"":""4"",""name"":""Clinically Proven"",""id"":""5000017703""},{""count"":""38"",""name"":""Cruelty Free"",""id"":""2999951423""},{""count"":""10"",""name"":""Dermatologist Recommended"",""id"":""5000017950""},{""count"":""11"",""name"":""Dye-Free"",""id"":""2999951449""},{""count"":""55"",""name"":""Gluten Free"",""id"":""2999951492""},{""count"":""10"",""name"":""Hypoallergenic"",""id"":""2999951481""},{""count"":""13"",""name"":""Natural"",""id"":""2999951488""},{""count"":""19"",""name"":""No Animal Derived Ingredients"",""id"":""2999951469""},{""count"":""110"",""name"":""No Animal Testing"",""id"":""2999951495""},{""count"":""50"",""name"":""No Artificial Colors"",""id"":""2999951483""},{""count"":""65"",""name"":""No Phthalates"",""id"":""2999951422""},{""count"":""1"",""name"":""No Preservatives"",""id"":""2999951480""},{""count"":""6"",""name"":""Non-Acnegenic"",""id"":""2999951161""},{""count"":""10"",""name"":""Non-Comedogenic/Won't Clog Pores"",""id"":""2999951430""},{""count"":""16"",""name"":""Non-GMO"",""id"":""2999951367""},{""count"":""11"",""name"":""Oil-Free"",""id"":""2999951479""},{""count"":""68"",""name"":""Organic"",""id"":""2999951417""},{""count"":""136"",""name"":""Paraben Free"",""id"":""2999951426""},{""count"":""12"",""name"":""PH Balance"",""id"":""5000017957""},{""count"":""2"",""name"":""Soy Free"",""id"":""2999951371""},{""count"":""83"",""name"":""Sulfate Free"",""id"":""2999951167""},{""count"":""35"",""name"":""Vegan"",""id"":""2999951405""},{""count"":""9"",""name"":""Vegetarian"",""id"":""2999951409""},{""count"":""13"",""name"":""Water Resistant"",""id"":""2999951165""}],""type"":""multi-select"",""attrName"":""Special Feature""}]}"; ;
            string Cat12MoreOptions = @"{""values"":[{""count"":""318"",""name"":""Ship to Store"",""id"":""2999951740""},{""count"":""95"",""name"":""Auto-Reorder & Save"",""id"":""3000009396""},{""count"":""7"",""name"":""Luxury Brand"",""id"":""5000019582""},{""count"":""13"",""name"":""FSA Item"",""id"":""4294840275""}],""type"":""multi-select"",""attrName"":""More Options""}";
            string Category12DealsandPromotions = @"{""values"":[{""count"":""26"",""name"":""Bonus Points"",""id"":""4294815983""},{""count"":""30"",""name"":""Coupon Available"",""id"":""2999952769""},{""count"":""129"",""name"":""Sales & Offers"",""id"":""4294896499""}],""type"":""multi-select"",""attrName"":""Deals & Promotions""}";

            FullFilter(Category12ProductTypes, CategoryID);
            FullFilter(Category12Brands, CategoryID);
            FullFilter(Cat12SkinTypes, CategoryID);
            FullFilter(Cat12HairType, CategoryID);
            FullFilter(Cat12Concern, CategoryID);
            FullFilter(Cat12SPF, CategoryID);
            FullFilter(Cat12Form, CategoryID);
            FullFilter(Cat12SpecialFeature, CategoryID);

            MultipleItemFilter(Cat12MultipleFilters, CategoryID);

            SingleItemFilter(Cat12MoreOptions, CategoryID);
            SingleItemFilter(Category12DealsandPromotions, CategoryID);
        }

        private static void FullFilter(string FullFilter, int CategoryID)
        {
            var filterRoot = JsonConvert.DeserializeObject<FilterRoot>(FullFilter);

            foreach (var element in filterRoot.refinements)
            {
                foreach (var item in element.values)
                {
                    var filtervalue = new FilterValue
                    {
                        Id = item.id,
                        CategoryID = CategoryID,
                        Count = item.count,
                        FilterName = element.attrName,
                        Name = item.name
                    };

                    DBHelper.Insert(filtervalue);
                }

            }
        }

        private static void SingleItemFilter(string SingleItemFilter, int CategoryID)
        {
            var singleItemFIlter = JsonConvert.DeserializeObject<Refinement>(SingleItemFilter);
            foreach (var item in singleItemFIlter.values)
            {
                var filtervalue = new FilterValue
                {
                    Id = item.id,
                    CategoryID = CategoryID,
                    Count = item.count,
                    FilterName = singleItemFIlter.attrName,
                    Name = item.name
                };
                DBHelper.Insert(filtervalue);
            }
        }

        private static void MultipleItemFilter(string MultipleFilters, int CategoryID)
        {
            var MultiItemFilter = JsonConvert.DeserializeObject<List<MultiFilterObject>>(MultipleFilters);
            foreach (var element in MultiItemFilter)
            {
                foreach (var item in element.values)
                {
                    var filtervalue = new FilterValue
                    {
                        Id = item.id,
                        CategoryID = CategoryID,
                        Count = item.count,
                        FilterName = element.attrName,
                        Name = item.name
                    };
                    DBHelper.Insert(filtervalue);
                }
            }
        }

        public static void ScrapeCategoryFilter()
        {
            var prodList = DBHelper.GetList<ProductInfo>("", "Where Processed = 0");
            Console.WriteLine("Products To Be Processed = " + prodList.Count);
            int Count = prodList.Count;

            //foreach (var element in prodList)
            //{
            //    Count = ExcractCategories(element, Count);
            //}
            Parallel.ForEach(prodList, new ParallelOptions { MaxDegreeOfParallelism = 6 }, element =>
            {
                ExcractCategories(element, ref Count);
            });


        }

        private static void ExcractCategories(ProductInfo element, ref int Count)
        {
            string html = string.Empty;
            while (string.IsNullOrWhiteSpace(html))
            {
                try
                { html = ExtractHtml(element); }
                catch (Exception ex)
                { }
            }
            try
            {
                html = html.Split(new string[] { "productInfo\":" }, StringSplitOptions.None)[1];
                html = html.Split(new string[] { "onlineRedemption" }, StringSplitOptions.None)[0];
                html = html.Trim('\"').Trim(',');
                var rootob = JsonConvert.DeserializeObject<RootObjectDetails>(html);
                element.color = rootob.color;
                element.tier1Category = rootob.tier1Category;
                element.tier2Category = rootob.tier2Category;
                element.tier3Category = rootob.tier3Category;
                element.brandName = rootob.brandName;
                element.Processed = true;
                DBHelper.Update(element, "Where ID = " + element.Id, null);
                Console.WriteLine("Products to Be Processed = " + --Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        private static string ExtractHtml(ProductInfo element)
        {
            var url = "https://www.walgreens.com" + element.productURL;
            string html = HtmlHelper.GetHtml(url).GetAwaiter().GetResult();
            return html;
        }

        private static void ScrapeData()
        {
            foreach (var category in DBHelper.GetList<Category>("", "Where Processed = 0"))
            {
                Console.WriteLine("Current Category : " + category.Name);
                string u = category.Link;
                string h = HtmlHelper.GetHtml(u).GetAwaiter().GetResult();
                int pageCount = 0;
                try
                {
                    string PageCount = h.Split(new string[] { "\"totalNumPages\":" }, StringSplitOptions.None)[1].Split(',')[0].Replace("\"", "");
                    pageCount = int.Parse(PageCount);
                }
                catch (Exception ex)
                {
                }

                Console.WriteLine("Total Pages :" + pageCount);
                for (int i = 0; i <= pageCount; i++)
                {
                    Console.WriteLine("Scrapping For Page: " + i);
                    string url, html;
                    try
                    {
                        TryGetHtml(category, i, out url, out html);
                        System.Threading.Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        TryGetHtml(category, i, out url, out html);
                    }
                    Console.WriteLine("Url : " + url);
                    var Products = JsonConvert.DeserializeObject<List<RootObject>>(html);
                    Console.WriteLine("Products Count : " + Products.Count);
                    foreach (var element in Products)
                    {
                        element.productInfo.CategoryID = category.ID;
                        var priceInfo = element.productInfo.priceInfo;
                        int priceInfoID = DBHelper.GetScaler((QueryMaker.InsertQuery(priceInfo) + ";SELECT SCOPE_IDENTITY();"));
                        element.productInfo.priceInfoID = priceInfoID;
                        int ProductID = DBHelper.GetScaler(QueryMaker.InsertQuery(element.productInfo) + ";SELECT SCOPE_IDENTITY();");
                        if (element.productInfo.concern != null)
                        {
                            foreach (var c in element.productInfo.concern)
                            {
                                c.ProductID = ProductID;
                                DBHelper.Insert(c);
                            }
                        }
                    }

                }


                category.Processed = true;
                DBHelper.Update(category, "Where ID = " + category.ID, null);
            }
        }

        private static void TryGetHtml(Category category, int i, out string url, out string html)
        {
            url = string.Empty;
            if (i == 0)
            {
                url = category.Link.Replace("No=24&", "");
            }
            else
            {
                url = category.Link.Replace("No=24&", $"No={i * 24}");
            }
            html = HtmlHelper.GetHtml(url).GetAwaiter().GetResult();
            try
            {
                html = html.Split(new string[] { "\"productList\":" }, StringSplitOptions.None)[1].Split(new string[] { ",\"filters\"" }, StringSplitOptions.None)[0];
            }
            catch (IndexOutOfRangeException ex)
            {
                url = category.Link.Replace("No=24&", "") + $"&No={i * 24}";
                html = HtmlHelper.GetHtml(url).GetAwaiter().GetResult();
                html = html.Split(new string[] { "\"productList\":" }, StringSplitOptions.None)[1].Split(new string[] { ",\"filters\"" }, StringSplitOptions.None)[0];
            }
        }


        public static void ExportToExcel()
        {
            try
            {
                foreach (var element in DBHelper.GetList<Category>("", "Where ID NOT IN (1,2,3,7,13)"))
                {

                    string query = $@"
  SELECT 
   CAST(Concern  AS VARCHAR(2000)) as Concern,
   Category1,  Category2,  Category3, Category4,
   SkinType, ProductType, ScentFamily, ColorFamily,
   Form, Usees, Brand, Age, Gender, SpecialFeature,
   Count, Fragrance, HairType, DealsAndPromotions,
   HairColor, MoreOptions, DaysSupply, FoundationColor,
   SPF, ProductName, Link, Size, 
   CAST(Price AS VARCHAR(1000)) AS Price, 
   CAST(ActiveIngredients AS VARCHAR(1000)) as ActiveIngredients, 
   value as InActiveIngredients  FROM (
  SELECT 
  ISNULL ( STUFF(( SELECT ',' + CAST(concern_message AS varchar) FROM Concern C  where C.ProductID = P.ID  FOR XML PATH('')), 1 ,1, '') , '')  AS Concern, 
   tier1Category as Category1, 
   tier2Category as Category2, 
   tier3Category as Category3,
   beautyCategoryName as Category4,
   SkinType_Filter As SkinType,
   ProductType_Filter as ProductType,
   ScentFamily_Filter as ScentFamily,
	ColorFamily_Filter as ColorFamily,
	Form_Filter as Form,
	Use_Filter as Usees,
	Brand_Filter as Brand,
	Age_Filter as Age,
	Gender_Filter as Gender,
	SpecialFeature_Filter as SpecialFeature,
	Count_Filter as Count,
	Fragrance_Filter as Fragrance,
	HairType_Filter as HairType,
	DealsAndPromotions_Filter as DealsAndPromotions,
	HairColorFamily_Filter as HairColor,
	MoreOptions_Filter as  MoreOptions,
	DaysSupply_Filter as DaysSupply,
	FoundationColor_Filter as  FoundationColor,
	SPF_Filter as SPF,
  productDisplayName as ProductName, 
  
  'https://www.walgreens.com' + productURL as Link,
  (SELECT TOP 1 * FROM STRING_SPLIT(productSize, ' ') M) as Size,
   REPLACE(PR.regularPrice, '$', '') as Price, 	
  ingredientName as ActiveIngredients,
  inactiveIngredients as InActiveIngredients
   FROM ProductInfo P 
   LEFT JOIN PriceInfo PR ON Pr.ID = P.priceInfoID
   Where P.CategoryID = {element.ID}
   ) ProductLinks  OUTER APPLY String_split( ProductLinks.InActiveIngredients, ',')

 ";


                    string FileName = HttpUtility.HtmlDecode( element.Name ).Replace(" ", "").Replace("&", "And");

                    var list = DBHelper.QueryList(query);
                    Console.WriteLine("Items : " + list.Count);
                    string filelocation = $@"D:\Export\{FileName}.xlsx";

                    Console.WriteLine("Creating Excel Export File at " + filelocation);
                    ExcelExport(FileName, list, filelocation);
                    Console.WriteLine("Created File");
                }

            }
            catch (Exception ex)
            {

            }
        }

        private static void ExcelExport(string FileName, List<Dictionary<string, string>> list, string filelocation)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filelocation + ";Extended Properties='Excel 12.0 XML;HDR=YES;'";
            OleDbConnection Cn = new OleDbConnection(connectionString);
            Cn.Open();

            DataTable dtSheets = Cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            var k = dtSheets.Select().ToList().Exists(sheet => sheet["TABLE_NAME"].ToString() == FileName);
            if (!k)
            {
                var cmd = Cn.CreateCommand();
                string tablQuery = $"CREATE TABLE {FileName}  (";
                foreach (var item in list.First().Keys)
                {
                    tablQuery += "[" + item + "]" + " MEMO, ";
                }
                tablQuery = tablQuery.Trim(' ').Trim(',') + ")";
                cmd.CommandText = tablQuery;
                cmd.ExecuteNonQuery();
            }


            foreach (var m in list)
            {
                string Query = $"INSERT INTO [{FileName}] (";
                string Values = ") VALUES (";
                foreach (var item in m)
                {
                    Query += "[" + item.Key + "],";
                    Values += $"'{HttpUtility.HtmlDecode( item.Value.Replace("'", "''") )}',";
                }
                Query = Query.Trim(',');
                Query += Values.Trim(',') + ");";
                OleDbCommand Com = new OleDbCommand(Query, Cn);
                Com.ExecuteNonQuery();

            }
            Cn.Close();
        }




        //foreach (var element in  Products.productInfo)
        //{
        //    Console.WriteLine(element.productName);
        //}


        //List<Product> products = DBHelper.GetList<Product>().Where(x => x.Processed == true).ToList();

        //foreach (var p in products.Where(x=>x.Price.Contains("/")).ToList())
        //{
        //    //p.Price = HttpUtility.HtmlDecode(p.Price);
        //    if (p.Price.Contains("/"))
        //    {
        //        p.Price = p.Price.Split('/').Last().Trim('.');
        //    }
        //    DBHelper.Update(p, "Where ID = " + p.ID,null);

        //}



        //while (DBHelper.GetList<Product>().Where(x => x.Processed == false).ToList().Count > 0)
        //{
        //    List<Product> products = DBHelper.GetList<Product>().Where(x => x.Processed == false).ToList();
        //    Console.WriteLine("Current Count : " + products.Count);
        //    Parallel.ForEach(products, new ParallelOptions { MaxDegreeOfParallelism = 6 }, product =>
        //    {
        //        ExtractProductData(product);
        //        Console.WriteLine("Current Count : " + DBHelper.GetList<Product>().Where(x => x.Processed == false).ToList().Count);
        //    });

        //    foreach (var product in products)
        //    {
        //        ExtractProductData(product);
        //        Console.WriteLine("Current Count : " + --Count);
        //    }

        //}

        //ExtractAllProducts();

        //foreach (var cat in Categories)
        //{
        //    ExtractAllProducts(cat);
        //}





        public static void ExtractAllProducts()
        {
            var category = DBHelper.Get<Category>("", "Where ID = 12");
            var doc = HtmlHelper.GetLazyLoadedPage(category.Link, 100);

            //var list = doc.QuerySelectorAll(".wag-prod-title a");
            var pageCount = doc.QuerySelectorAll(".pagination span.sr-only").FirstOrDefault().InnerHtml;
            var k = pageCount.Split(new string[] { "-->" }, StringSplitOptions.None);
            var count = k.Where(x => !string.IsNullOrWhiteSpace(x)).LastOrDefault();
            if (count != null)
            {
                count = count.Split(new string[] { "<!--" }, StringSplitOptions.None)[0];
            }

            int.TryParse(count, out int Counter);

            if (Counter > 0)
            {

                for (int i = 0; i < Counter; i++)
                {
                    try
                    {
                        Console.WriteLine("Iteration :" + i);
                        string URL = string.Empty;

                        if (i == 0)
                        {
                            URL = $"https://www.walgreens.com/store/store/category/productlist.jsp?N=360325&Eon=360325";

                        }
                        else
                        {
                            URL = $"https://www.walgreens.com/store/store/category/productlist.jsp?No={i * 24}&N=360325&Eon=360325";

                        }
                        Console.WriteLine(URL);
                        var d = HtmlHelper.GetLazyLoadedPage(URL, 100);
                        var l = doc.QuerySelectorAll(".wag-prod-title a");
                        Console.WriteLine("Products Found :" + l.Count);
                        foreach (var item in l)
                        {
                            Product p = new Product
                            {
                                Link = item.Attributes.FirstOrDefault(x => x.Name == "href").Value,
                                Name = item.InnerText,
                                CategoryID = category.ID
                            };

                            DBHelper.Insert(p);
                        }
                        Console.WriteLine("Iteration :" + i + " Completed");
                    }
                    catch (Exception ex)
                    {
                    }
                }


                //Parallel.For(0, Counter, new ParallelOptions { MaxDegreeOfParallelism = 6}, i=> {

                //});
            }


        }


        public static void ExtractProductData(Product product)
        {
            try
            {
                string url = product.Link;
                var doc = HtmlHelper.GetLazyLoadedPage(url, 100);

                product.Name = HttpUtility.HtmlDecode(doc.QuerySelectorAll("#productTitle").FirstOrDefault().InnerText);
                product.Size = doc.QuerySelectorAll("#productSizeCount").FirstOrDefault().InnerText;

                if (!string.IsNullOrWhiteSpace(product.Size))
                {
                    string size = product.Size.Split(' ')[0];
                    if (product.Size.Contains("ea"))
                    {
                        size = string.Empty;
                    }
                    size = size.Trim();
                    product.SizeInML = size;
                }

                var m = doc.QuerySelectorAll(".wag-unit-price-position ").FirstOrDefault();//.InnerHtml.Split(' ').Where(x => x.Contains("$")).FirstOrDefault();
                if (m == null)
                {
                    m = doc.QuerySelectorAll("#unit-price").FirstOrDefault();//;.InnerText;//.InnerHtml.Split(' ').Where(x=>x.Contains("$")).FirstOrDefault();
                }

                //var t = m.InnerText.Split(new string[] { ">" }, StringSplitOptions.None);

                if (m != null)
                {
                    product.UnitPrice = Regex.Replace(m.InnerText, "<!--[^>]*-->", "");

                }
                else
                {
                    product.UnitPrice = "";
                }

                //<sup>$</sup><span>26</span><sup>99</sup>
                //.$26.99
                try
                {
                    product.Price = doc.QuerySelectorAll(".product__price").FirstOrDefault().InnerHtml
                       .Replace("<span>", "")
                       .Replace("</span>", "")
                       .Replace("<sup>", ".")
                       .Replace("</sup>", "")
                       .Trim('.');

                }
                catch (Exception ex)
                {
                }
                if (!string.IsNullOrWhiteSpace(product.Price))
                {
                    product.Price = HttpUtility.HtmlDecode(product.Price);
                    if (product.Price.Contains("/"))
                    {
                        product.Price = product.Price.Split('/').Last().Trim('.');
                    }
                }


                //  var k2 = doc.QuerySelectorAll(".product__price").FirstOrDefault(); 
                var categoryLinks = doc.QuerySelectorAll("#breadcrumbs-desktop a");
                product.ProductCategory = string.Empty;
                foreach (var element in categoryLinks)
                {
                    product.ProductCategory += element.InnerText + ",";
                }
                product.ProductCategory = HttpUtility.HtmlDecode(product.ProductCategory.Trim(','));
                try
                {
                    product.Ingredients = Regex.Replace(doc.QuerySelectorAll("#Description-2").FirstOrDefault().InnerText, "<!--[^>]*-->", "");

                }
                catch (Exception ex)
                {
                    product.Ingredients = string.Empty;
                }
                product.BrandName = product.Name;
                product.Processed = true;
                DBHelper.Update(product, "Where ID = " + product.ID, null);
            }
            catch (Exception ex)
            {


            }
        }


    }
}
