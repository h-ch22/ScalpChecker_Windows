using Scalp_Checker.src.Frameworks.Models;
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
using System.Windows.Shapes;

namespace Scalp_Checker.src.Frameworks.View
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        static MessageBoxResult _result = MessageBoxResult.No;
        static CustomMessageBox _messageBox;
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        public MessageBoxResult Show(DialogType dialogType, MessageBoxType type, String title, String contents)
        {
            _messageBox = new CustomMessageBox
            {
                txt_title = {Text = title},
                txt_contents = {Text = contents}
            };

            setVisibillityOfButtons(dialogType, type);

            _messageBox.ShowDialog();

            return _result;
        }

        private static void setVisibillityOfButtons(DialogType dialogType, MessageBoxType type)
        {
            switch (type)
            {
                case MessageBoxType.OK:
                    _messageBox.btn_negative.Visibility = Visibility.Collapsed;
                    _messageBox.btn_text_positive.Text = "OK";
                    _messageBox.btn_close.Visibility = Visibility.Visible;
                    break;

                case MessageBoxType.Yes_No:
                    _messageBox.btn_negative.Visibility = Visibility.Visible;
                    _messageBox.btn_text_positive.Text = "Yes";
                    _messageBox.btn_text_negative.Text = "No";
                    _messageBox.btn_close.Visibility = Visibility.Collapsed;
                    break;

                case MessageBoxType.OK_Cancel:
                    _messageBox.btn_negative.Visibility = Visibility.Visible;
                    _messageBox.btn_text_positive.Text = "OK";
                    _messageBox.btn_text_negative.Text = "Cancel";
                    _messageBox.btn_close.Visibility = Visibility.Collapsed;
                    break;
            }

            switch (dialogType)
            {
                case DialogType.INFORMATION:
                    _messageBox.ic_title.Kind = MaterialDesignThemes.Wpf.PackIconKind.Information;
                    _messageBox.ic_contents.Kind = MaterialDesignThemes.Wpf.PackIconKind.InformationCircle;
                    _messageBox.ic_contents.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8BC0FF"));
                    break;

                case DialogType.ERROR:
                    _messageBox.ic_title.Kind = MaterialDesignThemes.Wpf.PackIconKind.Error;
                    _messageBox.ic_contents.Kind = MaterialDesignThemes.Wpf.PackIconKind.Error;
                    _messageBox.ic_contents.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF6262"));
                    break;

                case DialogType.WARNING:
                    _messageBox.ic_title.Kind = MaterialDesignThemes.Wpf.PackIconKind.WarningCircle;
                    _messageBox.ic_contents.Kind = MaterialDesignThemes.Wpf.PackIconKind.WarningCircle;
                    _messageBox.ic_contents.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFCF50"));
                    break;

                case DialogType.QUESTION:
                    _messageBox.ic_title.Kind = MaterialDesignThemes.Wpf.PackIconKind.Check;
                    _messageBox.ic_contents.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircle;
                    _messageBox.ic_contents.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF01a669"));
                    break;
            }
        }

        private void btn_onClick(object sender, RoutedEventArgs e)
        {
            if(sender == btn_positive)
            {
                _result = MessageBoxResult.Yes;
            }

            else if(sender == btn_negative)
            {
                _result = MessageBoxResult.No;
            }

            this.Close();
            _messageBox = null;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
    }
}
