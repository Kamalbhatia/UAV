using MahApps.Metro.Controls;
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
using UAV.Common;
using UAV.Controls;
using UAV.UserControls;


namespace UAV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MDIWindow : MetroWindow
    {
        #region [... Variable ...]

        SurveyList surveylist;
        AddEditSurvey addeditsurvey;
         AddEditSurveyStep2 addeditsurveystep2;
         AddEditSurveyStep3 addeditsurveystep3;
         AddEditSurveyStep4 addeditsurveystep4;

        #endregion

      

        #region [... Form Event ...]

        public MDIWindow()
        {
            InitializeComponent();
            this.ShowInTaskbar = true;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetAdminSection("SurveyList");
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

            PilotSession.UserName = string.Empty;
            PilotSession.UserId = 0;
            PilotSession.UserEmail = string.Empty;

            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            RemoveClassMenuItem(btn.Tag.ToString());
            switch (btn.Tag.ToString())
            {
                //case "Master":
                //    SetAdminSection("Manage_Code");
                //    break;
                //default:
                //    break;
            }

        }


        #endregion

        #region [... Functions ...]

        public void RemoveChild()
        {
            var panel = pnlContainerDP as DockPanel;
            if (panel != null)
            {
                for (int i = 0; i < panel.Children.Count; i++)
                    panel.Children.Remove(panel.Children[i]);
            }
        }

        public void SetAdminSection(string TabValue)
        {
            RemoveChild();
            pnlContainerDP.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            switch (TabValue)
            {
                case "SurveyList":

                    surveylist = new SurveyList();
                    surveylist.Focus();
                    surveylist.mdiWinow = this;
                    pnlContainerDP.Children.Add(surveylist);
                    pnlContainerDP.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                    break;

                case "AddEditSurvey":
                    addeditsurvey = new AddEditSurvey();
                    addeditsurvey.Focus();
                    addeditsurvey.mdiWinow = this;
                    pnlContainerDP.Children.Add(addeditsurvey);
                    break;

                case "AddEditSurveyStep2":
                    addeditsurveystep2 = new AddEditSurveyStep2();
                    addeditsurveystep2.Focus();
                    addeditsurveystep2.mdiWinow = this;
                    pnlContainerDP.Children.Add(addeditsurveystep2);
                    break;

                case "AddEditSurveyStep3":
                    addeditsurveystep3 = new AddEditSurveyStep3();
                    addeditsurveystep3.Focus();
                    addeditsurveystep3.mdiWinow = this;
                    pnlContainerDP.Children.Add(addeditsurveystep3);
                    break;

                case "AddEditSurveyStep4":
                    addeditsurveystep4 = new AddEditSurveyStep4();
                    addeditsurveystep4.Focus();
                    addeditsurveystep4.mdiWinow = this;
                    pnlContainerDP.Children.Add(addeditsurveystep4);
                    break;

            }
        }

        public void RemoveClassMenuItem(string btnName)
        {
            //btnMaster.Style = FindResource("MenuButtonNormalStyle") as Style;
            //switch (btnName)
            //{
            //    case "Master":
            //        btnMaster.Style = FindResource("MenuButtonActiveStyle") as Style;
            //        break;
            //    default:
            //        break;
            //}
        }

        #endregion


    }
}
