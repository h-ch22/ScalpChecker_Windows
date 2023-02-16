using ScalpAnalysis.src.Frameworks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalpAnalysis.src.Check.Models
{
    public class CheckResultViewModel : BaseViewModel
    {
        private static string id = null;
        public CheckResultViewModel()
        {
        }

        public static void setID(string id)
        {
            CheckResultViewModel.id = id;
        }

        public static string getID()
        {
            return id;
        }
    }
}
