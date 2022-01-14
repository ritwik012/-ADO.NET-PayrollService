using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_Service
{
    public class EmployeeData

    {
        /* public int id { get; set; }*/
        public string Name { get; set; }
        public double Basic_pay { get; set; }
        public DateTime StartDate { get; set; }
        public char gender { get; set; }
        public string phone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public double Deduction { get; set; }
        public double Taxable_pay { get; set; }
        public double IncomeTax_pay { get; set; }
        public double Net_Pay { get; set; }
        /*public int DepId { get; set; }*/
    }
}