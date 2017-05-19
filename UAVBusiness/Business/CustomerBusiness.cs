using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UAVBusiness.Common;
using UAVBusiness.Generic;
using UAVBusiness.Models;
using UAVData;




namespace UAVBusiness.Business
{
    public class CustomerBusiness
    {

        ErrorLogBusiness objErrorLogBusiness = new ErrorLogBusiness();
        ErrorLogModel objErrorLogModel = new ErrorLogModel();
        TResponse objTResponse = new TResponse();

        public TResponse AddUpdate(CustomerModel objCustomerModel)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    Customer objCustomer = db.CustomerRepository.Get(x => x.ID == objCustomerModel.ID).FirstOrDefault();

                    if (objCustomer == null)
                    {
                        objCustomer = new Customer();
                        objCustomer.UserId = objCustomerModel.UserId;
                        objCustomer.FName = objCustomerModel.FName;
                        objCustomer.LName = objCustomerModel.LName;
                        objCustomer.Email = objCustomerModel.Email;
                        objCustomer.Phone = objCustomerModel.Phone;
                        objCustomer.Address1 = objCustomerModel.Address1;
                        objCustomer.Address2 = objCustomerModel.Address2;
                        objCustomer.City = objCustomerModel.City;
                        // objCustomer.Location = objCustomerModel.Location;

                        objCustomer.IsActive = true;
                        objCustomer.IsDeleted = false;
                        objCustomer.CreatedOn = DateTime.Now;

                        objCustomer =  db.CustomerRepository.Insert(objCustomer);
                    }
                    else
                    {
                        
                       
                        objCustomer.FName = objCustomerModel.FName;
                        objCustomer.LName = objCustomerModel.LName;
                        objCustomer.Email = objCustomerModel.Email;
                        objCustomer.Phone = objCustomerModel.Phone;
                        objCustomer.Address1 = objCustomerModel.Address1;
                        objCustomer.Address2 = objCustomerModel.Address2;
                        objCustomer.City = objCustomerModel.City;

                        objCustomer.IsActive = objCustomerModel.IsActive;
                        objCustomer.IsDeleted = objCustomerModel.IsDeleted;

                        objCustomer.UpdatedOn = DateTime.Now;
                        objCustomer =  db.CustomerRepository.Update(objCustomer);
                    }
                    if (objCustomer != null)
                    {


                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = "";
                    }
                    else
                    {
                        objTResponse.Status = ResponseStaus.error;
                        objTResponse.Message = ResponseMessage.ItemNotFound;
                        objTResponse.ResponsePacket = null;
                    }
                    return objTResponse;
                }
                catch (DbEntityValidationException dbEx)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "AddCustomer", Id = objCustomerModel.ID, ClassName = "CustomerBusiness", Error = dbEx.Message });
                    return objTResponse;
                }
            }
        }

        public TResponse GetByID(long Id)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    CustomerModel objCustomerModel = new CustomerModel();
                    Customer objCustomer = db.CustomerRepository.Get(x => x.ID == Id).FirstOrDefault();
                    if (objCustomer != null)
                    {
                        objCustomerModel.ID = objCustomer.ID;

                        objCustomerModel.FName = objCustomer.FName;
                        objCustomerModel.LName = objCustomer.LName;
                        objCustomerModel.Email = objCustomer.Email;
                        objCustomerModel.Phone = objCustomer.Phone;
                        objCustomerModel.Address1 = objCustomer.Address1;
                        objCustomerModel.Address2 = objCustomer.Address2;
                        objCustomerModel.City = objCustomer.City;

                        objCustomerModel.IsActive = Convert.ToBoolean(objCustomer.IsActive);
                        objCustomerModel.IsDeleted = Convert.ToBoolean(objCustomer.IsDeleted);

                        objCustomerModel.UpdatedOn = Convert.ToDateTime(objCustomer.UpdatedOn);


                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objCustomerModel;

                    }
                    else
                    {
                        objTResponse.Status = ResponseStaus.error;
                        objTResponse.Message = ResponseMessage.ItemNotFound;
                        objTResponse.ResponsePacket = null;
                    }
                    return objTResponse;
                }
                catch (DbEntityValidationException dbEx)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "GetByID", Id = Id, ClassName = "CustomerBusiness", Error = dbEx.Message });
                    return objTResponse;
                }
            }
        }
       
        public TResponse GetCustomerLogin(string Email,string password)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    CustomerModel objCustomerModel = new CustomerModel();
                    Customer objCustomer = db.CustomerRepository.Get(x => x.Email == Email && x.Phone == password).FirstOrDefault();
                    if (objCustomer != null)
                    {
                        objCustomerModel.ID = objCustomer.ID;
                        objCustomerModel.UserId =Convert.ToInt16(objCustomer.UserId);
                        objCustomerModel.FName = objCustomer.FName;
                        objCustomerModel.LName = objCustomer.LName;
                        objCustomerModel.Email = objCustomer.Email;
                        objCustomerModel.Phone = objCustomer.Phone;
                        objCustomerModel.Address1 = objCustomer.Address1;
                        objCustomerModel.Address2 = objCustomer.Address2;
                        objCustomerModel.City = objCustomer.City;

                        objCustomerModel.IsActive = Convert.ToBoolean(objCustomer.IsActive);
                        objCustomerModel.IsDeleted = Convert.ToBoolean(objCustomer.IsDeleted);

                        objCustomerModel.UpdatedOn = Convert.ToDateTime(objCustomer.UpdatedOn);


                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objCustomerModel;

                    }
                    else
                    {
                        objTResponse.Status = ResponseStaus.error;
                        objTResponse.Message = ResponseMessage.ItemNotFound;
                        objTResponse.ResponsePacket = null;
                    }
                    return objTResponse;
                }
                catch (DbEntityValidationException dbEx)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "GetCustomerLogin", Id = 0, ClassName = "CustomerBusiness", Error = dbEx.Message });
                    return objTResponse;
                }
            }
        }

        public TResponse GetAll()
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    List<CustomerModel> lstCustomerModel = new List<CustomerModel>();
                    CustomerModel objCustomerModel;
                    List<Customer> lstCustomer = db.CustomerRepository.GetAll().ToList();
                    if (lstCustomer != null && lstCustomer.Count > 0)
                    {
                        foreach (Customer objCustomer in lstCustomer)
                        {
                            objCustomerModel = new CustomerModel();
                            objCustomerModel.ID = objCustomer.ID;

                            objCustomerModel.FName = objCustomer.FName;
                            objCustomerModel.LName = objCustomer.LName;
                            objCustomerModel.Email = objCustomer.Email;
                            objCustomerModel.Phone = objCustomer.Phone;
                            objCustomerModel.Address1 = objCustomer.Address1;
                            objCustomerModel.Address2 = objCustomer.Address2;
                            objCustomerModel.City = objCustomer.City;

                            objCustomerModel.IsActive = Convert.ToBoolean(objCustomer.IsActive);
                            objCustomerModel.IsDeleted = Convert.ToBoolean(objCustomer.IsDeleted);

                            objCustomerModel.UpdatedOn = DateTime.Now;
                            lstCustomerModel.Add(objCustomerModel);
                        }
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = lstCustomerModel;

                    }
                    else
                    {
                        objTResponse.Status = ResponseStaus.error;
                        objTResponse.Message = ResponseMessage.ItemNotFound;
                        objTResponse.ResponsePacket = null;
                    }
                    return objTResponse;
                }
                catch (DbEntityValidationException dbEx)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "ListCustomer", Id = 0, ClassName = "CustomerBusiness", Error = dbEx.Message });
                    return objTResponse;
                }
            }
        }

        public TResponse Delete(int ID)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    Customer objCustomer = db.CustomerRepository.GetById(ID);
                    if (objCustomer != null && objCustomer.ID > 0)
                    {
                        objCustomer.IsDeleted = true;
                        db.CustomerRepository.Update(objCustomer);
                    }


                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteCustomer", Id = 0, ClassName = "CustomerBusiness", Error = ex.Message });
                    return objTResponse;

                }

                return objTResponse;
            }
        }

        public TResponse UpdateStatus(int ID, bool Status)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    Customer objCustomer = db.CustomerRepository.GetById(ID);
                    if (objCustomer != null && objCustomer.ID > 0)
                    {
                        objCustomer.IsActive = Status;
                        db.CustomerRepository.Update(objCustomer);
                    }
                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteCustomer", Id = 0, ClassName = "CustomerBusiness", Error = ex.Message });
                    return objTResponse;
                }

                return objTResponse;
            }
        }
    }
}

