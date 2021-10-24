using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace lab3_linq
{
    public partial class TournamentParticipantContext : DbContext
    {
        public TournamentParticipantContext()
            : base("name=TournamentParticipantContext")
        {
        }

        public virtual DbSet<TournamentParticipant> TournamentParticipants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TournamentParticipant>()
                .Property(e => e.FullName)
                .IsFixedLength();

            modelBuilder.Entity<TournamentParticipant>()
                .Property(e => e.Sex)
                .IsFixedLength();

            modelBuilder.Entity<TournamentParticipant>()
                .Property(e => e.Country)
                .IsFixedLength();
        }
    }
}
