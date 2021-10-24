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
                dataGridView1.DataSource = mainDB.TournamentParticipants.ToList<TournamentParticipant>();
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
            using (TournamentParticipantContext mainDB = new TournamentParticipantContext())
            {
                dataGridView1.DataSource = mainDB.TournamentParticipants.Where(t => t.Sex == "Male").ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            beforeAll();
            using (TournamentParticipantContext mainDB = new TournamentParticipantContext())
            {
                dataGridView1.DataSource = mainDB.TournamentParticipants.OrderByDescending(t => t.Age).Take(1).ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            beforeAll();
            using (TournamentParticipantContext mainDB = new TournamentParticipantContext())
            {
                var countryGroup = mainDB.TournamentParticipants.GroupBy(t => t.Country).ToList();

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
                var listData = mainDB.TournamentParticipants.ToList<TournamentParticipant>();

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
                dataGridView1.DataSource = mainDB.TournamentParticipants.OrderBy(i => i.FullName).Skip(1).ToList<TournamentParticipant>();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            beforeAll();
            using (TournamentParticipantContext mainDB = new TournamentParticipantContext())
            {
                string forAllСonditionMsg = mainDB.TournamentParticipants.All(i => (i.CompetitionRating1 + i.CompetitionRating2 + i.CompetitionRating3) / 3 > 60) ? "all have average rating more than 60" : "not all have average rating more than 60";
                string forSomeСonditionMsg = mainDB.TournamentParticipants.Any(i => (i.CompetitionRating1 + i.CompetitionRating2 + i.CompetitionRating3) / 3 > 60) ? "someone have average rating more than 60" : "not someone have average rating more than 60";
                MessageBox.Show($"{forAllСonditionMsg} : {forSomeСonditionMsg}");
            }
        }
    }
}
