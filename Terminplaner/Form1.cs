using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Terminplaner
{
    public partial class Form1 : Form
    {
        TerminplanerEntities1 db;
        List<Termin> _termine;
        public Form1()
        {
            InitializeComponent();
            db = new TerminplanerEntities1();
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            FormPerson xfrm = new FormPerson();
            xfrm.ShowDialog();
            RefreshComboBox();
            RefreshDgv();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshComboBox();
            RefreshDgv();
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
            RefreshDgv();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int id = 0;
                int rowindex = dataGridView1.CurrentCell.RowIndex;

                id = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[3].Value);
                if (id == 0) return;
                Termin termin = db.Termin.SingleOrDefault(x => x.ID == id);
                if (termin == null) return;
                db.Termin.Remove(termin);
                db.SaveChanges();
                RefreshDgv();
            }

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            RefreshDgv();
        }

        private void RefreshComboBox()
        {
            List<Person> personen = db.Person.ToList();
            comboBox1.DataSource = personen;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
        }

        private void RefreshDgv()
        {
            dataGridView1.Rows.Clear();
            _termine = db.Termin.ToList();

            foreach (Termin t in _termine)
            {
                if (t == null) continue;
                dataGridView1.Rows.Add(t.Person.Name, t.Ort, t.Beschreibung, t.ID);
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            string date = monthCalendar1.SelectionRange.Start.ToShortDateString();
            Calendar calendar = db.Calendar.SingleOrDefault(x => x.Datum == date);
            _termine = db.Termin.Where(x => x.IDCalendar == calendar.ID).ToList();

            foreach (Termin t in _termine)
            {
                if (t == null) continue;
                dataGridView1.Rows.Add(t.Person.Name, t.Ort, t.Beschreibung, t.ID);
            }
        }
    }
}
