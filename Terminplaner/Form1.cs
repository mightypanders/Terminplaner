using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Terminplaner;

namespace Terminplaner
{
    public partial class Form1 : Form
    {
        TerminplanerEntities db;
        List<Termin> termine;
        public Form1()
        {
            InitializeComponent();
            db = new TerminplanerEntities();
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            formPerson xfrm = new formPerson();
            xfrm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshComboBox();
            RefreshDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Bitte mindestens eine Person anlegen.");
                return;
            }

            string date = monthCalendar1.SelectionRange.Start.ToShortDateString();
            Calendar calendar = db.Calendar.SingleOrDefault(x => x.Datum == date);
            Person person = (Person)comboBox1.SelectedItem;

            if (calendar != null)
            {
                Termin termin = new Termin
                {
                    IDPerson = person.ID,
                    IDCalendar = calendar.ID,
                    Beschreibung = txtDescription.Text,
                    Ort = txtPlace.Text
                };
                db.Termin.Add(termin);
                db.SaveChanges();
            }
            else
            {
                calendar = new Calendar
                {
                    Datum = date
                };
                db.Calendar.Add(calendar);
                db.SaveChanges();

                Termin termin = new Termin
                {
                    IDPerson = person.ID,
                    IDCalendar = calendar.ID,
                    Beschreibung = txtDescription.Text,
                    Ort = txtPlace.Text
                };
                db.Termin.Add(termin);
                db.SaveChanges();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int id = 0;
                int rowindex = dataGridView1.CurrentCell.RowIndex;

                id = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[3].Value);
                if (id != 0)
                {
                    Termin termin = db.Termin.SingleOrDefault(x => x.ID == id);
                    db.Termin.Remove(termin);
                    db.SaveChanges();
                    RefreshDGV();
                }
            }

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            RefreshDGV();
        }

        private void RefreshComboBox()
        {
            List<Person> personen = db.Person.ToList();
            comboBox1.DataSource = personen;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
        }

        private void RefreshDGV()
        {
            dataGridView1.Rows.Clear();
            termine = db.Termin.ToList();

            foreach (Termin t in termine)
            {
                if (t != null)
                {
                    this.dataGridView1.Rows.Add(t.Person.Name, t.Ort, t.Beschreibung, t.ID);
                }
            }
        }
    }
}
