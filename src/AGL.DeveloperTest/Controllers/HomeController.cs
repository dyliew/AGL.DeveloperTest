using System.Threading.Tasks;
using AGL.DeveloperTest.Models;
using Microsoft.AspNetCore.Mvc;
using AGL.DeveloperTest.Services;

namespace AGL.DeveloperTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOwnersService _ownerService;
        private readonly IPetsService _petsService;

        public HomeController(IOwnersService ownerService, IPetsService petsService)
        {
            _ownerService = ownerService;
            _petsService = petsService;
        }

        public async Task<IActionResult> Index()
        {
            var owners = await _ownerService.GetOwners();

            var malesOwnersCatNames = _petsService.GetPetNamesByOwnerGenderAndPetType(owners, Gender.Male.ToString(), PetType.Cat.ToString());
            var femalesOwnersCatNames = _petsService.GetPetNamesByOwnerGenderAndPetType(owners, Gender.Female.ToString(), PetType.Cat.ToString());

            return View(new ResultViewModel
            {
                FemaleOwnersCatNames = femalesOwnersCatNames,
                MaleOwnersCatNames = malesOwnersCatNames
            });
        }
    }
}
