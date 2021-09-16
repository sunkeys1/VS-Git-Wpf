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

namespace Point_Triangle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Line line = new Line();
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 5;
            line.X1 = 50;
            line.Y1 = 70;
            line.X2 = 100;
            line.Y2 = 180;
            canvas.Children.Add(line);
        }
    }
}
