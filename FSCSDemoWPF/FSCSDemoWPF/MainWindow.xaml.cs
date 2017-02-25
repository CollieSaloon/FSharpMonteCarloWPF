using System.Windows;
using System.Windows.Navigation;

namespace FSCSDemoWPF
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Page1 p1 = new Page1();
            //Display an instance of Page1 in the frame that is contained in MainWindow.
            myFrame.NavigationService.Navigate(p1);
            myFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }
    }
}
