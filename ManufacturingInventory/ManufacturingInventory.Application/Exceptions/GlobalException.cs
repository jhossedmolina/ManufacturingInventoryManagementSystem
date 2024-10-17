namespace ManufacturingInventory.Application.Exceptions
{
    public class GlobalException : Exception
    {
        public GlobalException()
        {
        }

        public GlobalException(string message) : base(message) {}
    }
}
