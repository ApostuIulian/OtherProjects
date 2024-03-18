namespace Assignment1.UI
{
    partial class EmployeeMenu
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
            preparateInStoc = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            cautaPreparat = new TextBox();
            placeOrder = new Button();
            comenziPlasate = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            label3 = new Label();
            actualizeazaStatus = new Button();
            ((System.ComponentModel.ISupportInitialize)preparateInStoc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comenziPlasate).BeginInit();
            SuspendLayout();
            // 
            // preparateInStoc
            // 
            preparateInStoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            preparateInStoc.Location = new Point(12, 128);
            preparateInStoc.Name = "preparateInStoc";
            preparateInStoc.Size = new Size(541, 414);
            preparateInStoc.TabIndex = 0;
            preparateInStoc.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(267, 40);
            label1.TabIndex = 1;
            label1.Text = "Preparate in Stoc";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(267, 29);
            label2.TabIndex = 2;
            label2.Text = "Cauta dupa nume:";
            // 
            // cautaPreparat
            // 
            cautaPreparat.Location = new Point(12, 81);
            cautaPreparat.Name = "cautaPreparat";
            cautaPreparat.Size = new Size(267, 23);
            cautaPreparat.TabIndex = 3;
            cautaPreparat.TextChanged += cautaPreparat_TextChanged;
            // 
            // placeOrder
            // 
            placeOrder.Location = new Point(12, 558);
            placeOrder.Name = "placeOrder";
            placeOrder.Size = new Size(541, 50);
            placeOrder.TabIndex = 4;
            placeOrder.Text = "Plaseaza Comanda";
            placeOrder.UseVisualStyleBackColor = true;
            placeOrder.Click += placeOrder_Click;
            // 
            // comenziPlasate
            // 
            comenziPlasate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            comenziPlasate.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            comenziPlasate.Location = new Point(645, 128);
            comenziPlasate.Name = "comenziPlasate";
            comenziPlasate.Size = new Size(543, 414);
            comenziPlasate.TabIndex = 5;
            comenziPlasate.CellContentClick += comenziPlasate_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "id";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "dataPlasarii";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 200;
            // 
            // Column3
            // 
            Column3.HeaderText = "status";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "costTotal";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(645, 9);
            label3.Name = "label3";
            label3.Size = new Size(543, 40);
            label3.TabIndex = 6;
            label3.Text = "Comenzi Plasate";
            label3.Click += label3_Click;
            // 
            // actualizeazaStatus
            // 
            actualizeazaStatus.Location = new Point(645, 558);
            actualizeazaStatus.Name = "actualizeazaStatus";
            actualizeazaStatus.Size = new Size(543, 50);
            actualizeazaStatus.TabIndex = 7;
            actualizeazaStatus.Text = "Actualizeaza Status";
            actualizeazaStatus.UseVisualStyleBackColor = true;
            actualizeazaStatus.Click += button1_Click;
            // 
            // EmployeeMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 661);
            Controls.Add(actualizeazaStatus);
            Controls.Add(label3);
            Controls.Add(comenziPlasate);
            Controls.Add(placeOrder);
            Controls.Add(cautaPreparat);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(preparateInStoc);
            Name = "EmployeeMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeeMenu";
            ((System.ComponentModel.ISupportInitialize)preparateInStoc).EndInit();
            ((System.ComponentModel.ISupportInitialize)comenziPlasate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView preparateInStoc;
        private Label label1;
        private Label label2;
        private TextBox cautaPreparat;
        private Button placeOrder;
        private DataGridView comenziPlasate;
        private Label label3;
        private Button actualizeazaStatus;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}