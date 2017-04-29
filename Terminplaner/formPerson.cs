using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminplaner
{
    public partial class formPerson : Form
    {
        TerminplanerEntities db;
        public formPerson()
        {
            InitializeComponent();
            db = new TerminplanerEntities();
            RefreshListBox();
        }

        private void formPerson_Load(object sender, EventArgs e)
        {
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Person person = new Person()
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
        }

        private void RefreshListBox()
        {
            List<Person> personen = db.Person.ToList();
            listBox1.DataSource = personen;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "ID";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person item = (Person)listBox1.SelectedItem;
            if (item != null)
            {
                txtVorname.Text = item.Vorname;
                txtNachname.Text = item.Nachname;
                txtStrasse.Text = item.Strasse;
                txtPLZ.Text = item.Postleitzahl.ToString();
                txtOrt.Text = item.Ort;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Person item = (Person)listBox1.SelectedItem;
            Person person = db.Person.SingleOrDefault(x => x.ID == item.ID);
            if (person != null)
            {
                person.Vorname = txtVorname.Text;
                person.Nachname = txtNachname.Text;
                person.Strasse = txtStrasse.Text;
                person.Postleitzahl = Convert.ToInt32(txtPLZ.Text);
                person.Ort = txtOrt.Text;
                db.SaveChanges();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Person item = (Person)listBox1.SelectedItem;
            Person person = db.Person.SingleOrDefault(x => x.ID == item.ID);
            if (person != null)
            {
                db.Person.Remove(person);
                db.SaveChanges();
            }
        }
    }
}
