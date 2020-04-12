using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.API.Extensions
{
    public static class ExceptionExtension
    {
        public static string GetInnerMessage(this Exception original)
        {
            if (original == null)
            {
                return null;
            }

            var ex = original;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            return ex.Message;
        }
    }
}
