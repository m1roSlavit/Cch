using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace lab5_api.Models
{
    public partial class Participants
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public int country { get; set; }
        public float competitionRating1 { get; set; }
        public float competitionRating2 { get; set; }
        public float competitionRating3 { get; set; }
    }
}
