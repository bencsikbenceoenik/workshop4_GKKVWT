using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using workshop4_GKKVWT.Logic;
using workshop4_GKKVWT.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.IO;
using Newtonsoft.Json;

namespace workshop4_GKKVWT.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IAthleteLogic logic;
        public ObservableCollection<Athlete> Athletes { get; set; }
        public ObservableCollection<Athlete> Team { get; set; }

        private Athlete selectedFromAthletes;

        public Athlete SelectedFromAthletes
        {
            get { return selectedFromAthletes; }
            set
            {
                SetProperty(ref selectedFromAthletes, value);
                if (selectedFromAthletes.Permit == true)
                {
                    (AddToTeamCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                
                (DetailsAthleteCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Athlete selectedFromTeam;
        public Athlete SelectedFromTeam
        {
            get { return selectedFromTeam; }
            set
            {
                SetProperty(ref selectedFromTeam, value);
                (RemoveFromTeamCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddToTeamCommand { get; set; }
        public ICommand RemoveFromTeamCommand { get; set; }
        public ICommand DetailsAthleteCommand { get; set; }

        public int AllCost
        { 
            get
            {
                return logic.AllCost;
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IAthleteLogic>())
        {

        }

        public MainWindowViewModel(IAthleteLogic logic)
        {
            this.logic = logic;
            //Athletes = new ObservableCollection<Athlete>();
            Team = new ObservableCollection<Athlete>()
            {
                new Athlete(){Name="Bence",Pb= 10,ActualBest= 12,Permit=true,Team="ASD",Racetype="Run" }
            };
            Athletes = new ObservableCollection<Athlete>()
            {
                new Athlete(){Name="Bence",Pb= 10,ActualBest= 12,Permit=true,Team="ASD",Racetype="Run" },
                new Athlete(){Name="Laci",Pb= 10,ActualBest= 12,Permit=false,Team="ASD",Racetype="Run" }
            };
            //string jsonstring = File.ReadAllText("athletes.json");
            //Athletes = JsonConvert.DeserializeObject<ObservableCollection<Athlete>>(jsonstring);

            logic.SetupCollections(Athletes, Team);

            AddToTeamCommand = new RelayCommand(
                () => logic.AddToTeam(SelectedFromAthletes),
                () => SelectedFromAthletes != null
                );

            RemoveFromTeamCommand = new RelayCommand(
                () => logic.RemoveFromTeam(SelectedFromTeam),
                () => SelectedFromTeam != null
                );

            DetailsAthleteCommand = new RelayCommand(
                () => logic.DetailsAthlete(SelectedFromAthletes),
                () => SelectedFromAthletes != null
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "AthleteInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AllCost");
            });
        }
    }
}
