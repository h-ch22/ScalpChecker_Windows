using Scalp_Checker.src.Check.View;
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

namespace Scalp_Checker.src.Frameworks.View
{
    /// <summary>
    /// Interaction logic for SoftwareIntegrityMainView.xaml
    /// </summary>
    public partial class SoftwareIntegrityMainView : Page
    {
        public SoftwareIntegrityMainView()
        {
            InitializeComponent();
        }

        private void btn_onClick(object sender, RoutedEventArgs e)
        {
            if(sender == btn_positive)
            {
                _NavigationFrame.Navigate(new onIntegritingView());

            }
            else
            {
                var parent = Window.GetWindow(this);

                if(parent != null)
                {
                    parent.Close();
                }
            }
        }
    }
}
