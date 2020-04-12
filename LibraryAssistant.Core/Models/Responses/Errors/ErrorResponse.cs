﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAssistant.Core.Models.Responses.Errors
{
    public class ErrorResponse
    {
        public ErrorResponse() { }

        public ErrorResponse(ErrorModel error)
        {
            Errors.Add(error);
        }

        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();


    }
}
