using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICliente.ViewModels
{
    public class Result
    {
        public class ResultHttpRequest
        {
            public bool estado { get; set; }
            public int codigo { get; set; }
            public string descripción { get; set; }
            
        }
    }
}