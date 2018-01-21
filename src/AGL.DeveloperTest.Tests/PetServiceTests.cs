using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGL.DeveloperTest.Tests
{
    [TestClass]
    public class PetServiceTests
    {
        private readonly Owner[] _owners = {
            new Owner
            {
                Name = "Bob",
                Gender = Gender.Male.ToString(),
                Age = 23,
                Pets = new[]
                {
                    new Pet { Name = "Garfield", Type = PetType.Cat.ToString() },
                    new Pet { Name = "Fido", Type = PetType.Dog.ToString() },
                }
            },
            new Owner
            {
                Name = "Robert",
                Gender = Gender.Male.ToString(),
                Age = 21,
                Pets = new[]
                {
                    new Pet { Name = "Nemo", Type = PetType.Fish.ToString() },
                    new Pet { Name = "Hello", Type = PetType.Cat.ToString() },
                }
            },
            new Owner
            {
                Name = "Mary",
                Gender = Gender.Female.ToString(),
                Age = 26,
                Pets = new[]
                {
                    new Pet { Name = "Woofy", Type = PetType.Fish.ToString() },
                    new Pet { Name = "Clumsy", Type = PetType.Dog.ToString() },
                }
            }
        };

        [TestMethod]
        public void ShouldContainsDogs()
        {
            var service = new PetsService();

            var names = service.GetPetNamesByOwnerGenderAndPetType(_owners, Gender.Male.ToString(), PetType.Dog.ToString());

            Assert.AreEqual(1, names.Count);
            Assert.IsTrue(names.Contains("Fido"));
            Assert.IsFalse(names.Contains("Clumsy"));
            Assert.IsFalse(names.Contains("Garfield"));
        }

        [TestMethod]
        public void ShouldContainsCats()
        {
            var service = new PetsService();

            var names = service.GetPetNamesByOwnerGenderAndPetType(_owners, Gender.Female.ToString(), PetType.Cat.ToString());

            Assert.AreEqual(0, names.Count);
            Assert.IsFalse(names.Contains("Clumsy"));
            Assert.IsFalse(names.Contains("Woofy"));
        }
    }
}