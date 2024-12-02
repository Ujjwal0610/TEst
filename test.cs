using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Threading;

class PlayTrailerTest
{
    static void Main(string[] args)
    {
        var options = new EdgeOptions();
        IWebDriver driver = new EdgeDriver(options);

        try
        {
            // Navigate to the web application
            driver.Navigate().GoToUrl("https://manos-movieszone.netlify.app/");
            System.Threading.Thread.Sleep(2000);

            // Login process
            driver.FindElement(By.CssSelector(".loginScreen__getStarted")).Click();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("input[placeholder='Email']")).SendKeys("manos@gmail.com");
            driver.FindElement(By.CssSelector("input[placeholder='Password']")).SendKeys("testing123");
            driver.FindElement(By.CssSelector("button")).Click();
            System.Threading.Thread.Sleep(3000);

            // Locate and play a trailer
            IWebElement trailerButton = driver.FindElement(By.CssSelector(".movieCard__trailerButton")); // Example selector
            trailerButton.Click();
            Console.WriteLine("Trailer is playing...");

            // Wait for a few seconds to simulate watching the trailer
            System.Threading.Thread.Sleep(5000);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            // Close the browser
            driver.Quit();
            Console.WriteLine("Browser closed.");
        }
    }
}
