// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Models.SaudNumber
namespace AQUAWEBAPI
{
    public class SaudNumber
    {
        private string Unloading = string.Empty;

        private string purchaseDate = string.Empty;

        private string purchaseType = string.Empty;

        private string supplierName = string.Empty;

        private string farmerName = string.Empty;

        private string pondNumber = string.Empty;

        private string sealNo = string.Empty;

        private string driverName = string.Empty;

        private string vehicleNumber = string.Empty;

        private string purchaseCount = string.Empty;

        private string pondWeight = string.Empty;

        private string processStatus = string.Empty;

        private string lotNumber = string.Empty;

        public string Saudanumber
        {
            get
            {
                return Unloading;
            }
            set
            {
                Unloading = value;
            }
        }

        public string PurchaseDate
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

        public string PurchaseType
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

        public string SupplierName
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

        public string FarmerName
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

        public string PondNumber
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

        public string SealNo
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

        public string DriverName
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

        public string VehicleNumber
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

        public string LotNumber
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

        public string PurchaseCount
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

        public string PondWeight
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

        public string ProcessStatus
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
    }
}