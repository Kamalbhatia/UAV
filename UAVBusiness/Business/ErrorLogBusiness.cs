using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAVBusiness.Common;
using UAVBusiness.Models;
using UAVData;
using UAVBusiness.Generic;




namespace UAVBusiness.Business
{
    public class ErrorLogBusiness
    {
        public TResponse AddErrorLog(ErrorLogModel model)
        {
            TResponse objResponse = new TResponse();
            ErrorLogModel adminModel = new ErrorLogModel();
            try
            {
                using (var db = new UnitOfWork())
                {
                    ErrorLog objErrorLog = new ErrorLog();
                    objErrorLog.ClassName = model.ClassName;
                    objErrorLog.MethodName = model.MethodName;
                    objErrorLog.Error = model.Error;
                    objErrorLog.CreatedOn = DateTime.Now;
                    objErrorLog = db.ErrorLogRepository.Insert(objErrorLog);

                    objResponse.Message = ResponseMessage.success;
                    objResponse.Status = ResponseStaus.ok;
                    objResponse.ResponsePacket = "";

                }

            }
            catch (Exception ex)
            {
                throw ex;
                //objResponse.Message = ResponseMessage.error;
                //objResponse.Status = ResponseStatus.error;
                //objResponse.ResponsePacket = model;
            }

            return objResponse;
        }
    }
}

