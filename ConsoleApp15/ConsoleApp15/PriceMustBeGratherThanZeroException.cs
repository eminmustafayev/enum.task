using System.Runtime.Serialization;

namespace ConsoleApp15
{
    [Serializable]
    internal class PriceMustBeGratherThanZeroException : Exception
    {
        public PriceMustBeGratherThanZeroException()
        {
        }

        public PriceMustBeGratherThanZeroException(string? message) : base(message)
        {
        }

        public PriceMustBeGratherThanZeroException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PriceMustBeGratherThanZeroException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}