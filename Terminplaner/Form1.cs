using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Drawing;

namespace Terminplaner
{
    public partial class Form1 : Form
    {
        TerminplanerEF db;

        public Form1()
        {
            InitializeComponent();

            db = new TerminplanerEF();
            SetConnectionString();
        }

        /// <summary>
        /// Setzt den ConnectionString zum aktuellen Ordnerpfad, damit eine Verbindung zur Datenbank (SQLite lokal) möglich ist 
        /// </summary>
        private void SetConnectionString()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string connectionString = "data source="+path+"\\Terminplaner.db";
            db.Database.Connection.ConnectionString = connectionString;
        }

        /// <summary>
        /// Öffnet die Form Person zum Anlegen, Bearbeiten und Löschen von Personen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Legt einen neuen Datenbankeintrag zu dem gewünschten Termin an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Löscht den selektierten Termin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Event beim Ändern der Selektion des Tages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            RefreshDgv();
            MarkMeetings();
        }

        /// <summary>
        /// Markiert Termine indem er die Schrift auf fett setzt
        /// </summary>
        private void MarkMeetings()
        {
            monthCalendar1.BoldedDates = ConvertStringToDateTime(db.Calendar.Select(x => x.Datum).ToArray());
        }

        /// <summary>
        /// Konvertiert String-Array to DateTime-Array, weil SQLite kein DateTime kennt..
        /// </summary>
        private DateTime[] ConvertStringToDateTime(string[] stringArray)
        {
            DateTime[] dateTimeArray = new DateTime[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                dateTimeArray[i] = Convert.ToDateTime(stringArray[i]);
            }
            return dateTimeArray;
        }

        /// <summary>
        /// Aktualisiert die Combobox
        /// </summary>
        private void RefreshComboBox()
        {
            try
            {
            List<Person> personen = db.Person.ToList();
            comboBox1.DataSource = personen;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Aktualisiert das DataGridView
        /// </summary>
        private void RefreshDgv()
        {
            dataGridView1.Rows.Clear();
            string selectedDate = monthCalendar1.SelectionRange.Start.ToShortDateString();

            Calendar termine =
                db.Calendar.SingleOrDefault(x => x.Datum == selectedDate);

            if (termine != null && termine.Termin.Any())
            {
                foreach (Termin t in termine.Termin)
                {
                    if (t == null) continue;
                    dataGridView1.Rows.Add(t.Person.Name, t.Ort, t.Beschreibung, t.ID);
                }
            }
        }
    }
}
