using System;

namespace Payroll_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter your Choice Number to Execute the Program Press- 1-Addition, 2-Delete, 3-Update, 4-View, 5-Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        EmployeeData data = new EmployeeData();
                        data.Name = "Rutwik";
                        data.Basic_pay = 89000.45;
                        data.StartDate = DateTime.Now;
                        data.gender = 'M';
                        data.phone = "7440922090";
                        data.Address = "Rewa";
                        data.Department = "HR";
                        data.Deduction = 567.34;
                        data.Taxable_pay = 34.23;
                        data.IncomeTax_pay = 10.23;
                        data.Net_Pay = 1000;
                        EmployeeConfig employeeConfig = new EmployeeConfig();
                        var result = employeeConfig.AddEmployee(data);
                        if (result != null)
                            Console.WriteLine("Data Got added Successfully");
                        else
                            Console.WriteLine("Provide Correct Data According to Coloumn");
                        break;
                    case 2:
                        flag = false;
                        break;
                }
            }
        }
    }
}