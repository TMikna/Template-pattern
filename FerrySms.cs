using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Helpers;

namespace Template
{
    class FerrySms : RepairDock
    {
        Repair repair = new Repair();
        Notifications notif = new Notifications();
        /// <summary>
        /// Sends an sms message for customer
        /// </summary>
        public override void SendNotification(string message)
        {
            notif.Sms(message);
        }
        public override MaterialsSet CountRepairMaterials(DamageLevel damageLevel)
        {
            return repair.FerryRepairMaterials(damageLevel);
        }

        public override int CountRepairTime(DamageLevel damageLevel)
        {
            return repair.FerryRepairTime(damageLevel);
        }

    }
}
