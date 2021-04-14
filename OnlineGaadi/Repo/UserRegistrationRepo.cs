using OnlineGaadi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGaadi.Repo
{
    public class UserRegistrationRepo
    {
    
            private SqlConnection con;
            //To Handle connection related activities
            private void connection()
            {
                string constr = "Server=LAPTOP-0QHGVH2Q; Database=OnlineGaadi; Trusted_Connection=True; MultipleActiveResultSets=true";
                con = new SqlConnection(constr);
            }

            //To Add Employee details
            public bool RegistrationUser(UserRegistrationProp userRegistration)
            {
                connection();
                SqlCommand com = new SqlCommand("spr_RegistrationUser", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UserName", userRegistration.UserName);
                com.Parameters.AddWithValue("@MobileNumber", userRegistration.MobileNumber);

                com.Parameters.AddWithValue("@PickupLocation", userRegistration.PickupLocation);
                com.Parameters.AddWithValue("@Password", userRegistration.Password);

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

            public List<UserRegistrationProp> FindDriverByLocation(string driverLocation)
            {
                connection();
                List<UserRegistrationProp> userDetails = new List<UserRegistrationProp>();
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
                    userDetails.Add(
                        new UserRegistrationProp
                        {
                            UserName = Convert.ToString(item["DriverName"]),
                            MobileNumber = Convert.ToString(item["MobileNumber"]),
                      
                            PickupLocation = Convert.ToString(item["PickupLocation"])
                        }
                        );
                }
                return userDetails;
            }
        }
    }

