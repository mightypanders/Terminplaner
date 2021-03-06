﻿using System.ComponentModel;
using System.Windows.Forms;

namespace Terminplaner
{
    partial class FormPerson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.Vorname = new System.Windows.Forms.Label();
            this.Nachname = new System.Windows.Forms.Label();
            this.Strasse = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVorname = new System.Windows.Forms.TextBox();
            this.txtNachname = new System.Windows.Forms.TextBox();
            this.txtStrasse = new System.Windows.Forms.TextBox();
            this.txtPLZ = new System.Windows.Forms.TextBox();
            this.txtOrt = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Vorname
            // 
            this.Vorname.AutoSize = true;
            this.Vorname.Location = new System.Drawing.Point(271, 13);
            this.Vorname.Name = "Vorname";
            this.Vorname.Size = new System.Drawing.Size(49, 13);
            this.Vorname.TabIndex = 0;
            this.Vorname.Text = "Vorname";
            // 
            // Nachname
            // 
            this.Nachname.AutoSize = true;
            this.Nachname.Location = new System.Drawing.Point(271, 52);
            this.Nachname.Name = "Nachname";
            this.Nachname.Size = new System.Drawing.Size(59, 13);
            this.Nachname.TabIndex = 0;
            this.Nachname.Text = "Nachname";
            // 
            // Strasse
            // 
            this.Strasse.AutoSize = true;
            this.Strasse.Location = new System.Drawing.Point(271, 89);
            this.Strasse.Name = "Strasse";
            this.Strasse.Size = new System.Drawing.Size(42, 13);
            this.Strasse.TabIndex = 0;
            this.Strasse.Text = "Strasse";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Postleitzahl";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ort";
            // 
            // txtVorname
            // 
            this.txtVorname.Location = new System.Drawing.Point(352, 10);
            this.txtVorname.Name = "txtVorname";
            this.txtVorname.Size = new System.Drawing.Size(100, 20);
            this.txtVorname.TabIndex = 1;
            // 
            // txtNachname
            // 
            this.txtNachname.Location = new System.Drawing.Point(352, 49);
            this.txtNachname.Name = "txtNachname";
            this.txtNachname.Size = new System.Drawing.Size(100, 20);
            this.txtNachname.TabIndex = 1;
            // 
            // txtStrasse
            // 
            this.txtStrasse.Location = new System.Drawing.Point(352, 86);
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.Size = new System.Drawing.Size(100, 20);
            this.txtStrasse.TabIndex = 1;
            // 
            // txtPLZ
            // 
            this.txtPLZ.Location = new System.Drawing.Point(352, 130);
            this.txtPLZ.Name = "txtPLZ";
            this.txtPLZ.Size = new System.Drawing.Size(100, 20);
            this.txtPLZ.TabIndex = 1;
            // 
            // txtOrt
            // 
            this.txtOrt.Location = new System.Drawing.Point(352, 173);
            this.txtOrt.Name = "txtOrt";
            this.txtOrt.Size = new System.Drawing.Size(100, 20);
            this.txtOrt.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(238, 329);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(274, 211);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(274, 263);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(148, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "Neuen Benutzer anlegen";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(274, 319);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Löschen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FormPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 375);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtOrt);
            this.Controls.Add(this.txtPLZ);
            this.Controls.Add(this.txtStrasse);
            this.Controls.Add(this.txtNachname);
            this.Controls.Add(this.txtVorname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Strasse);
            this.Controls.Add(this.Nachname);
            this.Controls.Add(this.Vorname);
            this.Name = "FormPerson";
            this.Text = "formPerson";
            this.Load += new System.EventHandler(this.formPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Vorname;
        private Label Nachname;
        private Label Strasse;
        private Label label4;
        private Label label5;
        private TextBox txtVorname;
        private TextBox txtNachname;
        private TextBox txtStrasse;
        private TextBox txtPLZ;
        private TextBox txtOrt;
        private ListBox listBox1;
        private Button btnSave;
        private Button btnNew;
        private Button btnDelete;
    }
}