using System.Threading.Tasks;
namespace Parser
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var parser = new WebParser();
            var wbDict = await parser.ParseWb(
                "https://www.wildberries.ru/catalog/24825388/detail.aspx");
            var ozonDict = await parser.ParseOzon(
                "https://www.ozon.ru/product/pivnoy-napitok-baltika-0-greypfrut-bezalkogolnoe-24-sht-h-0-33-l-banka-866130708/");
        }
    }
}
