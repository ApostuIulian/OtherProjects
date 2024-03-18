using Assignment1.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1.UI
{
    public partial class AdminMenu : Form
    {
        BL.ExecuteQueries query = new BL.ExecuteQueries();
        public AdminMenu()
        {
            InitializeComponent();
            getMealsInTable();
            //Console.WriteLine("UI");
            //tabelPreparate.ReadOnly = true;
        }

        public void getMealsInTable()
        {
            var meals = query.getListOfMeals();
            tabelPreparate.Rows.Clear();
            foreach (var meal in meals)
            {
                tabelPreparate.Rows.Add(meal.preparat, meal.pret, meal.stoc, meal.id);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void adaugaPreparat_Click(object sender, EventArgs e)
        {
            string nume = numePreparat.Text;
            string pret = pretPreparat.Text;
            string stoc = stocPreparat.Text;
            query.adaugaPreparat(nume, pret, stoc);
            numePreparat.ResetText();
            pretPreparat.ResetText();
            stocPreparat.ResetText();


            getMealsInTable();
        }

        private void adaugaAngajat_Click(object sender, EventArgs e)
        {
            string nume = numeAngajat.Text;
            string user = username.Text;
            string pass = parola.Text;
            query.adaugaAngajat(nume, user, pass);
            numeAngajat.ResetText();
            username.ResetText();
            parola.ResetText();
        }

        private void actualizeazaPreparat_Click(object sender, EventArgs e)
        {
            int selectedCells = tabelPreparate.SelectedCells.Count;
            for (int i = 0; i < selectedCells; i++)
            {
                int columnIndex = tabelPreparate.SelectedCells[i].ColumnIndex;
                string columnToChange = tabelPreparate.Columns[columnIndex].HeaderText;
                string newValue = (string)tabelPreparate.SelectedCells[i].Value;
                int rowOfValueToChange = tabelPreparate.SelectedCells[i].RowIndex;
                int idOfValueToChange = (int)tabelPreparate.Rows[rowOfValueToChange].Cells[3].Value;
                query.updateMealById(idOfValueToChange, columnToChange, newValue);
            }
            getMealsInTable();
        }

        private void deleteMeal_Click(object sender, EventArgs e)
        {
            int selectedRowCount =
                tabelPreparate.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    query.deleteMealById((int)tabelPreparate.SelectedRows[i].Cells[3].Value);
                }
            }
            getMealsInTable();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void veziComenzi_Click(object sender, EventArgs e)
        {
            DateTime date1 = firstDate.Value;
            string formattedDate1 = date1.ToString("yyyy-MM-dd 00-00-00");
            DateTime date2 = secondDate.Value;
            string formattedDate2 = date2.ToString("yyyy-MM-dd 00-00-00");
            Console.WriteLine(date1 + " " + date2);
            if (!(formattedDate1.Equals(formattedDate2)))
            {
                if (date2 < date1)
                {
                    MessageBox.Show("Prima data trebuie sa fie inainte de a doua!");
                    return;
                }
            }
            query.reportOfOrdersBetweenDate(formattedDate1, formattedDate2);
        }
    }
}
