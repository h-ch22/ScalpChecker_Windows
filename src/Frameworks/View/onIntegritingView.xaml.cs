using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ScalpAnalysis.src.Frameworks.View
{
    /// <summary>
    /// Interaction logic for onIntegritingView.xaml
    /// </summary>
    public partial class onIntegritingView : Page
    {
        private bool isMainFileExists;
        private bool isBIDUMExists;
        private bool isFIJIExists;
        private bool isHONGBANExists;
        private bool isMISEExists;
        private bool isNONGPOExists;
        private bool isTALMOExists;
        private bool isBIDUM_ViTExists;
        private bool isFIJI_ViTExists;
        private bool isHONGBAN_ViTExists;
        private bool isMISE_ViTExists;
        private bool isNONGPO_ViTExists;
        private bool isTALMO_ViTExists;
        private bool isGPUChecker_Exists;

        public onIntegritingView()
        {
            InitializeComponent();
            Task task = new Task(new Action(Check));
            task.Start();
            task.Wait();
            _NavigationFrame.Navigate(new SoftwareIntegrityToolResult(isMainFileExists, isGPUChecker_Exists, isBIDUMExists, isFIJIExists, isHONGBANExists, isMISEExists, isNONGPOExists, isTALMOExists, isBIDUM_ViTExists, isFIJI_ViTExists, isHONGBAN_ViTExists, isMISE_ViTExists, isNONGPO_ViTExists, isTALMO_ViTExists));
        }

        private void Check()
        {
            string mainFile = @"C:\Program Files\ScalpChecker\include\main.exe";
            string BIDUM_Model = @"C:\Program Files\ScalpChecker\Models\BIDUM.h5";
            string FIJI_Model = @"C:\Program Files\ScalpChecker\Models\FIJI.h5";
            string HONGBAN_Model = @"C:\Program Files\ScalpChecker\Models\HONGBAN.h5";
            string MISE_Model = @"C:\Program Files\ScalpChecker\Models\MISE.h5";
            string NONGPO_Model = @"C:\Program Files\ScalpChecker\Models\NONGPO.h5";
            string TALMO_Model = @"C:\Program Files\ScalpChecker\Models\TALMO.h5";

            string MODEL_DIR_BIDUM_ViT = @"C:\Program Files\ScalpChecker\Models\BIDUM_ViT.h5";
            string MODEL_DIR_FIJI_ViT = @"C:\Program Files\ScalpChecker\Models\FIJI_ViT.h5";
            string MODEL_DIR_HONGBAN_ViT = @"C:\Program Files\ScalpChecker\Models\HONGBAN_ViT.h5";
            string MODEL_DIR_MISE_ViT = @"C:\Program Files\ScalpChecker\Models\MISE_ViT.h5";
            string MODEL_DIR_NONGPO_ViT = @"C:\Program Files\ScalpChecker\Models\NONGPO_ViT.h5";
            string MODEL_DIR_TALMO_ViT = @"C:\Program Files\ScalpChecker\Models\TALMO_ViT.h5";

            string gpuCompatibilityFile = @"C:\Program Files\ScalpChecker\GPUCompatibility\main.exe";

            isMainFileExists = File.Exists(mainFile);
            isGPUChecker_Exists = File.Exists(gpuCompatibilityFile);
            isBIDUMExists = File.Exists(BIDUM_Model);
            isFIJIExists = File.Exists(FIJI_Model);
            isHONGBANExists = File.Exists(HONGBAN_Model);
            isMISEExists = File.Exists(MISE_Model);
            isNONGPOExists = File.Exists(NONGPO_Model);
            isTALMOExists = File.Exists(TALMO_Model);

            isBIDUM_ViTExists = File.Exists(MODEL_DIR_BIDUM_ViT);
            isFIJI_ViTExists = File.Exists(MODEL_DIR_FIJI_ViT);
            isHONGBAN_ViTExists = File.Exists(MODEL_DIR_HONGBAN_ViT);
            isMISE_ViTExists = File.Exists(MODEL_DIR_MISE_ViT);
            isNONGPO_ViTExists = File.Exists(MODEL_DIR_NONGPO_ViT);
            isTALMO_ViTExists = File.Exists(MODEL_DIR_TALMO_ViT);
        }
    }
}
