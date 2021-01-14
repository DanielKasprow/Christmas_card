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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Daniel_Kasprów_lista_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            window.ResizeMode = ResizeMode.NoResize;
            Zdjecie.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\image1.png" + ""));
            Bombki1.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\image2.png" + ""));
            Bombki2.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\image2.png" + ""));
            Bombki3.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\image2.png" + ""));

            initializeFlashing(Bombki1 ,400);
            initializeFlashing(Bombki2 ,450);
            initializeFlashing(Bombki3 ,500);
        }
        void initializeFlashing(Image image, int lenght)
        {
            DoubleAnimation opacityAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.5,
                Duration = new Duration(TimeSpan.FromMilliseconds(lenght)),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(int.MaxValue)
            };
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(opacityAnimation);
            Storyboard.SetTarget(opacityAnimation, image);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath("Opacity"));
            storyboard.Begin(image);
        }
    }
    public class Photo
    {
        public Photo(string path)
        {
            Source = path;
        }

        public string Source { get; }

        public override string ToString() => Source;
    }
}
