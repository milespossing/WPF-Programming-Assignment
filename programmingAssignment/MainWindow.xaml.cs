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

namespace ProgrammingAssignment
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

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            // I chose to implement this in code behind against what I believe to be my better judgement.
            // I'd certainly prefer to include this behavior in the ViewModel if I could, but I don't know how
            // to move this over there without giving the ViewModel this form, which is against MVVM.
            // The best other option I can think of is to create and implement some ICloseable and toss that into
            // the view model on its creation and call the Close() method of that member on close.
            Close();
        }
    }
}
