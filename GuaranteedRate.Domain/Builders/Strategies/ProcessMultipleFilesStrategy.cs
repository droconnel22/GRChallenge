using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GuaranteedRate.Domain.Builders.Strategies
{
    public class ProcessMultipleFilesStrategy : IProcessFileStrategy
    {
        private ICollection<Tuple<string, char>> filePlans;

        public ProcessMultipleFilesStrategy()
        {
            this.filePlans = new List<Tuple<string, char>>();
        }
        
        public void AddFilePlan(string filePath, char deliminator) => 
            this.filePlans.Add(new Tuple<string, char>(filePath, deliminator));

        public IEnumerable<string[]> ReadAllFiles()
        {
            if (filePlans.Count == 0) throw new InvalidOperationException("No files have been specified");
            var result = new List<string[]>();
            foreach (var filePlan in filePlans)
            {
                var interpretedOutput = 
                    File.ReadAllLines(filePlan.Item1)
                   .Select(ro => ro.Split(filePlan.Item2));
                if(interpretedOutput.Any(s => s.Length < 5))
                    throw new Exception("Read line does not contain all valid data");

                result.AddRange(interpretedOutput);
            }
            return result;
        }
}
            
}
