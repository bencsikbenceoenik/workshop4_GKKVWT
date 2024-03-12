using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop4_GKKVWT.Models;

namespace workshop4_GKKVWT.Services
{
    public class AthleteDetailsViaWindow : IAthleteDetailsService
    {
        public void Details(Athlete athlete)
        {
            new AtheleteDetailsWindow(athlete).ShowDialog();
        }
    }
}
