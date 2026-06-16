namespace Dsw2026Ej15.Domain
{
    public class Speciality : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Speciality(string name, string description)
        {
            name = Name;
            description = Description;
        }



    }
}
