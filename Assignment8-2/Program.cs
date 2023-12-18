using System;
using System.Data;

namespace Assignment8_2
{
    internal class Program
    {
        static DataTable Create()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PId", typeof(int));
            dt.Columns.Add("PName", typeof(string));
            dt.Columns.Add("PPrice", typeof(double));
            dt.Columns.Add("MnfDate", typeof(DateTime));
            dt.Columns.Add("ExpDate", typeof(DateTime));
            dt.PrimaryKey = new DataColumn[] { dt.Columns["PId"] };
            return dt;
        }

        static void Insert(DataTable dt, int id, string name, double price, DateTime mfdate, DateTime expdate)
        {
            DataRow dr = dt.NewRow();
            dr["PId"] = id;
            dr["PName"] = name;
            dr["PPrice"] = price;
            dr["MnfDate"] = mfdate;
            dr["ExpDate"] = expdate;
            dt.Rows.Add(dr);
        }
        static void search(DataTable dt, int id)
        {
            DataRow foundRow = dt.Rows.Find(id);
            if (foundRow == null)
            {
                Console.WriteLine($"No such PId {id} exist");
            }
            else
            {
                Console.WriteLine("Record Found Details as follows");
                Console.WriteLine($"ID: \t {foundRow["PId"]}");
                Console.WriteLine($"Product Name: \t {foundRow["PName"]}");
                Console.WriteLine($"Product Price: \t {foundRow["PPrice"]}");
                Console.WriteLine($"Manufacturing Date: \t {foundRow["MnfDate"]}");
                Console.WriteLine($"Expiry Date: \t {foundRow["ExpDate"]}");
            }
        }
        static void Delete(DataTable dt, int id)
        {
            DataRow delRow = dt.Rows.Find(id);
            if (delRow == null)
            {
                Console.WriteLine($"No such PId {id} exist");
            }
            else
            {
                dt.Rows.Remove(delRow);
                Console.WriteLine($"Record with Pid {id} deleted from Table");
            }
        }
        static void Update(DataTable dt, int id, String name, double price, DateTime mfdate, DateTime expdate)
        {
            DataRow updateRow = dt.Rows.Find(id);
            if (updateRow != null)
            {
                updateRow["PName"] = name;
                updateRow["PPrice"] = price;
                updateRow["MnfDate"] = mfdate;
                updateRow["ExpDate"] = expdate;             
            }
            else
            {
                Console.WriteLine($"No such Id {id} exist");
            }
        }
        static void Display(DataTable dt)
        {
            Console.WriteLine("Stored Current Data in Table");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"PID: \t" + row["PId"]);
                Console.WriteLine($"Product Name: \t" + row["PName"]);
                Console.WriteLine($"Product Price: \t" + row["PPrice"]);
                Console.WriteLine($"Manufacturing Date: \t" + row["MnfDate"]);
                Console.WriteLine($"Expiry Date: \t" + row["ExpDate"]);
                Console.WriteLine("------------------------------------------------");
            }
        }
        static void Main(string[] args)
        {
            DataTable dt = Create();
            string choice;
            do
            {
                Console.WriteLine("Choose the Operation 1.Insert 2.Delete 3.Search 4.Update");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            Insert(dt, 1, "Laptop", 65000.50, new DateTime(day: 25, month: 09, year: 2018), new DateTime(day: 23, month: 11, year: 2022));
                            Insert(dt, 5, "Mobile", 35000.30, new DateTime(day: 13, month: 01, year: 2019), new DateTime(day: 23, month: 12, year: 2025));
                            Insert(dt, 3, "Smart watch", 5000.45, new DateTime(day: 30, month: 09, year: 2022), new DateTime(day: 10, month: 9, year: 2026));
                            Display(dt);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter PId to delete data row");
                            int delid = int.Parse(Console.ReadLine());
                            Delete(dt, delid);
                            Console.WriteLine("After Delete method call table");
                            Display(dt);
                            break;

                        }
                    case 3:
                        {
                            Console.WriteLine("Enter PId to search the data row");
                            int sid = int.Parse(Console.ReadLine());
                            search(dt, sid);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter PId to be Update the Data Row");
                            int uId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter New Product Name");
                            string newname = Console.ReadLine();
                            Console.WriteLine("Enter New Price");
                            double price = double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter New Mnf Date");
                            DateTime mfDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new Exp Date");
                            DateTime expDate = DateTime.Parse(Console.ReadLine());
                            Update(dt, uId, newname, price, mfDate, expDate);
                            Console.WriteLine("*** After Update Method Call***");
                            Display(dt);
                            break;

                        }
                }

                Console.WriteLine("Do you wanna Continue Press y");
                choice = Console.ReadLine();

            } while (choice == "y");
        }
    }
}
