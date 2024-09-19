using System;

namespace AQUAWEBAPI.Models
{
    public class QueriesLog
    {
        public int Id { get; set; }
        public string Queries { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}