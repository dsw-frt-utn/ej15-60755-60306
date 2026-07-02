
namespace Dsw2026Ej15.Aplication.Models
{
    public record DoctorModel
    {
        public record Request(string Name, string LicenseNumber, Guid SpecialityId);
        public record Response(string Name, string LisenceNumber, string SpecialityName);
    }
}
