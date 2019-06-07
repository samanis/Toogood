using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Toogood.Saman.Transform.AppService;
using Toogood.Saman.Transform.Model.Input;

namespace Toogood.Saman.Transform.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var serviceProvider = BuildServiceProvider();

                var targetFileService = serviceProvider.GetService<ITargetFileService>();

                CreateTargetfileResult createTargetfileResult = targetFileService.WriteTargetFile(CreateInputFiles());

                if(!createTargetfileResult.Succseed)
                    throw new Exception(createTargetfileResult.Message);

                Console.WriteLine($"File created successful");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception happened {exception.Message}");
            }

            Console.WriteLine("Please press any key to exit");
            Console.ReadLine();
        }

        private static ServiceProvider BuildServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICsvFileHandler, CsvFileHandler>()
                .AddSingleton<ITargetFileService, TargetFileService>()
                .AddSingleton<ITargetFileFactory, TargetFileFactory>()
                .BuildServiceProvider();
            return serviceProvider;
        }

        private static IEnumerable<IInputFile> CreateInputFiles()
        {
            List<IInputFile> resultList = new List<IInputFile>();
            IInputFile customFormat = new CustomFormat("Custom Format","RRSP","C","BcdCode");
            resultList.Add(customFormat);
            IInputFile standardFormat = new StandardFormat("Standard",2,"CD", "123|AbcCode", DateTime.Now);
            resultList.Add(standardFormat);
            return resultList;
        }
    }
}
