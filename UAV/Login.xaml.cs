
using MahApps.Metro.Controls;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Windows;
using System.Windows.Input;
using UAV.Common;
using UAVBusiness.Business;
using UAVBusiness.Common;
using UAVBusiness.Models;


namespace UAV.Controls
{
    public partial class Login : MetroWindow
    {
        #region[..Variable..]

        public MDIWindow mdiWinow { get; set; }

        #endregion

        #region[.. Form Event ...]


        public Login()
        {

            InitializeComponent();
           txtEmail.Text = "Peterson1@gmail.com";
            txtPin.Password = "123456789";

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;

        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            // mdiWinow.SetAdminSection("Register");
        }

        private void btnSubmitLogin_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                if (txtEmail.Text.Trim().Length == 0)
                {
                    lblMsg.Content = "Enter an email.";
                    txtEmail.Focus();
                    return;
                }
                else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    lblMsg.Content = "Enter a valid email.";
                    txtEmail.Select(0, txtEmail.Text.Length);
                    txtEmail.Focus();
                    return;
                }
                else if (txtPin.Password.Trim().Length == 0)
                {
                    lblMsg.Content = "Enter password.";
                    txtPin.Focus();
                    //return;
                }
                else
                {
                    TResponse objTResponse = new UserProfileBusiness().UserProfileLogin(new LoginModel { Email = txtEmail.Text.Trim(), Password = txtPin.Password.Trim(), RememberMe = false, Type = "Pilot" });

                    if (objTResponse.ResponsePacket != null)
                    {
                        UserProfileModel objPilotModel = objTResponse.ResponsePacket as UserProfileModel;
                        if (objPilotModel != null)
                        {

                            PilotSession.UserName = objPilotModel.FName + " " + objPilotModel.LName;
                            PilotSession.UserId = objPilotModel.UserId;
                            PilotSession.UserEmail = objPilotModel.Email;
                            txtEmail.Text = string.Empty;
                            txtPin.Password = string.Empty;

                            MDIWindow md = new MDIWindow();
                            this.Close();
                            md.Show();
                          
                        }
                        else
                        {
                            lblMsg.Content = "Sorry! Please enter existing emailid/password.";
                            reset();
                        }
                    }
                    else
                    {
                        lblMsg.Content = "Sorry! Please enter existing emailid/password.";
                        reset();
                    }

                }


            }
            catch (Exception ex)
            {

                //PopupBox frmPopup = new PopupBox("Error", ex.Message, MessageBoxImage.Error);
                //frmPopup.ShowDialog();
            }

        }

        private void reset()
        {
            txtEmail.Text = string.Empty;
            txtPin.Password = string.Empty;
        }

        #endregion
    }

}

