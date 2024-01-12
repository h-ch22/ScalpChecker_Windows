using FontAwesome.Sharp;
using Scalp_Checker.src.Check.Models;
using Scalp_Checker.src.Check.View;
using Scalp_Checker.src.Dashboard.Models;
using Scalp_Checker.src.Statistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Scalp_Checker.src.Frameworks.Models
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentChildView;
        private string _caption;
        private IconChar _icon;

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

        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption= value;
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

        public ICommand ShowDashBoardViewCommand { get; }
        public ICommand ShowCheckViewCommand { get; }
        public ICommand ShowStatisticsViewCommand { get; }
        public ICommand ShowErrorViewCommand { get; }

        public MainViewModel()
        {
            ShowDashBoardViewCommand = new ViewModelCommand(ExecuteShowDashBoardViewCommand);
            ShowCheckViewCommand = new ViewModelCommand(ExecuteShowCheckViewCommand);
            ShowStatisticsViewCommand = new ViewModelCommand(ExecuteShowStatisticsCommand);
            ShowErrorViewCommand = new ViewModelCommand(ExecuteShowErrorViewCommand);

            ExecuteShowDashBoardViewCommand(null);
        }


        private void ExecuteShowDashBoardViewCommand(object obj)
        {
            CurrentChildView = new DashboardViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        public void ExecuteShowErrorViewCommand(object obj)
        {
            CurrentChildView = new CheckErrorViewModel();
            Caption = "Error";
            Icon = IconChar.Close;
        }

        public void ExecuteShowCheckViewCommand(object obj)
        {
            CurrentChildView = new CheckViewModel();
            Caption = "Inspection";
            Icon = IconChar.ClipboardCheck;
        }

        public void ExecuteShowResultViewCommand(object obj, string id)
        {
            CheckResultViewModel.setID(id);
            var resultViewModel = new CheckResultViewModel();
            CurrentChildView = resultViewModel;
            Caption = "Result";
            Icon = IconChar.CheckCircle;
        }

        private void ExecuteShowStatisticsCommand(object obj)
        {
            CurrentChildView = new StatisticsViewModel();
            Caption = "History";
            Icon = IconChar.ClockRotateLeft;
        }
    }
}
