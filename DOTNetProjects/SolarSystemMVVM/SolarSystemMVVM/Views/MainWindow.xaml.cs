using SolarSystemMVVM.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using SolarSystemMVVM.ViewModels;
using System;
using System.Windows.Threading;

namespace SolarSystemMVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int days = 1;
        MainWindowViewModel _viewModel;
        private TimeSpan SLOW = new TimeSpan(500000);
        public MainWindow()
        {
            _viewModel = new MainWindowViewModel();
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = SLOW;
            timer.Start();
            DataContext = _viewModel;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            UpdatePlanetPositions();
            DrawPlanets();
            if (days == 365)
            {
                days = 0;
            }

            days++;
        }

        #region private methods
        private void UpdatePlanetPositions()
        {
            foreach (SpaceObject spaceObject in _viewModel._solarSystem)
            {
                spaceObject.UpdatePosition(days);
            }
        }

        private void DrawPlanets()
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(255, 0, 255));
            canvasArea.Children.RemoveRange(0, _viewModel._solarSystem.Count);
            foreach (SpaceObject spaceObject in _viewModel._solarSystem)
            {
                Ellipse planet = new Ellipse();
                planet.Height = 20;
                planet.Width = 20;
                planet.Fill = brush;
                Canvas.SetLeft(planet, spaceObject.GetXPos());
                Canvas.SetTop(planet, spaceObject.GetYPos());
                canvasArea.Children.Add(planet);
            }

            #endregion

        }
    }
}

