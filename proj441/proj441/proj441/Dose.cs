using System;
using System.Collections.Generic;
using System.Text;

namespace proj441
{
    public class Dose
    {
        public Prescription PrescriptionTaken
        {
            get;
            set;
        }

        public DateTime DateTimeTaken
        {
            get;
            set;
        }

        public int QuantityTaken
        {
            get;
            set;
        }
    }
}
