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
using System.Windows.Shapes;

namespace Scalp_Checker.src.Frameworks.View
{
    /// <summary>
    /// Interaction logic for SoftwareintegrityTool.xaml
    /// </summary>
    public partial class SoftwareintegrityTool : Window
    {
        public SoftwareintegrityTool()
        {
            InitializeComponent();
            Main.Content = new SoftwareIntegrityMainView();
        }

        private void btn_onClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
    }
}
