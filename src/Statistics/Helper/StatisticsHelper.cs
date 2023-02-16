using ScalpAnalysis.src.Statistics.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace ScalpAnalysis.src.Statistics.Helper
{
    class StatisticsHelper
    {
        public static string selectedDate = "";
        public static string selectedID = "";
        public StatisticsHelper()
        {
        }

        private FileInfo[] getFiles()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\Results";
            FileInfo[] fileInfo;
            DirectoryInfo dirInfo;

            if (!Directory.Exists(path))
            {
                return null;
            }
            else
            {
                dirInfo = new DirectoryInfo(path);
                fileInfo = dirInfo.GetFiles("*.txt");

                return fileInfo;
            }
        }

        public List<DateTime> getDates()
        {
            var dates = new List<DateTime>() {  };

            var fileInfo = getFiles();

            if(fileInfo != null)
            {
                foreach (FileInfo f in fileInfo)
                {
                    var name = f.Name;
                    var name_splited = name.Split('_');
                    var date = name_splited[1];
                    string[] dateFormat = { "MM.dd.yy" };
                    var parsedDate = DateTime.ParseExact(date, dateFormat, new CultureInfo("en-US"), DateTimeStyles.None);
                    dates.Add(parsedDate);
                }

                return dates;
            }
            else
            {
                return dates;
            }


        }

        public string getFileCreationTime(string id, string date)
        {
            DateTime creation = File.GetCreationTime(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\Results\Results_" + date + "_" + id);

            return creation.ToString("HH:mm:ss");
        }

        public List<FileDataModel> getResults(string date)
        {
            var fileInfo = getFiles();
            var results = new List<FileDataModel>();

            if (fileInfo != null)
            {
                foreach (FileInfo f in fileInfo)
                {
                    var name = f.Name;
                    var name_splited = name.Split('_');
                    var _date = name_splited[1];
                    var format = new FileDataModel();

                    if (_date == date)
                    {
                        string contents = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\Results\" + name);

                        if (contents != "" && contents != null)
                        {
                            string[] splited_results = contents.Split('\n');

                            foreach (string result in splited_results)
                            {
                                format.id = name_splited[2];
                                string replaced = result.Replace("['", "");
                                replaced = replaced.Replace("']", "");
                                replaced = replaced.Replace("\n", "");
                                format.date = getFileCreationTime(format.id, _date);

                                if (replaced.Contains("BIDUM"))
                                {
                                    string[] result_BIDUM = replaced.Split(':');

                                    format.result_BIDUM = result_BIDUM[2];
                                }

                                else if (replaced.Contains("FIJI"))
                                {
                                    string[] result_FIJI = replaced.Split(':');
                                    format.result_FIJI = result_FIJI[2];
                                }

                                else if (replaced.Contains("MISE"))
                                {
                                    string[] result_MISE = replaced.Split(':');
                                    format.result_MISE = result_MISE[2];
                                }

                                else if (replaced.Contains("TALMO"))
                                {
                                    string[] result_TALMO = replaced.Split(':');
                                    format.result_TALMO = result_TALMO[2];
                                }

                                else if (replaced.Contains("HONGBAN"))
                                {
                                    string[] result_HONGBAN = replaced.Split(':');
                                    format.result_HONGBAN = result_HONGBAN[2];
                                }

                                else if (replaced.Contains("NONGPO"))
                                {
                                    string[] result_NONGPO = replaced.Split(':');
                                    format.result_NONGPO = result_NONGPO[2];
                                }

                            }

                            results.Add(format);

                        }
                    }
                }

            }



            return results;
        }
    }
}
