using Microsoft.Win32;
using ScalpAnalysis.src.Check.Helper;
using ScalpAnalysis.src.Check.Models;
using ScalpAnalysis.src.Frameworks;
using ScalpAnalysis.src.Frameworks.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScalpAnalysis.src.Check.View
{
    /// <summary>
    /// Interaction logic for CheckView.xaml
    /// </summary>
    public partial class CheckView : UserControl
    {
        private string imgPath = "";
        private CheckViewModel viewModel = new CheckViewModel();

        public CheckView()
        {
            InitializeComponent();
        }

        private void onClick_radioButton_All(object sender, RoutedEventArgs e)
        {
            categorical_group.Visibility = Visibility.Collapsed;
        }

        private void onClick_radioButton_Specific(object sender, RoutedEventArgs e)
        {
            categorical_group.Visibility = Visibility.Visible;
        }

        private void changeVisibility()
        {
            categorical_group.Visibility = Visibility.Collapsed;
            radioButton_All.Visibility = Visibility.Collapsed;
            radioButton_specific.Visibility = Visibility.Collapsed;
            btnOpen.Visibility = Visibility.Collapsed;
            btn_check.Visibility = Visibility.Collapsed;
            progressBar.Visibility = Visibility.Visible;
            radioButton_Keras.Visibility = Visibility.Collapsed;
            radioButton_ViT.Visibility = Visibility.Collapsed;
        }

        private void resetVisibility()
        {
            this.txt_description.Text = "If the imported image matches the image shown below, click the Start inspection button to start the inspection.";

            categorical_group.Visibility = Visibility.Visible;
            radioButton_All.Visibility = Visibility.Visible;
            radioButton_All.IsChecked = true;
            radioButton_specific.IsChecked = false;
            radioButton_specific.Visibility = Visibility.Visible;
            btnOpen.Visibility = Visibility.Visible;
            btn_check.Visibility = Visibility.Visible;
            progressBar.Visibility = Visibility.Collapsed;
            radioButton_Keras.IsChecked = true;
            radioButton_ViT.IsChecked = false;
            radioButton_Keras.Visibility = Visibility.Visible;
            radioButton_ViT.Visibility = Visibility.Visible;
        }

        private async void startInspection()
        {
            changeVisibility();
            this.txt_description.Text = "ScalpChecker is conducting the inspection. Do not exit the software or move to another view(page).";

            CheckHelper helper = new CheckHelper();

            await helper.CheckGPUCompatibility();
            
            if(!helper.getGPUCompatibility())
            {
                var dialog = new CustomMessageBox();
                var result = dialog.Show(Frameworks.Models.DialogType.WARNING, Frameworks.Models.MessageBoxType.Yes_No, "InCompatible GPU", "The GPU installed on this computer may not be compatible with ScalpChecker,\nor the GPU driver, cuDNN, and CUDA Toolkit may not be installed correctly.\nDo you want to continue?\n* If you continue with an incompatible GPU, the scan may be very slow or impossible.");

                if (result == MessageBoxResult.No)
                {
                    resetVisibility();
                    return;
                }
            }

            if(radioButton_Keras.IsChecked ?? true)
            {
                helper.createModelsRoot("Keras");

            } else if(radioButton_ViT.IsChecked ?? false)
            {
                helper.createModelsRoot("ViT");

            }

            var options = "";

            if (radioButton_All.IsChecked ?? false)
            {
                options = "BIDUM, FIJI, MISE, TALMO, HONGBAN, NONGPO";
            }
            else
            {
                if (CheckBox_BIDUM.IsChecked ?? false)
                {
                    options += "BIDUM, ";
                }

                if (CheckBox_FIJI.IsChecked ?? false)
                {
                    options += "FIJI, ";
                }

                if (CheckBox_HONGBAN.IsChecked ?? false)
                {
                    options += "HONGBAN, ";
                }

                if (CheckBox_MISE.IsChecked ?? false)
                {
                    options += "MISE, ";
                }

                if (CheckBox_NONGPO.IsChecked ?? false)
                {
                    options += "NONGPO, ";
                }

                if (CheckBox_TALMO.IsChecked ?? false)
                {
                    options += "TALMO, ";
                }
            }

            var modelType = "";

            if (radioButton_Keras.IsChecked ?? true)
            {
                modelType = "Keras";
            }
            else if(radioButton_ViT.IsChecked ?? false)
            {
                modelType = "ViT";
            }

            var id = createId();
            helper.createProperties(options, imgPath, id, modelType);

            await helper.Check();
            var exitCode = helper.getExitCode();

            if (exitCode == 0)
            {
                MainWindow _window = (MainWindow)Application.Current.MainWindow;
                _window.SetPage(id);

            }
            else
            {
                MainWindow _window = (MainWindow)Application.Current.MainWindow;
                _window.SetError();
            }
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            startInspection();
        }

        private string createId()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[8];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var id = new string(Charsarr);
            var today = DateTime.Now.ToString("MM.dd.yy");

            return today + "_" + id;
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            if((radioButton_All.IsChecked ?? false) || (radioButton_specific.IsChecked ?? false))
            {
                if((radioButton_specific.IsChecked ?? false) && (!CheckBox_BIDUM.IsChecked ?? false) && (!CheckBox_FIJI.IsChecked ?? false) && (!CheckBox_HONGBAN.IsChecked ?? false) && 
                    (!CheckBox_MISE.IsChecked ?? false) && (!CheckBox_NONGPO.IsChecked ?? false) && (!CheckBox_TALMO.IsChecked ?? false))
                {
                    var dialog = new CustomMessageBox();
                    dialog.Show(Frameworks.Models.DialogType.WARNING, Frameworks.Models.MessageBoxType.OK, "Select inspection site", "Please select one or more inspection site(s).");
                }
                else
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Title = "Select a photo";
                    dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";

                    if (dialog.ShowDialog() == true)
                    {
                        imgView_source.Source = new BitmapImage(new Uri(dialog.FileName));
                        this.imgPath = dialog.FileName;
                        imgView_source.Visibility = Visibility.Visible;

                        separator_button.Visibility = Visibility.Visible;
                        btn_check.Visibility = Visibility.Visible;

                        this.txt_description.Text = "If the imported image matches the image shown below, click the Start inspection button to start the inspection.";
                    }
                }
            }
            else
            {
                var dialog = new CustomMessageBox();
                dialog.Show(Frameworks.Models.DialogType.WARNING, Frameworks.Models.MessageBoxType.OK, "Select inspection type", "Please select a inspection type.");
            }

        }
    }
}
