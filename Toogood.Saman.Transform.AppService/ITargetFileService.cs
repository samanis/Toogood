using System.Collections.Generic;
using Toogood.Saman.Transform.Model.Input;

namespace Toogood.Saman.Transform.AppService
{
    public interface ITargetFileService
    {
        CreateTargetfileResult WriteTargetFile(IEnumerable<IInputFile> inputFiles);
    }
}