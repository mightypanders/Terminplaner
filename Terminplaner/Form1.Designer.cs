using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Terminplaner
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPerson = new Button();
            this.btnAdd = new Button();
            this.monthCalendar1 = new MonthCalendar();
            this.comboBox1 = new ComboBox();
            this.btnDelete = new Button();
            this.dataGridView1 = new DataGridView();
            this.colPerson = new DataGridViewTextBoxColumn();
            this.colPlace = new DataGridViewTextBoxColumn();
            this.colDescription = new DataGridViewTextBoxColumn();
            this.colID = new DataGridViewTextBoxColumn();
            this.txtDescription = new TextBox();
            this.txtPlace = new TextBox();
            this.lblDescription = new Label();
            this.label2 = new Label();
            ((ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPerson
            // 
            this.btnPerson.Location = new Point(29, 33);
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new Size(75, 23);
            this.btnPerson.TabIndex = 0;
            this.btnPerson.Text = "Personen";
            this.btnPerson.UseVisualStyleBackColor = true;
            this.btnPerson.Click += new EventHandler(this.btnPerson_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new Point(19, 435);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(178, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Termin hinzufügen";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new Point(18, 68);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateChanged += new DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(20, 274);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(178, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new Point(19, 477);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(178, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Termin löschen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
            this.colPerson,
            this.colPlace,
            this.colDescription,
            this.colID});
            this.dataGridView1.Location = new Point(233, 33);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new Size(521, 491);
            this.dataGridView1.TabIndex = 4;
            // 
            // colPerson
            // 
            this.colPerson.HeaderText = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.ReadOnly = true;
            // 
            // colPlace
            // 
            this.colPlace.HeaderText = "Ort";
            this.colPlace.Name = "colPlace";
            this.colPlace.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Beschreibung";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new Point(97, 313);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new Size(100, 20);
            this.txtDescription.TabIndex = 5;
            // 
            // txtPlace
            // 
            this.txtPlace.Location = new Point(97, 351);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new Size(100, 20);
            this.txtPlace.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new Point(17, 316);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(72, 13);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Beschreibung";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(17, 354);
            this.label2.Name = "label2";
            this.label2.Size = new Size(21, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ort";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(776, 536);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtPlace);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnPerson);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new EventHandler(this.Form1_Load);
            ((ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnPerson;
        private Button btnAdd;
        private MonthCalendar monthCalendar1;
        private ComboBox comboBox1;
        private Button btnDelete;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colPerson;
        private DataGridViewTextBoxColumn colPlace;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colID;
        private TextBox txtDescription;
        private TextBox txtPlace;
        private Label lblDescription;
        private Label label2;
    }
}

