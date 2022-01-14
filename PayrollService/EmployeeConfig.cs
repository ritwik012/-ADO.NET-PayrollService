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
        public List<EmployeeData> GetAllEmployees()
        {
            Connection();
            SqlCommand com = new SqlCommand("GetPayrollService", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                    new EmployeeData
                    {
                        Name = Convert.ToString(dr["Name"]),
                        Basic_pay = Convert.ToDouble(dr["Basic_pay"]),
                        StartDate = Convert.ToDateTime(dr["Date"]),
                        gender = Convert.ToChar(dr["gender"]),
                        phone = Convert.ToString(dr["phone"]),
                        Address = Convert.ToString(dr["Address"]),
                        Department = Convert.ToString(dr["Department"]),
                        Deduction = Convert.ToDouble(dr["Deduction"]),
                        Taxable_pay = Convert.ToDouble(dr["Raxable_pay"]),
                        IncomeTax_pay = Convert.ToDouble(dr["IncomeTax_pay"]),
                        Net_Pay = Convert.ToDouble(dr["Net_pay"]),
                    }
                    );
            }
            return EmpList;
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