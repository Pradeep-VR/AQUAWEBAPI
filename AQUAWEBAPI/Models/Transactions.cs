using System;

namespace AQUAWEBAPI.Models
{
    public class Transactions
    {
        public string TransId { get; set; }
        public string Modules { get; set; }
        public int SendingCount { get; set; }
        public int RecevingCount { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
        public string SendingBy { get; set; }
        public DateTime SendingTime { get; set; }
        public DateTime RecevingTime { get; set; }
    }
}