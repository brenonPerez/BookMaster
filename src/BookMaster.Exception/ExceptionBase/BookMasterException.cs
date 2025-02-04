namespace BookMaster.Exception.ExceptionBase;
public abstract class BookMasterException : SystemException
{
    protected BookMasterException(string message) : base(message) { }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
