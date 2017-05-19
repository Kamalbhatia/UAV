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
    public class DroneEquipmentBusiness
    {

        ErrorLogBusiness objErrorLogBusiness = new ErrorLogBusiness();
        ErrorLogModel objErrorLogModel = new ErrorLogModel();
        TResponse objTResponse = new TResponse();


        public TResponse AddUpdate(DroneEquipmentModel objDroneEquipmentModel)
        {
            using (var db = new UnitOfWork())
            {
                try
                {
                    DroneEquipment objDroneEquipment = db.DroneEquipmentRepository.Get(x => x.ID == objDroneEquipmentModel.ID).FirstOrDefault();

                    if (objDroneEquipment == null)
                    {
                        objDroneEquipment = new DroneEquipment();

                        objDroneEquipment.ID = objDroneEquipmentModel.ID;
                        objDroneEquipment.Model = objDroneEquipmentModel.Model;
                        objDroneEquipment.SerialNumber = objDroneEquipmentModel.SerialNumber;
                        objDroneEquipment.IsActive = true;
                        objDroneEquipment.IsDeleted = false;
                        objDroneEquipment.CreatedOn = DateTime.Now;
                        objDroneEquipment = db.DroneEquipmentRepository.Insert(objDroneEquipment);
                    }
                    else
                    {
                        objDroneEquipment.ID = objDroneEquipmentModel.ID;
                        objDroneEquipment.Model = objDroneEquipmentModel.Model;
                        objDroneEquipment.SerialNumber = objDroneEquipmentModel.SerialNumber;
                        // objDroneEquipment.IsActive = true;
                        //objDroneEquipment.IsDeleted = false;
                        objDroneEquipment.UpdatedOn = DateTime.Now;
                        objDroneEquipment = db.DroneEquipmentRepository.Update(objDroneEquipment);
                    }
                    if (objDroneEquipment != null)
                    {
                        objDroneEquipmentModel = new DroneEquipmentModel();
                        objDroneEquipmentModel.ID = objDroneEquipment.ID;
                        objDroneEquipmentModel.Model = objDroneEquipment.Model;
                        objDroneEquipmentModel.SerialNumber = objDroneEquipment.SerialNumber;
                        objDroneEquipmentModel.IsActive = Convert.ToBoolean(objDroneEquipment.IsActive);
                        objDroneEquipmentModel.IsDeleted = objDroneEquipmentModel.IsDeleted;
                        objDroneEquipmentModel.CreatedOn = objDroneEquipmentModel.CreatedOn;

                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objDroneEquipmentModel;
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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "AddDroneEquipment", Id = objDroneEquipmentModel.ID, ClassName = "DroneEquipmentBusiness", Error = dbEx.Message });
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
                    DroneEquipmentModel objDroneEquipmentModel = new DroneEquipmentModel();
                    DroneEquipment objDroneEquipment = db.DroneEquipmentRepository.Get(x => x.ID == Id).FirstOrDefault();
                    if (objDroneEquipment != null)
                    {
                        objDroneEquipmentModel = new DroneEquipmentModel();
                        objDroneEquipmentModel.ID = objDroneEquipment.ID;
                        objDroneEquipmentModel.Model = objDroneEquipment.Model;
                        objDroneEquipmentModel.SerialNumber = objDroneEquipment.SerialNumber;
                        objDroneEquipmentModel.IsActive = Convert.ToBoolean(objDroneEquipment.IsActive);
                        objDroneEquipmentModel.IsDeleted = Convert.ToBoolean(objDroneEquipment.IsDeleted);
                        objDroneEquipmentModel.CreatedOn = Convert.ToDateTime(objDroneEquipment.CreatedOn);
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = objDroneEquipmentModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "GetByID", Id = Id, ClassName = "DroneEquipmentBusiness", Error = dbEx.Message });
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
                    List<DroneEquipmentModel> lstDroneEquipmentModel = new List<DroneEquipmentModel>();
                    DroneEquipmentModel objDroneEquipmentModel;
                    List<DroneEquipment> lstDroneEquipment = db.DroneEquipmentRepository.GetAll().ToList();
                    if (lstDroneEquipment != null && lstDroneEquipment.Count > 0)
                    {
                        foreach (DroneEquipment obj in lstDroneEquipment)
                        {
                            objDroneEquipmentModel = new DroneEquipmentModel();
                            objDroneEquipmentModel.ID = obj.ID;
                            objDroneEquipmentModel.Model = obj.Model;
                            objDroneEquipmentModel.SerialNumber = obj.SerialNumber;
                            objDroneEquipmentModel.IsActive = Convert.ToBoolean(obj.IsActive);
                            objDroneEquipmentModel.IsDeleted = objDroneEquipmentModel.IsDeleted;

                            lstDroneEquipmentModel.Add(objDroneEquipmentModel);
                        }
                        objTResponse.Status = ResponseStaus.ok;
                        objTResponse.Message = ResponseMessage.success;
                        objTResponse.ResponsePacket = lstDroneEquipmentModel;

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
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "ListDroneEquipment", Id = 0, ClassName = "DroneEquipmentBusiness", Error = dbEx.Message });
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
                    DroneEquipment objDroneEquipment = db.DroneEquipmentRepository.GetById(ID);
                    if (objDroneEquipment != null && objDroneEquipment.ID > 0)
                    {
                        objDroneEquipment.IsDeleted = true;
                        db.DroneEquipmentRepository.Update(objDroneEquipment);
                    }


                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteDroneEquipment", Id = 0, ClassName = "DroneEquipmentBusiness", Error = ex.Message });
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
                    DroneEquipment objDroneEquipment = db.DroneEquipmentRepository.GetById(ID);
                    if (objDroneEquipment != null && objDroneEquipment.ID > 0)
                    {
                        objDroneEquipment.IsActive = Status;
                        db.DroneEquipmentRepository.Update(objDroneEquipment);
                    }
                    objTResponse.Status = ResponseStaus.ok;
                    objTResponse.Message = ResponseMessage.success;
                }
                catch (Exception ex)
                {
                    ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                    objerrorlog.AddErrorLog(new ErrorLogModel { MethodName = "DeleteDroneEquipment", Id = 0, ClassName = "DroneEquipmentBusiness", Error = ex.Message });
                    return objTResponse;
                }

                return objTResponse;
            }
        }
    }
}

