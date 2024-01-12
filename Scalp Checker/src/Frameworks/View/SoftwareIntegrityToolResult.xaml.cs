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
    /// Interaction logic for SoftwareIntegrityToolResult.xaml
    /// </summary>
    public partial class SoftwareIntegrityToolResult : Page
    {
        public SoftwareIntegrityToolResult(
         bool isMainFileExists, bool isGPUCheckerExists, bool isBIDUMExists, bool isFIJIExists, bool isHONGBANExists, bool isMISEExists, bool isNONGPOExists, bool isTALMOExists, bool isBIDUM_ViT_Exists, bool isFIJI_ViT_Exists, bool isHONGBAN_ViT_Exists, bool isMISE_ViT_Exists, bool isNONGPO_ViT_Exists, bool isTALMO_ViT_Exists
        )
        {
            InitializeComponent();

            if (!isMainFileExists || !isGPUCheckerExists || !isBIDUMExists || !isFIJIExists || !isHONGBANExists || !isMISEExists || !isNONGPOExists || !isTALMOExists || !isBIDUM_ViT_Exists || !isFIJI_ViT_Exists || !isHONGBAN_ViT_Exists || !isMISE_ViT_Exists || !isNONGPO_ViT_Exists || !isTALMO_ViT_Exists)
            {
                string errors = "";

                if (!isMainFileExists)
                {
                    errors += "Missing Inspection software file.\n";
                }

                if(!isGPUCheckerExists) {
                    errors += "Missing GPU Compatibility Checker.\n";
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
                    errors += "Missing pustule model file.\n";
                }

                if (!isNONGPOExists)
                {
                    errors += "Missing hair loss model file.\n";
                }

                if (!isBIDUM_ViT_Exists)
                {
                    errors += "Missing Dandruff_ViT model file.\n";
                }

                if (!isFIJI_ViT_Exists)
                {
                    errors += "Missing Sebum_ViT model file.\n";

                }

                if (!isHONGBAN_ViT_Exists)
                {
                    errors += "Missing erythema_ViT model file.\n";

                }

                if (!isMISE_ViT_Exists)
                {
                    errors += "Missing microkeratin_ViT model file.\n";

                }

                if (!isTALMO_ViT_Exists)
                {
                    errors += "Missing pustule_ViT model file.\n";
                }

                if (!isNONGPO_ViT_Exists)
                {
                    errors += "Missing hair loss_ViT model file.\n";
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
