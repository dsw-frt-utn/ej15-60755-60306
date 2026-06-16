using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain
{
    public class Doctor : BaseEntity
    {
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public bool IsActive { get; set; }
        public Speciality Speciality { get; set; }

        public Doctor(string name, string licenseNumber, bool IsActive, Speciality speciality)
        {
            name = Name;
            licenseNumber = LicenseNumber;
            IsActive = IsActive;
            speciality = Speciality;
        }

    }
}
