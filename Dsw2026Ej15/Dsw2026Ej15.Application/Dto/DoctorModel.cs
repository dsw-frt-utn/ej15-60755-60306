using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Application.Dto
{
    public class DoctorModel
    {
        public record Request(string Name, string LicenseNumber, Guid SpecialityId);
        public record Response(string Name, string LisenceNumber, string SpecialityName);
    }
}
