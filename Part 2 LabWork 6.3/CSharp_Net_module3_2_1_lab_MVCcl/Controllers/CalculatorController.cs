using CSharp_Net_module3_2_1_lab_MVCcl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp_Net_module3_2_1_lab_MVCcl.Controllers
{
    public class CalculatorController : Controller
    {
        private CalculatorModel calculator = new CalculatorModel();
        // GET: Calculator
        public ActionResult Index()
        {
            return View(calculator);
        }

        [HttpPost]
        public ActionResult Index(CalculatorModel calc)
        {
            try
            {
                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
                calc.result = proxy.add(calc.a, calc.b);
                switch (calc.oper)
                {
                    case "+":
                        calc.result = proxy.add(calc.a, calc.b);
                        break;
                    case "-":
                        calc.result = proxy.Sub(calc.a, calc.b);
                        break;
                    case "*":
                        calc.result = proxy.Mul(calc.a, calc.b);
                        break;
                    case "/":
                        calc.result = proxy.Div(calc.a, calc.b);
                        break;
                }

                ViewBag.rslt = calc.result.ToString();
                return PartialView("Result");
            }
            catch (Exception ex)
            {
                return PartialView(ex.Message);
            }

 
        }



    }
}