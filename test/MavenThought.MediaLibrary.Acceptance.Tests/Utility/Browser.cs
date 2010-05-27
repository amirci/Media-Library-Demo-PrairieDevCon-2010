using System;
using System.IO;
using System.Reflection;
using Cassini;
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
        private const string ApplicationURL = "http://localhost:8091";

        /// <summary>
        /// Browser used or the tests
        /// </summary>
        public static IE Instance
        {
            get { return (IE) FeatureContext.Current["browser"]; }
            
            set { FeatureContext.Current["browser"] = value;  }
        }

        /// <summary>
        /// Get the web server
        /// </summary>
        protected static Server WebServer { get; private set; }

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
            //var physicalPath = @"C:\Workbench\MavenThought\Presentations\PrairieDevCon 2010\BDD\Git MediaLibrary\main\MavenThought.MediaLibrary.WebClient";
            const string relativePath = @"..\..\..\..\main\MavenThought.MediaLibrary.WebClient";
            
            // var physicalPath = string.Format("{0}{1}{2}", Directory.GetCurrentDirectory(), Path.DirectorySeparatorChar, relativePath);
            var physicalPath = @"C:\Workbench\MavenThought\Media-Library-Demo-PrairieDevCon-2010\main\MavenThought.MediaLibrary.WebClient";
            
            WebServer = new Server(8091, "/", physicalPath);

            WebServer.Start();

            Instance = new IE(ApplicationURL);
        }

        /// <summary>
        /// Shutdown the browser
        /// </summary>
        public static void ShutdownBrowser()
        {
            Instance.Close();

            WebServer.Stop();
        }
    }
}