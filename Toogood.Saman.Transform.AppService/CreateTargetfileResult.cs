namespace Toogood.Saman.Transform.AppService
{
    public class CreateTargetfileResult
    {
        public CreateTargetfileResult(bool succseed, string message)
        {
            Succseed = succseed;
            Message = message;
        }

        public CreateTargetfileResult(bool succseed)
        {
            Succseed = succseed;
        }

        public bool Succseed { get; private set; }
        public string Message { get; private set; }
    }
}