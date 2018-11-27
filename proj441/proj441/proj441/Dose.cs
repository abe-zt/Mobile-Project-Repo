using System;
using System.Collections.Generic;
using System.Text;

namespace proj441
{
    public class Dose : Prescription
    {
        
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
