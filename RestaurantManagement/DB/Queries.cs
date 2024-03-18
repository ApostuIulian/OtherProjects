using Assignment1.BL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Assignment1.DB
{
    class Queries
    {
        private string ConnectionInfo = Database.getConnectionInfo();
        private string DatabaseName = Database.getDatabaseName();
        private string connectionStr = Database.getConnectionStr();
        public int checkCredentials(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    string checkLogin = "SELECT username, parola, idRol FROM user WHERE username = '" + username + "' AND parola = '" + BL.PasswordSecurity.encrypt(password) + "'";
                    using (MySqlCommand command = new MySqlCommand(checkLogin, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetInt32(2);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Select: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return -1;
        }

        public void addMeal(string name, string price, string stock)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                string insert = "INSERT INTO preparat (numePreparat, pret, stoc) VALUES ('" + name + "', '" + price + "', '" + stock + "')";
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insert, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Row inserted successfully!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Preparat> getMeals(bool stoc)
        {
            List<Preparat> meals = new List<Preparat>();
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    string getAllMeals = "SELECT * FROM preparat";
                    if (stoc)
                    {
                        getAllMeals += " WHERE stoc > 0";
                    }
                    using (MySqlCommand command = new MySqlCommand(getAllMeals, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Preparat p = new Preparat(reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3));
                                meals.Add(p);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Select: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return meals;
        }

        public void deleteMeal(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                string delete = "DELETE FROM preparat where id = " + id;
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(delete, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Row deleted successfully!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void updateMeal(int id, string columnToChange, string newValue)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                string update = "UPDATE preparat SET " + columnToChange + " = '" + newValue + "' WHERE id = " + id;
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(update, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Row updated successfully!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void addEmployee(string nume, string username, string parola)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                string addEmp = $"CALL adaugaAngajat('{nume}', '{username}', '{parola}')";
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(addEmp, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Emplyee added successfully!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public int getLastIdPreparatComanda()
        {
            int id = 1;
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    string getLastId = "SELECT id FROM preparateComanda ORDER BY id DESC LIMIT 1";
                    using (MySqlCommand command = new MySqlCommand(getLastId, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = reader.GetInt32(0) + 1;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Select: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return id;
        }

        public void adaugaPreparatComanda(int idPreparat, int cantitate, int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    string placeOrder = $"CALL adaugaComanda('{idPreparat}', '{cantitate}', '{id}')";
                    using (MySqlCommand command = new MySqlCommand(placeOrder, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Procedure called successfully!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Select: {ex.Message} aici2");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public List<Comanda> getListOfOrders()
        {
            List<Comanda> orders = new List<Comanda>();
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    string getAllMeals = "SELECT * FROM comanda ORDER BY id DESC";
                    using (MySqlCommand command = new MySqlCommand(getAllMeals, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Comanda c = new Comanda(reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetDateTime(2).ToString("yyyy-MM-dd HH:mm:ss"),
                                reader.GetString(3),
                                reader.GetInt32(4));
                                orders.Add(c);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Select: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return orders;
        }

        public void updateStatusById(int id, string status)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                string update = "UPDATE comanda SET status = '" + status + "' WHERE id = " + id;
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(update, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Row updated successfully!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public Dictionary<string, int> getStatistics(string date1, string date2)
        {
            Dictionary<string, int> mealQuantity = new Dictionary<string, int>();
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    string getMealAndQuentity = "SELECT * FROM comanda " +
                        "JOIN preparateComanda ON idPreparateComanda = preparateComanda.id " +
                        "JOIN preparat ON idPreparat = preparat.id " +
                        "WHERE status = 'Finalizata' AND dataPlasarii > '" + date1 + "' AND dataPlasarii <= '" + date2 + "'";
                    using (MySqlCommand command = new MySqlCommand(getMealAndQuentity, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string meal = reader.GetString(9);
                            int quantity = reader.GetInt32(7);
                            if (mealQuantity.ContainsKey(meal))
                            {
                                quantity += mealQuantity[meal];
                                mealQuantity.Remove(meal);
                            }
                            mealQuantity.Add(meal, quantity);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Select: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return mealQuantity;
        }
    }
}
