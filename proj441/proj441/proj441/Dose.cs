using System;
using System.Collections.Generic;
using System.Text;

namespace proj441
{
    public class Dose
    {
        public Prescription PrescriptionDose
        {
            get;
            set;
        }

        public DateTime TimeDose
        {
            get;
            set;
        }

        public int DoseQuantity
        {
            get;
            set;
        }
    }
}
