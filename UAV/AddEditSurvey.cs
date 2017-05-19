


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


namespace UAV.UserControls
{

    public partial class AddEditSurvey : UserControl
    {
        #region [... Variable ...]

        public MDIWindow mdiWinow { get; set; }


        #endregion


        #region[.. Form Event ...]

        public AddEditSurvey()
        {
            InitializeComponent();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            GetSurveyList(UserSession.PilotId);
            mdiWinow.lblPilotName.Content = UserSession.PilotEmail;
            mdiWinow.lblLogout.Content ="[" +UserSession.PilotName+"]";
        }

        private void cntxtMenu_ViewSurvey(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (dgSurvey.SelectedItem != null)
            //    {
            //        mdiWinow.RemoveClassMenuItem("Master");
            //        UserSession.projectid = Convert.ToInt64(((user_projects)(dgSurvey.SelectedCells[0].Item)).project_id.ToString());

            //        GetSurveyDetailByUIdPid(UserSession.projectid, UserSession.userid);
            //        if (Convert.ToInt64(((user_projects)(dgSurvey.SelectedCells[0].Item)).tree_count) > 0)
            //        { mdiWinow.RemoveClassMenuItem(mdiWinow.btnTree.Tag.ToString()); mdiWinow.SetAdminSection("ManageTreeList"); }
            //        else
            //        {
            //            mdiWinow.SetAdminSection("Manage_Code");
            //        }
            //        mdiWinow.MenuBar.Visibility = System.Windows.Visibility.Visible;
            //    }
            //    else
            //    {
            //        PopupBox frmPopup = new PopupBox("Information", "Please Select a project first.", MessageBoxImage.Error);
            //        frmPopup.ShowDialog();
            //    }
            //}
            //catch
            //{

            //}
        }

        private void cntxtMenu_AddSurvey(object sender, RoutedEventArgs e)
        {
            //UserSession.IsNews = false;
            
            if (dgSurvey.SelectedItem != null && UserSession.PilotId>0)
            {
                mdiWinow.SetAdminSection("AddEditSurvey");
            }
            else
            {
                PopupBox frmPopup = new PopupBox("Information", "Please Select a project first.", MessageBoxImage.Error);
                frmPopup.ShowDialog();
            }
        }
       

     

        #endregion


        #region[.. Functions ...]

        private void GetSurveyList(long id)
        {
            dgSurvey.ItemsSource = null;

            TResponse objTResponse = new SurveyDetailBusiness().GetAll();
            if (objTResponse.ResponsePacket != null)
            {
                cmstripRow.Visibility = Visibility.Visible;
                List<SurveyModel> lstSurvey = objTResponse.ResponsePacket as List<SurveyModel>;

                dgSurvey.ItemsSource = lstSurvey.ToList();

            }
            else
            {
                // cmstripRow.Visibility = Visibility.Collapsed;
                // MessageBox.Show("Sorry! You Have no more projects.");
            }
        }

        //private void GetSurveyDetailByUIdPid(long projectid, long userid)
        //{
        //    try
        //    {
        //        SurveyBusiness objSurveyBusiness = new SurveyBusiness();

        //        DataTable dtSurvey = objSurveyBusiness.GetSurveyDetailByPidUid(projectid, userid);
        //        if (dtSurvey.Rows.Count > 0)
        //        {
        //            mdiWinow.lblSurveyName.Content = "Survey: " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtSurvey.Rows[0]["project_name"].ToString().ToLower());
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        PopupBox frmPopup = new PopupBox("Error", ex.Message, MessageBoxImage.Error);
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
