namespace Toogood.Saman.Transform.Model.Input
{
    public abstract class InputFileBase<T> : IInputFile
    {
        protected InputFileBase(string name, T type, string currency)
        {
            Name = name;
            Currency = currency;
            Type = type;
        }

        public string Name { get; private set; }

        public string Currency { get; protected set; }

        public T Type { get; protected set; }

        public abstract EnumFileFormat FileFormat { get; }

    }
}
