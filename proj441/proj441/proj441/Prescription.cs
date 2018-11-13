using System;
using System.Collections.Generic;
using System.Text;

namespace proj441
{
    public class Prescription
    {
        public string Name
        {
            get;
            set;
        }

        public string Strength
        {
            get;
            set;
        }

        public string Instructions
        {
            get;
            set;
        }

        public int PrescribedDosage
        {
            get;
            set;
        }

        public string PhysicalDescription
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public int Remaining
        {
            get;
            set;
        }

        //copy constructor
        public Prescription CopyPrescription(Prescription pervious)
        {
            Name = pervious.Name;
            Strength = pervious.Strength;
            Instructions = pervious.Instructions;
            PrescribedDosage = pervious.PrescribedDosage;
            PhysicalDescription = pervious.PhysicalDescription;
            Quantity = pervious.Quantity;
            Remaining = pervious.Remaining;
            return this;
        }
    }
}
