using System;
using System.Xml.XPath;
using Assignment1.BL;
using MySql.Data.MySqlClient;

namespace Assignment1
{
    public sealed class Database
    {
        private static Database instance = null;
        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }
        private const string ConnectionInfo = "Server=localhost;User ID=root;Password=135790;";
        private const string DatabaseName = "Restaurant";

        public static string getConnectionInfo()
        {
            return ConnectionInfo;
        }

        public static string getDatabaseName()
        {
            return DatabaseName;
        }

        private static string connectionStr => $"{ConnectionInfo}Database={DatabaseName};";

        public static string getConnectionStr()
        {
            return connectionStr;
        }

        public void creareBazaDate()
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionInfo))
            {
                try
                {
                    connection.Open();

                    string createDatabaseQuery = $"CREATE DATABASE IF NOT EXISTS {DatabaseName}";

                    using (MySqlCommand createDatabaseCommand = new MySqlCommand(createDatabaseQuery, connection))
                    {
                        createDatabaseCommand.ExecuteNonQuery();
                        Console.WriteLine($"Database '{DatabaseName}' created successfully!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating database: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void creareTabele()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                String[] creates = {"CREATE TABLE IF NOT EXISTS persoana ("+
                            "id INT AUTO_INCREMENT PRIMARY KEY,"+
                            "nume VARCHAR(255) UNIQUE NOT NULL)",

                            "CREATE TABLE IF NOT EXISTS rol ("+
                            "id INT PRIMARY KEY UNIQUE NOT NULL,"+
                            "rol VARCHAR(255) UNIQUE NOT NULL) ",

                            "CREATE TABLE IF NOT EXISTS user ("+
                            "id INT AUTO_INCREMENT PRIMARY KEY,"+
                            "username VARCHAR(255) UNIQUE NOT NULL," +
                            "parola VARCHAR(255) NOT NULL," +
                            "idPersoana INT UNIQUE NOT NULL," +
                            "idRol Int NOT NULL,"+
                            "FOREIGN KEY (idPersoana) REFERENCES persoana(id)," +
                            "FOREIGN KEY (idRol) REFERENCES rol(id))",

                            "CREATE TABLE IF NOT EXISTS preparat (" +
                            "id INT AUTO_INCREMENT PRIMARY KEY," +
                            "numePreparat VARCHAR(255) UNIQUE NOT NULL," +
                            "pret INT NOT NULL,"+
                            "stoc INT NOT NULL)",

                            "CREATE TABLE IF NOT EXISTS preparateComanda(" +
                            "id INT NOT NULL," +
                            "idPreparat INT NOT NULL," +
                            "cantitate INT NOT NULL," +
                            "FOREIGN KEY (idPreparat) REFERENCES preparat(id))",

                            "CREATE TABLE IF NOT EXISTS comanda (" +
                            "id INT AUTO_INCREMENT PRIMARY KEY UNIQUE NOT NULL," +
                            "idPreparateComanda INT UNIQUE NOT NULL," +
                            "dataPlasarii DATETIME DEFAULT NOW() NOT NULL," +
                            "status VARCHAR(255) NOT NULL,"+
                            "pretTotal INT NOT NULL)"
                };

                for (int i = 0; i < creates.Length; i++)
                {
                    try
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(creates[i], connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine($"Table {i} created successfully!");
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
        }

        public void populeazaTabele()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                String parolaAdmin = "1234";
                String encryptedPass = PasswordSecurity.encrypt(parolaAdmin);
                String[] inserts = {
                        "INSERT INTO rol VALUES (0, 'Admin')",
                        "INSERT INTO rol VALUES (1, 'Angajat')",
                        "INSERT INTO persoana (nume) VALUES ('Apostu Iulian-Eduard')",
                        "INSERT INTO user (username, parola, idPersoana, idRol) VALUES ('Iuliane', '"+encryptedPass+"', 1, 0)"
                        //"INSERT INTO user (username, parola, idPersoana, idRol) VALUES ('iuliane', '1234', 1, 0)"
                    };
                for (int i = 0; i < inserts.Length; i++)
                {
                    try
                    {
                        connection.Open();

                        using (MySqlCommand command = new MySqlCommand(inserts[i], connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine($"Row {i} inserted successfully!");
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
        }

        public void creazaProceduri()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                String[] proceduri = {
                    "CREATE PROCEDURE IF NOT EXISTS adaugaAngajat(numeA varchar(255), usernameA varchar(255), parolaA varchar(255))" +
                    "BEGIN "+
                    "INSERT INTO persoana(nume) VALUES (numeA);" +
                    "INSERT INTO user (username, parola, idPersoana, idRol) values (usernameA, parolaA, LAST_INSERT_ID(), 1);" +
                    "END;",

                    "CREATE PROCEDURE IF NOT EXISTS adaugaComanda(idPreparat INT, cantitatePrep INT, idPrepComanda INT)" +
                    "BEGIN "+
                    "INSERT INTO preparateComanda VALUES(idPrepComanda, idPreparat, cantitatePrep);"+
                    "UPDATE preparat SET stoc = stoc - cantitatePrep WHERE id = idPreparat;"+
                    "INSERT IGNORE INTO comanda (idPreparateComanda, pretTotal, status) VALUES (idPrepComanda, 0, 'noua');"+
                    "UPDATE comanda SET pretTotal = pretTotal + (cantitatePrep*(SELECT pret FROM preparat WHERE preparat.id = idPreparat)) WHERE idPreparateComanda = idPrepComanda;"+
                    "END;"
                    };
                for (int i = 0; i < proceduri.Length; i++)
                {
                    try
                    {
                        connection.Open();

                        using (MySqlCommand command = new MySqlCommand(proceduri[i], connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine($"Procedure {i} created successfully!");
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
        }
    }
}
