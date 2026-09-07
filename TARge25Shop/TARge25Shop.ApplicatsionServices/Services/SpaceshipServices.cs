using System.Runtime.InteropServices;
using TARge25Shop.Core.Domain;
using TARge25Shop.Core.Dto;
using TARge25Shop.Data;

namespace TARge25Shop.ApplicatsionServices.Services
{
    public class SpaceshipServices : ISpaceshipServices
    {
        private readonly TARge25ShopContext _context;

        public SpaceshipServices
           (
                TARge25ShopContext context
            )
        {
            _context = context;
        }

        //see meetod on vaja controlleris esile kutsuda
        //peab lisama interfacei, et kutsuda see meetod välja
        public async Task<Spaceship> Create(SpaceshipDto dto)
        {
            //siin peab tegema vaheinstantsi dto ja domaini vahel,
            //et andmed liiguvad dto-st domain objekti
            Spaceship spaceShip = new();

            spaceShip.Id = dto.Id;
            spaceShip.Name = dto.Name;
            spaceShip.ShipType = dto.ShipType;
            spaceShip.Crew = dto.Crew;
            spaceShip.EnginePower = dto.EnginePower;
            spaceShip.CreatedAt = dto.CreatedAt;
            spaceShip.UpdatedAt = dto.UpdatedAt;

            //andmete salvestamine andmebaasi
            _context.Spaceships.Add(spaceShip);
            await _context.SaveChangesAsync();

            return spaceShip;
        }
    }
}
