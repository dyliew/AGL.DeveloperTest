using System;
using System.Collections.Generic;
using System.Linq;
using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Services
{
    public class PetsService : IPetsService
    {
        public List<string> GetPetNamesByOwnerGenderAndPetType(Owner[] owners, string gender, string type)
        {
            return owners
                .Where(p => p.Gender.Equals(gender, StringComparison.InvariantCultureIgnoreCase) && p.Pets != null && p.Pets.Length > 1)
                .SelectMany(p => p.Pets)
                .Where(p => p.Type.Equals(type, StringComparison.InvariantCultureIgnoreCase))
                .Select(p => p.Name)
                .ToList();
        }
    }
}