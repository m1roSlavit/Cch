using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace lab3_linq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (TournamentParticipantContext mainDB = new TournamentParticipantContext())
            {
                dataGridView1.DataSource = mainDB.TournamentParticipants.AsParallel().ToList<TournamentParticipant>();
            }
        }

        private void beforeAll()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            beforeAll();
            var myList = new List<TournamentParticipant>();
            using (TournamentParticipantContext mainDB = new TournamentParticipantContext())
            {
                myList = mainDB.TournamentParticipants.AsParallel().Where(t => t.Sex == "Male").ToList<TournamentParticipant>();
            }

            dataGridView1.DataSource = myList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            beforeAll();
            using (TournamentParticipantContext mainDB = new TournamentParticipantContext())
            {
                dataGridView1.DataSource = mainDB.TournamentParticipants.AsParallel().OrderByDescending(t => t.Age).Take(1).ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            beforeAll();
            using (TournamentParticipantContext mainDB = new TournamentParticipantContext())
            {
                var countryGroup = mainDB.TournamentParticipants.AsParallel().GroupBy(t => t.Country).ToList();

                dataGridView1.Columns.Add("Country", null);
                dataGridView1.Columns.Add("Participants", null);

                foreach (var t in countryGroup)
                {
                    dataGridView1.Rows.Add(t.Key, t.Count());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            beforeAll();
            using (TournamentParticipantContext mainDB = new TournamentParticipantContext())
            {
                var listData = mainDB.TournamentParticipants.AsParallel().ToList<TournamentParticipant>();

                listData.ForEach(i => {
                    i.CompetitionRating1 += 17;
                    i.CompetitionRating2 += 17;
                    i.CompetitionRating3 += 17;
                });
                string json = JsonConvert.SerializeObject(listData, Formatting.Indented);
                File.WriteAllText("../../tournament-participants.json", json);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            beforeAll();
            using (TournamentParticipantContext mainDB = new TournamentParticipantContext())
            {
                dataGridView1.DataSource = mainDB.TournamentParticipants.AsParallel().OrderBy(i => i.FullName).Skip(1).ToList<TournamentParticipant>();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            beforeAll();
            using (TournamentParticipantContext mainDB = new TournamentParticipantContext())
            {
                string forAllСonditionMsg = mainDB.TournamentParticipants.AsParallel().All(i => (i.CompetitionRating1 + i.CompetitionRating2 + i.CompetitionRating3) / 3 > 60) ? "all have average rating more than 60" : "not all have average rating more than 60";
                string forSomeСonditionMsg = mainDB.TournamentParticipants.AsParallel().Any(i => (i.CompetitionRating1 + i.CompetitionRating2 + i.CompetitionRating3) / 3 > 60) ? "someone have average rating more than 60" : "not someone have average rating more than 60";
                MessageBox.Show($"{forAllСonditionMsg} : {forSomeСonditionMsg}");
            }
        }
    }
}
