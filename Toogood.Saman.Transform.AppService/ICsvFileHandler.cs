using System.Collections.Generic;
using Toogood.Saman.Transform.Model.Target;

namespace Toogood.Saman.Transform.AppService
{
    public interface ICsvFileHandler
    {
        void CreateTargetFile(IEnumerable<TargetFile> targetFiles);
    }
}