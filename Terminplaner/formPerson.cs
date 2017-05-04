using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Terminplaner
{
    public partial class FormPerson : Form
    {
        TerminplanerEF db;
        public FormPerson()
        {
            InitializeComponent();
            db = new TerminplanerEF();
            SetConnectionString();
        }

        private void formPerson_Load(object sender, EventArgs e)
        {
            RefreshListBox();
        }
        /// <summary>
        /// Setzt den ConnectionString zum aktuellen Ordnerpfad, damit eine Verbindung zur Datenbank (SQLite lokal) möglich ist 
        /// </summary>
        private void SetConnectionString()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string connectionString = "data source=" + path + "\\Terminplaner.db";
            db.Database.Connection.ConnectionString = connectionString;
        }
        /// <summary>
        /// Legt eine neue Person an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!isValidUser())
                return;
            Person person = new Person
            {
                Vorname = txtVorname.Text,
                Nachname = txtNachname.Text,
                Strasse = txtStrasse.Text,
                Postleitzahl = Convert.ToInt32(txtPLZ.Text),
                Ort = txtOrt.Text
            };
            db.Person.Add(person);
            db.SaveChanges();
            RefreshListBox();
            clearLabels();
        }

        /// <summary>
        /// Aktualisiert die Listbox
        /// </summary>
        private void RefreshListBox()
        {
            List<Person> personen = db.Person.ToList();
            listBox1.DataSource = personen;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "ID";
        }

        /// <summary>
        /// Anpassung der Textboxen beim Selektieren einer anderen Person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person item = (Person)listBox1.SelectedItem;
            if (item == null) return;
            txtVorname.Text = item.Vorname;
            txtNachname.Text = item.Nachname;
            txtStrasse.Text = item.Strasse;
            txtPLZ.Text = item.Postleitzahl.ToString();
            txtOrt.Text = item.Ort;
        }

        /// <summary>
        /// Speichern der Änderungen an einer Person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Person item = (Person)listBox1.SelectedItem;
            Person person = db.Person.SingleOrDefault(x => x.ID == item.ID);
            if (person == null) return;
            person.Vorname = txtVorname.Text;
            person.Nachname = txtNachname.Text;
            person.Strasse = txtStrasse.Text;
            person.Postleitzahl = Convert.ToInt32(txtPLZ.Text);
            person.Ort = txtOrt.Text;
            db.SaveChanges();
            RefreshListBox();
        }

        /// <summary>
        /// Löschen der selektierten Person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Person item = (Person)listBox1.SelectedItem;
            Person person = db.Person.SingleOrDefault(x => x.ID == item.ID);
            if (person == null) return;
            db.Person.Remove(person);
            db.SaveChanges();
            RefreshListBox();
            clearLabels();
        }

        private bool isValidUser()
        {
            if (String.IsNullOrWhiteSpace(txtNachname.Text))
                return false;
            if (String.IsNullOrWhiteSpace(txtVorname.Text))
                return false;
            List<Person> list = db.Person.Where(x => x.Nachname == txtNachname.Text && x.Vorname == txtVorname.Text).ToList();
            if (list.Count > 0)
            {
                MessageBox.Show("Es exisitiert bereits ein Benutzer mit diesem Namen.");
                return false;
            }
            return true;
        }

        private void clearLabels()
        {
            txtVorname.Clear();
            txtNachname.Clear();
            txtOrt.Clear();
            txtPLZ.Clear();
            txtStrasse.Clear();
        }
    }
}
