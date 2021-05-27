using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public static class DBManager
    {
        public static UserDTO Validate(String Login, String Password)
        { 
            String connString = @"Server=.\DEV-WS;Database = Arham;User Id=sa;Password=12345;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    String sqlQuery = String.Format("Select UserID,Login,IsAdmin from dbo.Users where Login='{0}' and Password='{1}'", Login, Password);

                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        UserDTO dto = new UserDTO();
                        dto.UserID = reader.GetInt32(0);
                        dto.Login = reader.GetString(1);
                        dto.IsAdmin = reader.GetBoolean(2);
                        return dto;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public static List<student> GetAllStudents()
        {
            List<student> students = new List<student>();
            students.Add(new student() { ID = "1", Name = "Bilal 1" });
            students.Add(new student() { ID = "1", Name = "Bilal 2" });
            students.Add(new student() { ID = "2", Name = "Bilal 3" });
            students.Add(new student() { ID = "3", Name = "Bilal 4" });
            students.Add(new student() { ID = "4", Name = "Bilal 5" });

            return students;
        }

        public static List<ProductDTO> GetProducts()
        {
            String connString = @"Server=.\DEV-WS;Database=Arham;User Id=sa;Password=123456;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    String sqlQuery = String.Format("Select * from dbo.Products");

                    SqlCommand command = new SqlCommand(sqlQuery, conn);

                    SqlDataReader reader = command.ExecuteReader();

                    List<ProductDTO> list = new List<ProductDTO>();
                    while (reader.Read() == true)
                    {
                        ProductDTO dto = new ProductDTO();
                        dto.ProductID = reader.GetInt32(0);
                        dto.Name = reader.GetString(1);
                        dto.Price = reader.GetDouble(2);
                        dto.CreatedOn = reader.GetDateTime(3);
                        dto.CreatedBy = reader.GetInt32(4);

                        list.Add(dto);
                    }
                    return list;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }

        }

    }
}
 