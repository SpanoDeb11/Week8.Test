using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week8.Esercitazione.Core.Entities
{
    public class ResultBL
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ResultBL(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }
    }
}
