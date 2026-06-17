namespace Dsw2026Ej15.Domain.Entities
{
    public class Speciality : BaseEntity
    {
        public string Name { get; init; }
        public string Description { get; set; }

        public Speciality(string name, string description,Guid? id=null):base(id)
        {
            name = Name;
            description = Description;
        }



    }
}
