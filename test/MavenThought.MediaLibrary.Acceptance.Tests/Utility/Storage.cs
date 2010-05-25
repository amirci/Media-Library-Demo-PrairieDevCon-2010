using MavenThought.MediaLibrary.Domain;
using MavenThought.MediaLibrary.Storage.NHibernate;

namespace MavenThought.MediaLibrary.Acceptance.Tests.Utility
{
    /// <summary>
    /// Base class for movie library steps
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// Setup the library
        /// </summary>
        static Storage()
        {
            const string databaseFile = @"c:\temp\media_library.db";

            Instance = new StorageMediaLibrary(databaseFile);             
        }

        /// <summary>
        /// Gets the instance of the library
        /// </summary>
        public static IMediaLibrary Instance
        {
            get; private set;
        }
    }
}