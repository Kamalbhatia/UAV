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
    public class SurveyDetailBusiness
    {

        ErrorLogBusiness objErrorLogBusiness = new ErrorLogBusiness();
        ErrorLogModel objErrorLogModel = new ErrorLogModel();
        TResponse objTResponse = new TResponse();

        public TResponse AddUpdate(SurveyModel objSurveyModel)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    Survey objSurvey = db.SurveyRepository.Get(x => x.ID == objSurveyModel.ID).FirstOrDefault();

                    if (objSurvey == null)
                    {
                        objSurvey = new Survey();
                        objSurvey.ID = objSurveyModel.ID;
                        objSurvey.Title = objSurveyModel.Title;
                        objSurvey.SurveyDate = objSurveyModel.SurveyDate;
                        objSurvey.SurveyTime = objSurveyModel.SurveyTime;
                        objSurvey.CustomerID = objSurveyModel.CustomerID;
                        objSurvey.CustomerLocationID = objSurveyModel.CustomerLocationID;
                        objSurvey.PilotID = objSurveyModel.PilotID;
                        objSurvey.DroneID = objSurveyModel.DroneID;
                        objSurvey.SurveyStatusID = objSurveyModel.SurveyStatusID;
                        objSurvey.EC_ATC = objSurveyModel.EC_ATC;
                        objSurvey.EC_LocalPolice = objSurveyModel.EC_LocalPolice;
                        objSurvey.EC_FireBrigde = objSurveyModel.EC_FireBrigde;
                        objSurvey.EC_AE = objSurveyModel.EC_AE;
                        objSurvey.WC_Wind = objSurveyModel.WC_Wind;
                        objSurvey.WC_Precipitation = objSurveyModel.WC_Precipitation;
                        objSurvey.WC_Visibility = objSurveyModel.WC_Visibility;
                        objSurvey.WC_CloudCover = objSurveyModel.WC_CloudCover;
                        objSurvey.WC_KP = objSurveyModel.WC_KP;
                        objSurvey.W_SunRise = objSurveyModel.W_SunRise;
                        objSurvey.W_SunSet = objSurveyModel.W_SunSet;
                        objSurvey.W_CTAFS = objSurveyModel.W_CTAFS;
                        objSurvey.W_WindSpeed = objSurveyModel.W_WindSpeed;
                        objSurvey.W_Prepreciption = objSurveyModel.W_Prepreciption;
                        objSurvey.W_Temperature = objSurveyModel.W_Temperature;
                        objSurvey.W_Notams = objSurveyModel.W_Notams;
                        objSurvey.SH_NotedStructure = objSurveyModel.SH_NotedStructure;
                        objSurvey.SH_PedestrainRisk = objSurveyModel.SH_PedestrainRisk;
                        objSurvey.SH_VehileRisk = objSurveyModel.SH_VehileRisk;
                        objSurvey.SH_ATR = objSurveyModel.SH_ATR;
                        objSurvey.SH_ExplosiveRisk = objSurveyModel.SH_ExplosiveRisk;
                        objSurvey.MS_Name = objSurveyModel.MS_Name;
                        objSurvey.MS_Telephone = objSurveyModel.MS_Telephone;
                        objSurvey.MS_Email = objSurveyModel.MS_Email;
                        objSurvey.FT_StartTime = objSurveyModel.FT_StartTime;
                        objSurvey.FT_EndTime = objSurveyModel.FT_EndTime;
                        objSurvey.TimeHack = objSurveyModel.TimeHack;
                        objSurvey.NearAreaPopulation = objSurveyModel.NearAreaPopulation;
                        objSurvey.SiteAddress = objSurveyModel.SiteAddress;
                        objSurvey.OperatingArea = objSurveyModel.OperatingArea;
                        objSurvey.Question = objSurveyModel.Question;
                        objSurvey.WorkDescription = objSurveyModel.WorkDescription;
                        objSurvey.Comments = objSurveyModel.Comments;
                        objSurvey.IsActive = true;
                        objSurvey.IsDeleted = false;
                        objSurvey.CreatedOn = DateTime.Now;

                        objSurvey = objSurvey = db.SurveyRepository.Insert(objSurvey);
                    }
                    else
                    {
                        objSurvey = new Survey();
                        objSurvey.ID = objSurveyModel.ID;
                        objSurvey.Title = objSurveyModel.Title;
                        objSurvey.SurveyDate = objSurveyModel.SurveyDate;
                        objSurvey.SurveyTime = objSurveyModel.SurveyTime;
                        objSurvey.CustomerID = objSurveyModel.CustomerID;
                        objSurvey.CustomerLocationID = objSurveyModel.CustomerLocationID;
                        objSurvey.PilotID = objSurveyModel.PilotID;
                        objSurvey.DroneID = objSurveyModel.DroneID;
                        objSurvey.SurveyStatusID = objSurveyModel.SurveyStatusID;
                        objSurvey.EC_ATC = objSurveyModel.EC_ATC;
                        objSurvey.EC_LocalPolice = objSurveyModel.EC_LocalPolice;
                        objSurvey.EC_FireBrigde = objSurveyModel.EC_FireBrigde;
                        objSurvey.EC_AE = objSurveyModel.EC_AE;
                        objSurvey.WC_Wind = objSurveyModel.WC_Wind;
                        objSurvey.WC_Precipitation = objSurveyModel.WC_Precipitation;
                        objSurvey.WC_Visibility = objSurveyModel.WC_Visibility;
                        objSurvey.WC_CloudCover = objSurveyModel.WC_CloudCover;
                        objSurvey.WC_KP = objSurveyModel.WC_KP;
                        objSurvey.W_SunRise = objSurveyModel.W_SunRise;
                        objSurvey.W_SunSet = objSurveyModel.W_SunSet;
                        objSurvey.W_CTAFS = objSurveyModel.W_CTAFS;
                        objSurvey.W_WindSpeed = objSurveyModel.W_WindSpeed;
                        objSurvey.W_Prepreciption = objSurveyModel.W_Prepreciption;
                        objSurvey.W_Temperature = objSurveyModel.W_Temperature;
                        objSurvey.W_Notams = objSurveyModel.W_Notams;
                        objSurvey.SH_NotedStructure = objSurveyModel.SH_NotedStructure;
                        objSurvey.SH_PedestrainRisk = objSurveyModel.SH_PedestrainRisk;
                        objSurvey.SH_VehileRisk = objSurveyModel.SH_VehileRisk;
                        objSurvey.SH_ATR = objSurveyModel.SH_ATR;
                        objSurvey.SH_ExplosiveRisk = objSurveyModel.SH_ExplosiveRisk;
                        objSurvey.MS_Name = objSurveyModel.MS_Name;
                        objSurvey.MS_Telephone = objSurveyModel.MS_Telephone;
                        objSurvey.MS_Email = objSurveyModel.MS_Email;
                        objSurvey.FT_StartTime = objSurveyModel.FT_StartTime;
                        objSurvey.FT_EndTime = objSurveyModel.FT_EndTime;
                        objSurvey.TimeHack = objSurveyModel.TimeHack;
                        objSurvey.NearAreaPopulation = objSurveyModel.NearAreaPopulation;
                        objSurvey.SiteAddress = objSurveyModel.SiteAddress;
                        objSurvey.OperatingArea = objSurveyModel.OperatingArea;
                        objSurvey.Question = objSurveyModel.Question;
                        objSurvey.WorkDescription = objSurveyModel.WorkDescription;
                        objSurvey.Comments = objSurveyModel.Comments;
                        objSurvey.IsActive = objSurveyModel.IsActive;
                        objSurvey.IsDeleted = objSurveyModel.IsDeleted;
                        objSurvey.CreatedOn = objSurveyModel.CreatedOn;
                        objSurvey.UpdatedOn = DateTime.Now;
                        objSurvey = objSurvey = db.SurveyRepository.Update(objSurvey);
                    }
                    if (objSurvey != null)
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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "AddSurveyDetail", Id = objSurveyModel.ID, ClassName = "SurveyDetailBusiness", Error = dbEx.Message });
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
                    SurveyModel objSurveyModel = new SurveyModel();
                    Survey objSurvey = db.SurveyRepository.Get(x => x.ID == Id).FirstOrDefault();
                    if (objSurvey != null)
                    {
                        objSurveyModel.ID = objSurvey.ID;
                        objSurveyModel.Title = objSurvey.Title;
                        objSurveyModel.SurveyDate = Convert.ToDateTime(objSurvey.SurveyDate);
                        //objSurveyModel.SurveyTime = Convert.ToDateTime(objSurvey.SurveyTime).Ticks;
                        objSurveyModel.CustomerID = Convert.ToInt64(objSurvey.CustomerID);
                        objSurveyModel.CustomerLocationID = Convert.ToInt64(objSurvey.CustomerLocationID);
                        objSurveyModel.PilotID = Convert.ToInt32(objSurvey.PilotID);
                        objSurveyModel.DroneID = Convert.ToInt32(objSurvey.DroneID);
                        objSurveyModel.SurveyStatusID = Convert.ToInt32(objSurvey.SurveyStatusID);
                        objSurveyModel.EC_ATC = objSurvey.EC_ATC;
                        objSurveyModel.EC_LocalPolice = objSurvey.EC_LocalPolice;
                        objSurveyModel.EC_FireBrigde = objSurvey.EC_FireBrigde;
                        objSurveyModel.EC_AE = objSurvey.EC_AE;
                        objSurveyModel.WC_Wind = objSurvey.WC_Wind;
                        objSurveyModel.WC_Precipitation = objSurvey.WC_Precipitation;
                        objSurveyModel.WC_Visibility = objSurvey.WC_Visibility;
                        objSurveyModel.WC_CloudCover = objSurvey.WC_CloudCover;
                        objSurveyModel.WC_KP = objSurvey.WC_KP;
                        objSurveyModel.W_SunRise = objSurvey.W_SunRise;
                        objSurveyModel.W_SunSet = objSurvey.W_SunSet;
                        objSurveyModel.W_CTAFS = objSurvey.W_CTAFS;
                        objSurveyModel.W_WindSpeed = objSurvey.W_WindSpeed;
                        objSurveyModel.W_Prepreciption = objSurvey.W_Prepreciption;
                        objSurveyModel.W_Temperature = objSurvey.W_Temperature;
                        objSurveyModel.W_Notams = objSurvey.W_Notams;
                        objSurveyModel.SH_NotedStructure = objSurvey.SH_NotedStructure;
                        objSurveyModel.SH_PedestrainRisk = objSurvey.SH_PedestrainRisk;
                        objSurveyModel.SH_VehileRisk = objSurvey.SH_VehileRisk;
                        objSurveyModel.SH_ATR = objSurvey.SH_ATR;
                        objSurveyModel.SH_ExplosiveRisk = objSurvey.SH_ExplosiveRisk;
                        objSurveyModel.MS_Name = objSurvey.MS_Name;
                        objSurveyModel.MS_Telephone = objSurvey.MS_Telephone;
                        objSurveyModel.MS_Email = objSurvey.MS_Email;
                        objSurveyModel.FT_StartTime = Convert.ToDateTime(objSurvey.FT_StartTime);
                        objSurveyModel.FT_EndTime = Convert.ToDateTime(objSurvey.FT_EndTime);
                        objSurveyModel.TimeHack = Convert.ToDateTime(objSurvey.TimeHack);
                        objSurveyModel.NearAreaPopulation = objSurvey.NearAreaPopulation;
                        objSurveyModel.SiteAddress = objSurvey.SiteAddress;
                        objSurveyModel.OperatingArea = objSurvey.OperatingArea;
                        objSurveyModel.Question = objSurvey.Question;
                        objSurveyModel.WorkDescription = objSurvey.WorkDescription;
                        objSurveyModel.Comments = objSurvey.Comments;
                        objSurveyModel.IsActive = Convert.ToBoolean(objSurvey.IsActive);
                        objSurveyModel.IsDeleted = Convert.ToBoolean(objSurvey.IsDeleted);
                        objSurveyModel.CreatedOn = Convert.ToDateTime(objSurvey.CreatedOn);
                        objSurveyModel.UpdatedOn = Convert.ToDateTime(objSurvey.UpdatedOn);

                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objSurveyModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "GetByID", Id = Id, ClassName = "SurveyDetailBusiness", Error = dbEx.Message });
                    return objTResponse;
                }
            }
        }

        public TResponse GetSurveyList(long PilotId)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    List<SurveyModel> lstSurveyModel = new List<SurveyModel>();
                    SurveyModel objSurveyModel;
                    List<Survey> lstSurvey = db.SurveyRepository.Get(x => x.PilotID == PilotId).ToList();
                    if (lstSurvey != null && lstSurvey.Count > 0)
                    {
                        foreach (Survey objSurvey in lstSurvey)
                        {
                            objSurveyModel = new SurveyModel();
                            objSurveyModel.ID = objSurvey.ID;
                            objSurveyModel.Title = objSurvey.Title;
                            objSurveyModel.SurveyDate = Convert.ToDateTime(objSurvey.SurveyDate);
                            //objSurveyModel.SurveyTime = Convert.ToDateTime(objSurvey.SurveyTime).Ticks;
                            objSurveyModel.CustomerID = Convert.ToInt64(objSurvey.CustomerID);
                            objSurveyModel.CustomerName = objSurvey.UserProfile.FName + " " + objSurvey.UserProfile.LName;
                            
                            objSurveyModel.CustomerLocationID = Convert.ToInt64(objSurvey.CustomerLocationID);
                            objSurveyModel.PilotID = Convert.ToInt32(objSurvey.PilotID);
                            objSurveyModel.DroneID = Convert.ToInt32(objSurvey.DroneID);
                            objSurveyModel.SurveyStatusID = Convert.ToInt32(objSurvey.SurveyStatusID);
                            objSurveyModel.EC_ATC = objSurvey.EC_ATC;
                            objSurveyModel.EC_LocalPolice = objSurvey.EC_LocalPolice;
                            objSurveyModel.EC_FireBrigde = objSurvey.EC_FireBrigde;
                            objSurveyModel.EC_AE = objSurvey.EC_AE;
                            objSurveyModel.WC_Wind = objSurvey.WC_Wind;
                            objSurveyModel.WC_Precipitation = objSurvey.WC_Precipitation;
                            objSurveyModel.WC_Visibility = objSurvey.WC_Visibility;
                            objSurveyModel.WC_CloudCover = objSurvey.WC_CloudCover;
                            objSurveyModel.WC_KP = objSurvey.WC_KP;
                            objSurveyModel.W_SunRise = objSurvey.W_SunRise;
                            objSurveyModel.W_SunSet = objSurvey.W_SunSet;
                            objSurveyModel.W_CTAFS = objSurvey.W_CTAFS;
                            objSurveyModel.W_WindSpeed = objSurvey.W_WindSpeed;
                            objSurveyModel.W_Prepreciption = objSurvey.W_Prepreciption;
                            objSurveyModel.W_Temperature = objSurvey.W_Temperature;
                            objSurveyModel.W_Notams = objSurvey.W_Notams;
                            objSurveyModel.SH_NotedStructure = objSurvey.SH_NotedStructure;
                            objSurveyModel.SH_PedestrainRisk = objSurvey.SH_PedestrainRisk;
                            objSurveyModel.SH_VehileRisk = objSurvey.SH_VehileRisk;
                            objSurveyModel.SH_ATR = objSurvey.SH_ATR;
                            objSurveyModel.SH_ExplosiveRisk = objSurvey.SH_ExplosiveRisk;
                            objSurveyModel.MS_Name = objSurvey.MS_Name;
                            objSurveyModel.MS_Telephone = objSurvey.MS_Telephone;
                            objSurveyModel.MS_Email = objSurvey.MS_Email;
                            objSurveyModel.FT_StartTime = Convert.ToDateTime(objSurvey.FT_StartTime);
                            objSurveyModel.FT_EndTime = Convert.ToDateTime(objSurvey.FT_EndTime);
                            objSurveyModel.TimeHack = Convert.ToDateTime(objSurvey.TimeHack);
                            objSurveyModel.NearAreaPopulation = objSurvey.NearAreaPopulation;
                            objSurveyModel.SiteAddress = objSurvey.SiteAddress;
                            objSurveyModel.OperatingArea = objSurvey.OperatingArea;
                            objSurveyModel.Question = objSurvey.Question;
                            objSurveyModel.WorkDescription = objSurvey.WorkDescription;
                            objSurveyModel.Comments = objSurvey.Comments;
                            objSurveyModel.IsActive = Convert.ToBoolean(objSurvey.IsActive);
                            objSurveyModel.IsDeleted = Convert.ToBoolean(objSurvey.IsDeleted);
                            objSurveyModel.CreatedOn = Convert.ToDateTime(objSurvey.CreatedOn);
                            objSurveyModel.UpdatedOn = Convert.ToDateTime(objSurvey.UpdatedOn);
                            lstSurveyModel.Add(objSurveyModel);
                        }
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = lstSurveyModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "ListSurveyDetail", Id = 0, ClassName = "SurveyDetailBusiness", Error = dbEx.Message });
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
                    Survey objSurveyDetail = db.SurveyRepository.GetById(ID);
                    if (objSurveyDetail != null && objSurveyDetail.ID > 0)
                    {
                        objSurveyDetail.IsDeleted = true;
                        db.SurveyRepository.Update(objSurveyDetail);
                    }


                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteSurveyDetail", Id = 0, ClassName = "SurveyDetailBusiness", Error = ex.Message });
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
                    Survey objSurveyDetail = db.SurveyRepository.GetById(ID);
                    if (objSurveyDetail != null && objSurveyDetail.ID > 0)
                    {
                        objSurveyDetail.IsActive = Status;
                        db.SurveyRepository.Update(objSurveyDetail);
                    }
                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteSurveyDetail", Id = 0, ClassName = "SurveyDetailBusiness", Error = ex.Message });
                    return objTResponse;
                }

                return objTResponse;
            }
        }
    }
}

