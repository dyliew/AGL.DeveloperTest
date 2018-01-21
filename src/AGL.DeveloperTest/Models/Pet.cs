namespace AGL.DeveloperTest.Models
{
    public class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public enum PetType
    {
        Cat,
        Dog,
        Fish
    }
}