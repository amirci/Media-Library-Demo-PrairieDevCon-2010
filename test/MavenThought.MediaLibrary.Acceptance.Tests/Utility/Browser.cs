using System;
using System.IO;
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
        /// Path to find the web application
        /// </summary>
        const string relativePath = @"main\MavenThought.MediaLibrary.WebClient";

        /// <summary>
        /// Port to use
        /// </summary>
        private const int Port = 8091;

        /// <summary>
        /// Main URL for the application
        /// </summary>
        private static readonly string ApplicationURL = string.Format("http://localhost:{0}", Port);

        /// <summary>
        /// Browser initialization
        /// </summary>
        static Browser()
        {
            WebServer = new Server(Port, "/", GetPhysicalPath());
        }

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

        /// <summary>
        /// Calculates the physical path for the web application
        /// </summary>
        /// <returns>A string with the path</returns>
        private static string GetPhysicalPath()
        {
            var dir = Directory.GetCurrentDirectory();

            var index = dir.IndexOf("test");

            dir = dir.Remove(index);

            return Path.Combine(dir, relativePath);
        }
    }
}