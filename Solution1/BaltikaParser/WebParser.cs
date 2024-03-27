using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumUndetectedChromeDriver;
namespace Parser
{
 internal class WebParser
    {
        private UndetectedChromeDriver _driver;
        public WebParser()
        {
            Setup();
        }
        public void Setup()
        {
            var options = new ChromeOptions();
            //options.AddArguments("headless");                                     не работает
            _driver = UndetectedChromeDriver.Create(options,
                driverExecutablePath:
                @"chromedriver.exe");
            _driver.Manage().Window.Maximize();
        }
        public async Task<Dictionary<string, string>> ParseWb(string url)
        {
            _driver.GoToUrl(url);
            Dictionary<string, string> result = new Dictionary<string, string>();
            await Task.Delay(5000);

            _driver.FindElement(By.XPath("//button[@class='product-page__btn-detail j-wba-card-item j-wba-card-item-show j-wba-card-item-observe']")).Click();
            await Task.Delay(5000);

            var html = _driver.PageSource;
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var doc = await context.OpenAsync(req => req.Content(html));

            var descriptionElements = doc.Body.QuerySelectorAll("div.product-details .product-params__row");
            foreach (var element in descriptionElements)
            {
                string key = element.QuerySelector("th")?.TextContent;
                string value = element.QuerySelector("td")?.TextContent;
                Console.WriteLine($"Ключ: {key}");
                Console.WriteLine($"Значение: {value}");
                Console.WriteLine(new string('-', 30));
                result.Add(key, value);
            }

            var fullDescription = doc.Body.QuerySelector(".option__text").TextContent;
            result.Add("Описание", fullDescription);

            var images = doc.QuerySelectorAll("li img");
            foreach (var image in images)
            {
                Console.WriteLine(image.GetAttribute("src").Replace("c246x328", "big"));
            }

            return result;
        }
        
        
        public async Task<Dictionary<string, string>> ParseOzon(string url)
        {
            _driver.GoToUrl(url);
            Dictionary<string, string> result = new Dictionary<string, string>();
            await Task.Delay(5000);

            _driver.FindElement(By.XPath("//button[@class='product-page__btn-detail j-wba-card-item j-wba-card-item-show j-wba-card-item-observe']")).Click();
            await Task.Delay(5000);

            var html = _driver.PageSource;
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var doc = await context.OpenAsync(req => req.Content(html));

            var descriptionElements = doc.Body.QuerySelectorAll("div.product-details .product-params__row");
            foreach (var element in descriptionElements)
            {
                string key = element.QuerySelector("th")?.TextContent;
                string value = element.QuerySelector("td")?.TextContent;
                Console.WriteLine($"Ключ: {key}");
                Console.WriteLine($"Значение: {value}");
                Console.WriteLine(new string('-', 30));
                result.Add(key, value);
            }

            var fullDescription = doc.Body.QuerySelector(".option__text").TextContent;
            result.Add("Описание", fullDescription);

            var images = doc.QuerySelectorAll("li img");
            foreach (var image in images)
            {
                Console.WriteLine(image.GetAttribute("src").Replace("c246x328", "big"));
            }

            return result;
        }
    }
}