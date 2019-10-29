using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Helpers;

namespace Template
{
    class Client
    {
        RepairDock repairDock;
        DamageLevel damageLevel;

        public void Main()
        {
            bool choosing = true;

            int shipType  = 1;
            int notifMethod = 1;

            while (choosing)
            {
                Console.WriteLine("Strategy method\n");

                shipType = chooseShipType();
                notifMethod = chooseNotificationMethod();

                if (!chooseDamageLevel())
                    continue;

                choosing = false;
            }

            
            switch (shipType)
            {
                case 1:
                    if (notifMethod == 1)
                        repairDock = new BoatSms();
                    else
                        repairDock = new BoatEmail();
                    break;
                case 2:
                    if (notifMethod == 2)
                        repairDock = new YachtSms();
                    else
                        repairDock = new YachtEmail();
                    break;
                case 3:
                    if (notifMethod == 1)
                        repairDock = new FerrySms();
                    else
                        repairDock = new FerryEmail();
                    break;
                default:

                   break;

            }

            Console.WriteLine("Resources, required for your boat repair:");
            printTimeMaterials();

            Console.WriteLine("Does conditios suit you? Press 1 if you want to place order or any other number to cancel");
            var q = Console.ReadLine();
            int result;
            Int32.TryParse(q, out result);
            if (result == 1)
                sendNotification();

            Console.ReadKey();


        }

        private int chooseShipType()
        {
            Console.WriteLine("Choose ship type (1 - boat, 2 - yacht or 3 - ferry)");
            var input = Console.ReadLine();
            int type;
            Int32.TryParse(input, out type);

            return type;

        }

        private bool chooseDamageLevel()
        {
            Console.WriteLine("Choose damage level ( 0 - No damage, 1 - small, 2 - medium, 3 - heavy, 4 - ship is completely destroyed)");
            var input = Console.ReadLine();
            int damageLvl;
            Int32.TryParse(input, out damageLvl);
            if (damageLvl <= (int)DamageLevel.Destroyed && damageLvl >= (int)DamageLevel.Undamaged)
            {
                damageLevel = new DamageLevel();
                damageLevel = (DamageLevel)damageLvl;
            }
            else
            {
                Console.WriteLine("Wrong input. Try Again");
                return false;
            }
            return true;
        }

        private int chooseNotificationMethod()
        {
            Console.WriteLine("Choose how do you wand to be notified ( 1 - by SMS, 2 - by email )");
            var input = Console.ReadLine();
            int notifType;
            Int32.TryParse(input, out notifType);

            return notifType;
        }




        private void printTimeMaterials()
        {
            Console.WriteLine("Time: " + repairDock.CountRepairTime(damageLevel));

            Console.WriteLine("Materials: ");
            MaterialsSet materials = repairDock.CountRepairMaterials(damageLevel);
            materials.printMaterials();
        }

        private void sendNotification()
        {
            repairDock.SendNotification("Your ship is repaired.");
        }

    }
}
