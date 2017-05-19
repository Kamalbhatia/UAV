using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAVData;
using UAVBusiness.Generic;
using UAVBusiness.Generic;

namespace UAVBusiness.Generic
{
    public class UnitOfWork : BusinessBase
    {
        private GenericUnit<ErrorLog> _ErrorLog;

        private GenericUnit<UserProfile> _UserProfile;

        private GenericUnit<Survey> _Survey;

        private GenericUnit<DroneEquipment> _DroneEquipment;

        private GenericUnit<CustomerLocation> _CustomerLocation;

        private GenericUnit<SurveyStatu> _SurveyStatus;

        private GenericUnit<AssignedCustomer> _AssignedCustomer;



        public GenericUnit<ErrorLog> ErrorLogRepository
        {
            get
            {
                if (this._ErrorLog == null)
                {
                    this._ErrorLog = new GenericUnit<ErrorLog>(DB);
                }
                return _ErrorLog;
            }
        }

        public GenericUnit<UserProfile> UserProfileRepository
        {
            get
            {
                if (this._UserProfile == null)
                {
                    this._UserProfile = new GenericUnit<UserProfile>(DB);
                }
                return _UserProfile;
            }
        }

        public GenericUnit<Survey> SurveyRepository
        {
            get
            {
                if (this._Survey == null)
                {
                    this._Survey = new GenericUnit<Survey>(DB);
                }
                return _Survey;
            }
        }

        public GenericUnit<DroneEquipment> DroneEquipmentRepository
        {
            get
            {
                if (this._DroneEquipment == null)
                {
                    this._DroneEquipment = new GenericUnit<DroneEquipment>(DB);
                }
                return _DroneEquipment;
            }
        }

        public GenericUnit<CustomerLocation> CustomerLocationRepository
        {
            get
            {
                if (this._CustomerLocation == null)
                {
                    this._CustomerLocation = new GenericUnit<CustomerLocation>(DB);
                }
                return _CustomerLocation;
            }
        }

        public GenericUnit<SurveyStatu> SurveyStatusRepository
        {
            get
            {
                if (this._SurveyStatus == null)
                {
                    this._SurveyStatus = new GenericUnit<SurveyStatu>(DB);
                }
                return _SurveyStatus;
            }
        }

        public GenericUnit<AssignedCustomer> AssignedCustomerRepository
        {
            get
            {
                if (this._AssignedCustomer == null)
                {
                    this._AssignedCustomer = new GenericUnit<AssignedCustomer>(DB);
                }
                return _AssignedCustomer;
            }
        }


        public void Save()
        {
            DB.SaveChanges();
        }
    }
}
