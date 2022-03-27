using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace HotelListing.ADO
{
    public class HotelCountryDataAccess
    {
        string connectionString = "Data Source=localhost,1433;Database=HotelListingDB;User Id=sa;Password=P@ssword1s";  

        //To View all employees details    
        public IEnumerable<HotelCountry> GetAllHotels()  
        {  
            List<HotelCountry> lstHotel = new List<HotelCountry>();  
  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("sp_GetAllHotels", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
  
                con.Open();  
                SqlDataReader rdr = cmd.ExecuteReader();  
  
                while (rdr.Read())  
                {  
                    HotelCountry hotelCountry = new HotelCountry();  
  
                    hotelCountry.HotelId = Convert.ToInt32(rdr["HotelId"]);  
                    hotelCountry.CountryId = Convert.ToInt32(rdr["CountryId"]);  
                    hotelCountry.HotelName = rdr["HotelName"].ToString();  
                    hotelCountry.CountryName = rdr["CountryName"].ToString();  
                   
  
                    lstHotel.Add(hotelCountry);  
                }  
                con.Close();  
            }  
            return lstHotel;  
        }

        public void AddHotel(HotelCountry hotel)  
        {  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("sp_AddHotel", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
  
                cmd.Parameters.AddWithValue("@HotelName", hotel.HotelName);  
                cmd.Parameters.AddWithValue("@CountryId", hotel.CountryId);
  
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }  
  
        //To Update the records of a particluar employee  
        public void UpdateEmployee(HotelCountry hotel)  
        {  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("sp_UpdateHotel", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
  
                cmd.Parameters.AddWithValue("@HotelId", hotel.HotelId);  
                cmd.Parameters.AddWithValue("@CountryId", hotel.CountryId);  
                cmd.Parameters.AddWithValue("@HotelName", hotel.HotelName);
  
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }  
  
        //Get the details of a particular employee  
        public HotelCountry GetHotelCountryData(int? id)  
        {  
            HotelCountry hotelCountry = new HotelCountry();  
  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                // string sqlQuery = "SELECT * FROM Hotels WHERE EmployeeID= " + id;  
                // SqlCommand cmd = new SqlCommand(sqlQuery, con);  
                SqlCommand cmd = new SqlCommand("sp_getHotelById", con);  
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("@id", id);  
  
                con.Open();  
                SqlDataReader rdr = cmd.ExecuteReader();  
  
                while (rdr.Read())  
                {  
                    hotelCountry.HotelId = Convert.ToInt32(rdr["HotelId"]); 
                    hotelCountry.CountryId = Convert.ToInt32(rdr["CountryId"]); 
                    hotelCountry.CountryName = rdr["CountryName"].ToString();  
                    hotelCountry.HotelName = rdr["HotelName"].ToString();   
                    
                }  
            }  
            return hotelCountry;  
        }  
  
        //To Delete the record on a particular employee  
        public void DeleteEmployee(int? id)  
        {  
  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("sp_DeleteHotelCountry", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
  
                cmd.Parameters.AddWithValue("@HotelId", id);  
  
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }    
    }
}