namespace BMIWebApi.Exceptions
{
    public class NotValidMeasurementsException : Exception
    {
        public NotValidMeasurementsException(string? message) : base(message)
        {
        }
    }
}
