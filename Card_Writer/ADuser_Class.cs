using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Writer
{
    class ADuser_Class
    {
        public ADuser_Class ()
        {
            this.userNameAcco = "";
            this.userNameFull = "";
            this.tel = "";
            this.mob = "";
            this.cardNumberFull = "";
            this.cardNumberPre = "";
            this.cardNumberOld = "";
            this.haveCard = "";
            this.leader = "";
            this.title = "";
            this.place = "";
        }
        
        public string userNameAcco;
        public string userNameFull;
        public string tel;
        public string mob;
        public string cardNumberFull;
        public string cardNumberPre;
        public string cardNumberOld;
        public string haveCard;
        public string leader;
        public string title;
        public string place;

        public void clean()
        {
            this.userNameAcco = "";
            this.userNameFull = "";
            this.tel = "";
            this.mob = "";
            this.cardNumberFull = "";
            this.cardNumberPre = "";
            this.cardNumberOld = "";
            this.haveCard = "";
            this.leader = "";
            this.title = "";
            this.place = "";
        }
    }
}
