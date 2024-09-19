// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.Unload
using System.Collections.Generic;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    public class Unload
    {
        private List<SaudNumber> SaudaNumberCode;

        private List<SaudNumber> purchaseDate;

        private List<SaudNumber> purchaseType;

        private List<SaudNumber> supplierName;

        private List<SaudNumber> farmerName;

        private List<SaudNumber> pondNumber;

        private List<SaudNumber> sealNo;

        private List<SaudNumber> driverName;

        private List<SaudNumber> vehicleNumber;

        private List<SaudNumber> purchaseCount;

        private List<SaudNumber> pondWeight;

        private List<SaudNumber> processStatus;

        private List<SaudNumber> lotNumber;

        public List<SaudNumber> Unloading
        {
            get
            {
                return SaudaNumberCode;
            }
            set
            {
                SaudaNumberCode = value;
            }
        }

        public List<SaudNumber> PurchaseDate
        {
            get
            {
                return purchaseDate;
            }
            set
            {
                purchaseDate = value;
            }
        }

        public List<SaudNumber> PurchaseType
        {
            get
            {
                return purchaseType;
            }
            set
            {
                purchaseType = value;
            }
        }

        public List<SaudNumber> SupplierName
        {
            get
            {
                return supplierName;
            }
            set
            {
                supplierName = value;
            }
        }

        public List<SaudNumber> FarmerName
        {
            get
            {
                return farmerName;
            }
            set
            {
                farmerName = value;
            }
        }

        public List<SaudNumber> PondNumber
        {
            get
            {
                return pondNumber;
            }
            set
            {
                pondNumber = value;
            }
        }

        public List<SaudNumber> SealNo
        {
            get
            {
                return sealNo;
            }
            set
            {
                sealNo = value;
            }
        }

        public List<SaudNumber> DriverName
        {
            get
            {
                return driverName;
            }
            set
            {
                driverName = value;
            }
        }

        public List<SaudNumber> VehicleNumber
        {
            get
            {
                return vehicleNumber;
            }
            set
            {
                vehicleNumber = value;
            }
        }

        public List<SaudNumber> PurchaseCount
        {
            get
            {
                return purchaseCount;
            }
            set
            {
                purchaseCount = value;
            }
        }

        public List<SaudNumber> PondWeight
        {
            get
            {
                return pondWeight;
            }
            set
            {
                pondWeight = value;
            }
        }

        public List<SaudNumber> ProcessStatus
        {
            get
            {
                return processStatus;
            }
            set
            {
                processStatus = value;
            }
        }

        public List<SaudNumber> LotNumber
        {
            get
            {
                return lotNumber;
            }
            set
            {
                lotNumber = value;
            }
        }
    }
}