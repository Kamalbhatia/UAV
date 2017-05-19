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
    public class CustomerLocationBusiness
    {

        ErrorLogBusiness objErrorLogBusiness = new ErrorLogBusiness();
        ErrorLogModel objErrorLogModel = new ErrorLogModel();
        TResponse objTResponse = new TResponse();

        public TResponse AddUpdate(CustomerLocationModel objCustomerLocationModel)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    CustomerLocation objCustomerLocation = db.CustomerLocationRepository.Get(x => x.ID == objCustomerLocationModel.ID).FirstOrDefault();

                    if (objCustomerLocation == null)
                    {
                        objCustomerLocation = new CustomerLocation();

                        objCustomerLocation.CustomerID = Convert.ToInt64(objCustomerLocationModel.CustomerID);
                        objCustomerLocationModel.Location = objCustomerLocation.Location;
                        objCustomerLocationModel.LocationName = objCustomerLocation.LocationName;
                        objCustomerLocation.IsActive = true;
                        objCustomerLocation.IsDeleted = false;
                        objCustomerLocation.CreatedOn = DateTime.Now;

                        objCustomerLocation = objCustomerLocation = db.CustomerLocationRepository.Insert(objCustomerLocation);
                    }
                    else
                    {
                        objCustomerLocation = new CustomerLocation();
                        objCustomerLocation.CustomerID = Convert.ToInt64(objCustomerLocationModel.CustomerID);
                        objCustomerLocation.Location = objCustomerLocationModel.Location;
                        objCustomerLocation.LocationName = objCustomerLocationModel.LocationName;
                        objCustomerLocation.UpdatedOn = DateTime.Now;
                        objCustomerLocation = objCustomerLocation = db.CustomerLocationRepository.Update(objCustomerLocation);
                    }
                    if (objCustomerLocation != null)
                    {
                        objCustomerLocationModel = new CustomerLocationModel();
                        objCustomerLocationModel.CustomerID = Convert.ToInt64(objCustomerLocation.CustomerID);
                        objCustomerLocationModel.LocationName = objCustomerLocation.LocationName;
                        objCustomerLocationModel.Location = objCustomerLocation.Location;
                        objCustomerLocationModel.IsActive = Convert.ToBoolean(objCustomerLocation.IsActive);
                        objCustomerLocationModel.IsDeleted = Convert.ToBoolean(objCustomerLocation.IsDeleted);
                        objCustomerLocationModel.CreatedOn = Convert.ToDateTime(objCustomerLocation.CreatedOn);

                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objCustomerLocationModel;
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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "AddCustomerLocation", Id = objCustomerLocationModel.ID, ClassName = "CustomerLocationBusiness", Error = dbEx.Message });
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
                    CustomerLocationModel objCustomerLocationModel = new CustomerLocationModel();
                    CustomerLocation objCustomerLocation = db.CustomerLocationRepository.Get(x => x.ID == Id).FirstOrDefault();
                    if (objCustomerLocation != null)
                    {
                        objCustomerLocationModel.ID = objCustomerLocation.ID;
                        objCustomerLocationModel.CustomerID = Convert.ToInt64(objCustomerLocation.CustomerID);
                        objCustomerLocationModel.CustomerName = objCustomerLocation.UserProfile.FName + " " + objCustomerLocation.UserProfile.FName;
                        objCustomerLocationModel.Location = objCustomerLocation.Location;
                        objCustomerLocationModel.LocationName = objCustomerLocation.LocationName;
                        objCustomerLocationModel.IsActive = Convert.ToBoolean(objCustomerLocation.IsActive);
                        objCustomerLocationModel.IsDeleted = Convert.ToBoolean(objCustomerLocation.IsDeleted);
                        objCustomerLocationModel.CreatedOn = Convert.ToDateTime(objCustomerLocation.CreatedOn);
                        objCustomerLocationModel.UpdatedOn = Convert.ToDateTime(objCustomerLocation.UpdatedOn);

                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objCustomerLocationModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "GetByID", Id = Id, ClassName = "CustomerLocationBusiness", Error = dbEx.Message });
                    return objTResponse;
                }
            }
        }

        public TResponse GetAll(long CustomerID)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    List<CustomerLocationModel> lstCustomerLocationModel = new List<CustomerLocationModel>();
                    CustomerLocationModel objCustomerLocationModel;
                    List<CustomerLocation> lstCustomerLocation = db.CustomerLocationRepository.Get(x => x.CustomerID == CustomerID).ToList();
                    if (lstCustomerLocation != null && lstCustomerLocation.Count > 0)
                    {
                        foreach (CustomerLocation objCustomerLocation in lstCustomerLocation)
                        {
                            objCustomerLocationModel = new CustomerLocationModel();
                            objCustomerLocationModel.ID = objCustomerLocation.ID;
                            objCustomerLocationModel.CustomerID = Convert.ToInt64(objCustomerLocation.CustomerID);
                            objCustomerLocationModel.CustomerName = objCustomerLocation.UserProfile.FName + " " + objCustomerLocation.UserProfile.LName;
                            objCustomerLocationModel.Location = objCustomerLocation.Location;
                            objCustomerLocationModel.LocationName = objCustomerLocation.LocationName;
                            objCustomerLocationModel.IsActive = Convert.ToBoolean(objCustomerLocation.IsActive);
                            objCustomerLocationModel.IsDeleted = Convert.ToBoolean(objCustomerLocation.IsDeleted);
                            objCustomerLocationModel.CreatedOn = Convert.ToDateTime(objCustomerLocation.CreatedOn);
                            objCustomerLocationModel.UpdatedOn = Convert.ToDateTime(objCustomerLocation.UpdatedOn);
                            objCustomerLocationModel.UpdatedOn = Convert.ToDateTime(objCustomerLocation.UpdatedOn);
                            lstCustomerLocationModel.Add(objCustomerLocationModel);
                        }
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = lstCustomerLocationModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "ListCustomerLocation", Id = 0, ClassName = "CustomerLocationBusiness", Error = dbEx.Message });
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
                    List<CustomerLocationModel> lstCustomerLocationModel = new List<CustomerLocationModel>();
                    CustomerLocationModel objCustomerLocationModel;
                    List<CustomerLocation> lstCustomerLocation = db.CustomerLocationRepository.Get().ToList();
                    if (lstCustomerLocation != null && lstCustomerLocation.Count > 0)
                    {
                        foreach (CustomerLocation objCustomerLocation in lstCustomerLocation)
                        {
                            objCustomerLocationModel = new CustomerLocationModel();
                            objCustomerLocationModel.ID = objCustomerLocation.ID;
                            objCustomerLocationModel.CustomerID = Convert.ToInt64(objCustomerLocation.CustomerID);
                            objCustomerLocationModel.CustomerName = objCustomerLocation.UserProfile.FName + " " + objCustomerLocation.UserProfile.LName;
                            objCustomerLocationModel.Location = objCustomerLocation.Location;
                            objCustomerLocationModel.LocationName = objCustomerLocation.LocationName;
                            objCustomerLocationModel.IsActive = Convert.ToBoolean(objCustomerLocation.IsActive);
                            objCustomerLocationModel.IsDeleted = Convert.ToBoolean(objCustomerLocation.IsDeleted);
                            objCustomerLocationModel.CreatedOn = Convert.ToDateTime(objCustomerLocation.CreatedOn);
                            objCustomerLocationModel.UpdatedOn = Convert.ToDateTime(objCustomerLocation.UpdatedOn);
                            objCustomerLocationModel.UpdatedOn = Convert.ToDateTime(objCustomerLocation.UpdatedOn);
                            lstCustomerLocationModel.Add(objCustomerLocationModel);
                        }
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = lstCustomerLocationModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "ListCustomerLocation", Id = 0, ClassName = "CustomerLocationBusiness", Error = dbEx.Message });
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
                    CustomerLocation objCustomerLocation = db.CustomerLocationRepository.GetById(ID);
                    if (objCustomerLocation != null && objCustomerLocation.ID > 0)
                    {
                        objCustomerLocation.IsDeleted = true;
                        db.CustomerLocationRepository.Update(objCustomerLocation);
                    }


                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteCustomerLocation", Id = 0, ClassName = "CustomerLocationBusiness", Error = ex.Message });
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
                    CustomerLocation objCustomerLocation = db.CustomerLocationRepository.GetById(ID);
                    if (objCustomerLocation != null && objCustomerLocation.ID > 0)
                    {
                        objCustomerLocation.IsActive = Status;
                        db.CustomerLocationRepository.Update(objCustomerLocation);
                    }
                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteCustomerLocation", Id = 0, ClassName = "CustomerLocationBusiness", Error = ex.Message });
                    return objTResponse;
                }

                return objTResponse;
            }
        }
    }
}

