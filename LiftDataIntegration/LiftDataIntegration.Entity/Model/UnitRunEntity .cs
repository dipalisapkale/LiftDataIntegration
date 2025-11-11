using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model
{
    class UnitRun
    {

        public int RunId { get; set; }
        public int UnitId { get; set; }
        public string EquipmentNo { get; set; }
        public int RunNo { get; set; }

        public DateTime RunDate { get; set; }

        public DateTime RunStartTime { get; set; }
        public DateTime RunEndTime { get; set; }
        public decimal SpeedOfRun { get; set; }

        public int StartFloorNo { get; set; }

        public int EndFloorNo { get; set; }
        public int NoOfFloor { get; set; }
        public int CallingFloor { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
