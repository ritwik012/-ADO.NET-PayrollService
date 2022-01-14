using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Payroll_Service
{
    public class EmployeeConfig
    {
        private SqlConnection con;
        private void Conncection()
        {
            string connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = payroll_services; Trusted_Connection = true";
            con = new SqlConnection(connectionString);
        }
        public bool AddEmployee(EmployeeData obj)
        {
            Conncection();
            SqlCommand com = new SqlCommand("AddPayRoleServices", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@@Basic_pay", obj.Basic_pay);
            com.Parameters.AddWithValue("@StartDate", obj.Date);
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
                return true;
            else
                return false;
        }
    }
}