


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

    public partial class AddEditSurveyStep3 : UserControl
    {
        #region [... Variable ...]

        public MDIWindow mdiWinow { get; set; }
        public CustomerLocationModel objCustomerLocationModel { get; set; }

        #endregion


        #region[.. Form Event ...]

        public AddEditSurveyStep3()
        {
            InitializeComponent();

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

                addImageToMap(CustomerSiteMap, null);
            }


        }

        private void addImageToMap(object sender, RoutedEventArgs e)
        {

            List<UIElement> lstMapLayer = CustomerSiteMap.Children.Cast<UIElement>().ToList();
            for (int i = 0; i < lstMapLayer.Count; i++)
            {
                if (lstMapLayer[i].GetType().ToString() == "Microsoft.Maps.MapControl.WPF.MapLayer")
                    CustomerSiteMap.Children.Remove(lstMapLayer[i]);
            }
            CustomerSiteMap.UpdateLayout();

            MapLayer imageLayer = new MapLayer();


            Image image = new Image();
            image.Height = 50;
            image.Width = 50;
            //Define the URI location of the image
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();

            myBitmapImage.UriSource = new Uri("http://www.iconsdb.com/icons/preview/red/marker-xxl.png");
            // To save significant application memory, set the DecodePixelWidth or  
            // DecodePixelHeight of the BitmapImage value of the image source to the desired 
            // height or width of the rendered image. If you don't do this, the application will 
            // cache the image as though it were rendered as its normal size rather then just 
            // the size that is displayed.
            // Note: In order to preserve aspect ratio, set DecodePixelWidth
            // or DecodePixelHeight but not both.
            //Define the image display properties
            myBitmapImage.DecodePixelHeight = 50;
            myBitmapImage.EndInit();
            image.Source = myBitmapImage;
            image.Opacity = 0.6;
            image.Stretch = System.Windows.Media.Stretch.None;

            //The map location to place the image at
            Location location = new Location() { Latitude = Convert.ToDouble(objCustomerLocationModel.Location.Latitude), Longitude = Convert.ToDouble(objCustomerLocationModel.Location.Longitude) };
            //{ Latitude =Convert.ToDouble(objCustomerLocationModel.Location.Latitude), Longitude =Convert.ToDouble(objCustomerLocationModel.Location.Longitude) };
            // Location location = new Location() { Latitude = 26.922070, Longitude = 75.778885 };
            //Location location = new Location() { Latitude = 23.424076, Longitude = 53.847818 };
            //Location location = new Location() { Latitude = 33.93911, Longitude = 67.709953 };

            //Center the image around the location specified
            PositionOrigin position = PositionOrigin.Center;

            //Add the image to the defined map layer
            imageLayer.AddChild(image, location, position);
            //Add the image layer to the map
            CustomerSiteMap.Children.Add(imageLayer);
            CustomerSiteMap.ZoomLevel = 2;
            CustomerSiteMap.BringIntoView();

        }

        private void btnSurveyList_Click(object sender, RoutedEventArgs e)
        {
            PilotSession.SurveyId = 0;
            mdiWinow.SetAdminSection("SurveyList");
        }

        #endregion

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            mdiWinow.SetAdminSection("AddEditSurveyStep4");
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //txtDate.DisplayDateStart = dpFromDate.SelectedDate;
        }

    }

}
