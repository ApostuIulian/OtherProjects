namespace Assignment1.UI
{
    partial class AdminMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            actualizeazaPreparat = new Button();
            label1 = new Label();
            tabelPreparate = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            numePreparat = new TextBox();
            adaugaPreparat = new Button();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            pretPreparat = new TextBox();
            label6 = new Label();
            stocPreparat = new TextBox();
            label7 = new Label();
            parola = new TextBox();
            label8 = new Label();
            username = new TextBox();
            label9 = new Label();
            adaugaAngajat = new Button();
            numeAngajat = new TextBox();
            deleteMeal = new Button();
            label10 = new Label();
            label11 = new Label();
            veziComenzi = new Button();
            firstDate = new DateTimePicker();
            secondDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)tabelPreparate).BeginInit();
            SuspendLayout();
            // 
            // actualizeazaPreparat
            // 
            actualizeazaPreparat.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            actualizeazaPreparat.Location = new Point(12, 786);
            actualizeazaPreparat.Name = "actualizeazaPreparat";
            actualizeazaPreparat.Size = new Size(216, 70);
            actualizeazaPreparat.TabIndex = 0;
            actualizeazaPreparat.Text = "Actualizeaza";
            actualizeazaPreparat.UseVisualStyleBackColor = true;
            actualizeazaPreparat.Click += actualizeazaPreparat_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(92, 37);
            label1.TabIndex = 2;
            label1.Text = "Meniu";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabelPreparate
            // 
            tabelPreparate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelPreparate.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            tabelPreparate.Location = new Point(12, 62);
            tabelPreparate.Name = "tabelPreparate";
            tabelPreparate.Size = new Size(435, 718);
            tabelPreparate.TabIndex = 7;
            tabelPreparate.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "numePreparat";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "pret";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "stoc";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "id";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // numePreparat
            // 
            numePreparat.Location = new Point(483, 100);
            numePreparat.Name = "numePreparat";
            numePreparat.Size = new Size(216, 23);
            numePreparat.TabIndex = 8;
            // 
            // adaugaPreparat
            // 
            adaugaPreparat.Location = new Point(483, 314);
            adaugaPreparat.Name = "adaugaPreparat";
            adaugaPreparat.Size = new Size(216, 37);
            adaugaPreparat.TabIndex = 9;
            adaugaPreparat.Text = "Adauga";
            adaugaPreparat.UseVisualStyleBackColor = true;
            adaugaPreparat.Click += adaugaPreparat_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(483, 9);
            label3.Name = "label3";
            label3.Size = new Size(216, 37);
            label3.TabIndex = 12;
            label3.Text = "Adauga Preparat";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(781, 9);
            label2.Name = "label2";
            label2.Size = new Size(208, 37);
            label2.TabIndex = 13;
            label2.Text = "Adauga Angajat";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(483, 62);
            label4.Name = "label4";
            label4.Size = new Size(116, 21);
            label4.TabIndex = 14;
            label4.Text = "Nume Preparat";
            label4.TextAlign = ContentAlignment.TopCenter;
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(483, 136);
            label5.Name = "label5";
            label5.Size = new Size(38, 21);
            label5.TabIndex = 16;
            label5.Text = "Pret";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // pretPreparat
            // 
            pretPreparat.Location = new Point(483, 174);
            pretPreparat.Name = "pretPreparat";
            pretPreparat.Size = new Size(216, 23);
            pretPreparat.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(483, 212);
            label6.Name = "label6";
            label6.Size = new Size(39, 21);
            label6.TabIndex = 18;
            label6.Text = "Stoc";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // stocPreparat
            // 
            stocPreparat.Location = new Point(483, 250);
            stocPreparat.Name = "stocPreparat";
            stocPreparat.Size = new Size(216, 23);
            stocPreparat.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(781, 212);
            label7.Name = "label7";
            label7.Size = new Size(53, 21);
            label7.TabIndex = 25;
            label7.Text = "Parola";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // parola
            // 
            parola.Location = new Point(781, 250);
            parola.Name = "parola";
            parola.Size = new Size(216, 23);
            parola.TabIndex = 24;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(781, 136);
            label8.Name = "label8";
            label8.Size = new Size(81, 21);
            label8.TabIndex = 23;
            label8.Text = "Username";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // username
            // 
            username.Location = new Point(781, 174);
            username.Name = "username";
            username.Size = new Size(216, 23);
            username.TabIndex = 22;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(781, 62);
            label9.Name = "label9";
            label9.Size = new Size(110, 21);
            label9.TabIndex = 21;
            label9.Text = "Nume Angajat";
            label9.TextAlign = ContentAlignment.TopCenter;
            // 
            // adaugaAngajat
            // 
            adaugaAngajat.Location = new Point(781, 314);
            adaugaAngajat.Name = "adaugaAngajat";
            adaugaAngajat.Size = new Size(216, 37);
            adaugaAngajat.TabIndex = 20;
            adaugaAngajat.Text = "Adauga";
            adaugaAngajat.UseVisualStyleBackColor = true;
            adaugaAngajat.Click += adaugaAngajat_Click;
            // 
            // numeAngajat
            // 
            numeAngajat.Location = new Point(781, 100);
            numeAngajat.Name = "numeAngajat";
            numeAngajat.Size = new Size(216, 23);
            numeAngajat.TabIndex = 19;
            // 
            // deleteMeal
            // 
            deleteMeal.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deleteMeal.Location = new Point(240, 786);
            deleteMeal.Name = "deleteMeal";
            deleteMeal.Size = new Size(216, 70);
            deleteMeal.TabIndex = 26;
            deleteMeal.Text = "Sterge Selectate";
            deleteMeal.UseVisualStyleBackColor = true;
            deleteMeal.Click += deleteMeal_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(781, 457);
            label10.Name = "label10";
            label10.Size = new Size(59, 21);
            label10.TabIndex = 30;
            label10.Text = "Pana la";
            label10.TextAlign = ContentAlignment.TopCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(483, 457);
            label11.Name = "label11";
            label11.Size = new Size(45, 21);
            label11.TabIndex = 29;
            label11.Text = "De la";
            label11.TextAlign = ContentAlignment.TopCenter;
            // 
            // veziComenzi
            // 
            veziComenzi.Location = new Point(483, 525);
            veziComenzi.Name = "veziComenzi";
            veziComenzi.Size = new Size(216, 37);
            veziComenzi.TabIndex = 31;
            veziComenzi.Text = "Vezi Comenzi";
            veziComenzi.UseVisualStyleBackColor = true;
            veziComenzi.Click += veziComenzi_Click;
            // 
            // firstDate
            // 
            firstDate.Location = new Point(483, 496);
            firstDate.Name = "firstDate";
            firstDate.Size = new Size(216, 23);
            firstDate.TabIndex = 32;
            firstDate.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // secondDate
            // 
            secondDate.Location = new Point(773, 496);
            secondDate.Name = "secondDate";
            secondDate.Size = new Size(216, 23);
            secondDate.TabIndex = 33;
            // 
            // AdminMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 861);
            Controls.Add(secondDate);
            Controls.Add(firstDate);
            Controls.Add(veziComenzi);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(deleteMeal);
            Controls.Add(label7);
            Controls.Add(parola);
            Controls.Add(label8);
            Controls.Add(username);
            Controls.Add(label9);
            Controls.Add(adaugaAngajat);
            Controls.Add(numeAngajat);
            Controls.Add(label6);
            Controls.Add(stocPreparat);
            Controls.Add(label5);
            Controls.Add(pretPreparat);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(adaugaPreparat);
            Controls.Add(numePreparat);
            Controls.Add(tabelPreparate);
            Controls.Add(label1);
            Controls.Add(actualizeazaPreparat);
            Name = "AdminMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminMenu";
            ((System.ComponentModel.ISupportInitialize)tabelPreparate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button actualizeazaPreparat;
        private Label label1;
        private DataGridView tabelPreparate;
        private TextBox numePreparat;
        private Button adaugaPreparat;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label5;
        private TextBox pretPreparat;
        private Label label6;
        private TextBox stocPreparat;
        private Label label7;
        private TextBox parola;
        private Label label8;
        private TextBox username;
        private Label label9;
        private Button adaugaAngajat;
        private TextBox numeAngajat;
        private Button deleteMeal;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Label label10;
        private Label label11;
        private Button veziComenzi;
        private DateTimePicker firstDate;
        private DateTimePicker secondDate;
    }
}