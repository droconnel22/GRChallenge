using System.Collections.Generic;

namespace GuaranteedRate.Domain.Builders.Strategies
{
    public interface IProcessFileStrategy
    {
        void AddFilePlan(string filePath, char deliminator);

        IEnumerable<string[]> ReadAllFiles();
    }
}