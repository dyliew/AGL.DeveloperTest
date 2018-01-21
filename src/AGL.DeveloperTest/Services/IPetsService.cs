using System.Collections.Generic;
using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Services
{
    public interface IPetsService
    {
        List<string> GetPetNamesByOwnerGenderAndPetType(Owner[] owners, string gender, string type);
    }
}