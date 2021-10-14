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

namespace Binary_Multiply
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] f = new int[8]; // f - fisrt
        int[] s = new int[8]; // s - second
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 8; i++)
            {
                Button btnA = new Button();
                btnA.Tag = i;
                btnA.Content = 0;

                btnA.Width = 30;
                btnA.Height = 30;

                btnA.Click += Button_Click_A;


                Button btnB = new Button();
                btnB.Tag = i;
                btnB.Content = 0;

                btnB.Width = 30;
                btnB.Height = 30;

                btnB.Click += Button_Click_B;

                ufgA.Children.Add(btnA);
                ufgB.Children.Add(btnB);
            }
        }
        private void Button_Click_A(object sender, RoutedEventArgs e)
        {


            if(f[(int)(((Button)sender).Tag)] == 1)
            {
                f[(int)(((Button)sender).Tag)] = 0;
            }
            else
            {
                f[(int)(((Button)sender).Tag)] = 1;
            } 
            ((Button)sender).Content = f[(int)(((Button)sender).Tag)];

            decA.Text = binToDec(f).ToString();
        }
        private void Button_Click_B(object sender, RoutedEventArgs e)
        {

            if(s[(int)(((Button)sender).Tag)] == 1)
            {
                s[(int)(((Button)sender).Tag)] = 0;
            }
            else
            {
                s[(int)(((Button)sender).Tag)] = 1;
            }   
            ((Button)sender).Content = s[(int)(((Button)sender).Tag)];
            decB.Text = binToDec(s).ToString();
        }
        sbyte binToDec(int[] n) // двоичное в десятичное
        {
            sbyte res = 0;

            for (int i = 0; i < 8; i++)
            {
                res += (sbyte)((1 << i) * n[7 - i]);
            }
            return res;
        }
        int[] addBinary(int[] n1, int[] n2) // сложение двоичных
        {
            int[] n3 = new int[8];

            n1.CopyTo(n3, 0);

            for (int i = 7; i >= 0; i--)
            {
                if (n2[i] == 1)
                    n3 = addOne(n3, i);
            }
            return n3;
        }
        int[] addOne(int[] n, int start) // добавление
        {
            int k = 1;

            for (int i = start; i >= 0; i--)
            {
                n[i] += k;
                k = 0;

                if (n[i] > 1)
                {
                    n[i] = 0;
                    k = 1;
                }
                if (k == 0) break;
            }
            return n;
        }
        string ToString(int[] n)  // переопределение двоичного в строку
        {
            string res = "";
            for (int i = 0; i < 8; i++)
            {
                res += n[i].ToString();
            }
            return res;
        }
        int[] multiplyBinary(int[] n1, int[] n2) // само умножение двоичных
        {
            int[] n3 = new int[8];
            int[] help = new int[8];

            for (int i = 7; i >= 0; i--)
            {
                n3 = move(n1, 7 - i);
                if (n2[i] == 1)
                {
                    help = addBinary(help, n3);
                }
            }
            return help;
        }
        int[] move(int[] n, int mv) // двигает числа влево
        {
            if (mv == 0) return n;

            int[] help = new int[8];

            n.CopyTo(help, 0);

            int i, j;
            for (i = 0, j = mv; j < 8; i++, j++)
            {
                help[i] = n[j];
                help[j] = 0;
            }

            for (; i < 8; i++)
            {
                help[i] = 0;
            }
            return help;
        }
        private void DecA_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //int[] C = addBinar(f, s);

            //string st = "";
            //for (int i = 0; i < 8; i++)
            //{
            //    st += C[i].ToString();  // эта штука для сложения чисел
            //}
            //value.Content = st + "   " + binToDec(C);
            int[] C = multiplyBinary(f, s);
            value.Content = ToString(C) + "  " + binToDec(C).ToString();
        }
    }
}
