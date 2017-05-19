using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAVBusiness.Models
{
    public class ErrorLogModel
    {
        public long Id { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string Error { get; set; }
    
    }
}
