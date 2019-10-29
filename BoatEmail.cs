
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Helpers;

namespace Template
{
    class BoatEmail : RepairDock
    {
        Repair repair = new Repair();
        Notifications notif = new Notifications();
        /// <summary>
        /// Sends an email message for customer
        /// </summary>
        public override void SendNotification(string message)
        {
            notif.Email(message);
        }

        public override MaterialsSet CountRepairMaterials(DamageLevel damageLevel)
        {
            return repair.BoatMaterials(damageLevel);
        }

        /// <summary>
        /// Repair time in days
        /// Repair time depends on damage level + time for inspection
        /// </summary>
        /// <param name="damageLevel"></param>
        /// <returns></returns>
        public override int CountRepairTime(DamageLevel damageLevel)
        {
            return repair.BoatRepairTime(damageLevel);
        }
    }
}

