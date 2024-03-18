using Assignment1.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace Assignment1.BL
{
    class ExecuteQueries
    {
        Queries q = new Queries();
        public int logIn(String username, String password)
        {
            return q.checkCredentials(username, password);
        }

        public void adaugaPreparat(String nume, String pret, String stoc)
        {
            q.addMeal(nume, pret, stoc);
        }

        public List<Preparat> getListOfMeals()
        {
            return q.getMeals(false); ;
        }

        public List<Preparat> getListOfMealsInStock()
        {
            return q.getMeals(true); ;
        }

        public void deleteMealById(int id)
        {
            q.deleteMeal(id);
        }

        public void updateMealById(int id, string column, string newValue)
        {
            q.updateMeal(id, column, newValue);
        }

        public void adaugaAngajat(string nume, string username, string parola)
        {
            q.addEmployee(nume, username, BL.PasswordSecurity.encrypt(parola));
        }

        public int getLastIdPrepComanda()
        {
            return q.getLastIdPreparatComanda();
        }

        public void adaugaPreparatLaComanda(int idPreparat, int cantitate, int id)
        {
            q.adaugaPreparatComanda(idPreparat, cantitate, id);
        }

        public List<Comanda> getListOfOrders()
        {
            //Console.WriteLine(q.getMeals);
            return q.getListOfOrders();
        }

        public void updateStatus(int id, string newStatus)
        {
            q.updateStatusById(id, newStatus);
        }

/*        public void reportOfOrdersBetweenDate(string date1, string date2)
        {
            //List<Comanda> c = q.getListOfOrdersBetweenDates(date1, date2);
            foreach (var kvp in q.getStatistics(date1, date2))
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }*/

        public void reportOfOrdersBetweenDate(string date1, string date2)
        {
            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("RaportComenzi");
                worksheet.Cells[1, 1].Value = "Raport generat pentru intervalul calendaristic: "+date1+" -> "+date2;
                worksheet.Cells[2, 1].Value = "Preparat";
                worksheet.Cells[2, 3].Value = "Cantitate Comandata";
                Dictionary<string, int> statistics = q.getStatistics(date1, date2);
                int row = 3;
                foreach (var dictEntry in statistics)
                {
                    worksheet.Cells[row, 1].Value = dictEntry.Key;
                    worksheet.Cells[row, 3].Value = dictEntry.Value;
                    row++;
                }
                FileInfo excelFile = new FileInfo("RaportComenzi.xlsx");
                excelPackage.SaveAs(excelFile);
                Console.WriteLine("Raport Generat/Actualizat!");
            }
        }
    }
}
