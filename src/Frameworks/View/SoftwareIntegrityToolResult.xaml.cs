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

namespace ScalpAnalysis.src.Frameworks.View
{
    /// <summary>
    /// Interaction logic for SoftwareIntegrityToolResult.xaml
    /// </summary>
    public partial class SoftwareIntegrityToolResult : Page
    {
        public SoftwareIntegrityToolResult(
         bool isMainFileExists, bool isBIDUMExists, bool isFIJIExists, bool isHONGBANExists, bool isMISEExists, bool isNONGPOExists, bool isTALMOExists
        )
        {
            InitializeComponent();

            if (!isMainFileExists || !isBIDUMExists || !isFIJIExists || !isHONGBANExists || !isMISEExists || !isNONGPOExists || !isTALMOExists)
            {
                string errors = "";

                if (!isMainFileExists)
                {
                    errors += "Missing Inspection software file.\n";
                }

                if (!isBIDUMExists)
                {
                    errors += "Missing Dandruff model file.\n";
                }

                if(!isFIJIExists)
                {
                    errors += "Missing Sebum model file.\n";

                }

                if (!isHONGBANExists)
                {
                    errors += "Missing erythema model file.\n";

                }

                if (!isMISEExists)
                {
                    errors += "Missing microkeratin model file.\n";

                }

                if (!isTALMOExists)
                {
                    errors += "Missing hair loss model file.\n";
                }

                TXT_RESULT_HEADER.Text = "Software integrity check tool found a problem with this software.";
                TXT_RESULT_DETAIL.Text = errors;
            }
            else
            {
                TXT_RESULT_HEADER.Text = "The software integrity check tool has not detected any problem with this software.";
                TXT_RESULT_DETAIL.Text = "";
                TXT_RESULT_DETAIL.Visibility = Visibility.Collapsed;
            }
        }

        private void btn_onClick(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this);

            if (parent != null)
            {
                parent.Close();
            }
        }
    }
}
