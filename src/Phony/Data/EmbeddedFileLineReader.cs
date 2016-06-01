using System;
using System.IO;
using System.Reflection;

namespace Phony.Data
{
    /// <summary>
    /// Read contents of an embedded resource
    /// </summary>
    public class EmbeddedFileLineReader
    {
        private const int fileLineCount = 1000;
        private Random random;
        private readonly string resourceName;

        /// <summary>
        /// Create a reader an embedded resource
        /// </summary>
        /// <param name="resourceName"></param>
        public EmbeddedFileLineReader(string resourceName)
        {
            random = new Random();
            this.resourceName = resourceName;
        }

        /// <summary>
        /// Return a random line from the embedded file
        /// </summary>
        /// <returns></returns>
        protected string SelectRandomLine()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Phony.Databases." + this.resourceName;
            
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var lineNumber = NextRandomInt(max: fileLineCount);
                for (int i = 0; i < lineNumber; i++)
                {
                    reader.ReadLine(); //skip lines
                }
                return reader.ReadLine();
                
            }
        }

        private int NextRandomInt(int max)
        {
            return random.Next(0, max);
        }
    }
}