namespace CP.BLL.Exceptions
{
    public class TeamNotFoundException : Exception
    {
        public TeamNotFoundException()
        {

        }

        public TeamNotFoundException(string message)
            : base(message)
        {

        }
    }
}
