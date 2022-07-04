namespace CourseAttendanceAPI.Exceptions
{
    public class OperationFailedException : Exception
    {
        public OperationFailedException()
        {
        }

        public OperationFailedException(string customMessage) : base(customMessage)
        {
        }
    }
}
