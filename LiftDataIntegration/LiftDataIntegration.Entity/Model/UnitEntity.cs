using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model
{
    class UnitEntity
    {

        public int UnitId { get; set; }
        public int BuildingId { get; set; }
        public string EquipmentNo { get; set; }
        public string UnitDisplayName { get; set; }

        public string UnitType { get; set; }

        public string ProductId { get; set; }
        public int NumberOfFloors { get; set; }
        public string PremiumStatus { get; set; }
        public bool IsLinkable { get; set; }
        public bool OtisOne { get; set; }
        public string RouteNo { get; set; }
        public DateTime DateInstalled { get; set; }

        public DateTime DateModified { get; set; }


    }

    }
