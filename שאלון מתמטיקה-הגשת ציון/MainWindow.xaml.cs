using System.Data.Common;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace שאלון_מתמטיקה_הגשת_ציון
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int count= 0;
        int count_right= 0;
        private void Bdika_ans(object sender, RoutedEventArgs e)
        {
            int n1 = int.Parse(num1.Text);
            int n2 = int.Parse(num2.Text);
            int answer = 0;
            string pula1 = peula.Text;
            
            if (pula1 == "+")
                answer = n1 + n2;
            else if (pula1 == "-")
                answer = n1 - n2;
            else if (pula1 == "*")
                answer = n1 * n2;
            else answer = n1 / n2;
            int u_ans = int.Parse(user_ans.Text);
            if (answer == u_ans||(double)answer==(double)u_ans)
            {
                right.Visibility = Visibility.Visible;
                count_right++;
            }
            else wrong.Visibility = Visibility.Visible;
            count++;
            if (count == 10)
                Grade();

            check.Visibility = Visibility.Collapsed;
            next_trgil.Visibility = Visibility.Visible;
        }

        private void Targil(object sender, RoutedEventArgs e)
        {
            if (opening.Visibility == Visibility.Visible)
            {
                opening.Visibility = Visibility.Collapsed;
                shelon.Visibility = Visibility.Visible;
            }
            
            int n1 = new Random().Next(1,11);
            int n2 = new Random().Next(2, 11);
            int num_pula= new Random().Next(1, 5);
           
            num1.Text= n1.ToString();
            num2.Text= n2.ToString();
            if (num_pula == 1)
                peula.Text = "+";
            else if (num_pula == 2)
                peula.Text ="-";
            else if (num_pula == 3)
                peula.Text = "*";
            else
            {
                peula.Text = "/";
                if (n2>n1)
                {
                    num1.Text = n2.ToString();
                    num2.Text = n1.ToString();
                }
            }
                
            check.Visibility = Visibility.Visible;
            next_trgil.Visibility = Visibility.Collapsed;
            CancelEverything();
        }
        private void CancelEverything()
        {
            user_ans.Text = "";
            right.Visibility = Visibility.Collapsed;
            wrong.Visibility = Visibility.Collapsed;
        }
        private void Grade()
        {
            int grade = count_right * 10;
            finle_gread.Visibility = Visibility.Visible;
            if (grade >50)
                happy.Visibility = Visibility.Visible;
            else sad.Visibility = Visibility.Visible;

            idk.Text = grade.ToString()+ "/100 הציון הסופי";
            shelon.Visibility= Visibility.Collapsed;
        }
    }
}
