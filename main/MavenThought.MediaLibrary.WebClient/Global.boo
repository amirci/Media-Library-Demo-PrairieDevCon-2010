import System.Web.Mvc
import MavenThought.MediaLibrary.WebClient.Controllers
import MavenThought.MediaLibrary.Storage.NHibernate
import MavenThought.MediaLibrary.Domain

component "HomeController", HomeController:
  @lifestyle = "transient"

component "MoviesController", MoviesController:
  @lifestyle = "transient"
  
component IMediaLibrary, StorageMediaLibrary:
  databaseFile = "C:/Documents and Settings/amirb/Local Settings/Temp/tmp132A.tmp"
