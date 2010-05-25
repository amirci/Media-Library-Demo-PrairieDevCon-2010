using MavenThought.MediaLibrary.Acceptance.Tests.PageObjects;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace MavenThought.MediaLibrary.Acceptance.Tests.Steps
{
    /// <summary>
    /// Steps related to movie
    /// </summary>
    public class MovieSteps
    {
        /// <summary>
        /// Setup the movies page
        /// </summary>
        public MovieSteps()
        {
            this.BrowsePage = new BrowseMoviesPage();
        }

        /// <summary>
        /// Gets the movies page
        /// </summary>
        protected BrowseMoviesPage BrowsePage { get; private set; }

        /// <summary>
        /// Checks the image for the case is empty
        /// </summary>
        [Then(@"the case for (.*) should be empty")]
        public void AssertCaseIsEmpty(string title)
        {
            this.BrowsePage.HasEmptyCase(title).Should().Be.True();
        }

        /// <summary>
        /// Checks the image for the case is empty
        /// </summary>
        [Then(@"the case for (.*) should not be empty")]
        public void AssertCaseIsNotEmpty(string title)
        {
            this.BrowsePage.HasEmptyCase(title).Should().Be.False();
        } 
    }
}