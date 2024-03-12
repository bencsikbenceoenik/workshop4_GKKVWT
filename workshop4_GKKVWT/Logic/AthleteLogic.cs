using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop4_GKKVWT.Models;
using workshop4_GKKVWT.Services;

namespace workshop4_GKKVWT.Logic
{
    public class AthleteLogic : IAthleteLogic
    {
        IList<Athlete> athletes;
        IList<Athlete> team;
        IMessenger messenger;
        IAthleteDetailsService detailsService;

        public AthleteLogic(IMessenger messenger, IAthleteDetailsService detailsService)
        {
            this.messenger = messenger;
            this.detailsService = detailsService;
        }

        public void SetupCollections(IList<Athlete> Athletes, IList<Athlete> Team)
        {
            athletes = Athletes;
            team = Team;
        }

        public int AllCost
        {
            get
            {
                return team.Count == 0 ? 0 : team.Sum(t => t.Worth);
            }
        }

        public void AddToTeam(Athlete athlete)
        {
            team.Add(athlete.GetCopy());
            messenger.Send("Athlete added", "AthleteInfo");
        }

        public void DetailsAthlete(Athlete athlete)
        {
            detailsService.Details(athlete);
        }

        public void RemoveFromTeam(Athlete athlete)
        {
            team.Remove(athlete);
            messenger.Send("Athlete removed", "AthleteInfo");
        }
    }
}
