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
using System.Xml.Serialization;

namespace lab_1_xml_json
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<TournamentParticipant> tournamentParticipants = new List<TournamentParticipant>{
            new TournamentParticipant("Ivan ivanov Ivanovich", Sex.Male, 24, "Ukraine", 58, 91, 24),
            new TournamentParticipant("Travis Holland", Sex.Male, 36, "USA", 29, 85, 18),
            new TournamentParticipant("Nicole Stevens", Sex.Female, 29, "GB", 11, 100, 87),
            new TournamentParticipant("raymond hunt", Sex.Male, 22, "USA", 89, 75, 56),
            new TournamentParticipant("erica byrd", Sex.Female, 19, "USA", 17, 29, 56),
            new TournamentParticipant("Alberto Stephens", Sex.Male, 24, "Ukraine", 28, 76, 12),
            new TournamentParticipant("Lonnie Fox", Sex.Male, 17, "GB", 91, 87, 89),
            new TournamentParticipant("marjorie king", Sex.Male, 24, "China", 18, 99, 81),
            new TournamentParticipant("roland stevens", Sex.Male, 19, "GB", 98, 76, 29),
            new TournamentParticipant("Irma Day", Sex.Female, 34, "India", 56, 26, 34),
        };

        private async void button1_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<TournamentParticipant>));

            using (FileStream fs = new FileStream("./tournament-participants.xml", FileMode.Create, FileAccess.Write))
            {
                await Task.Run(() => formatter.Serialize(fs, tournamentParticipants.ToList<TournamentParticipant>()));
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(tournamentParticipants, Formatting.Indented);
            await File.WriteAllTextAsync("./tournament-participants.json", json);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            List<TournamentParticipant> data = JsonConvert.DeserializeObject<List<TournamentParticipant>>(await File.ReadAllTextAsync("./tournament-participants.json"));
            List<TournamentParticipant> filteredData = data.Where(tournamentParticipant => tournamentParticipant.Country != textBox1.Text || tournamentParticipant.Age < Convert.ToInt32(textBox2.Text)).ToList<TournamentParticipant>();
            string json = JsonConvert.SerializeObject(filteredData, Formatting.Indented);
            await File.WriteAllTextAsync("./tournament-participants.json", json);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            List<TournamentParticipant> data = new List<TournamentParticipant>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<TournamentParticipant>));

            using (FileStream fs = new FileStream("./tournament-participants.xml", FileMode.Open, FileAccess.Read))
            {    
                data = (List<TournamentParticipant>)await Task.Run(() => formatter.Deserialize(fs));
            }

            var filteredData = data.Where(tournamentParticipant => tournamentParticipant.Country != textBox1.Text || tournamentParticipant.Age < Convert.ToInt32(textBox2.Text)).ToList<TournamentParticipant>();

            using (FileStream fs = new FileStream("./tournament-participants.xml", FileMode.Create, FileAccess.Write))
            {
                await Task.Run(() => formatter.Serialize(fs, filteredData.ToList<TournamentParticipant>()));
            }
        }
    }
    [Serializable]
    public class Sex
    {
       public static string Male = "Male";
       public static string Female = "Female";
    }
    [Serializable]
    public class TournamentParticipant
    {
        public string FullName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public int CompetitionRating1 { get; set; }
        public int CompetitionRating2 { get; set; }
        public int CompetitionRating3 { get; set; }
        public TournamentParticipant(string fullName, string sex, int age, string country, int competitionRating1, int competitionRating2, int competitionRating3)
        {
            this.FullName = fullName;
            this.Sex = sex;
            this.Age = age;
            this.Country = country;
            this.CompetitionRating1 = competitionRating1;
            this.CompetitionRating2 = competitionRating2;
            this.CompetitionRating3 = competitionRating3;
        }
        public TournamentParticipant()
        {
        }
    }

}
