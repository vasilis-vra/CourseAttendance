namespace CourseAttendanceAPI.Exceptions
{
    public class InvalidModelException : Exception
    {
        public InvalidModelException()
        {
        }

        public InvalidModelException(string customMessage) : base(customMessage)
        {
        }
    }
}
