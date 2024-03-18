using Assignment1.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Assignment1.UI
{
    public partial class EmployeeMenu : Form
    {

        private DataTable filterPreparate = new DataTable();

        BL.ExecuteQueries query = new BL.ExecuteQueries();
        public EmployeeMenu()
        {
            InitializeComponent();
            filterPreparate.Columns.Add("id", typeof(int));
            filterPreparate.Columns.Add("numePreparat", typeof(string));
            filterPreparate.Columns.Add("stoc", typeof(int));
            filterPreparate.Columns.Add("pret", typeof(int));
            filterPreparate.Columns.Add("cantitatea", typeof(int));
            afiseazaPreparateInStoc();
            afiseazaComenzi();
        }

        private void afiseazaPreparateInStoc()
        {
            var meals = query.getListOfMealsInStock();
            filterPreparate.Rows.Clear();
            //preparateInStoc.Rows.Clear();
            foreach (var meal in meals)
            {
                filterPreparate.Rows.Add(meal.id, meal.preparat, meal.stoc, meal.pret, 0);
                Console.WriteLine(meal.preparat);
            }
            filterPreparate.Columns[0].ReadOnly = true;
            filterPreparate.Columns[1].ReadOnly = true;
            filterPreparate.Columns[2].ReadOnly = true;
            filterPreparate.Columns[3].ReadOnly = true;
            preparateInStoc.DataSource = filterPreparate;
        }

        private void afiseazaComenzi()
        {
            var orders = query.getListOfOrders();
            comenziPlasate.Rows.Clear();
            //preparateInStoc.Rows.Clear();
            foreach (var order in orders)
            {
               comenziPlasate.Rows.Add(order.id, order.dataPlasarii, order.status, order.costTotal);
            }
            comenziPlasate.Columns[0].ReadOnly = true;
            comenziPlasate.Columns[1].ReadOnly = true;
            comenziPlasate.Columns[3].ReadOnly = true;
        }

        private void cautaPreparat_TextChanged(object sender, EventArgs e)
        {
            filterPreparate.DefaultView.RowFilter = "numePreparat like '%"+cautaPreparat.Text+"%'";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                int selectedCells = comenziPlasate.SelectedCells.Count;
                for (int i = 0; i < selectedCells; i++)
                {
                    string columnToChange = comenziPlasate.Columns[2].HeaderText;
                    string newValue = (string)comenziPlasate.SelectedCells[i].Value;
                    int rowOfValueToChange = comenziPlasate.SelectedCells[i].RowIndex;
                    int idOfValueToChange = (int)comenziPlasate.Rows[rowOfValueToChange].Cells[0].Value;
                    query.updateStatus(idOfValueToChange, newValue);
                }
             afiseazaComenzi();
        }

        private void placeOrder_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < preparateInStoc.Rows.Count; i++)
            {
                int cantitate = preparateInStoc.Rows[i].Cells[4].Value is not null ? (int)preparateInStoc.Rows[i].Cells[4].Value : 0;
                int stoc = preparateInStoc.Rows[i].Cells[2].Value is not null ? (int)preparateInStoc.Rows[i].Cells[2].Value : 0;
                if (cantitate > 0)
                {
                    if (cantitate > stoc)
                    {
                        MessageBox.Show($"Preparatul {(string)preparateInStoc.Rows[i].Cells[1].Value} nu se afla in stoc! (Cantitate prea mare)!");
                        afiseazaPreparateInStoc();
                        return;
                    }
                }
            }
            int id = query.getLastIdPrepComanda();
            for (int i = 0; i < preparateInStoc.Rows.Count; i++)
            {
                int idPreparat = preparateInStoc.Rows[i].Cells[0].Value is not null ? (int)preparateInStoc.Rows[i].Cells[0].Value : 0;
                int cantitate = preparateInStoc.Rows[i].Cells[4].Value is not null ? (int)preparateInStoc.Rows[i].Cells[4].Value : 0;
                int stoc = preparateInStoc.Rows[i].Cells[2].Value is not null ? (int)preparateInStoc.Rows[i].Cells[2].Value : 0;
                if (cantitate > 0)
                {
                    query.adaugaPreparatLaComanda(idPreparat, cantitate, id);
                }
            }
            afiseazaPreparateInStoc();
            afiseazaComenzi();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comenziPlasate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
