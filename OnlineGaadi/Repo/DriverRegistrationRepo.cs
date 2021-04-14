using Microsoft.Extensions.Configuration;
using OnlineGaadi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGaadi.Repo
{
    public class DriverRegistrationRepo
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = "Server=LAPTOP-3GK5UBBG\\SURAJ; Database=OnlineGaadi; Trusted_Connection=True; MultipleActiveResultSets=true";
            con = new SqlConnection(constr);
        }

        //To Add Employee details
        public bool RegistrationDriver(DriverRegistrationProp driverRegistration)
        {
            connection();
            SqlCommand com = new SqlCommand("spr_RegistrationDriver", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DriverName", driverRegistration.DriverName);
            com.Parameters.AddWithValue("@MobileNumber", driverRegistration.MobileNumber);
            com.Parameters.AddWithValue("@VehicleNumber", driverRegistration.VehicleNumber);
            com.Parameters.AddWithValue("@PickupLocation", driverRegistration.PickupLocation);
            com.Parameters.AddWithValue("@Password", driverRegistration.Password);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<DriverRegistrationProp> FindDriverByLocation(string driverLocation)
        {
            connection();
            List<DriverRegistrationProp> driverDetails = new List<DriverRegistrationProp>();
            SqlCommand com = new SqlCommand("spr_FindDriverByLocation ", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DriverLocation", driverLocation);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            List<DataRow> list = dt.AsEnumerable().ToList();
            foreach (var item in list)
            {
                driverDetails.Add(
                    new DriverRegistrationProp
                    {
                        DriverName = Convert.ToString(item["DriverName"]),
                        MobileNumber = Convert.ToString(item["MobileNumber"]),
                        VehicleNumber = Convert.ToString(item["VehicleNumber"]),
                        PickupLocation = Convert.ToString(item["PickupLocation"])
                    }
                    );
            }
            return driverDetails;
        }
    }
}
