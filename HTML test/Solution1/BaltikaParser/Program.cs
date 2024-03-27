using System.Threading.Tasks;
namespace Parser
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var parser = new WebParser();
            var dict = await parser.ParseWb("https://www.wildberries.ru/catalog/24825388/detail.aspx");
        }
    }
}
