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
    public class AssignedCustomerBusiness
    {

        ErrorLogBusiness objErrorLogBusiness = new ErrorLogBusiness();
        ErrorLogModel objErrorLogModel = new ErrorLogModel();
        TResponse objTResponse = new TResponse();

        #region [-Web-]

        //public TResponse AddUpdate(AssignedCustomerModel objAssignedCustomerModel)
        //{
        //    using (var db = new UnitOfWork())
        //    {
        //        try
        //        {
        //            AssignedCustomer objAssignedCustomer = db.AssignedCustomerRepository.Get(x => x.Id == objAssignedCustomerModel.UserId).FirstOrDefault();

        //            if (objAssignedCustomer == null)
        //            {
        //                objAssignedCustomer = new AssignedCustomer();

        //                objAssignedCustomer.CustomerID = objAssignedCustomerModel.CustomerID;
        //                objAssignedCustomer.PilotID = objAssignedCustomerModel.PilotID;
                      
        //                objAssignedCustomer.IsActive = true;
        //                objAssignedCustomer.IsDeleted = false;
        //                objAssignedCustomer.CreatedOn = DateTime.Now;
        //                objAssignedCustomer = db.AssignedCustomerRepository.Insert(objAssignedCustomer);
        //            }
        //            else
        //            {
        //                objAssignedCustomer.Id = Convert.ToInt16(objAssignedCustomerModel.Id);
        //                objAssignedCustomer.CustomerID = objAssignedCustomerModel.CustomerID;
        //                objAssignedCustomer.PilotID = objAssignedCustomerModel.PilotID;
                       
        //                objAssignedCustomer.UpdatedOn = DateTime.Now;
        //                objAssignedCustomer = db.AssignedCustomerRepository.Update(objAssignedCustomer);
        //            }
        //            if (objAssignedCustomer != null)
        //            {
        //                objAssignedCustomerModel = new AssignedCustomerModel();
        //                objAssignedCustomerModel.Id = objAssignedCustomer.Id;
        //                objAssignedCustomerModel.CustomerID = objAssignedCustomer.CustomerID;
        //                objAssignedCustomerModel.PilotID = objAssignedCustomer.PilotID;
                        
        //                objAssignedCustomerModel.IsActive = Convert.ToBoolean(objAssignedCustomer.IsActive);
        //                objAssignedCustomerModel.IsDeleted = objAssignedCustomerModel.IsDeleted;
        //                objAssignedCustomerModel.CreatedOn = objAssignedCustomerModel.CreatedOn;

        //                objTResponse.Status = ResponseStaus.ok;
        //                objTResponse.Message = ResponseMessage.success;
        //                objTResponse.ResponsePacket = objAssignedCustomerModel;
        //            }
        //            else
        //            {
        //                objTResponse.Status = ResponseStaus.error;
        //                objTResponse.Message = ResponseMessage.ItemNotFound;
        //                objTResponse.ResponsePacket = null;
        //            }
        //            return objTResponse;
        //        }
        //        catch (DbEntityValidationException dbEx)
        //        {
        //            ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
        //            objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "AddAssignedCustomer", Id = objAssignedCustomerModel.UserId, ClassName = "AssignedCustomerBusiness", Error = dbEx.Message });
        //            return objTResponse;
        //        }
        //    }
        //}

        //public TResponse GetByID(long Id)
        //{
        //    using (var db = new UnitOfWork())
        //    {
        //        try
        //        {
        //            AssignedCustomerModel objAssignedCustomerModel = new AssignedCustomerModel();
        //            AssignedCustomer objAssignedCustomer = db.AssignedCustomerRepository.Get(x => x.UserId == Id).FirstOrDefault();
        //            if (objAssignedCustomer != null)
        //            {
        //                objAssignedCustomerModel.Id = objAssignedCustomer.Id;
        //                objAssignedCustomerModel.CustomerID = objAssignedCustomer.CustomerID;
        //                objAssignedCustomerModel.PilotID = objAssignedCustomer.PilotID;
                     
        //                objAssignedCustomerModel.IsActive = Convert.ToBoolean(objAssignedCustomer.IsActive);
        //                objAssignedCustomerModel.IsDeleted = objAssignedCustomerModel.IsDeleted;
        //                objAssignedCustomerModel.CreatedOn = objAssignedCustomerModel.CreatedOn;
        //                objTResponse.Status = ResponseStaus.ok;
        //                objTResponse.Message = ResponseMessage.success;
        //                objTResponse.ResponsePacket = objAssignedCustomerModel;

        //            }
        //            else
        //            {
        //                objTResponse.Status = ResponseStaus.error;
        //                objTResponse.Message = ResponseMessage.ItemNotFound;
        //                objTResponse.ResponsePacket = null;
        //            }
        //            return objTResponse;
        //        }
        //        catch (DbEntityValidationException dbEx)
        //        {
        //            ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
        //            objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "GetByID", Id = Id, ClassName = "AssignedCustomerBusiness", Error = dbEx.Message });
        //            return objTResponse;
        //        }
        //    }
        //}

        public TResponse GetByPilot(long Id)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    List<AssignedCustomerModel> lstAssignedCustomerModel = new List<AssignedCustomerModel>();
                    AssignedCustomerModel objAssignedCustomerModel = new AssignedCustomerModel();
                    List<AssignedCustomer> lstAssignedCustomer = db.AssignedCustomerRepository.Get(x => x.PilotID == Id).ToList();
                    if (lstAssignedCustomer != null)
                    {
                        foreach (AssignedCustomer objAssignedCustomer in lstAssignedCustomer)
                        {
                            objAssignedCustomerModel = new AssignedCustomerModel();
                            objAssignedCustomerModel.Id = objAssignedCustomer.Id;
                            objAssignedCustomerModel.CustomerID = objAssignedCustomer.CustomerID;
                            objAssignedCustomerModel.PilotID = objAssignedCustomer.PilotID;

                            objAssignedCustomerModel.CustomerName = objAssignedCustomer.UserProfile.FName + " " + objAssignedCustomer.UserProfile.LName;
                            objAssignedCustomerModel.PilotName = objAssignedCustomer.UserProfile.FName + " " + objAssignedCustomer.UserProfile.LName;

                            objAssignedCustomerModel.IsActive = Convert.ToBoolean(objAssignedCustomer.IsActive);
                            objAssignedCustomerModel.IsDeleted = objAssignedCustomerModel.IsDeleted;
                            objAssignedCustomerModel.CreatedOn = objAssignedCustomerModel.CreatedOn;
                            lstAssignedCustomerModel.Add(objAssignedCustomerModel);
                        }
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = lstAssignedCustomerModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "GetByID", Id = Id, ClassName = "AssignedCustomerBusiness", Error = dbEx.Message });
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
                    List<AssignedCustomerModel> lstAssignedCustomerModel = new List<AssignedCustomerModel>();
                    AssignedCustomerModel objAssignedCustomerModel;
                    List<AssignedCustomer> lstAssignedCustomer = db.AssignedCustomerRepository.GetAll().ToList();
                    if (lstAssignedCustomer != null && lstAssignedCustomer.Count > 0)
                    {
                        foreach (AssignedCustomer obj in lstAssignedCustomer)
                        {
                            objAssignedCustomerModel = new AssignedCustomerModel();
                            objAssignedCustomerModel.Id = obj.Id;
                            objAssignedCustomerModel.CustomerID = obj.CustomerID;
                            objAssignedCustomerModel.PilotID = obj.PilotID;
                      
                            objAssignedCustomerModel.IsActive = Convert.ToBoolean(obj.IsActive);
                            objAssignedCustomerModel.IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                            objAssignedCustomerModel.CreatedOn = Convert.ToDateTime(obj.CreatedOn);
                            lstAssignedCustomerModel.Add(objAssignedCustomerModel);
                        }
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = lstAssignedCustomerModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "ListAssignedCustomer", Id = 0, ClassName = "AssignedCustomerBusiness", Error = dbEx.Message });
                    return objTResponse;
                }
            }
        }

        //public TResponse Delete(int ID)
        //{
        //    using (var db = new UnitOfWork())
        //    {
        //        try
        //        {
        //            AssignedCustomer objAssignedCustomer = db.AssignedCustomerRepository.GetById(ID);
        //            if (objAssignedCustomer != null && objAssignedCustomer.UserId > 0)
        //            {
        //                objAssignedCustomer.IsDeleted = true;
        //                db.AssignedCustomerRepository.Update(objAssignedCustomer);
        //            }


        //            objTResponse.Status = ResponseStaus.ok;
        //            objTResponse.Message = ResponseMessage.success;
        //        }
        //        catch (Exception ex)
        //        {
        //            ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
        //            objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteAssignedCustomer", Id = 0, ClassName = "AssignedCustomerBusiness", Error = ex.Message });
        //            return objTResponse;

        //        }

        //        return objTResponse;
        //    }
        //}

      
        //public TResponse UpdateStatus(long ID, bool Status)
        //{
        //    using (var db = new UnitOfWork())
        //    {
        //        try
        //        {
        //            AssignedCustomer objAssignedCustomer = db.AssignedCustomerRepository.GetById(ID); 
        //            if (objAssignedCustomer != null && objAssignedCustomer.UserId > 0)
        //            {
        //                objAssignedCustomer.IsActive = Status;
        //                db.AssignedCustomerRepository.Update(objAssignedCustomer);
        //            }
        //            objTResponse.Status = ResponseStaus.ok;
        //            objTResponse.Message = ResponseMessage.success;
        //        }
        //        catch (Exception ex)
        //        {
        //            ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
        //            objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteAssignedCustomer", Id = 0, ClassName = "AssignedCustomerBusiness", Error = ex.Message });
        //            return objTResponse;
        //        }

        //        return objTResponse;
        //    }
        //}

      
        #endregion

      
    }
}

