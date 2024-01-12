using Scalp_Checker.src.Dashboard.Helper;
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

namespace Scalp_Checker.src.Dashboard.View
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        private DashboardHelper helper = new DashboardHelper();
        public DashboardView()
        {
            helper.calc();
            InitializeComponent();

            init();
        }

        private void setColorGraph(ProgressBar progress, float value)
        {
            if (value >= 0 && value < 1)
            {
                progress.Foreground = Brushes.Green;
                progress.Background = Brushes.LightGreen;
                progress.BorderBrush = Brushes.LightGreen;
            }
            else if (value >= 1 && value < 2)
            {
                progress.Foreground = Brushes.Yellow;
                progress.Background = Brushes.LightYellow;
                progress.BorderBrush = Brushes.LightYellow;
            }
            else if (value >= 2 && value < 3)
            {
                progress.Foreground = Brushes.DarkOrange;
                progress.Background = Brushes.Orange;
                progress.BorderBrush = Brushes.Orange;
            }
            else if (value >= 3)
            {
                progress.Foreground = Brushes.DarkRed;
                progress.Background = Brushes.Red;
                progress.BorderBrush = Brushes.Red;
            }
        }

        private void init()
        {
            var dandruff_Value = helper.getBIDUM() / 4;
            setColorGraph(progress_Dandrff, helper.getBIDUM());
            progress_Dandrff.Value = dandruff_Value * 100;
            percentage_dandruff.Text = helper.getBIDUM() + " / 3";

            var sebum_value = helper.getFIJI() / 4;
            setColorGraph(progress_Sebum, helper.getFIJI());
            progress_Sebum.Value = sebum_value * 100;
            percentage_sebum.Text = helper.getFIJI() + " / 3";

            var erythema_Value = helper.getHONGBAN() / 4;
            setColorGraph(progress_Erythema, helper.getHONGBAN());
            progress_Erythema.Value = erythema_Value * 100;
            percentage_erythema.Text = helper.getHONGBAN() + " / 3";

            var pustule_Value = helper.getNONGPO() / 4;
            setColorGraph(progress_Pustule, helper.getNONGPO());
            progress_Pustule.Value = pustule_Value * 100;
            percentage_pustule.Text = helper.getNONGPO() + " / 3";

            var microKeratin_Value = helper.getMISE() / 4;
            setColorGraph(progress_MicroKeratin, helper.getMISE());
            progress_MicroKeratin.Value = microKeratin_Value * 100;
            percentage_microKeratin.Text = helper.getMISE() + " / 3";

            var hairLoss_Value = helper.getTALMO() / 4;
            setColorGraph(progress_HairLoss, helper.getTALMO());
            progress_HairLoss.Value = hairLoss_Value * 100;
            percentage_hairLoss.Text = helper.getTALMO() + " / 3";
        }
    }
}
