using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using workshop4_GKKVWT.Models;
using workshop4_GKKVWT.ViewModels;

namespace workshop4_GKKVWT
{
    /// <summary>
    /// Interaction logic for AtheleteDetailsWindow.xaml
    /// </summary>
    public partial class AtheleteDetailsWindow : Window
    {
        public AtheleteDetailsWindow(Athlete athlete)
        {
            InitializeComponent();
            var vm = new AthleteDetailsWindowViewModel();
            vm.Setup(athlete);
            this.DataContext = vm;
        }
    }
}
