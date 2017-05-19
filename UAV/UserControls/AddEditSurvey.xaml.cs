


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
using Microsoft.Maps.MapControl.WPF;


namespace UAV.UserControls
{

    public partial class AddEditSurvey : UserControl
    {
        #region [... Variable ...]

        public MDIWindow mdiWinow { get; set; }
        public CustomerLocationModel objCustomerLocationModel { get; set; }

        #endregion


        #region[.. Form Event ...]

        public AddEditSurvey()
        {
            InitializeComponent();
            txtDate.Text = Convert.ToDateTime(DateTime.Now.Date).ToString("dd/MM/yyyy");
            FillCustomers();
            if (PilotSession.SurveyId > 0)
            { GetSurveyDetail(PilotSession.SurveyId); }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        #endregion


        #region[.. Functions ...]

        private void FillCustomers()
        {
            TResponse objTResponse = new UserProfileBusiness().GetAllUserByType("Customer");
            if (objTResponse.ResponsePacket != null)
            {
                List<UserProfileModel> lstUserProfileModel = objTResponse.ResponsePacket as List<UserProfileModel>;
                cmbCustomers.DisplayMemberPath = "FName";
                cmbCustomers.SelectedValuePath = "UserId";
                cmbCustomers.ItemsSource = lstUserProfileModel;
                cmbCustomers.SelectedIndex = -1;
            }
        }

        private void GetSurveyDetail(long id)
        {
            TResponse objTResponse = new SurveyDetailBusiness().GetByID(id);
            if (objTResponse.ResponsePacket != null)
            {
                SurveyModel objSurveyModel = objTResponse.ResponsePacket as SurveyModel;

                FillSurveyDetail(objSurveyModel);
            }

        }

        private void FillSurveyDetail(SurveyModel objSurveyModel)
        {
            txtTitle.Text = objSurveyModel.Title;
            cmbCustomers.SelectedValue = objSurveyModel.CustomerID;
            txtDate.Text = Convert.ToDateTime(objSurveyModel.SurveyDate).ToString("dd/MM/yyyy");
            txtTime.Text = objSurveyModel.SurveyTime.ToString();

            FillCustomerSites(Convert.ToInt64(cmbCustomers.SelectedValue));

        }

        private void FillCustomerSites(long CustomerID)
        {
            TResponse objTResponse = new CustomerLocationBusiness().GetAll(CustomerID);
            if (objTResponse.ResponsePacket != null)
            {
                List<CustomerLocationModel> lstCustomerLocationModel = objTResponse.ResponsePacket as List<CustomerLocationModel>;
                cmbSites.DisplayMemberPath = "LocationName";
                cmbSites.SelectedValuePath = "ID";
                cmbSites.ItemsSource = lstCustomerLocationModel;
                cmbSites.SelectedIndex = 0;


            }

        }

        private void cmbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Int64 SelectedValue = Convert.ToInt64(cmbCustomers.SelectedValue);
            if (SelectedValue > 0)
            {
                FillCustomerSites(SelectedValue);

            }
            else
            {
                //if (cmbCustomers.Items.Count > 0)
                //{ cmbCustomers.SelectedIndex = 0; }
                //else
                //{
                //    PopupBox frmPopup = new PopupBox("Information", "Select a customer", MessageBoxImage.Information);
                //    frmPopup.ShowDialog();
                //    return;
                //}

            }

        }

        private void cmbSites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSites.SelectedItem as CustomerLocationModel != null)
            {
                 objCustomerLocationModel = cmbSites.SelectedItem as CustomerLocationModel;
                 Location location = new Location() { Latitude = Convert.ToDouble(objCustomerLocationModel.Location.Latitude), Longitude = Convert.ToDouble(objCustomerLocationModel.Location.Longitude) };
                 CustomerSiteMap.Children.Cast<Microsoft.Maps.MapControl.WPF.Pushpin>().FirstOrDefault().Location = location;
                 CustomerSiteMap.Center = location; 
                //addImageToMap(CustomerSiteMap, null);
            }
          
           
        }
        
        private void addImageToMap(object sender, RoutedEventArgs e)
        {
            Location location = new Location() { Latitude = Convert.ToDouble(objCustomerLocationModel.Location.Latitude), Longitude = Convert.ToDouble(objCustomerLocationModel.Location.Longitude) };
            CustomerSiteMap.Children.Cast<Microsoft.Maps.MapControl.WPF.Pushpin>().FirstOrDefault().Location = location;
            CustomerSiteMap.Center = location; 
        }
       
        private void btnSurveyList_Click(object sender, RoutedEventArgs e)
        {
            PilotSession.SurveyId = 0;
            mdiWinow.SetAdminSection("SurveyList");
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            mdiWinow.SetAdminSection("AddEditSurveyStep2");
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //txtDate.DisplayDateStart = dpFromDate.SelectedDate;
        }


        #endregion

      
    }

}
