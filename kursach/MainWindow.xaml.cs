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

namespace kursach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db; 
        public MainWindow()
        {

            InitializeComponent();
            db = new ApplicationContext();
        }

        public void Button_login(object sender, RoutedEventArgs e)
        {
            var login = textBoxLogin.Text;
            var pass = passBox.Password;

            User authUser = null;

            using (ApplicationContext db = new ApplicationContext())
            {
                authUser = db.Users.Where(b => b.login == login && b.pass == pass).FirstOrDefault();
            }

            if (authUser != null)
            {
                textBoxLogin.BorderBrush = Brushes.Transparent;
                passBox.BorderBrush = Brushes.Transparent;
                WorkWindow workWindow = new WorkWindow();
                workWindow.Show();
                this.Hide();
            }
            else
            {
                textBoxLogin.BorderBrush = Brushes.Red;
                passBox.BorderBrush = Brushes.Red;
            }
            
        }
    }
}