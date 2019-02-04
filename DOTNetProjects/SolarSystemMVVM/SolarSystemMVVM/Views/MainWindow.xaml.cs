using SolarSystemMVVM.DataProviders;
using SolarSystemMVVM.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SolarSystemMVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            PlanetsDataProvider provider = new PlanetsDataProvider();

            var planets = provider.GetSpaceObjects();

            foreach (SpaceObject so in planets)
            {
                Console.WriteLine(so);
            }

            Console.WriteLine("TOTAL NUMBER OF SPACE OBJECTS : " + planets.Count());
            InitializeComponent();

        }
    }
    }

