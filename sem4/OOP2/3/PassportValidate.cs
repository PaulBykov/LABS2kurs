using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public class PassportValidate 
    {
        [BelarusPassport]
        public string PassportNumber { get; set; }

        public PassportValidate(string s) {
            PassportNumber = s;
        }
    }
}
