using System.Threading.Tasks;
using AGL.DeveloperTest.Controllers;
using AGL.DeveloperTest.Models;
using AGL.DeveloperTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AGL.DeveloperTest.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private readonly Owner[] _owners = new Owner[]
        {
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
                Name = "Jennifer",
                Gender = Gender.Female.ToString(),
                Age = 18,
                Pets = new[]
                {
                    new Pet { Name = "Garfield", Type = PetType.Cat.ToString() },
                }
            },
            new Owner
            {
                Name = "Steve",
                Gender = Gender.Male.ToString(),
                Age = 45,
                Pets = null
            },
            new Owner
            {
                Name = "Fred",
                Gender = Gender.Male.ToString(),
                Age = 40,
                Pets = new[]
                {
                    new Pet { Name = "Tom", Type = PetType.Cat.ToString() },
                    new Pet { Name = "Max", Type = PetType.Cat.ToString() },
                    new Pet { Name = "Sam", Type = PetType.Dog.ToString() },
                    new Pet { Name = "Jim", Type = PetType.Cat.ToString() },
                }
            },
            new Owner
            {
                Name = "Samantha",
                Gender = Gender.Female.ToString(),
                Age = 40,
                Pets = new[]
                {
                    new Pet { Name = "Tabby", Type = PetType.Cat.ToString() },
                }
            },
            new Owner
            {
                Name = "Alice",
                Gender = Gender.Female.ToString(),
                Age = 64,
                Pets = new[]
                {
                    new Pet { Name = "Simba", Type = PetType.Cat.ToString() },
                    new Pet { Name = "Nemo", Type = PetType.Fish.ToString() },
                }
            }
        };

        [TestMethod]
        public void ShouldReturnCatNames()
        {
            var ownersServiceMock = new Mock<IOwnersService>();
            ownersServiceMock.Setup(p => p.GetOwners()).Returns(Task.FromResult(_owners));

            var petsService = new PetsService();
            var controller = new HomeController(ownersServiceMock.Object, petsService);

            var result = controller.Index().Result as ViewResult;
            var model = result.Model as ResultViewModel;

            Assert.IsNotNull(model);

            Assert.AreEqual(4, model.MaleOwnersCatNames.Count);
            Assert.IsTrue(model.MaleOwnersCatNames.Contains("Garfield"));
            Assert.IsTrue(model.MaleOwnersCatNames.Contains("Tom"));
            Assert.IsTrue(model.MaleOwnersCatNames.Contains("Max"));
            Assert.IsTrue(model.MaleOwnersCatNames.Contains("Jim"));

            Assert.AreEqual(1, model.FemaleOwnersCatNames.Count);
            Assert.IsTrue(model.FemaleOwnersCatNames.Contains("Simba"));
        }
    }
}