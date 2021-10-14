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

namespace binary_multiplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] binarr = new int[8];
        int[] binarr2 = new int[8];
        public MainWindow()
        {
            InitializeComponent();
        }
        static int[] ToBin(SByte n) // перевод в двоичную
        {
            int[] m = new int[8];
            for (int i = 0; i < 8; i++)
            {
                sbyte x = (sbyte)(n & 1);
                if (x > 0)
                {
                    m[i] = 1;
                }
                else
                {
                    m[i] = 0;
                }   
                n = (sbyte)(n >> 1);
            }
            return m;
        }
        static string ToString(int[] n) // преобразование массива в строку
        {
            string s = "";
            for (int i = 7; i >= 0; i--)
            {
                s += n[i] + "";
            }
            return s;
        }
        int[] multyplyBin(int[] n1, int[] n2) // умножение двоичного
        {
            int[] n3 = new int[8];
            int[] value = new int[8];

            for (int i = 7; i >= 0; i--)
            {
                n3 = move(n1, 7 - i);
                if (n2[i] == 1)
                {
                    value = addBin(value, n3);
                }
            }
            return value;
        }
        int[] move(int[] n, int mv) // двигает указатель
        {
            if (mv == 0)
            {
                return n;
            }
            int[] value = new int[8];

            n.CopyTo(value, 0);

            int i, j;
            for (i = 0, j = mv; j < 8; i++, j++)
            {
                value[i] = n[j];
                value[j] = 0;
            }

            for (; i < 8; i++)
            {
                value[i] = 0;
            }
            return value;
        }
        int[] addOne(int[] n, int start) // добавление единички
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
                if (k == 0)
                {
                    break;
                }
            }
            return n;
        }
        int[] addBin(int[] n1, int[] n2) // двоичная сумма
        {
            int[] n3 = new int[8];

            n1.CopyTo(n3, 0);

            for (int i = 7; i >= 0; i--)
            {
                if (n2[i] == 1)
                {
                    n3 = addOne(n3, i);
                }     
            }
            return n3;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var f = Convert.ToSByte(first.Text); // f - первое число
            var s = Convert.ToSByte(second.Text); // s - второе число
            
            binarr = ToBin(f);
            bfirst.Content = ToString(binarr);
            binarr2 = ToBin(s);
            bsecond.Content = ToString(binarr2);

            int[] Ans = multyplyBin(binarr, binarr2);
            answer.Content = ToString(Ans);
            // answer.Content = Convert.ToString(f, 2); // так можно сразу переводить в двоичный
        }
    }
}
