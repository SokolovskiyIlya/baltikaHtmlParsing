using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumUndetectedChromeDriver;
using AngleSharp.Scripting;
using AngleSharp.Html.Parser;

namespace ConsoleApplication1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var driver = Setup();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(
                 @"//button[@class='product-page__btn-detail j-wba-card-item j-wba-card-item-show j-wba-card-item-observe']")).Click();
            Thread.Sleep(5000);
            var html = driver.PageSource;
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var doc = await context.OpenAsync(req => req.Content(html));
            var descriptoin = doc.Body.QuerySelectorAll("div.product-details");
            var text = descriptoin.Select((m => m.TextContent));
            Console.WriteLine(text);
        }

        public static UndetectedChromeDriver Setup()
        {
            var options = new ChromeOptions();
            options.AddArguments(new List<string>()
            {
            });
            var driver = UndetectedChromeDriver.Create(options,
                driverExecutablePath: @"C:\Users\ISokolovskiy\Desktop\HTML test\Solution1\HtmlTester\chromedriver.exe");
            //driver.Manage().Window.Maximize();
            driver.GoToUrl("https://www.wildberries.ru/catalog/24825388/detail.aspx");
            return driver;

            // var options = new ChromeOptions();
            // options.AddArguments("--incognito");
            // var driver = new ChromeDriver(options);
            // driver.Navigate().GoToUrl("https://www.okeydostavka.ru/msk/pivo-baltika-0-bezalkogol-noe-0-5-0-45l-zh-b");
        }
    }
}