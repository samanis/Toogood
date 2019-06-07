namespace Toogood.Saman.Transform.Model.Input
{
    public interface IInputFile
    {
        string Name { get; }
        string Currency { get; }
        EnumFileFormat FileFormat { get; }
    }
}