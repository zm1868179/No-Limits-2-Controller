using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No_Limits_2_Controller
{
    class Quaternion
    {
        public double x;
        public double y;
        public double z;
        public double w;

        public double toPitchFromYUp()
        {
            double vx = 2 * (x * y + w * y);
            double vy = 2 * (w * x - y * z);
            double vz = 1.0 - 2 * (x * x + y * y);

            return Math.Atan2(vy, Math.Sqrt(vx * vx + vz * vz));
        }

        public double toYawFromYUp()
        {
            return Math.Atan2(2 * (x * y + w * y), 1.0 - 2 * (x * x + y * y));
        }

        public double toRollFromYUp()
        {
            return Math.Atan2(2 * (x * y + w * z), 1.0 - 2 * (x * x + z * z));
        }
    }
}
