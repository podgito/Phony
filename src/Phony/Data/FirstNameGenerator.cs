namespace Phony.Data
{
    /// <summary>
    /// Generates
    /// </summary>
    public class FirstNameGenerator : EmbeddedFileLineReader // RandomFileLineReader
    {
        /// <summary>
        ///
        /// </summary>
        public FirstNameGenerator() : base("firstNames.txt")
        {
        }

        /// <summary>
        /// Generates a random name
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            return this.SelectRandomLine();
        }
    }

    /// <summary>
    /// PhonyGenerator extension methods
    /// </summary>
    public static class FirstNameGeneratorConfigurationExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="generatorConfig"></param>
        /// <returns></returns>
        public static string FirstName<TModel>(this PhonyGenerator<TModel> generatorConfig) where TModel : new()
        {
            return new FirstNameGenerator().Generate();
        }
    }
}