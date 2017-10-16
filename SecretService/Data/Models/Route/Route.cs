using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretService.Data
{
    public class Route : Base
    {
        public DateTime RequestDate { get; set; }
        public DateTime ValidUntil { get; set; }
        public User Requester { get; set; }
        public List<Stop> Stops { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
