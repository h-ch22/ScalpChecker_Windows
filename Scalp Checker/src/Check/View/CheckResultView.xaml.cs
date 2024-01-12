using Scalp_Checker.src.Check.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Brushes = System.Windows.Media.Brushes;

namespace Scalp_Checker.src.Check.View
{
    /// <summary>
    /// Interaction logic for CheckResultView.xaml
    /// </summary>
    public partial class CheckResultView : UserControl
    {
        string id;
        public CheckResultView()
        {
            this.id = CheckResultViewModel.getID();
            Console.WriteLine(id);

            InitializeComponent();
            showResult();
        }

        private void onRetryButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow _window = (MainWindow)System.Windows.Application.Current.MainWindow;
            _window.goToPrevious();
        }

        private void showResult()
        {
            var result_root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\" + id + @"\";
            DirectoryInfo dirinfo = new DirectoryInfo(result_root);

            FileInfo[] files = dirinfo.GetFiles("*.png");

            foreach(FileInfo file in files)
            {
                if (file.Name.Contains("BIDUM"))
                {
                    imgView_BIDUM.Source = new BitmapImage(new Uri(result_root + file.Name));
                } else if (file.Name.Contains("FIJI"))
                {
                    imgView_FIJI.Source = new BitmapImage(new Uri(result_root + file.Name));
                } else if (file.Name.Contains("MISE"))
                {
                    imgView_MISE.Source = new BitmapImage(new Uri(result_root + file.Name));
                } else if (file.Name.Contains("TALMO"))
                {
                    imgView_TALMO.Source = new BitmapImage(new Uri(result_root + file.Name));
                } else if (file.Name.Contains("HONGBAN"))
                {
                    imgView_HONGBAN.Source = new BitmapImage(new Uri(result_root + file.Name));
                } else if (file.Name.Contains("NONGPO"))
                {
                    imgView_NONGPO.Source = new BitmapImage(new Uri(result_root + file.Name));
                }
            }

            var result_txt_root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\Results\Results_" + id + @".txt";
            string results = System.IO.File.ReadAllText(result_txt_root);

            if(results != "")
            {
                string[] splited_results = results.Split('\n');

                foreach(string result in splited_results)
                {
                    string replaced = result.Replace("['", "");
                    replaced = replaced.Replace("']", "");
                    replaced = replaced.Replace("\n", "");

                    if (replaced.Contains("BIDUM"))
                    {
                        string[] result_BIDUM = replaced.Split(':');

                        TXT_RESULT_BIDUM.Text = "Dandruff :" + result_BIDUM[2];

                        Console.WriteLine(result_BIDUM[2]);

                        if (result_BIDUM[2].Contains("level0"))
                        {
                            TXT_RESULT_BIDUM.Foreground = Brushes.LightGreen;
                            imgView_BIDUM.Visibility = Visibility.Collapsed;
                            TXT_NORMAL_BIDUM.Visibility = Visibility.Visible;
                        } else if (result_BIDUM[2].Contains("level1"))
                        {
                            TXT_RESULT_BIDUM.Foreground = Brushes.Yellow;
                            imgView_BIDUM.Visibility = Visibility.Visible;
                            TXT_NORMAL_BIDUM.Visibility = Visibility.Collapsed;
                        } else if (result_BIDUM[2].Contains("level2"))
                        {
                            TXT_RESULT_BIDUM.Foreground = Brushes.Orange;
                            imgView_BIDUM.Visibility = Visibility.Visible;
                            TXT_NORMAL_BIDUM.Visibility = Visibility.Collapsed;
                        } else if (result_BIDUM[2].Contains("level3"))
                        {
                            TXT_RESULT_BIDUM.Foreground = Brushes.Red;
                            imgView_BIDUM.Visibility = Visibility.Visible;
                            TXT_NORMAL_BIDUM.Visibility = Visibility.Collapsed;
                        }
                    }

                    else if (replaced.Contains("FIJI"))
                    {
                        string[] result_FIJI = replaced.Split(':');
                        TXT_RESULT_FIJI.Text = "Oiliness :" + result_FIJI[2];

                        if (result_FIJI[2].Contains("level0"))
                        {
                            TXT_RESULT_FIJI.Foreground = Brushes.LightGreen;
                            imgView_FIJI.Visibility = Visibility.Collapsed;
                            TXT_NORMAL_FIJI.Visibility = Visibility.Visible;
                        }
                        else if (result_FIJI[2].Contains("level1"))
                        {
                            TXT_RESULT_FIJI.Foreground = Brushes.Yellow;
                            imgView_FIJI.Visibility = Visibility.Visible;
                            TXT_NORMAL_FIJI.Visibility = Visibility.Collapsed;
                        }
                        else if (result_FIJI[2].Contains("level2"))
                        {
                            TXT_RESULT_FIJI.Foreground = Brushes.Orange;
                            imgView_FIJI.Visibility = Visibility.Visible;
                            TXT_NORMAL_FIJI.Visibility = Visibility.Collapsed;
                        }
                        else if (result_FIJI[2].Contains("level3"))
                        {
                            TXT_RESULT_FIJI.Foreground = Brushes.Red;
                            imgView_FIJI.Visibility = Visibility.Visible;
                            TXT_NORMAL_FIJI.Visibility = Visibility.Collapsed;

                        }
                    }

                    else if (replaced.Contains("MISE"))
                    {
                        string[] result_MISE = replaced.Split(':');
                        TXT_RESULT_MISE.Text = "Dryness :" + result_MISE[2];


                        if (result_MISE[2].Contains("level0"))
                        {
                            TXT_RESULT_MISE.Foreground = Brushes.LightGreen;
                            imgView_MISE.Visibility = Visibility.Collapsed;
                            TXT_NORMAL_MISE.Visibility = Visibility.Visible;
                        }
                        else if (result_MISE[2].Contains("level1"))
                        {
                            TXT_RESULT_MISE.Foreground = Brushes.Yellow;
                            imgView_MISE.Visibility = Visibility.Visible;
                            TXT_NORMAL_MISE.Visibility = Visibility.Collapsed;
                        }
                        else if (result_MISE[2].Contains("level2"))
                        {
                            TXT_RESULT_MISE.Foreground = Brushes.Orange;
                            imgView_MISE.Visibility = Visibility.Visible;
                            TXT_NORMAL_MISE.Visibility = Visibility.Collapsed;
                        }

                        else if (result_MISE[2].Contains("level3"))
                        {
                            TXT_RESULT_MISE.Foreground = Brushes.Red;
                            imgView_MISE.Visibility = Visibility.Visible;
                            TXT_NORMAL_MISE.Visibility = Visibility.Collapsed;
                        }
                    }

                    else if (replaced.Contains("TALMO"))
                    {
                        string[] result_TALMO = replaced.Split(':');
                        TXT_RESULT_TALMO.Text = "Hair loss :" + result_TALMO[2];

                        if (result_TALMO[2].Contains("level0"))
                        {
                            TXT_RESULT_TALMO.Foreground = Brushes.LightGreen;
                            imgView_TALMO.Visibility = Visibility.Collapsed;
                            TXT_NORMAL_TALMO.Visibility = Visibility.Visible;
                        }
                        else if (result_TALMO[2].Contains("level1"))
                        {
                            TXT_RESULT_TALMO.Foreground = Brushes.Yellow;
                            imgView_TALMO.Visibility = Visibility.Visible;
                            TXT_NORMAL_TALMO.Visibility = Visibility.Collapsed;
                        }
                        else if (result_TALMO[2].Contains("level2"))
                        {
                            TXT_RESULT_TALMO.Foreground = Brushes.Orange;
                            imgView_TALMO.Visibility = Visibility.Visible;
                            TXT_NORMAL_TALMO.Visibility = Visibility.Collapsed;
                        }
                        else if (result_TALMO[2].Contains("level3"))
                        {
                            TXT_RESULT_TALMO.Foreground = Brushes.Red;
                            imgView_TALMO.Visibility = Visibility.Visible;
                            TXT_NORMAL_TALMO.Visibility = Visibility.Collapsed;
                        }
                    }

                    else if (replaced.Contains("HONGBAN"))
                    {
                        string[] result_HONGBAN = replaced.Split(':');
                        TXT_RESULT_HONGBAN.Text = "Erythema :" + result_HONGBAN[2];

                        if (result_HONGBAN[2].Contains("level0"))
                        {
                            TXT_RESULT_HONGBAN.Foreground = Brushes.LightGreen;
                            imgView_HONGBAN.Visibility = Visibility.Collapsed;
                            TXT_NORMAL_HONGBAN.Visibility = Visibility.Visible;
                        }
                        else if (result_HONGBAN[2].Contains("level1"))
                        {
                            TXT_RESULT_HONGBAN.Foreground = Brushes.Yellow;
                            imgView_HONGBAN.Visibility = Visibility.Visible;
                            TXT_NORMAL_HONGBAN.Visibility = Visibility.Collapsed;
                        }
                        else if (result_HONGBAN[2].Contains("level2"))
                        {
                            TXT_RESULT_HONGBAN.Foreground = Brushes.Orange;
                            imgView_HONGBAN.Visibility = Visibility.Visible;
                            TXT_NORMAL_HONGBAN.Visibility = Visibility.Collapsed;
                        }
                        else if (result_HONGBAN[2].Contains("level3"))
                        {
                            TXT_RESULT_HONGBAN.Foreground = Brushes.Red;
                            imgView_HONGBAN.Visibility = Visibility.Visible;
                            TXT_NORMAL_HONGBAN.Visibility = Visibility.Collapsed;

                        }
                    }

                    else if (replaced.Contains("NONGPO"))
                    {
                        string[] result_NONGPO = replaced.Split(':');
                        TXT_RESULT_NONGPO.Text = "Foliculitis :" + result_NONGPO[2];

                        if (result_NONGPO[2].Contains("level0"))
                        {
                            TXT_RESULT_NONGPO.Foreground = Brushes.LightGreen;
                            imgView_NONGPO.Visibility = Visibility.Collapsed;
                            TXT_NORMAL_NONGPO.Visibility = Visibility.Visible;
                        }
                        else if (result_NONGPO[2].Contains("level1"))
                        {
                            TXT_RESULT_NONGPO.Foreground = Brushes.Yellow;
                            imgView_NONGPO.Visibility = Visibility.Visible;
                            TXT_NORMAL_NONGPO.Visibility = Visibility.Collapsed;
                        }
                        else if (result_NONGPO[2].Contains("level2"))
                        {
                            TXT_RESULT_NONGPO.Foreground = Brushes.Orange;
                            imgView_NONGPO.Visibility = Visibility.Visible;
                            TXT_NORMAL_NONGPO.Visibility = Visibility.Collapsed;
                        }
                        else if (result_NONGPO[2].Contains("level3"))
                        {
                            TXT_RESULT_NONGPO.Foreground = Brushes.Red;
                            imgView_NONGPO.Visibility = Visibility.Visible;
                            TXT_NORMAL_NONGPO.Visibility = Visibility.Collapsed;

                        }
                    }
                }
            }
        }
    }
}
