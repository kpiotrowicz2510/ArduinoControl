using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoControl
{
    class Reading
    {
        public Reading()
        {

        }
        public int returnType(string code)
        {
            int ret=-1;
            switch (code)
            {
                case "FFA25D":
                    ret=0;
                    break;
                case "FF30CF":
                    ret = 1;
                    break;
                case "FF18E7":
                    ret = 2;
                    break;
                case "FF7A85":
                   ret = 3;
                    break;
                case "FFFFFFFF":
                    ret = -1;
                    break;
            }
            return ret;
        }
        public string returnMessage(int code)
        {
            string ret = "Bad code!";
            switch (code)
            {
                case 0:
                    ret = "Launching";
                    break;
                case 1:
                    ret = "Setting to pos: 0";
                    break;
                case 2:
                    ret = "Setting to pos: 50";
                    break;
                case 3:
                    ret = "Setting to pos: 100";
                    break;
                case -1:
                    ret = "Bad code!";
                    break;
            }
            return ret;
        }
    }
}
