using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Payroll_Service
{
    public class EmployeeConfig
    {
        public List<EmployeeData> EmpList = new List<EmployeeData>();
        private SqlConnection con;
        private void Connection()
        {
            string connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = payroll_services; Trusted_Connection = true";
            con = new SqlConnection(connectionString);
        }
        public EmployeeData AddEmployee(EmployeeData obj)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("AddPayrollService", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", obj.Name);
                com.Parameters.AddWithValue("@Basic_pay", obj.Basic_pay);
                com.Parameters.AddWithValue("@StartDate", obj.StartDate);
                com.Parameters.AddWithValue("@gender", obj.gender);
                com.Parameters.AddWithValue("@phone", obj.phone);
                com.Parameters.AddWithValue("@Address", obj.Address);
                com.Parameters.AddWithValue("@Department", obj.Department);
                com.Parameters.AddWithValue("@Deduction", obj.Deduction);
                com.Parameters.AddWithValue("@Taxable_pay", obj.Taxable_pay);
                com.Parameters.AddWithValue("@IncomeTax_pay", obj.IncomeTax_pay);
                com.Parameters.AddWithValue("@Net_Pay", obj.Net_Pay);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                    return obj;
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int DeleteEmployee(int empId)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("DeletePayrollServices", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", empId);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                    return empId;
                else
                    return 0;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public EmployeeData UpdateEmployee(EmployeeData obj)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("UpdatePayrollServices", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Basic_pay", obj.Basic_pay);
                com.Parameters.AddWithValue("@Name", obj.Name);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                    return obj;
                else
                    return null;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public DataSet GetAllEmployees()
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("GetPayrollService", con);
                com.CommandType = CommandType.StoredProcedure;
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("GetPayrollService", this.con);
                adapter.Fill(dataSet, "employee_payroll");
                foreach (DataRow dr in dataSet.Tables["employee_payroll"].Rows)
                {
                    Console.WriteLine(dr["id"] + " " + dr["Name"] + " " + dr["Basic_pay"] + " " + dr["StartDate"] + " " + dr["gender"] + " " + dr["phone"] + " "
                     + dr["Address"] + " " + dr["Department"] + " " + dr["Deduction"] + " " + dr["Taxable_pay"] + " " + dr["IncomeTax_pay"] + " " + dr["Net_Pay"]);
                }
                con.Close();
                return dataSet;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Display()
        {
            foreach (var item in EmpList)
            {
                Console.WriteLine("\nName\tBasic_pay\t\tDate\tgender\n");
                Console.WriteLine(item.Name + "\t" + item.Basic_pay + "\t" + item.StartDate + "\t" + item.gender);
            }
        }
    }
}