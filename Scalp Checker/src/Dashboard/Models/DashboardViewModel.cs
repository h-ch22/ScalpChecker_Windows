using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp;
using Scalp_Checker.src.Dashboard.Helper;
using Scalp_Checker.src.Frameworks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Scalp_Checker.src.Dashboard.Models
{
    public class DelegateCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new NullReferenceException("execute can not null");

            _execute = execute;
            _canExecute = canExecute;
        }

        public DelegateCommand(Action<object> execute) : this(execute, null)
        {

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }

    public class DashboardViewModel : BaseViewModel
    {
        private DashboardHelper helper = new DashboardHelper();
        public ISeries[] data { get; set; }
        public ICommand radioButtonCommand { get; private set; }
        public Axis[] XAxes { get; set; } = new Axis[]
        {
            new Axis
            {
                NamePaint = new SolidColorPaint(SKColors.White),
                LabelsPaint = new SolidColorPaint(SKColors.White),
                SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray){ StrokeThickness = 2 }
            }
        };

        public Axis[] YAxes { get; set; } = new Axis[]
        {
            new Axis
            {
                MinStep = 1,
                NamePaint = new SolidColorPaint(SKColors.White),
                LabelsPaint = new SolidColorPaint(SKColors.White),
                SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray)
                {
                    StrokeThickness = 2,
                    PathEffect = new DashEffect(new float[] { 3, 3 })
                }             
            }
        };
        public DashboardViewModel()
        {
            radioButtonCommand = new DelegateCommand(radioButtonClick);

            helper.calc();
            data = new ISeries[]
            {
                new LineSeries<int>
                {
                    Values = helper.getMISEResults(),
                    Fill = null,
                    TooltipLabelFormatter = (chartPoint) => $"DRYNESS : {chartPoint.PrimaryValue}"
                }
            };

        }

        private void radioButtonClick(object sender)
        {
            Console.WriteLine((string)sender);
            switch((string)sender)
            {
                case "DANDRUFF":
                    data = new ISeries[]
                    {
                        new LineSeries<int>
                        {
                            Values = helper.getBIDUMResults(),
                            Fill = null,
                            TooltipLabelFormatter = (chartPoint) => $"DANDRUFF : {chartPoint.PrimaryValue}"
                        }
                    };

                    OnPropertyChanged(nameof(data));

                    break;

                case "SEBUM":
                    data = new ISeries[]
                    {
                        new LineSeries<int>
                        {
                            Values = helper.getFIJIResults(),
                            Fill = null,
                            TooltipLabelFormatter = (chartPoint) => $"OILINESS : {chartPoint.PrimaryValue}"
                        }
                    };
                    OnPropertyChanged(nameof(data));


                    break;

                case "ERYTHEMA":
                    data = new ISeries[]
                    {
                        new LineSeries<int>
                        {
                            Values = helper.getHONGBANResults(),
                            Fill = null,
                            TooltipLabelFormatter = (chartPoint) => $"ERYTHEMA : {chartPoint.PrimaryValue}"
                        }
                    };
                    OnPropertyChanged(nameof(data));

                    break;

                case "PUSTULE":
                    data = new ISeries[]
                    {
                        new LineSeries<int>
                        {
                            Values = helper.getNONGPOResults(),
                            Fill = null,
                            TooltipLabelFormatter = (chartPoint) => $"FOLICULITIS : {chartPoint.PrimaryValue}"
                        }
                    };
                    OnPropertyChanged(nameof(data));

                    break;

                case "MICROKERATIN":
                    data = new ISeries[]
                    {
                        new LineSeries<int>
                        {
                            Values = helper.getMISEResults(),
                            Fill = null,
                            TooltipLabelFormatter = (chartPoint) => $"DRYNESS : {chartPoint.PrimaryValue}"
                        }
                    };
                    OnPropertyChanged(nameof(data));

                    break;

                case "HAIRLOSS":
                    data = new ISeries[]
                    {
                        new LineSeries<int>
                        {
                            Values = helper.getTALMOResults(),
                            Fill = null,
                            TooltipLabelFormatter = (chartPoint) => $"HAIRLOSS : {chartPoint.PrimaryValue}"
                        }
                    };
                    OnPropertyChanged(nameof(data));

                    break;
            }
        }
    }
}
