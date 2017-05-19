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
    public class PilotBusiness
    {

        ErrorLogBusiness objErrorLogBusiness = new ErrorLogBusiness();
        ErrorLogModel objErrorLogModel = new ErrorLogModel();
        TResponse objTResponse = new TResponse();

        #region [-Web-]
        
        public TResponse AddUpdate(PilotModel objPilotModel)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    Pilot objPilot = db.PilotRepository.Get(x => x.ID == objPilotModel.ID).FirstOrDefault();

                    if (objPilot == null)
                    {
                        objPilot = new Pilot();
                        //objPilot.UserId = Convert.ToInt16(objPilotModel.UserId);
                        objPilot.FName = objPilotModel.FName;
                        objPilot.LName = objPilotModel.LName;
                        objPilot.Email = objPilotModel.Email;
                        objPilot.Phone = objPilotModel.Phone;
                        objPilot.Address1 = objPilotModel.Address1;
                        objPilot.Address2 = objPilotModel.Address2;
                        objPilot.City = objPilotModel.City;
                        objPilot.IsActive = true;
                        objPilot.IsDeleted = false;
                        objPilot.CreatedOn = DateTime.Now;
                        objPilot = db.PilotRepository.Insert(objPilot);
                    }
                    else
                    {
                        objPilot.FName = objPilotModel.FName;
                        objPilot.LName = objPilotModel.LName;
                        objPilot.Email = objPilotModel.Email;
                        objPilot.Phone = objPilotModel.Phone;
                        objPilot.Address1 = objPilotModel.Address1;
                        objPilot.Address2 = objPilotModel.Address2;
                        objPilot.City = objPilotModel.City;
                        objPilot.IsActive = objPilotModel.IsActive;
                        objPilot.IsDeleted = objPilotModel.IsDeleted;
                        objPilot.UpdatedOn = DateTime.Now;
                        objPilot = db.PilotRepository.Update(objPilot);
                    }
                    if (objPilot != null)
                    {
                        objPilotModel = new PilotModel();
                        objPilotModel.FName = objPilot.FName;
                        objPilotModel.LName = objPilot.LName;
                        objPilotModel.Email = objPilot.Email;
                        objPilotModel.Phone = objPilot.Phone;
                        objPilotModel.Address1 = objPilot.Address1;
                        objPilotModel.Address2 = objPilot.Address2;
                        objPilotModel.City = objPilot.City;
                        objPilotModel.IsActive = Convert.ToBoolean(objPilot.IsActive);
                        objPilotModel.IsDeleted = objPilotModel.IsDeleted;
                        objPilotModel.CreatedOn = objPilotModel.CreatedOn;

                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objPilotModel;
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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "AddPilot", Id = objPilotModel.ID, ClassName = "PilotBusiness", Error = dbEx.Message });
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
                    PilotModel objPilotModel = new PilotModel();
                    Pilot objPilot = db.PilotRepository.Get(x => x.ID == Id).FirstOrDefault();
                    if (objPilot != null)
                    {
                        objPilotModel.ID = objPilot.ID;
                        //objPilotModel.UserId = Convert.ToInt16(objPilot.UserId);
                        objPilotModel.FName = objPilot.FName;
                        objPilotModel.LName = objPilot.LName;
                        objPilotModel.Email = objPilot.Email;
                        objPilotModel.Phone = objPilot.Phone;
                        objPilotModel.Address1 = objPilot.Address1;
                        objPilotModel.Address2 = objPilot.Address2;
                        objPilotModel.City = objPilot.City;
                        objPilotModel.IsActive = Convert.ToBoolean(objPilot.IsActive);
                        objPilotModel.IsDeleted = objPilotModel.IsDeleted;
                        objPilotModel.CreatedOn = objPilotModel.CreatedOn;
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objPilotModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "GetByID", Id = Id, ClassName = "PilotBusiness", Error = dbEx.Message });
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
                    List<PilotModel> lstPilotModel = new List<PilotModel>();
                    PilotModel objPilotModel;
                    List<Pilot> lstPilot = db.PilotRepository.GetAll().ToList();
                    if (lstPilot != null && lstPilot.Count > 0)
                    {
                        foreach (Pilot obj in lstPilot)
                        {
                            objPilotModel = new PilotModel();
                            objPilotModel.ID = obj.ID;
                            //objPilotModel.UserId =Convert.ToInt16(obj.UserId);
                            objPilotModel.FName = obj.FName;
                            objPilotModel.LName = obj.LName;
                            objPilotModel.Email = obj.Email;
                            objPilotModel.Phone = obj.Phone;
                            objPilotModel.Address1 = obj.Address1;
                            objPilotModel.Address2 = obj.Address2;
                            objPilotModel.City = obj.City;
                            objPilotModel.IsActive = Convert.ToBoolean(obj.IsActive);
                            objPilotModel.IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                            objPilotModel.CreatedOn = Convert.ToDateTime(obj.CreatedOn);
                            lstPilotModel.Add(objPilotModel);
                        }
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = lstPilotModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "ListPilot", Id = 0, ClassName = "PilotBusiness", Error = dbEx.Message });
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
                    Pilot objPilot = db.PilotRepository.GetById(ID);
                    if (objPilot != null && objPilot.ID > 0)
                    {
                        objPilot.IsDeleted = true;
                        db.PilotRepository.Update(objPilot);
                    }


                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeletePilot", Id = 0, ClassName = "PilotBusiness", Error = ex.Message });
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
                    Pilot objPilot =db.PilotRepository.GetById(ID);
                    if (objPilot != null && objPilot.ID > 0)
                    {
                        objPilot.IsActive = Status;
                        db.PilotRepository.Update(objPilot);
                    }
                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeletePilot", Id = 0, ClassName = "PilotBusiness", Error = ex.Message });
                    return objTResponse;
                }

                return objTResponse;
            }
        }
        
        #endregion
        
        #region [-Desktop-]

        public TResponse PilotLogin(string email, string pasword,string type)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    PilotModel objPilotModel = new PilotModel();
                    UserProfile objPilot = db.UserProfileRepository.Get(x => x.Email == email && x.Password == pasword && x.Type == type && x.IsDeleted == false).FirstOrDefault();
                    if (objPilot != null)
                    {
                        objPilotModel.UserId = objPilot.UserId;
                        objPilotModel.FName = objPilot.FName;
                        objPilotModel.LName = objPilot.LName;
                        objPilotModel.Email = objPilot.Email;
                        objPilotModel.Password = objPilot.Password;
                        objPilotModel.Phone = objPilot.Phone;
                        objPilotModel.Address1 = objPilot.Address1;
                        objPilotModel.Address2 = objPilot.Address2;
                        objPilotModel.City = objPilot.City;
                        objPilotModel.IsActive = Convert.ToBoolean(objPilot.IsActive);
                        objPilotModel.IsDeleted = objPilotModel.IsDeleted;
                        objPilotModel.CreatedOn = objPilotModel.CreatedOn;
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objPilotModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "PilotLogin", Id = 0, ClassName = "PilotBusiness", Error = dbEx.Message });
                    return objTResponse;
                }
            }
        }

        #endregion
    }
}

