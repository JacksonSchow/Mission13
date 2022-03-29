using System;
using System.Linq;

namespace BowlingLeague.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        void AddBowler(Bowler bowler);
        void UpdateBowler(Bowler bowler);
        void DeleteBowler(Bowler bowler);
    }
}
