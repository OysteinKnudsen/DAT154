using SolarSystem;
using SolarSystem.SpaceObjects;
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
using System.Windows.Threading;

namespace SolarSystemGraphics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Planet[] planets;

        int loopCounter;
        private DispatcherTimer timer;
        Ellipse planetDrawing;
        Random rand = new Random();
        double time = 0;
        Planet sun = new Planet(10, 10, Color.FromRgb(252, 212, 64), 900000, new Coordinates(50, 50));
        Planet mercury = new Planet(50000, 88.0, Color.FromRgb(213, 210, 209), 25000, new Coordinates(0, 0));
       
        

        public MainWindow()
        {
            InitializeComponent();
            planets = new Planet[10];
            planets[0] = sun;
            planets[1] = mercury;


            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += timer1_Tick;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            //Remove the previous ellipse from the paint canvas.
            PaintCanvas.Children.Remove(planetDrawing);

            time += 0.1;
            //Add the ellipse to the canvas
            UpdatePosition(planets);
        }

        private void UpdatePosition(Planet [] planets)
        {
            foreach (Planet planet in planets)
            {
                planetDrawing = DrawPlanet(planet);
                PaintCanvas.Children.Add(planetDrawing);
                Coordinates coords = planet.CalculatePosition(time);
                Canvas.SetLeft(planetDrawing, 100 + coords.x / 1000);
                Canvas.SetTop(planetDrawing, 100 + coords.y / 1000);
            }
            
        }

        private Ellipse CreateAnEllipse(int height, int width)
        {
            SolidColorBrush fillBrush = new SolidColorBrush() { Color = Colors.Red };
            SolidColorBrush borderBrush = new SolidColorBrush() { Color = Colors.Black };

            return new Ellipse()
            {
                Height = height,
                Width = width,
                StrokeThickness = 1,
                Stroke = borderBrush,
                Fill = fillBrush
            };
        }

        private Ellipse DrawPlanet (Planet planet)
        {
            SolidColorBrush fillBrush = new SolidColorBrush() { Color = Color.FromRgb(200,250,234) };
            SolidColorBrush borderBrush = new SolidColorBrush() { Color = Colors.Black };

            return new Ellipse()
            {
                Height = Math.Log(planet._radius),
                Width = Math.Log(planet._radius),
                StrokeThickness = 1,
                Stroke = borderBrush,
                Fill = fillBrush
            };
        }
    }
    }

