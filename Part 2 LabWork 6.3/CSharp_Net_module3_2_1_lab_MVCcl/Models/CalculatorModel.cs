using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSharp_Net_module3_2_1_lab_MVCcl.Models
{

    public class CalculatorModel
    {
        [Required(ErrorMessage = "Title is required")]
        public int a { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public int b { get; set; }
        public string oper { get; set; }
        public int result { get; set; }
    }
}