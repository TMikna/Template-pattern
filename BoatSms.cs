using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Helpers;

namespace Template
{
    class BoatSms : RepairDock
    {
        Notifications notif = new Notifications();
        Repair repair = new Repair();
        /// <summary>
        /// Sends an sms message for customer
        /// </summary>
        public override void SendNotification(string message)
        {
            notif.Sms(message);
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
