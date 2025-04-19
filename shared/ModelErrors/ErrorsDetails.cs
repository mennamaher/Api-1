using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace shared.ModelErrors
{
    public class ErrorsDetails
    {
        public int statusCode { get; set; }
        public string ErrorMsg { get; set; }
        public override string ToString()
        {
           return JsonSerializer.Serialize(this);

        }
    }
}
