using System;
using System.Collections.Generic;
using System.Linq;
using Toogood.Saman.Transform.Model.Input;

namespace Toogood.Saman.Transform.AppService
{
    public class TargetFileService : ITargetFileService
    {
        public CreateTargetfileResult WriteTargetFile(IEnumerable<IInputFile> inputFiles)
        {
            CreateTargetfileResult createTargetfileResult;
            try
            {
                var targetFileFactory = new TargetFileFactory();
                var targetFiles = inputFiles.Select(inputFile => targetFileFactory.CreateTargetFile(inputFile)).ToList();
                var csvFileHandler = new CsvFileHandler();
                csvFileHandler.CreateTargetFile(targetFiles);
                createTargetfileResult = new CreateTargetfileResult(true);
            }
            catch (Exception exception)
            {
                createTargetfileResult = new CreateTargetfileResult(false, exception.Message);
            }

            return createTargetfileResult;
        }
    }
}