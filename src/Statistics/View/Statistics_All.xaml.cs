using ScalpAnalysis.src.Statistics.Helper;
using System;
using System.Collections.Generic;
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

namespace ScalpAnalysis.src.Statistics.View
{
    /// <summary>
    /// Interaction logic for Statistics_All.xaml
    /// </summary>
    public partial class Statistics_All : Page
    {
        public Statistics_All()
        {
            InitializeComponent();
        }

        private void reset()
        {
            TXT_TITLE_DANDRUFF.Text = "Dandruff";
            TXT_TITLE_DANDRUFF.Foreground = Brushes.White;

            TXT_TITLE_ERYTHEMA.Text = "Erythema";
            TXT_TITLE_ERYTHEMA.Foreground = Brushes.White;

            TXT_TITLE_HAIRLOSS.Text = "Hair loss";
            TXT_TITLE_HAIRLOSS.Foreground = Brushes.White;

            TXT_TITLE_MICROKERATIN.Text = "Microkeratin";
            TXT_TITLE_MICROKERATIN.Foreground = Brushes.White;

            TXT_TITLE_PUSTULE.Text = "Pustule";
            TXT_TITLE_PUSTULE.Foreground = Brushes.White;

            TXT_TITLE_SEBUM.Text = "Sebum";
            TXT_TITLE_SEBUM.Foreground = Brushes.White;
        }

        public void setResults()
        {
            reset();
            var result_txt_root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\Results\Results_" + StatisticsHelper.selectedDate + "_" + StatisticsHelper.selectedID;
            string results = System.IO.File.ReadAllText(result_txt_root);

            if (results != "")
            {
                string[] splited_results = results.Split('\n');

                foreach (string result in splited_results)
                {
                    Console.WriteLine(result);

                    string replaced = result.Replace("['", "");
                    replaced = replaced.Replace("']", "");
                    replaced = replaced.Replace("\n", "");

                    if (replaced.Contains("BIDUM"))
                    {
                        string[] result_BIDUM = replaced.Split(':');

                        TXT_TITLE_DANDRUFF.Text = "Dandruff :" + result_BIDUM[2];

                        Console.WriteLine(result_BIDUM[2]);

                        if (result_BIDUM[2].Contains("level0"))
                        {
                            TXT_TITLE_DANDRUFF.Foreground = Brushes.LightGreen;
                            imgView_DANDRUFF.Visibility = Visibility.Collapsed;
                            TXT_NODATA_DANDRUFF.Visibility = Visibility.Visible;
                            TXT_NODATA_DANDRUFF.Text = "NORMAL";
                            TXT_NODATA_DANDRUFF.Foreground = Brushes.LightGreen;
                        }
                        else if (result_BIDUM[2].Contains("level1"))
                        {
                            TXT_TITLE_DANDRUFF.Foreground = Brushes.Yellow;
                            imgView_DANDRUFF.Visibility = Visibility.Visible;
                            TXT_NODATA_DANDRUFF.Visibility = Visibility.Collapsed;
                        }
                        else if (result_BIDUM[2].Contains("level2"))
                        {
                            TXT_TITLE_DANDRUFF.Foreground = Brushes.Orange;
                            imgView_DANDRUFF.Visibility = Visibility.Visible;
                            TXT_NODATA_DANDRUFF.Visibility = Visibility.Collapsed;
                        }
                        else if (result_BIDUM[2].Contains("level3"))
                        {
                            TXT_TITLE_DANDRUFF.Foreground = Brushes.Red;
                            imgView_DANDRUFF.Visibility = Visibility.Visible;
                            TXT_NODATA_DANDRUFF.Visibility = Visibility.Collapsed;
                        }

                    }

                    else if (replaced.Contains("FIJI"))
                    {
                        string[] result_FIJI = replaced.Split(':');
                        TXT_TITLE_SEBUM.Text = "Sebum :" + result_FIJI[2];

                        if (result_FIJI[2].Contains("level0"))
                        {
                            TXT_TITLE_SEBUM.Foreground = Brushes.LightGreen;
                            imgView_SEBUM.Visibility = Visibility.Collapsed;
                            TXT_NODATA_SEBUM.Visibility = Visibility.Visible;
                            TXT_NODATA_SEBUM.Text = "NORMAL";
                            TXT_NODATA_SEBUM.Foreground = Brushes.LightGreen;
                        }
                        else if (result_FIJI[2].Contains("level1"))
                        {
                            TXT_TITLE_SEBUM.Foreground = Brushes.Yellow;
                            imgView_SEBUM.Visibility = Visibility.Visible;
                            TXT_NODATA_SEBUM.Visibility = Visibility.Collapsed;
                        }
                        else if (result_FIJI[2].Contains("level2"))
                        {
                            TXT_TITLE_SEBUM.Foreground = Brushes.Orange;
                            imgView_SEBUM.Visibility = Visibility.Visible;
                            TXT_NODATA_SEBUM.Visibility = Visibility.Collapsed;
                        }
                        else if (result_FIJI[2].Contains("level3"))
                        {
                            TXT_TITLE_SEBUM.Foreground = Brushes.Red;
                            imgView_SEBUM.Visibility = Visibility.Visible;
                            TXT_NODATA_SEBUM.Visibility = Visibility.Collapsed;
                        }
                    }

                    else if (replaced.Contains("MISE"))
                    {
                        string[] result_MISE = replaced.Split(':');
                        TXT_TITLE_MICROKERATIN.Text = "Microkeratin :" + result_MISE[2];


                        if (result_MISE[2].Contains("level0"))
                        {
                            TXT_TITLE_MICROKERATIN.Foreground = Brushes.LightGreen;
                            imgView_MICROKERATIN.Visibility = Visibility.Collapsed;
                            TXT_NODATA_MICROKERATIN.Visibility = Visibility.Visible;
                            TXT_NODATA_MICROKERATIN.Text = "NORMAL";
                            TXT_NODATA_MICROKERATIN.Foreground = Brushes.LightGreen;
                        }
                        else if (result_MISE[2].Contains("level1"))
                        {
                            TXT_TITLE_MICROKERATIN.Foreground = Brushes.Yellow;
                            TXT_TITLE_MICROKERATIN.Visibility = Visibility.Visible;
                            TXT_NODATA_MICROKERATIN.Visibility = Visibility.Collapsed;
                        }
                        else if (result_MISE[2].Contains("level2"))
                        {
                            TXT_TITLE_MICROKERATIN.Foreground = Brushes.Orange;
                            TXT_TITLE_MICROKERATIN.Visibility = Visibility.Visible;
                            TXT_NODATA_MICROKERATIN.Visibility = Visibility.Collapsed;
                        }

                        else if (result_MISE[2].Contains("level3"))
                        {
                            TXT_TITLE_MICROKERATIN.Foreground = Brushes.Red;
                            TXT_TITLE_MICROKERATIN.Visibility = Visibility.Visible;
                            TXT_NODATA_MICROKERATIN.Visibility = Visibility.Collapsed;
                        }
                    }

                    else if (replaced.Contains("TALMO"))
                    {
                        string[] result_TALMO = replaced.Split(':');
                        TXT_TITLE_HAIRLOSS.Text = "Hair loss :" + result_TALMO[2];

                        if (result_TALMO[2].Contains("level0"))
                        {
                            TXT_TITLE_HAIRLOSS.Foreground = Brushes.LightGreen;
                            imgView_HAIRLOSS.Visibility = Visibility.Collapsed;
                            TXT_NODATA_HAIRLOSS.Visibility = Visibility.Visible;
                            TXT_NODATA_HAIRLOSS.Text = "NORMAL";
                            TXT_NODATA_HAIRLOSS.Foreground = Brushes.LightGreen;
                        }
                        else if (result_TALMO[2].Contains("level1"))
                        {
                            TXT_TITLE_HAIRLOSS.Foreground = Brushes.Yellow;
                            imgView_HAIRLOSS.Visibility = Visibility.Visible;
                            TXT_NODATA_HAIRLOSS.Visibility = Visibility.Collapsed;
                        }
                        else if (result_TALMO[2].Contains("level2"))
                        {
                            TXT_TITLE_HAIRLOSS.Foreground = Brushes.Orange;
                            imgView_HAIRLOSS.Visibility = Visibility.Visible;
                            TXT_NODATA_HAIRLOSS.Visibility = Visibility.Collapsed;
                        }
                        else if (result_TALMO[2].Contains("level3"))
                        {
                            TXT_TITLE_HAIRLOSS.Foreground = Brushes.Red;
                            imgView_HAIRLOSS.Visibility = Visibility.Visible;
                            TXT_NODATA_HAIRLOSS.Visibility = Visibility.Collapsed;
                        }
                    }

                    else if (replaced.Contains("HONGBAN"))
                    {
                        string[] result_HONGBAN = replaced.Split(':');
                        TXT_TITLE_ERYTHEMA.Text = "Erythema :" + result_HONGBAN[2];

                        if (result_HONGBAN[2].Contains("level0"))
                        {
                            TXT_TITLE_ERYTHEMA.Foreground = Brushes.LightGreen;
                            imgView_ERYTHEMA.Visibility = Visibility.Collapsed;
                            TXT_NODATA_ERYTHEMA.Visibility = Visibility.Visible;
                            TXT_NODATA_ERYTHEMA.Text = "NORMAL";
                            TXT_NODATA_ERYTHEMA.Foreground = Brushes.LightGreen;
                        }
                        else if (result_HONGBAN[2].Contains("level1"))
                        {
                            TXT_TITLE_ERYTHEMA.Foreground = Brushes.Yellow;
                            imgView_ERYTHEMA.Visibility = Visibility.Visible;
                            TXT_NODATA_ERYTHEMA.Visibility = Visibility.Collapsed;
                        }
                        else if (result_HONGBAN[2].Contains("level2"))
                        {
                            TXT_TITLE_ERYTHEMA.Foreground = Brushes.Orange;
                            imgView_ERYTHEMA.Visibility = Visibility.Visible;
                            TXT_NODATA_ERYTHEMA.Visibility = Visibility.Collapsed;
                        }
                        else if (result_HONGBAN[2].Contains("level3"))
                        {
                            TXT_TITLE_ERYTHEMA.Foreground = Brushes.Red;
                            imgView_ERYTHEMA.Visibility = Visibility.Visible;
                            TXT_NODATA_ERYTHEMA.Visibility = Visibility.Collapsed;

                        }
                    }

                    else if (replaced.Contains("NONGPO"))
                    {
                        string[] result_NONGPO = replaced.Split(':');
                        TXT_TITLE_PUSTULE.Text = "Pustule :" + result_NONGPO[2];

                        if (result_NONGPO[2].Contains("level0"))
                        {
                            TXT_TITLE_PUSTULE.Foreground = Brushes.LightGreen;
                            imgView_PUSTULE.Visibility = Visibility.Collapsed;
                            TXT_NODATA_PUSTULE.Visibility = Visibility.Visible;
                            TXT_NODATA_PUSTULE.Text = "NORMAL";
                            TXT_NODATA_PUSTULE.Foreground = Brushes.LightGreen;
                        }
                        else if (result_NONGPO[2].Contains("level1"))
                        {
                            TXT_TITLE_PUSTULE.Foreground = Brushes.Yellow;
                            imgView_PUSTULE.Visibility = Visibility.Visible;
                            TXT_NODATA_PUSTULE.Visibility = Visibility.Collapsed;
                        }
                        else if (result_NONGPO[2].Contains("level2"))
                        {
                            TXT_TITLE_PUSTULE.Foreground = Brushes.Orange;
                            imgView_PUSTULE.Visibility = Visibility.Visible;
                            TXT_NODATA_PUSTULE.Visibility = Visibility.Collapsed;
                        }
                        else if (result_NONGPO[2].Contains("level3"))
                        {
                            TXT_TITLE_PUSTULE.Foreground = Brushes.Red;
                            imgView_PUSTULE.Visibility = Visibility.Visible;
                            TXT_NODATA_PUSTULE.Visibility = Visibility.Collapsed;

                        }
                    }
                }

                setContents();
            }
        }

        public void setContents()
        {
           var imgDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\" + StatisticsHelper.selectedDate + "_" + StatisticsHelper.selectedID.Replace(".txt", "") + @"\";

            var BIDUM_DIR = imgDir + StatisticsHelper.selectedDate + "_" + "BIDUM_" + StatisticsHelper.selectedDate + "_" + StatisticsHelper.selectedID.Replace(".txt", "") + ".png";
            var FIJI_DIR = imgDir + StatisticsHelper.selectedDate + "_" + "FIJI_" + StatisticsHelper.selectedDate + "_" + StatisticsHelper.selectedID.Replace(".txt", "") + ".png";
            var HONGBAN_DIR = imgDir + StatisticsHelper.selectedDate + "_" + "HONGBAN_" + StatisticsHelper.selectedDate + "_" + StatisticsHelper.selectedID.Replace(".txt", "") + ".png";
            var MISE_DIR = imgDir + StatisticsHelper.selectedDate + "_" + "MISE_" + StatisticsHelper.selectedDate + "_" + StatisticsHelper.selectedID.Replace(".txt", "") + ".png";
            var NONGPO_DIR = imgDir + StatisticsHelper.selectedDate + "_" + "NONGPO_" + StatisticsHelper.selectedDate + "_" + StatisticsHelper.selectedID.Replace(".txt", "") + ".png";
            var TALMO_DIR = imgDir + StatisticsHelper.selectedDate + "_" + "TALMO_" + StatisticsHelper.selectedDate + "_" + StatisticsHelper.selectedID.Replace(".txt", "") + ".png";

            if (File.Exists(BIDUM_DIR))
            {
                imgView_DANDRUFF.Visibility = Visibility.Visible;
                TXT_NODATA_DANDRUFF.Visibility = Visibility.Collapsed;
                imgView_DANDRUFF.Source = new BitmapImage(new Uri(BIDUM_DIR));
            }
            else
            {
                TXT_NODATA_DANDRUFF.Text = "No Data";
                TXT_NODATA_DANDRUFF.Foreground = Brushes.Gray;

                TXT_NODATA_DANDRUFF.Visibility = Visibility.Visible;
            }

            if (File.Exists(FIJI_DIR))
            {
                imgView_SEBUM.Visibility = Visibility.Visible;
                TXT_NODATA_SEBUM.Visibility = Visibility.Collapsed;
                imgView_SEBUM.Source = new BitmapImage(new Uri(FIJI_DIR));
            }
            else
            {
                imgView_SEBUM.Visibility = Visibility.Collapsed;
                TXT_NODATA_SEBUM.Text = "No Data";
                TXT_NODATA_SEBUM.Foreground = Brushes.Gray;

                TXT_NODATA_SEBUM.Visibility = Visibility.Visible;
            }

            if (File.Exists(HONGBAN_DIR))
            {
                imgView_ERYTHEMA.Visibility= Visibility.Visible;    
                TXT_NODATA_ERYTHEMA.Visibility = Visibility.Collapsed;
                imgView_ERYTHEMA.Source = new BitmapImage(new Uri(HONGBAN_DIR));
            }
            else
            {
                imgView_ERYTHEMA.Visibility = Visibility.Collapsed;
                TXT_NODATA_ERYTHEMA.Text = "No Data";
                TXT_NODATA_ERYTHEMA.Foreground = Brushes.Gray;

                TXT_NODATA_ERYTHEMA.Visibility = Visibility.Visible;
            }

            if (File.Exists(MISE_DIR))
            {
                imgView_MICROKERATIN.Visibility= Visibility.Visible;    
                TXT_NODATA_MICROKERATIN.Visibility = Visibility.Collapsed;
                imgView_MICROKERATIN.Source = new BitmapImage(new Uri(MISE_DIR));
            }
            else
            {
                imgView_MICROKERATIN.Visibility = Visibility.Collapsed;
                TXT_NODATA_MICROKERATIN.Text = "No Data";
                TXT_NODATA_MICROKERATIN.Foreground = Brushes.Gray;

                TXT_NODATA_MICROKERATIN.Visibility = Visibility.Visible;
            }

            if (File.Exists(NONGPO_DIR))
            {
                imgView_PUSTULE.Visibility = Visibility.Visible;
                TXT_NODATA_PUSTULE.Visibility = Visibility.Collapsed;
                imgView_PUSTULE.Source = new BitmapImage(new Uri(NONGPO_DIR));
            }
            else
            {
                imgView_PUSTULE.Visibility = Visibility.Collapsed;
                TXT_NODATA_PUSTULE.Text = "No Data";
                TXT_NODATA_PUSTULE.Foreground = Brushes.Gray;
                TXT_NODATA_PUSTULE.Visibility = Visibility.Visible;
            }

            if (File.Exists(TALMO_DIR))
            {
                imgView_HAIRLOSS.Visibility = Visibility.Visible;
                TXT_NODATA_HAIRLOSS.Visibility = Visibility.Collapsed;
                imgView_HAIRLOSS.Source = new BitmapImage(new Uri(TALMO_DIR));
            }
            else
            {
                imgView_HAIRLOSS.Visibility = Visibility.Collapsed;
                TXT_NODATA_HAIRLOSS.Text = "No Data";
                TXT_NODATA_HAIRLOSS.Foreground = Brushes.Gray;
                TXT_NODATA_HAIRLOSS.Visibility = Visibility.Visible;
            }

        }
    }
}
