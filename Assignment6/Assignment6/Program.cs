using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    internal class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader reader;
        public static string constr = "server=DESKTOP-VDRMSHO;database=ProductInventoryDb;trusted_connection=true;";
        static void Main(string[] args)
        {
            try
            {


                con = new SqlConnection(constr);
                cmd = new SqlCommand()
                {
                    Connection = con,
                    
                };
                Console.WriteLine("1.Display All\n2.Add Product\n3.Update Product\n4.Delete Product");
                Console.WriteLine("enter choice");
                int choice=int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                             cmd.CommandText = "select * from Products";
                        con.Open();
                        reader = cmd.ExecuteReader();
                        Console.WriteLine(" ID \t  Name \t\t  Price    Quantity\t MfDate\t\t\t  ExpDate");
                        while (reader.Read())
                        {
                            Console.Write(reader["Pid"] + "\t");
                            Console.Write(reader["Pname"] + "\t\t");
                            Console.Write(reader["Price"] + "\t\t");
                            Console.Write(reader["Quantity"] + "\t");
                            Console.Write(reader["MfDate"] + "\t");
                            Console.Write(reader["ExpDate"] + "\t");
                             Console.WriteLine("\n");
                        }
                        break;

                    case 2:
                            cmd.CommandText = "insert into Products(Pid,Pname,Price,Quantity,MfDate,ExpDate) values(@id,@name,@price,@qt,@mf,@ex)";
                            Console.WriteLine("enter Product Id");
                            cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));

                            Console.WriteLine("enter Product  name");
                            cmd.Parameters.AddWithValue("@name", Console.ReadLine());

                            Console.WriteLine("enter price");
                            cmd.Parameters.AddWithValue("@price", float.Parse(Console.ReadLine()));

                            Console.WriteLine("enter quantity");
                            cmd.Parameters.AddWithValue("@qt", int.Parse(Console.ReadLine()));

                            Console.WriteLine("enter mf date");
                            cmd.Parameters.AddWithValue("@mf", DateTime.Parse(Console.ReadLine()));

                            Console.WriteLine("enter Exp date");
                            cmd.Parameters.AddWithValue("@ex", DateTime.Parse(Console.ReadLine()));


                            con.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Record inserted!!");
                        break;  

                    case 3:
                               cmd.CommandText = "update Products set Pname=@name,Price=@price,Quantity=@qt where Pid=@id";
                                Console.WriteLine("enter Product Id");
                                cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));

                                Console.WriteLine("enter Product  name");
                                cmd.Parameters.AddWithValue("@name", Console.ReadLine());

                                Console.WriteLine("enter price");
                                cmd.Parameters.AddWithValue("@price", float.Parse(Console.ReadLine()));

                                Console.WriteLine("enter quantity");
                                cmd.Parameters.AddWithValue("@qt", int.Parse(Console.ReadLine()));

                                con.Open();
                                int noe = cmd.ExecuteNonQuery();
                                if (noe > 0)
                                {
                                    Console.WriteLine("record updated");
                                }
                        break;


                    case 4:

                        cmd.CommandText = "delete from Products where Pid=@id";
                        Console.WriteLine("enter Product id");
                        cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));

                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        if (n > 0)
                        {
                            Console.WriteLine("record deleted");
                        }
                        break;

                    default:
                            Console.WriteLine("invalid choice");
                        break;
                            
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!" + ex.Message);
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }
    }
}
