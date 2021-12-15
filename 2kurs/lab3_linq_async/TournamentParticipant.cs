namespace lab3_linq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TournamentParticipant")]
    public partial class TournamentParticipant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(10)]
        public string Sex { get; set; }

        public int? Age { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        public int? CompetitionRating1 { get; set; }

        public int? CompetitionRating2 { get; set; }

        public int? CompetitionRating3 { get; set; }
    }
}
