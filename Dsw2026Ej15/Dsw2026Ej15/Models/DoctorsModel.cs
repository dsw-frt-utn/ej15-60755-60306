
namespace Dsw2026Ej15.Api.Models
{
    public record DoctorsModel
    {
        public record Request(string Name, string LicenseNumber, Guid SpecialityId);// Por convencion hay un record dentro de otro record, implementa request y response puedo devolver y recibir datos de dos formas
    }
}
