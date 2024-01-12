using Scalp_Checker.src.Statistics.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scalp_Checker.src.Dashboard.Helper
{
    class DashboardHelper
    {
        private int sum_BIDUM = 0;
        private int sum_FIJI = 0;
        private int sum_HONGBAN = 0;
        private int sum_NONGPO = 0;
        private int sum_MISE = 0;
        private int sum_TALMO = 0;

        private int fileNum_BIDUM = 0;
        private int fileNum_FIJI = 0;
        private int fileNum_HONGBAN = 0;
        private int fileNum_NONGPO = 0;
        private int fileNum_MISE = 0;
        private int fileNum_TALMO = 0;

        private List<int> results_BIDUM = new List<int>();
        private List<int> results_FIJI = new List<int>();
        private List<int> results_HONGBAN = new List<int>();
        private List<int> results_NONGPO = new List<int>();
        private List<int> results_MISE = new List<int>();
        private List<int> results_TALMO = new List<int>();

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

        public float getBIDUM()
        {
            try
            {
                return sum_BIDUM / fileNum_BIDUM;
            }
            catch
            {
                return 0;
            }
        }

        public float getFIJI()
        {
            try
            {
                return sum_FIJI / fileNum_FIJI;
            }
            catch
            {
                return 0;
            }
        }

        public float getHONGBAN()
        {
            try
            {
                return sum_HONGBAN / fileNum_HONGBAN;
            }
            catch
            {
                return 0;
            }
        }

        public float getNONGPO()
        {
            try
            {
                return sum_NONGPO / fileNum_NONGPO;
            }
            catch
            {
                return 0;
            }
        }

        public float getMISE()
        {
            try
            {
                return sum_MISE/ fileNum_MISE;
            }
            catch
            {
                return 0;
            }
        }

        public float getTALMO()
        {
            try
            {
                return sum_TALMO / fileNum_TALMO;
            }
            catch
            {
                return 0;
            }
        }

        public int[] getBIDUMResults()
        {
            return results_BIDUM.ToArray();
        }

        public int[] getFIJIResults()
        {
            return results_FIJI.ToArray();
        }

        public int[] getHONGBANResults()
        {
            return results_HONGBAN.ToArray();
        }

        public int[] getNONGPOResults()
        {
            return results_NONGPO.ToArray();
        }

        public int[] getMISEResults()
        {
            return results_MISE.ToArray();
        }

        public int[] getTALMOResults()
        {
            return results_TALMO.ToArray();
        }

        public void calc()
        {
            var fileInfo = getFiles();

            if(fileInfo != null)
            {
                foreach (FileInfo f in fileInfo)
                {
                    var name = f.Name;
                    var name_splited = name.Split('_');
                    var _date = name_splited[1];

                    string contents = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ScalpChecker\Results\" + name);

                    if (contents != "" && contents != null)
                    {
                        string[] splited_results = contents.Split('\n');

                        foreach (string result in splited_results)
                        {
                            string replaced = result.Replace("['", "");
                            replaced = replaced.Replace("']", "");
                            replaced = replaced.Replace("\n", "");

                            if (replaced.Contains("BIDUM"))
                            {
                                string[] result_BIDUM = replaced.Split(':');

                                int num = Int32.Parse(result_BIDUM[2].Replace("level", ""));
                                sum_BIDUM += num;
                                fileNum_BIDUM += 1;
                                results_BIDUM.Add(num);
                            }

                            else if (replaced.Contains("FIJI"))
                            {
                                string[] result_FIJI = replaced.Split(':');
                                int num = Int32.Parse(result_FIJI[2].Replace("level", ""));
                                sum_FIJI += num;
                                fileNum_FIJI += 1;
                                results_FIJI.Add(num);
                            }

                            else if (replaced.Contains("MISE"))
                            {
                                string[] result_MISE = replaced.Split(':');
                                int num = Int32.Parse(result_MISE[2].Replace("level", ""));
                                sum_MISE += num;
                                fileNum_MISE += 1;
                                results_MISE.Add(num);
                            }

                            else if (replaced.Contains("TALMO"))
                            {
                                string[] result_TALMO = replaced.Split(':');
                                int num = Int32.Parse(result_TALMO[2].Replace("level", ""));
                                sum_TALMO += num;
                                fileNum_TALMO += 1;
                                results_TALMO.Add(num);
                            }

                            else if (replaced.Contains("HONGBAN"))
                            {
                                string[] result_HONGBAN = replaced.Split(':');
                                int num = Int32.Parse(result_HONGBAN[2].Replace("level", ""));
                                sum_HONGBAN += num;
                                fileNum_HONGBAN += 1;
                                results_HONGBAN.Add(num);
                            }

                            else if (replaced.Contains("NONGPO"))
                            {
                                string[] result_NONGPO = replaced.Split(':');
                                int num = Int32.Parse(result_NONGPO[2].Replace("level", ""));
                                sum_NONGPO += num;
                                fileNum_NONGPO += 1;
                                results_NONGPO.Add(num);
                            }

                        }
                    }
                }
            }
        }
    }
}
