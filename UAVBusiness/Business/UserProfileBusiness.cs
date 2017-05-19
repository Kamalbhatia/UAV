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
    public class UserProfileBusiness
    {

        ErrorLogBusiness objErrorLogBusiness = new ErrorLogBusiness();
        ErrorLogModel objErrorLogModel = new ErrorLogModel();
        TResponse objTResponse = new TResponse();

        #region [-Web-]

        public TResponse AddUpdate(UserProfileModel objUserProfileModel)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    UserProfile objUserProfile = db.UserProfileRepository.Get(x => x.UserId == objUserProfileModel.UserId).FirstOrDefault();

                    if (objUserProfile == null)
                    {
                        objUserProfile = new UserProfile();

                        objUserProfile.FName = objUserProfileModel.FName;
                        objUserProfile.LName = objUserProfileModel.LName;
                        objUserProfile.Email = objUserProfileModel.Email;
                        objUserProfile.Password = objUserProfileModel.Password;
                        objUserProfile.Type = objUserProfileModel.Type;
                        objUserProfile.Phone = objUserProfileModel.Phone;
                        objUserProfile.Address1 = objUserProfileModel.Address1;
                        objUserProfile.Address2 = objUserProfileModel.Address2;
                        objUserProfile.City = objUserProfileModel.City;
                        objUserProfile.IsActive = true;
                        objUserProfile.IsDeleted = false;
                        objUserProfile.CreatedOn = DateTime.Now;
                        objUserProfile = db.UserProfileRepository.Insert(objUserProfile);
                    }
                    else
                    {
                        objUserProfile.UserId = Convert.ToInt16(objUserProfileModel.UserId);
                        objUserProfile.FName = objUserProfileModel.FName;
                        objUserProfile.LName = objUserProfileModel.LName;
                        objUserProfile.Email = objUserProfileModel.Email;
                        objUserProfile.Password = objUserProfileModel.Password;
                        objUserProfile.Type = objUserProfileModel.Type;
                        objUserProfile.Phone = objUserProfileModel.Phone;
                        objUserProfile.Address1 = objUserProfileModel.Address1;
                        objUserProfile.Address2 = objUserProfileModel.Address2;
                        objUserProfile.City = objUserProfileModel.City;

                        objUserProfile.UpdatedOn = DateTime.Now;
                        objUserProfile = db.UserProfileRepository.Update(objUserProfile);
                    }
                    if (objUserProfile != null)
                    {
                        objUserProfileModel = new UserProfileModel();
                        objUserProfileModel.UserId = objUserProfile.UserId;
                        objUserProfileModel.FName = objUserProfile.FName;
                        objUserProfileModel.LName = objUserProfile.LName;
                        objUserProfileModel.Email = objUserProfile.Email;
                        objUserProfileModel.Password = objUserProfile.Password;
                        objUserProfileModel.Type = objUserProfile.Type;
                        objUserProfileModel.Phone = objUserProfile.Phone;
                        objUserProfileModel.Address1 = objUserProfile.Address1;
                        objUserProfileModel.Address2 = objUserProfile.Address2;
                        objUserProfileModel.City = objUserProfile.City;
                        objUserProfileModel.IsActive = Convert.ToBoolean(objUserProfile.IsActive);
                        objUserProfileModel.IsDeleted = objUserProfileModel.IsDeleted;
                        objUserProfileModel.CreatedOn = objUserProfileModel.CreatedOn;

                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objUserProfileModel;
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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "AddUserProfile", Id = objUserProfileModel.UserId, ClassName = "UserProfileBusiness", Error = dbEx.Message });
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
                    UserProfileModel objUserProfileModel = new UserProfileModel();
                    UserProfile objUserProfile = db.UserProfileRepository.Get(x => x.UserId == Id).FirstOrDefault();
                    if (objUserProfile != null)
                    {
                        objUserProfileModel.UserId = objUserProfile.UserId;
                        objUserProfileModel.FName = objUserProfile.FName;
                        objUserProfileModel.LName = objUserProfile.LName;
                        objUserProfileModel.Email = objUserProfile.Email;
                        objUserProfileModel.Password = objUserProfile.Password;
                        objUserProfileModel.Type = objUserProfile.Type;
                        objUserProfileModel.Phone = objUserProfile.Phone;
                        objUserProfileModel.Address1 = objUserProfile.Address1;
                        objUserProfileModel.Address2 = objUserProfile.Address2;
                        objUserProfileModel.City = objUserProfile.City;
                        objUserProfileModel.IsActive = Convert.ToBoolean(objUserProfile.IsActive);
                        objUserProfileModel.IsDeleted = objUserProfileModel.IsDeleted;
                        objUserProfileModel.CreatedOn = objUserProfileModel.CreatedOn;
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objUserProfileModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "GetByID", Id = Id, ClassName = "UserProfileBusiness", Error = dbEx.Message });
                    return objTResponse;
                }
            }
        }

        public TResponse GetByTypeID(string type,long Id)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    UserProfileModel objUserProfileModel = new UserProfileModel();
                    UserProfile objUserProfile = db.UserProfileRepository.Get(x => x.UserId == Id && x.Type == type).FirstOrDefault();
                    if (objUserProfile != null)
                    {
                        objUserProfileModel.UserId = objUserProfile.UserId;
                        objUserProfileModel.FName = objUserProfile.FName;
                        objUserProfileModel.LName = objUserProfile.LName;
                        objUserProfileModel.Email = objUserProfile.Email;
                        objUserProfileModel.Password = objUserProfile.Password;
                        objUserProfileModel.Type = objUserProfile.Type;
                        objUserProfileModel.Phone = objUserProfile.Phone;
                        objUserProfileModel.Address1 = objUserProfile.Address1;
                        objUserProfileModel.Address2 = objUserProfile.Address2;
                        objUserProfileModel.City = objUserProfile.City;
                        objUserProfileModel.IsActive = Convert.ToBoolean(objUserProfile.IsActive);
                        objUserProfileModel.IsDeleted = objUserProfileModel.IsDeleted;
                        objUserProfileModel.CreatedOn = objUserProfileModel.CreatedOn;
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objUserProfileModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "GetByID", Id = Id, ClassName = "UserProfileBusiness", Error = dbEx.Message });
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
                    List<UserProfileModel> lstUserProfileModel = new List<UserProfileModel>();
                    UserProfileModel objUserProfileModel;
                    List<UserProfile> lstUserProfile = db.UserProfileRepository.GetAll().ToList();
                    if (lstUserProfile != null && lstUserProfile.Count > 0)
                    {
                        foreach (UserProfile obj in lstUserProfile)
                        {
                            objUserProfileModel = new UserProfileModel();
                            objUserProfileModel.UserId = obj.UserId;
                            objUserProfileModel.FName = obj.FName;
                            objUserProfileModel.LName = obj.LName;
                            objUserProfileModel.Email = obj.Email;
                            objUserProfileModel.Phone = obj.Phone;
                            objUserProfileModel.Address1 = obj.Address1;
                            objUserProfileModel.Address2 = obj.Address2;
                            objUserProfileModel.City = obj.City;
                            objUserProfileModel.IsActive = Convert.ToBoolean(obj.IsActive);
                            objUserProfileModel.IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                            objUserProfileModel.CreatedOn = Convert.ToDateTime(obj.CreatedOn);
                            lstUserProfileModel.Add(objUserProfileModel);
                        }
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = lstUserProfileModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "ListUserProfile", Id = 0, ClassName = "UserProfileBusiness", Error = dbEx.Message });
                    return objTResponse;
                }
            }
        }
       
        public TResponse GetAllByType(string type)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    List<UserProfileModel> lstUserProfileModel = new List<UserProfileModel>();
                    UserProfileModel objUserProfileModel;
                    List<UserProfile> lstUserProfile = db.UserProfileRepository.Get(x => x.Type == type).ToList();
                    if (lstUserProfile != null && lstUserProfile.Count > 0)
                    {
                        foreach (UserProfile obj in lstUserProfile)
                        {
                            objUserProfileModel = new UserProfileModel();
                            objUserProfileModel.UserId = obj.UserId;
                            objUserProfileModel.FName = obj.FName;
                            objUserProfileModel.LName = obj.LName;
                            objUserProfileModel.Email = obj.Email;
                            objUserProfileModel.Type = obj.Type;
                            objUserProfileModel.Phone = obj.Phone;
                            objUserProfileModel.Address1 = obj.Address1;
                            objUserProfileModel.Address2 = obj.Address2;
                            objUserProfileModel.City = obj.City;
                            objUserProfileModel.IsActive = Convert.ToBoolean(obj.IsActive);
                            objUserProfileModel.IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                            objUserProfileModel.CreatedOn = Convert.ToDateTime(obj.CreatedOn);
                            lstUserProfileModel.Add(objUserProfileModel);
                        }
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = lstUserProfileModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "ListUserProfile", Id = 0, ClassName = "UserProfileBusiness", Error = dbEx.Message });
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
                    UserProfile objUserProfile = db.UserProfileRepository.GetById(ID);
                    if (objUserProfile != null && objUserProfile.UserId > 0)
                    {
                        objUserProfile.IsDeleted = true;
                        db.UserProfileRepository.Update(objUserProfile);
                    }


                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteUserProfile", Id = 0, ClassName = "UserProfileBusiness", Error = ex.Message });
                    return objTResponse;

                }

                return objTResponse;
            }
        }

        public TResponse DeleteByTypeId( string type,int ID)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    UserProfile objUserProfile = db.UserProfileRepository.Get( x=>x.Type== type && x.UserId== ID).FirstOrDefault();
                    if (objUserProfile != null && objUserProfile.UserId > 0)
                    {
                        objUserProfile.IsDeleted = true;
                        db.UserProfileRepository.Update(objUserProfile);
                    }


                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteUserProfile", Id = 0, ClassName = "UserProfileBusiness", Error = ex.Message });
                    return objTResponse;

                }

                return objTResponse;
            }
        }

        public TResponse UpdateStatus(long ID, bool Status)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    UserProfile objUserProfile = db.UserProfileRepository.GetById(ID); 
                    if (objUserProfile != null && objUserProfile.UserId > 0)
                    {
                        objUserProfile.IsActive = Status;
                        db.UserProfileRepository.Update(objUserProfile);
                    }
                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteUserProfile", Id = 0, ClassName = "UserProfileBusiness", Error = ex.Message });
                    return objTResponse;
                }

                return objTResponse;
            }
        }

        public TResponse UpdateStatusByTypeId(string type, int ID, bool Status)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    UserProfile objUserProfile = db.UserProfileRepository.Get(x => x.Type == type && x.UserId == ID).FirstOrDefault();
                    if (objUserProfile != null && objUserProfile.UserId > 0)
                    {
                        objUserProfile.IsActive = Status;
                        db.UserProfileRepository.Update(objUserProfile);
                    }
                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteUserProfile", Id = 0, ClassName = "UserProfileBusiness", Error = ex.Message });
                    return objTResponse;
                }

                return objTResponse;
            }
        }

        #endregion

        #region [-Desktop-]

        public TResponse UserProfileLogin(LoginModel objLoginModel)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    UserProfileModel objUserProfileModel = new UserProfileModel();
                    UserProfile objUserProfile = db.UserProfileRepository.Get(x => x.Email == objLoginModel.Email && x.Password == objLoginModel.Password && x.IsDeleted == false).FirstOrDefault();
                    if (objUserProfile != null)
                    {
                        objUserProfileModel.UserId = objUserProfile.UserId;
                        objUserProfileModel.Type = objUserProfile.Type;
                        objUserProfileModel.FName = objUserProfile.FName;
                        objUserProfileModel.LName = objUserProfile.LName;
                        objUserProfileModel.Email = objUserProfile.Email;
                        objUserProfileModel.Phone = objUserProfile.Phone;
                        objUserProfileModel.Address1 = objUserProfile.Address1;
                        objUserProfileModel.Address2 = objUserProfile.Address2;
                        objUserProfileModel.City = objUserProfile.City;
                        objUserProfileModel.IsActive = Convert.ToBoolean(objUserProfile.IsActive);
                        objUserProfileModel.IsDeleted = objUserProfileModel.IsDeleted;
                        objUserProfileModel.CreatedOn = objUserProfileModel.CreatedOn;
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objUserProfileModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "UserProfileLogin", Id = 0, ClassName = "UserProfileBusiness", Error = dbEx.Message });
                    return objTResponse;
                }
            }
        }

        public TResponse GetAllUserByType(string type)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    UserProfileModel objUserProfileModel;
                    List<UserProfileModel> lstUserProfileModel = new List<UserProfileModel>();
                    List<UserProfile> lstUserProfile = db.UserProfileRepository.Get(x => x.Type == type).ToList();
                    if (lstUserProfile != null)
                    {
                        foreach (UserProfile objUserProfile in lstUserProfile)
                        {
                            objUserProfileModel = new UserProfileModel();
                            objUserProfileModel.UserId = objUserProfile.UserId;
                            objUserProfileModel.FName = objUserProfile.FName;
                            objUserProfileModel.LName = objUserProfile.LName;
                            objUserProfileModel.Email = objUserProfile.Email;
                            objUserProfileModel.Phone = objUserProfile.Phone;
                            objUserProfileModel.Address1 = objUserProfile.Address1;
                            objUserProfileModel.Address2 = objUserProfile.Address2;
                            objUserProfileModel.City = objUserProfile.City;
                            objUserProfileModel.IsActive = Convert.ToBoolean(objUserProfile.IsActive);
                            objUserProfileModel.IsDeleted = objUserProfileModel.IsDeleted;
                            objUserProfileModel.CreatedOn = objUserProfileModel.CreatedOn;

                            lstUserProfileModel.Add(objUserProfileModel);

                        }
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = lstUserProfileModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "GetByType", Id = 0, ClassName = "UserProfileBusiness", Error = dbEx.Message });
                    return objTResponse;
                }
            }
        }

        #endregion
    }
}

