using System;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace MavenThought.MediaLibrary.Acceptance.Tests.Utility
{
    /// <summary>
    /// Steps related to browser operations
    /// </summary>
    public class Browser
    {
        /// <summary>
        /// Main URL for the application
        /// </summary>
        private const string ApplicationURL = "http://localhost:1591";

        /// <summary>
        /// Browser used or the tests
        /// </summary>
        public static IE Instance
        {
            get { return (IE) FeatureContext.Current["browser"]; }
            
            set { FeatureContext.Current["browser"] = value;  }
        }

        /// <summary>
        /// Go to a path in the application
        /// </summary>
        /// <param name="path">Path to go</param>
        public static void GoTo(string path)
        {
            Instance.GoTo(String.Format("{0}/{1}", ApplicationURL, path));  
            Instance.Refresh();          
        }

        /// <summary>
        /// Initialize the browser
        /// </summary>
        public static void InitializeBrowser()
        {
            Instance = new IE(ApplicationURL);
        }

        /// <summary>
        /// Shutdown the browser
        /// </summary>
        public static void ShutdownBrowser()
        {
            Instance.Close();
        }
    }
}