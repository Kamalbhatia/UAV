using UAVData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAVBusiness.Generic
{
    public abstract class BusinessBase : ClsDispose
    {
        public UAVEntities DB;

        public BusinessBase()
        {
            try
            {
                DB = new UAVEntities();

            }
            catch (TimeoutException toe)
            {
                throw toe;
                // using (ErrorLog objError = new ErrorLog())
                //   objError.InsertErrorLog("BusinessBase", "TimeoutException in creating connection", toe.Message);
            }
            catch (SqlException sqle)
            {
                throw sqle;
                //using (ErrorLog objError = new ErrorLog())
                //  objError.InsertErrorLog("BusinessBase", "SqlException in creating connection", sqle.Message);
            }
            catch (Exception ex)
            {
                throw ex;
                //using (ErrorLog objError = new ErrorLog())
                //  objError.InsertErrorLog("BusinessBase", "SqlException in creating connection", sqle.Message);
            }
        }


    }
}
