using Toogood.Saman.Transform.Model.Input;
using Toogood.Saman.Transform.Model.Target;

namespace Toogood.Saman.Transform.AppService
{
    public interface ITargetFileFactory
    {
        TargetFile CreateTargetFile(IInputFile inputFileBase);
    }
}