


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Controls.Primitives;
using System.Windows.Media;

using System.Globalization;
using UAV.Common;
using UAVBusiness.Business;
using UAVBusiness.Models;
using UAVBusiness.Common;

using System.Windows.Markup;

namespace UAV.UserControls
{

    public partial class SurveyList : UserControl
    {
        #region [... Variable ...]

        public MDIWindow mdiWinow { get; set; }


        #endregion


        #region[.. Form Event ...]

        public SurveyList()
        {
            InitializeComponent();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            GetSurveyList(PilotSession.UserId);
            mdiWinow.lblPilotName.Content = PilotSession.UserEmail;
            mdiWinow.lblLogout.Content = "[" + PilotSession.UserName + "]";
        }

       



        #endregion


        #region[.. Functions ...]

        private void GetSurveyList(long id)
        {
            dgSurvey.ItemsSource = null;

            TResponse objTResponse = new SurveyDetailBusiness().GetSurveyList(id);
            if (objTResponse.ResponsePacket != null)
            {
                cmstripRow.Visibility = Visibility.Visible;
                List<SurveyModel> lstSurvey = objTResponse.ResponsePacket as List<SurveyModel>;
                for (int i = 0; i < lstSurvey.Count; i++)
                {
                    lstSurvey[i].RowNumber = (i + 1);

                }
                dgSurvey.ItemsSource = lstSurvey.ToList();
                
            }
            else
            {
                // cmstripRow.Visibility = Visibility.Collapsed;
                // MessageBox.Show("Sorry! You Have no more projects.");
            }
        }
       
        private void btnAddSurvey_Click(object sender, RoutedEventArgs e)
        {
            PilotSession.SurveyId = 0;
            mdiWinow.SetAdminSection("AddEditSurvey");
        }
        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()+2).ToString();
        }
        private void cntxtMenu_ViewSurvey(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgSurvey.SelectedItem != null)
                {

                    PilotSession.SurveyId = (dgSurvey.SelectedItem as SurveyModel).ID;
                    mdiWinow.SetAdminSection("AddEditSurvey");
                }
                else
                {
                    PopupBox frmPopup = new PopupBox("Information", "Please Select a survey first.", MessageBoxImage.Error);
                    frmPopup.ShowDialog();
                }
            }
            catch
            {

            }
        }

       
        //private void cntxtMenu_AddSurvey(object sender, RoutedEventArgs e)
        //{
        //    //UserSession.IsNews = false;

        //    if (dgSurvey.SelectedItem != null && UserSession.PilotId > 0)
        //    {
        //        UserSession.SurveyId = 0;
        //        mdiWinow.SetAdminSection("AddEditSurvey");
        //    }
        //    else
        //    {
        //        PopupBox frmPopup = new PopupBox("Information", "Please Select a project first.", MessageBoxImage.Error);
        //        frmPopup.ShowDialog();
        //    }
        //}

        private void dgSurvey_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            cntxtMenu_ViewSurvey(ViewMenuItem, null);
        }

        

        #endregion

    }

}
