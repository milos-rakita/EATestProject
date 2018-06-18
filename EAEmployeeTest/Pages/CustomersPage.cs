using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAEmployeeTest.Pages
{
    public class CustomersPage : BasePage
    {
        private IWebElement _customerSubMenu;
        private IWebElement _customersMenu;

        [FindsBy(How = How.Id, Using = "ui-accordion-adminAppMenu-header-2")]
        public IWebElement CustomersMenu { get => _customersMenu; set => _customersMenu = value; }

        [FindsBy(How = How.Id, Using = "ui-accordion-adminAppMenu-panel-2")]
        public IWebElement CustomerSubMenu { get => _customerSubMenu; set => _customerSubMenu = value; }



    }
}
