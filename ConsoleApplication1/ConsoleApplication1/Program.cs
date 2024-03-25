using AngleSharp;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Test();
        }

        public static async Task Test()
        {
            var config = Configuration.Default.WithDefaultCookies();
            var address = "https://www.ozon.ru/product/pivo-bezalkogolnoe-baltika-0-svetloe-450-ml-287342381";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);
            var cells = document.Body.TextContent;
        }
    }
}