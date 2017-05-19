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

namespace UAV
{
    public partial class PopupBox : Window
    {
        #region[...Variable...]

        Uri uriSource;
        public MessageBoxResult result;


        #endregion

        #region[...Form Function...]

        public PopupBox()
        {
            InitializeComponent();
        }

        public PopupBox(string Title, string Message)
        {
            InitializeComponent();
            txtTitle.Text = Title;
            txtMessage.Text = Message;
            ShowButton(MessageBoxButton.OK);
        }

        public PopupBox(string Title, string Message, MessageBoxImage img)
        {
             
            
            InitializeComponent();
            txtTitle.Text = Title;
            txtMessage.Text = Message;
            uriSource = new Uri(@"/Resource/Images/logo.png", UriKind.Relative);
            imgIcon.Source = new BitmapImage(uriSource);
            switch (img)
            {
                case MessageBoxImage.Asterisk:
                //         case MessageBoxImage.Information:
                case MessageBoxImage.None:
                    break;
                case MessageBoxImage.Error:
                    break;
            }
            ShowButton(MessageBoxButton.OK);
             
        }

        public PopupBox(string Title, string Message, MessageBoxImage img, MessageBoxButton btn)
        {
            InitializeComponent();
            txtTitle.Text = Title;
            txtMessage.Text = Message;
            uriSource = new Uri(@"Resource/Images/logo.png", UriKind.Relative);
            imgIcon.Source = new BitmapImage(uriSource);
            switch (img)
            {
                case MessageBoxImage.Asterisk:

                    break;
                case MessageBoxImage.None:

                    break;
                case MessageBoxImage.Error:
                   
                    break;
            }
            ShowButton(btn);
        }

        private void ShowButton(MessageBoxButton obj)
        {
            switch (obj)
            {
                case MessageBoxButton.OK:
                    btnOk.Visibility = System.Windows.Visibility.Visible;
                    break;
                case MessageBoxButton.YesNo:
                    btnYes.Visibility = System.Windows.Visibility.Visible;
                    btnNo.Visibility = System.Windows.Visibility.Visible;
                    break;
                case MessageBoxButton.OKCancel:
                    btnOk.Visibility = System.Windows.Visibility.Visible;
                    btnCancel.Visibility = System.Windows.Visibility.Visible;
                    break;
                case MessageBoxButton.YesNoCancel:
                    btnYes.Visibility = System.Windows.Visibility.Visible;
                    btnNo.Visibility = System.Windows.Visibility.Visible;
                    btnCancel.Visibility = System.Windows.Visibility.Visible;
                    break;
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            result = new MessageBoxResult();
            switch (((Button)sender).Tag.ToString())
            {
                case "ok":
                    result = MessageBoxResult.OK;
                    break;
                case "yes":
                    result = MessageBoxResult.Yes;
                    break;
                case "none":
                    result = MessageBoxResult.None;
                    break;
                case "cancel":
                    result = MessageBoxResult.Cancel;
                    break;
                default:
                    result = MessageBoxResult.None;
                    break;
            }
            this.Close();
        }

        #endregion
    }
}
