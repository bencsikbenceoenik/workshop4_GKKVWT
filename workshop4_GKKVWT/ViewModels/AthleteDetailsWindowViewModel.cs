using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using workshop4_GKKVWT.Models;

namespace workshop4_GKKVWT.ViewModels
{
    public class AthleteDetailsWindowViewModel
    {
        public Athlete Actual { get; set; }

        public void Setup(Athlete athlete)
        {
            this.Actual = athlete;
        }


        public AthleteDetailsWindowViewModel()
        {

        }
    }
}