using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phony.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class RandomFileLineReader
    {
        private readonly string filePath;
        private readonly Random random;
        const int FileLineCount = 999;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        public RandomFileLineReader(string filePath)
        {
            this.random = new Random();
            this.filePath = filePath;
        }

        /// <summary>
        /// Selects a random line in the file
        /// </summary>
        /// <returns></returns>
        protected string SelectRandomLine()
        {
            var lineNumber = NextRandomInt(FileLineCount);
            return File.ReadLines(filePath).Skip(lineNumber).Take(1).First();
        }

        private int NextRandomInt(int max)
        {
            return random.Next(0, max);
        }
    }
}
