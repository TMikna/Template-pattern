using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Helpers;

namespace Template
{
    abstract class RepairDock
    {
        //INotificationStrategy notificationStrategy;
        //IRepairStrategy repairStrategy;


        //public RepairDock(INotificationStrategy notifStr, IRepairStrategy repStr)
        //{
        //    notificationStrategy = notifStr;
        //    repairStrategy = repStr;
        //}

        public abstract int CountRepairTime(DamageLevel damageLevel);

        public abstract MaterialsSet CountRepairMaterials(DamageLevel damageLevel);

        public abstract void SendNotification(string message);
    }
}
