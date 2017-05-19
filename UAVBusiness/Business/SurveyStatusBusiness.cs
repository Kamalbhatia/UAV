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
    public class SurveyStatusStatusBusiness
    {

        ErrorLogBusiness objErrorLogBusiness = new ErrorLogBusiness();
        ErrorLogModel objErrorLogModel = new ErrorLogModel();
        TResponse objTResponse = new TResponse();

        public TResponse AddUpdate(SurveyStatusModel objSurveyStatusModel)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    SurveyStatu objSurveyStatus = db.SurveyStatusRepository.Get(x => x.ID == objSurveyStatusModel.ID).FirstOrDefault();

                    if (objSurveyStatus == null)
                    {
                        objSurveyStatus = new SurveyStatu();
                      
                        objSurveyStatus.Title = objSurveyStatusModel.Title;
                        objSurveyStatus.IsDeleted = false;
                        objSurveyStatus.CreatedOn = DateTime.Now;

                        objSurveyStatus = objSurveyStatus = db.SurveyStatusRepository.Insert(objSurveyStatus);
                    }
                    else
                    {
                        objSurveyStatus = new SurveyStatu();
                        objSurveyStatus.ID = objSurveyStatusModel.ID;
                        objSurveyStatus.Title = objSurveyStatusModel.Title;
                       
                        objSurveyStatus.IsDeleted = objSurveyStatusModel.IsDeleted;
                        objSurveyStatus.CreatedOn = objSurveyStatusModel.CreatedOn;
                        objSurveyStatus.UpdatedOn = DateTime.Now;
                        objSurveyStatus = objSurveyStatus = db.SurveyStatusRepository.Update(objSurveyStatus);
                    }
                    if (objSurveyStatus != null)
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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "AddSurveyStatusStatus", Id = objSurveyStatusModel.ID, ClassName = "SurveyStatusStatusBusiness", Error = dbEx.Message });
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
                    SurveyStatusModel objSurveyStatusModel = new SurveyStatusModel();
                    SurveyStatu objSurveyStatus = db.SurveyStatusRepository.Get(x => x.ID == Id).FirstOrDefault();
                    if (objSurveyStatus != null)
                    {
                        objSurveyStatusModel.ID = objSurveyStatus.ID;
                        objSurveyStatusModel.Title = objSurveyStatus.Title;
                       
                        objSurveyStatusModel.IsDeleted = Convert.ToBoolean(objSurveyStatus.IsDeleted);
                        objSurveyStatusModel.CreatedOn = Convert.ToDateTime(objSurveyStatus.CreatedOn);
                        objSurveyStatusModel.UpdatedOn = Convert.ToDateTime(objSurveyStatus.UpdatedOn);

                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objSurveyStatusModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "GetByID", Id = Id, ClassName = "SurveyStatusStatusBusiness", Error = dbEx.Message });
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
                    List<SurveyStatusModel> lstSurveyStatusModel = new List<SurveyStatusModel>();
                    SurveyStatusModel objSurveyStatusModel;
                    List<SurveyStatu> lstSurveyStatus = db.SurveyStatusRepository.GetAll().ToList();
                    if (lstSurveyStatus != null && lstSurveyStatus.Count > 0)
                    {
                        foreach (SurveyStatu objSurveyStatus in lstSurveyStatus)
                        {
                            objSurveyStatusModel = new SurveyStatusModel();
                            objSurveyStatusModel.ID = objSurveyStatus.ID;
                            objSurveyStatusModel.Title = objSurveyStatus.Title;
                           
                            objSurveyStatusModel.IsDeleted = Convert.ToBoolean(objSurveyStatus.IsDeleted);
                            objSurveyStatusModel.CreatedOn = Convert.ToDateTime(objSurveyStatus.CreatedOn);
                            objSurveyStatusModel.UpdatedOn = Convert.ToDateTime(objSurveyStatus.UpdatedOn);
                            lstSurveyStatusModel.Add(objSurveyStatusModel);
                        }
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = lstSurveyStatusModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "ListSurveyStatusStatus", Id = 0, ClassName = "SurveyStatusStatusBusiness", Error = dbEx.Message });
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
                    SurveyStatu objSurveyStatusStatus = db.SurveyStatusRepository.GetById(ID);
                    if (objSurveyStatusStatus != null && objSurveyStatusStatus.ID > 0)
                    {
                        objSurveyStatusStatus.IsDeleted = true;
                        db.SurveyStatusRepository.Update(objSurveyStatusStatus);
                    }


                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteSurveyStatusStatus", Id = 0, ClassName = "SurveyStatusStatusBusiness", Error = ex.Message });
                    return objTResponse;

                }

                return objTResponse;
            }
        }

       
    }
}

