using System.Net;

namespace BookMaster.Exception.ExceptionBase;
public class NotFoundException : BookMasterException
{
    public NotFoundException(string message) : base(message) { }

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
