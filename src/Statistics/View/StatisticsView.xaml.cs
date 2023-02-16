using ScalpAnalysis.src.Statistics.Helper;
using ScalpAnalysis.src.Statistics.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for StatisticsView.xaml
    /// </summary>
    public partial class StatisticsView : UserControl
    {
        private bool IsChecked = false;
        private StatisticsHelper helper = new StatisticsHelper();
        private List<FileDataModel> results;
        private int currentIndex = 0;
        private string selectedDate;
        private Statistics_All allView = new Statistics_All();
        public StatisticsView()
        {
            InitializeComponent();
            CalendarControl.SelectedDatesChanged += onSelectedDateChanged;
            Frame_Statistics.Content = allView;

            var dates = helper.getDates();

            if(dates.Count > 0)
            {
                var firstDate = dates.First();
                var lastDate = dates.Last();
                var dateCounter = firstDate;

                foreach (var d in dates.Skip(1))
                {
                    if (d.AddDays(-1).Date != dateCounter.Date)
                    {
                        CalendarControl.BlackoutDates.Add(new CalendarDateRange(dateCounter.AddDays(1), d.AddDays(-1)));
                    }

                    dateCounter = d;
                }

                CalendarControl.DisplayDateStart = firstDate;
                CalendarControl.DisplayDateEnd = lastDate;
                selectedDate = lastDate.ToString("MM.dd.yy");

                init();
            }
            else
            {

            }


        }

        private void init()
        {
            currentIndex = 0;
            StatisticsHelper.selectedDate = selectedDate;

            results = helper.getResults(selectedDate);

            if(results.Count > 0)
            {

                setText(results[0].id);
                StatisticsHelper.selectedID = results[0].id;

                allView.setResults();

                if (results.Count == 1)
                {
                    btn_next.IsEnabled = false;
                    btn_previous.IsEnabled = false;
                }
                else
                {
                    btn_previous.IsEnabled = false;
                    btn_next.IsEnabled = true;
                }
            }


        }

        private void onSelectedDateChanged(object sender, EventArgs e)
        {
            selectedDate = CalendarControl.SelectedDate?.ToString("MM.dd.yy");
            init();
        }
        private void onCalendarButtonClick(object sender, RoutedEventArgs e) {
            IsChecked = true;
        }

        private void setText(string id)
        {
            TXT_ID.Text = helper.getFileCreationTime(id, selectedDate) + "( " + id.Replace(".txt", "") + " )";
        }

        private void onClick(object sender, RoutedEventArgs e)
        {
            if(sender == btn_previous)
            {
                currentIndex--;

                if (currentIndex >= 0 && results.Count > 0)
                {
                    btn_next.IsEnabled = true;
                    setText(results[currentIndex].id);
                    StatisticsHelper.selectedID = results[currentIndex].id;

                    allView.setResults();
                }
                else
                {
                    btn_previous.IsEnabled = false;
                }
            } else if(sender == btn_next)
            {
                if (results.Count != currentIndex+1)
                {
                    currentIndex++;
                    btn_previous.IsEnabled = true;
                    Console.WriteLine(results.Count + ", " + currentIndex);

                    setText(results[currentIndex].id);
                    StatisticsHelper.selectedID = results[currentIndex].id;

                    allView.setResults();

                    if (results.Count == currentIndex+1)
                    {
                        btn_next.IsEnabled = false;
                    }
                }
                else
                {
                    btn_previous.IsEnabled = false;
                }
            }
        }
    }
}
