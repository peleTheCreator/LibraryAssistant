using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAssistant.Core.Models.Responses.Errors
{
    public class ErrorModel
    {
        public string FieldName { get; set; }

        public string Message { get; set; }
    }
}
