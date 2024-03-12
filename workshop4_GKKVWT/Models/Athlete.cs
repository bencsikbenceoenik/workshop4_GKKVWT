using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop4_GKKVWT.Models
{
    public class Athlete : ObservableObject
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { SetProperty(ref name, value); }
		}

		private int pb;

		public int Pb
		{
			get { return pb; }
			set { SetProperty(ref pb, value); }
		}

		private int actualBest;

		public int ActualBest
		{
			get { return actualBest; }
			set { SetProperty(ref actualBest, value); }
		}

		private bool permit;

		public bool Permit
		{
			get { return permit; }
			set { SetProperty(ref permit, value); }
		}

		private string team;

		public string Team
		{
			get { return team; }
			set { SetProperty(ref team, value); }
		}

		private string racetype;

		public string Racetype
		{
			get { return racetype; }
			set { SetProperty(ref racetype, value); }
		}

		public int Worth
		{
			get
			{ 
				return pb * actualBest;
			}
		}

        public Athlete GetCopy()
        {
            return new Athlete()
            {
                Name = this.Name,
				Pb = this.Pb,
				ActualBest = this.ActualBest,
				Permit = this.Permit,
				Team = this.Team,
				Racetype = this.Racetype,
        };
        }


    }
}
