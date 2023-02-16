using ScalpAnalysis.src.Frameworks.View;
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

namespace ScalpAnalysis.src.Check.View
{
    /// <summary>
    /// Interaction logic for CheckErrorView.xaml
    /// </summary>
    public partial class CheckErrorView : UserControl
    {
        public CheckErrorView()
        {
            InitializeComponent();
        }

        private void onRetryButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow _window = (MainWindow)System.Windows.Application.Current.MainWindow;
            _window.goToPrevious();
        }

        private void onCheckButtonClick(object sender, RoutedEventArgs e)
        {
            SoftwareintegrityTool integrityTool = new SoftwareintegrityTool();
            integrityTool.Show();
        }
    }

}
