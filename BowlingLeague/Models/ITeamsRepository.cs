using System;
using System.Linq;

namespace BowlingLeague.Models
{
    public interface ITeamsRepository
    {
        IQueryable<Team> Teams { get; }
    }
}
