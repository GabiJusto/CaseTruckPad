using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Truckpad.Login.Teste
{
    class Program
    {
        static void Main(string[] args)
        {

            string resultadoLogin = string.Empty;

            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://tms.truckpad.com.br/entrar");

                var usuario = driver.FindElementById("user_email");
                var senha = driver.FindElementById("user_password");
                var btnEntrar = driver.FindElementByXPath("//input[@type='submit']");

                usuario.SendKeys("desenvolvedor@truckpad.com.br");
                senha.SendKeys("truckpad@caseQA2019");
                btnEntrar.Click();

                resultadoLogin = driver.FindElementByXPath("//div[@class='alert alert-danger']").Text;

                driver.GetScreenshot().SaveAsFile($@"print_login-{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}-{DateTime.Now.Second}.png", ScreenshotImageFormat.Png);

              //  Console.ReadLine();
            }
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Resultado  Login: {resultadoLogin}");
            Console.ReadLine();


            }
    }
}
