using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Shared;

public record Error(string Code, string? Message = "")
{
    public static readonly Error None = new Error(string.Empty);
    public static readonly Error NullValue = new Error("Error.NullValue", "The requested value is null.");
}

public record ErrorWithDetails(string Code, string Message, IEnumerable<Error> Details) : Error(Code, Message);
