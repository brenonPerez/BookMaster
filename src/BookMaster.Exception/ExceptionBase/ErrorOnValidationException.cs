﻿using System.Net;

namespace BookMaster.Exception.ExceptionBase;
public class ErrorOnValidationException : BookMasterException
{
    private readonly List<string> _errors;

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public ErrorOnValidationException(List<string> errors) : base(string.Empty)
    {
        _errors = errors;
    }

    public override List<string> GetErrors()
    {
        return _errors;
    }
}
