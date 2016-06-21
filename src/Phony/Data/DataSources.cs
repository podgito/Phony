using System;

namespace Phony.Data
{
    /// <summary>
    /// Class for discovering available data sources
    /// </summary>
    public static class DataSources
    {
        /// <summary>
        /// Gets first names
        /// </summary>
        public static Func<string> FirstNames
        {
            get
            {
                return new FirstNameGenerator().Generate;
            }
        }
    }
}