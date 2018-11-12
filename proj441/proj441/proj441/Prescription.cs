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

        public Prescription CopyPrescription(Prescription p)
        {
            Name = p.Name;
            Strength = p.Strength;
            Instructions = p.Instructions;
            PrescribedDosage = p.PrescribedDosage;
            PhysicalDescription = p.PhysicalDescription;
            Quantity = p.Quantity;
            Remaining = p.Remaining;
            return this;
        }
    }
}
