using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
