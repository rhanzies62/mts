﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Dto
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            Success = true;
            ErrorMesssage = new List<string>();
        }
        public bool Success { get; set; }
        public List<string> ErrorMesssage { get; set; }
        public T DataResponse { get; set; }
    }
}
