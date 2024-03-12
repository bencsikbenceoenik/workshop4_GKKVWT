using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop4_GKKVWT.Models;

namespace workshop4_GKKVWT.Logic
{
    public interface IAthleteLogic
    {
        int AllCost { get; }
        //double AVGPower { get; }
        //double AVGSpeed { get; }

        void AddToTeam(Athlete athlete);
        void DetailsAthlete(Athlete athlete);
        void RemoveFromTeam(Athlete athlete);
        void SetupCollections(IList<Athlete> athletes, IList<Athlete> Team);
    }
}
