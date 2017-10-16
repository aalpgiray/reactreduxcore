using System;

namespace SecretService.Data
{
    public class Stop : Base
    {
        public Route Route { get; set; }
        public StopType StopType { get; set; }
        public Geometry Geometry { get; set; }
    }
}
