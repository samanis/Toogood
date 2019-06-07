using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using CsvHelper;
using Toogood.Saman.Transform.Model.Target;

namespace Toogood.Saman.Transform.AppService
{
    public class CsvFileHandler : ICsvFileHandler
    {
        public void CreateTargetFile(IEnumerable<TargetFile> targetFiles)
        {
            var directoryName = GetDirectoryName();
            using (var writer = new StreamWriter(directoryName))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(targetFiles);
            }
        }

        private static string GetDirectoryName()
        {
            var directoryName = ConfigurationManager.AppSettings["baseFolder"].ToLower() ??
                                throw new ArgumentNullException("Folder name is null or empty");
            return directoryName;
        }
    }
}