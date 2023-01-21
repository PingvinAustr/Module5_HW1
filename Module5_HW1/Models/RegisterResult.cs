using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5_HW1.Models
{
    public class RegisterResult : Validation
    {
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
