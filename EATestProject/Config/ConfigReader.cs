using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace EAAutoFramework.Config
{
    public static class ConfigReader
    {

        public static void SetFrameworkSettnigs()
        {
            XPathItem aut;
            XPathItem buildName;
            XPathItem testType;
            XPathItem isLog;
            XPathItem isReport;
            XPathItem logPath;

            string strFileName = Environment.CurrentDirectory.ToString() + "\\Config\\GlobalConfig.xml";
            FileStream stream = new FileStream(strFileName, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            //Get XML  Details and pass it in XPathItem type variables
            string xmlPath = "EAAutoFramework/RunSettings";
            aut = navigator.SelectSingleNode(xmlPath + "AUT");
            buildName = navigator.SelectSingleNode(xmlPath + "BuildName");
            testType = navigator.SelectSingleNode(xmlPath + "TestType");
            isLog = navigator.SelectSingleNode(xmlPath + "IsLog");
            isReport = navigator.SelectSingleNode(xmlPath + "IsReport");
            logPath = navigator.SelectSingleNode(xmlPath + "LogPath");

            //Set XML Details in the property to be used accross framework
            Settings.AUT = aut.Value.ToString();
            Settings.BuildName = buildName.Value.ToString();
            Settings.TestType = testType.Value.ToString();
            Settings.IsLog = isLog.Value.ToString();
            Settings.IsReporting = isReport.Value.ToString();
            Settings.LogPath = logPath.Value.ToString();

        }


    }
}
