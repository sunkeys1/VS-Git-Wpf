using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Сапьёр
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Size = 30;

        cGen gen;
        int count;
        Button[,] btns;
        BitmapImage mine = new BitmapImage(new Uri(@"F:\VS Git Wpf\Сапьёр\Mine.png", UriKind.Absolute));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            //получение значения лежащего в Tag
            int i = (int)((Button)sender).Tag;


            int oi = i % int.Parse(tbA.Text); //коорд кнопки кот нажали
            int oj = i / int.Parse(tbA.Text); //

            if (gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text)) == 0)
            {
                //установка фона нажатой кнопки, цвета и размера шрифта
                ((Button)sender).Background = Brushes.White;
                ((Button)sender).Foreground = Brushes.Black;
                ((Button)sender).FontSize = 23;
                //запись в нажатую кнопку её номера

            }

            if (gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text)) == 9)
            {
                //создание контейнера для хранения изображения
                Image img = new Image();
                //запись картинки с миной в контейнер
                img.Source = mine;
                //создание компонента для отображения изображения
                StackPanel stackPnl = new StackPanel();
                //установка толщины границ компонента
                stackPnl.Margin = new Thickness(1);
                //добавление контейнера с картинкой в компонент
                stackPnl.Children.Add(img);
                //запись компонента в кнопку
                ((Button)sender).Content = stackPnl;
                MessageBox.Show("Game over :(");

                ugr.Children.Clear();
                ((Button)sender).Background = Brushes.White;
                foreach (Button b in ugr.Children)
                {

                    int ind = (int)(b).Tag;
                    int ni = ind % int.Parse(tbA.Text);
                    int nj = ind / int.Parse(tbA.Text);
                    if (ind != i)
                    {
                        if (((Math.Abs(oi - ni) == 1) && (Math.Abs(oj - nj) == 0) || ((Math.Abs(oi - ni) == 0)) && (Math.Abs(oj - nj) == 1) || ((Math.Abs(oi - ni) == 1) && (Math.Abs(oj - nj) == 1)))) ;
                        {

                            if (b.Background != Brushes.White)
                            {
                                if (gen.getCell(ni, nj) == 9)
                                    Btn_Click(b, e);
                            }
                        }
                    }
                }
            }
            if (gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text)) == 0)
            {
                ((Button)sender).Content = " ";
                count++;
                ((Button)sender).IsEnabled = false;
            }
            if (gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text)) == 1)
            {
                ((Button)sender).Content = gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text));
                ((Button)sender).Foreground = Brushes.Blue;
                ((Button)sender).Background = Brushes.White;
                count++;
                ((Button)sender).IsEnabled = false;
                   
            }
            if (gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text)) == 2)
            {
                ((Button)sender).Content = gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text));
                ((Button)sender).Foreground = Brushes.Green;
                ((Button)sender).Background = Brushes.White;
                count++;
                ((Button)sender).IsEnabled = false;
            }
            if (gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text)) == 3)
            {
                ((Button)sender).Content = gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text));
                ((Button)sender).Foreground = Brushes.Red;
                ((Button)sender).Background = Brushes.White;
                count++;
                ((Button)sender).IsEnabled = false;
            }
            if (gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text)) == 4)
            {
                ((Button)sender).Content = gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text));
                ((Button)sender).Foreground = Brushes.Brown;
                ((Button)sender).Background = Brushes.White;
                count++;
                ((Button)sender).IsEnabled = false;
            }
            if (gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text)) == 5)
            {
                ((Button)sender).Content = gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text));
                ((Button)sender).Foreground = Brushes.Purple;
                ((Button)sender).Background = Brushes.White;
                count++;
                ((Button)sender).IsEnabled = false;
            }
            if (gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text)) == 6)
            {
                ((Button)sender).Content = gen.getCell(i % int.Parse(tbA.Text), i / int.Parse(tbA.Text));
                ((Button)sender).Foreground = Brushes.MidnightBlue;
                ((Button)sender).Background = Brushes.White;
                count++;
                ((Button)sender).IsEnabled = false;
            }
            if (count == int.Parse(tbA.Text) * int.Parse(tbA.Text) - int.Parse(tbC.Text))
            {
                MessageBox.Show("Here is a winner!");
                ugr.Children.Clear();

                count = 0;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            //указыается количество строк и столбцов в сетке
            ugr.Rows = int.Parse(tbA.Text);
            // ugr.Columns = int.Parse(tbB.Text);
            //указываются размеры сетки (число ячеек * (размер кнопки в ячейки + толщина её границ))
            ugr.Width = int.Parse(tbA.Text) * (Size + 4);
            ugr.Height = int.Parse(tbA.Text) * (Size + 4);
            //толщина границ сетки
            ugr.Margin = new Thickness(5, 5, 5, 5);
            gen = new cGen(int.Parse(tbA.Text), int.Parse(tbC.Text));

            gen.generate();


            ugr.Children.Clear();
            for (int i = 0; i < int.Parse(tbA.Text) * int.Parse(tbA.Text); i++)

            {
                //создание кнопки
                Button btn = new Button();
                //запись номера кнопки
                btn.Tag = i;
                //установка размеров кнопки
                btn.Width = Size;
                btn.Height = Size;
                //текст на кнопке
                btn.Content = " ";
                //толщина границ кнопки
                btn.Margin = new Thickness(2);
                //при нажатии кнопки, будет вызываться метод Btn_Click
                btn.Click += Btn_Click;

                //добавление кнопки в сетку
                ugr.Children.Add(btn);
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}