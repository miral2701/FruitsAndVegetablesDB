using Microsoft.Data.SqlClient;
using System.Collections.Specialized;

namespace DataBase
{
    internal class Program
    {
        static string connectionString = "Server=DESKTOP-A9BTA2K\\SQLEXPRESS;Database=FruitsAndVegetables;Trusted_Connection=True;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            //CreateTable();
            //

            //1
            //GetAllDatabaseInfo();

            //2
            //GetAllNames();

            //3
            // GetAllColors();

            //4
            //GetMaxCalories();

            //5
            //GetMinCalories();

            //6
            //GetMidCalories();

            //7
            //GetVegetableCount();

            //8
            //GetFruitCount();

            //9
            //GetCountByColor("red");

            //11
           // GetByCaloriesLessThenB(100);

            //12
           // GetByCaloriesMoreThenA(100);

            //13
            //GetByCaloriesRange(40, 270);
            //14
            //GetByColorRedOrYellow();
        }

        //public static void CreateTable()
        //{
        //    // Строка подключения
        //    string connectionString = "Server=DESKTOP-A9BTA2K\\SQLEXPRESS;Database=FruitsAndVegetables;Trusted_Connection=True;TrustServerCertificate=True";
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            Console.WriteLine("Connected");

        //            // Исправленный SQL-запрос
        //            SqlCommand command = new SqlCommand("CREATE TABLE [Fruits]([Id] INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(60) NOT NULL,[Color] NVARCHAR(60) NOT NULL,[Calories] INT  NOT NULL)", connection);
        //            command.ExecuteNonQuery();

        //            SqlCommand command2 = new SqlCommand("CREATE TABLE [Vegetables]([Id] INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(60) NOT NULL,[Color] NVARCHAR(60) NOT NULL,[Calories] INT  NOT NULL)", connection);
        //            command2.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex) {

        //        Console.WriteLine("Error");
        //    }
        //}





        // 1) Отображение всей информации из таблицы с овощами и фруктами; 
        public static void GetAllDatabaseInfo()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Fruits]", connection);
                SqlCommand command2 = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Vegetables]", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader.Read())
                    {
                        Console.Write("Id: " + reader.GetValue(0) + " |");
                        Console.Write("Name: " + reader.GetValue(1) + " |");
                        Console.Write("Color: " + reader.GetValue(2) + " |");
                        Console.Write("Calories: " + reader.GetValue(3) + " |");

                        Console.WriteLine();
                    }
                }
                reader.Close();
                SqlDataReader reader2 = command2.ExecuteReader();

                Console.WriteLine("----------------------------------------");
                if (reader2.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader2.Read())
                    {
                        Console.Write("Id: " + reader2.GetValue(0) + " |");
                        Console.Write("Name: " + reader2.GetValue(1) + " |");
                        Console.Write("Color: " + reader2.GetValue(2) + " |");
                        Console.Write("Calories:" + reader2.GetValue(3) + " |");

                        Console.WriteLine();
                    }
                }
                reader2.Close();


            }
        }


        //2) Отображение всех названий овощей и фруктов; 
        public static void GetAllNames()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Fruits]", connection);
                SqlCommand command2 = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Vegetables]", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader.Read())
                    {
                        Console.Write("Name: " + reader.GetValue(1) + " |");


                        Console.WriteLine();
                    }
                }
                reader.Close();
                SqlDataReader reader2 = command2.ExecuteReader();

                Console.WriteLine("----------------------------------------");
                if (reader2.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader2.Read())
                    {

                        Console.Write("Name: " + reader2.GetValue(1) + " |");

                        Console.WriteLine();
                    }
                }
                reader2.Close();


            }
        }


        //3) Отображение всех цветов;
        public static void GetAllColors()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Fruits]", connection);
                SqlCommand command2 = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Vegetables]", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader.Read())
                    {
                        Console.Write("Color: " + reader.GetValue(2) + " |");


                        Console.WriteLine();
                    }
                }
                reader.Close();
                SqlDataReader reader2 = command2.ExecuteReader();

                Console.WriteLine("----------------------------------------");
                if (reader2.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader2.Read())
                    {

                        Console.Write("Color: " + reader2.GetValue(2) + " |");

                        Console.WriteLine();
                    }
                }
                reader2.Close();


            }
        }

        //4) Показать максимальную калорийность; 
        public static void GetMaxCalories()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<int> calories = new List<int>();
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Fruits]", connection);
                SqlCommand command2 = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Vegetables]", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader.Read())
                    {

                        calories.Add(Convert.ToInt32(reader.GetValue(3)));

                    }
                }
                reader.Close();
                SqlDataReader reader2 = command2.ExecuteReader();

                if (reader2.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader2.Read())
                    {

                        calories.Add(Convert.ToInt32(reader2.GetValue(3)));

                    }
                }
                reader2.Close();
                Console.WriteLine("Max calories:" + calories.Max());
            }
        }

        //5) Показать минимальную калорийность; 
        public static void GetMinCalories()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<int> calories = new List<int>();
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Fruits]", connection);
                SqlCommand command2 = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Vegetables]", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader.Read())
                    {

                        calories.Add(Convert.ToInt32(reader.GetValue(3)));

                    }
                }
                reader.Close();
                SqlDataReader reader2 = command2.ExecuteReader();

                if (reader2.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader2.Read())
                    {

                        calories.Add(Convert.ToInt32(reader2.GetValue(3)));

                    }
                }
                reader2.Close();
                Console.WriteLine("Min calories:" + calories.Min());
            }
        }

        //6) Показать среднюю калорийность.
        public static void GetMidCalories()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<int> calories = new List<int>();
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Fruits]", connection);
                SqlCommand command2 = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Vegetables]", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader.Read())
                    {

                        calories.Add(Convert.ToInt32(reader.GetValue(3)));

                    }
                }
                reader.Close();
                SqlDataReader reader2 = command2.ExecuteReader();

                if (reader2.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader2.Read())
                    {

                        calories.Add(Convert.ToInt32(reader2.GetValue(3)));

                    }
                }
                int res = 0;
                foreach (var item in calories)
                {
                    res += Convert.ToInt32(item);
                }
                reader2.Close();
                Console.WriteLine("Middle calories:" + res / calories.Count);
            }
        }

        //7) Показать количество овощей; 
        public static void GetVegetableCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int count = 0;
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command2 = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Vegetables]", connection);



                SqlDataReader reader2 = command2.ExecuteReader();

                if (reader2.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader2.Read())
                    {
                        count++;

                    }
                }
                reader2.Close();
                Console.WriteLine("Vegetable count:" + count);
            }
        }

        // 8) Показать количество фруктов; 
        public static void GetFruitCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int count = 0;
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command2 = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Fruits]", connection);



                SqlDataReader reader2 = command2.ExecuteReader();

                if (reader2.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader2.Read())
                    {
                        count++;

                    }
                }
                reader2.Close();
                Console.WriteLine("Fruit count:" + count);
            }
        }

        //9) Показать количество овощей и фруктов заданного цвета;
        public static void GetCountByColor(string color)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Fruits]", connection);
                SqlCommand command2 = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Vegetables]", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader.Read())
                    {
                        if (reader.GetValue(2).ToString() == color)
                        {
                            count++;
                        }

                    }
                }
                reader.Close();
                SqlDataReader reader2 = command2.ExecuteReader();

                Console.WriteLine("----------------------------------------");
                if (reader2.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader2.Read())
                    {

                        if (reader2.GetValue(2).ToString() == color)
                        {
                            count++;
                        }
                    }
                }
                reader2.Close();

                Console.WriteLine("There are "+count+" "+color+" fruits and vegetables");
            }
        }


        
        //11) Показать овощи и фрукты с калорийностью ниже указанной;
        public static void GetByCaloriesLessThenB( int b)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Fruits]", connection);
                SqlCommand command2 = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Vegetables]", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader.Read())
                    {
                        if ( Convert.ToInt32(reader.GetValue(3)) < b)
                        {
                            Console.Write("Name: " + reader.GetValue(1) + " |");
                            Console.Write("Calories " + reader.GetValue(3) + " |");
                        }

                    }
                }
                reader.Close();
                SqlDataReader reader2 = command2.ExecuteReader();

                Console.WriteLine("----------------------------------------");
                if (reader2.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader2.Read())
                    {
                        if ( Convert.ToInt32(reader2.GetValue(3)) < b)
                        {
                            Console.Write("Name: " + reader2.GetValue(1) + " |");
                            Console.Write("Calories " + reader2.GetValue(3) + " |");
                        }
                    }
                }
                reader2.Close();

            }
        }
        //12) Показать овощи и фрукты с калорийностью выше указанной; 
        public static void GetByCaloriesMoreThenA(int a)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Fruits]", connection);
                SqlCommand command2 = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Vegetables]", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader.GetValue(3)) > a )
                        {
                            Console.Write("Name: " + reader.GetValue(1) + " |");
                            Console.Write("Calories " + reader.GetValue(3) + " |");
                        }

                    }
                }
                reader.Close();
                SqlDataReader reader2 = command2.ExecuteReader();

                Console.WriteLine("----------------------------------------");
                if (reader2.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader2.Read())
                    {
                        if (Convert.ToInt32(reader2.GetValue(3)) > a )
                        {
                            Console.Write("Name: " + reader2.GetValue(1) + " |");
                            Console.Write("Calories " + reader2.GetValue(3) + " |");
                        }
                    }
                }
                reader2.Close();

            }
        }

        //13) Показать овощи и фрукты с калорийностью в указанном диапазоне; 
        public static void GetByCaloriesRange(int a,int b)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Fruits]", connection);
                SqlCommand command2 = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Vegetables]", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader.GetValue(3))>a && Convert.ToInt32(reader.GetValue(3))<b)
                        {
                            Console.Write("Name: " + reader.GetValue(1) + " |");
                            Console.Write("Calories " + reader.GetValue(3) + " |");
                        }

                    }
                }
                reader.Close();
                SqlDataReader reader2 = command2.ExecuteReader();

                Console.WriteLine("----------------------------------------");
                if (reader2.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader2.Read())
                    {
                        if (Convert.ToInt32(reader2.GetValue(3)) > a && Convert.ToInt32(reader2.GetValue(3)) < b)
                        {
                            Console.Write("Name: " + reader2.GetValue(1) + " |");
                            Console.Write("Calories " + reader2.GetValue(3) + " |");
                        }
                    }
                }
                reader2.Close();

            }
        }

        //14) Показать все овощи и фрукты, у которых цвет желтый или красный.
        public static void GetByColorRedOrYellow()
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Fruits]", connection);
                SqlCommand command2 = new SqlCommand($"SELECT [Id],[Name],[Color],[Calories] FROM [Vegetables]", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader.Read())
                    {
                        if (reader.GetValue(2).ToString() == "red" || reader.GetValue(2).ToString()=="yellow")
                        {
                            Console.WriteLine(reader.GetValue(1));
                        }

                    }
                }
                reader.Close();
                SqlDataReader reader2 = command2.ExecuteReader();

                Console.WriteLine("----------------------------------------");
                if (reader2.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader2.Read())
                    {
                        if (reader2.GetValue(2).ToString() == "red" || reader2.GetValue(2).ToString() == "yellow")
                        {
                            Console.WriteLine(reader2.GetValue(1));
                        }

                    }
                }
                reader2.Close();

            }
        }


    }
}