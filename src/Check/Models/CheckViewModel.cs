using FontAwesome.Sharp;
using Microsoft.Win32;
using ScalpAnalysis.src.Frameworks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ScalpAnalysis.src.Check.Models
{
    public class CheckViewModel : BaseViewModel
    {
        private BaseViewModel _currentChildView;

        public ICommand ShowResultViewCommand { get; }
        public ICommand ShowFailViewCommand { get; }
        private string _caption;
        private IconChar _icon;
        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public BaseViewModel CurrentChildView
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public CheckViewModel()
        {
            ShowResultViewCommand = new ViewModelCommand(ExecuteShowResultViewCommand);
            ShowFailViewCommand = new ViewModelCommand(ExecuteShowFailViewCommand);
        }

        private void ExecuteShowResultViewCommand(object obj)
        {
            CurrentChildView = new CheckResultViewModel();
            Caption = "Check";
            Icon = IconChar.ClipboardCheck;
        }

        private void ExecuteShowFailViewCommand(object obj)
        {
            CurrentChildView = new CheckErrorViewModel();
            Caption = "Check";
            Icon = IconChar.ClipboardCheck;
        }
    }
}
