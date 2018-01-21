namespace AGL.DeveloperTest.Models
{
    public class Owner
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public Pet[] Pets { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}