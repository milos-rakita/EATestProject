using EAAutoFramework.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Extensions
{
    public static class WebDriverExtension
    {

        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri=> 
            {
                string state = dri.ExecuteJS("return document.readyState").ToString();
                return state == "complete";
            },10);
        }

        
        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var stopWach = Stopwatch.StartNew();
            while(stopWach.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj)) 
                {
                    break;
                }
            }
            
        }


        public static object ExecuteJS(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }


    }
}
