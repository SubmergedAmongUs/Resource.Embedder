namespace DotNetCore.Tests.Helper
{
    public static class WebTestHelper
    {
        /// <summary>
        /// Helper that sets up api server.
        /// </summary>
        /// <returns></returns>
        public static WebApplicationTestFactory SetupTestFactory(string relativePath)
             => new WebApplicationTestFactory(relativePath);
    }
}
