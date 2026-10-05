using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TARge25Shop.Core.Domain;
using TARge25Shop.Core.Dto;
using TARge25Shop.Core.ServiceInterface;
using TARge25Shop.Data;

namespace TARge25Shop.ApplicationServices.Services
{
    public class SpaceshipServices : ISpaceshipServices
    {
        private readonly TARge25ShopContext _context;
        private readonly IFileServices _fileServices;

        public SpaceshipServices
            (
                TARge25ShopContext context,
                IFileServices fileServices
            );
        public SpaceshipServices(TARge25ShopContext context)
        {
            _context = context;
            _fileServices = fileServices;
            
        }

        public async Task<Spaceship> Create(SpaceshipDto dto)
        {
            Spaceship spaceShip = new();

            spaceShip.Id = Guid.NewGuid();
            spaceShip.Name = dto.Name;
            spaceShip.ShipType = dto.ShipType;
            spaceShip.Crew = dto.Crew;
            spaceShip.EnginePower = dto.EnginePower;
            spaceShip.CreatedAt = DateTime.Now;
            spaceShip.UpdatedAt = DateTime.Now;
            //kui uus ankeet on loodud, siis 
            //toimub ka faili salvestamine
            //saab kutsuda teise service clasi meetotit
            //esile service clasis
            _fileServices.FilesToApi(dto, spaceShip);

            _context.Spaceships.Add(spaceShip);

            await _context.SaveChangesAsync();

            return spaceShip;
        }

        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            Spaceship spaceShip = new();

            spaceShip.Id = dto.Id;
            spaceShip.Name = dto.Name;
            spaceShip.ShipType = dto.ShipType;
            spaceShip.Crew = dto.Crew;
            spaceShip.EnginePower = dto.EnginePower;
            spaceShip.CreatedAt = dto.CreatedAt;
            spaceShip.UpdatedAt = DateTime.Now;

            _context.Spaceships.Update(spaceShip);

            await _context.SaveChangesAsync();

            return spaceShip;
        }

        public async Task<Spaceship> DetailAsync(Guid id)
        {
            var spaceship = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);

            return spaceship;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceship = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);

            if (spaceship == null)
            {
                return null;
            }

            _context.Spaceships.Remove(spaceship);

            await _context.SaveChangesAsync();

            return spaceship;
        }
    }
}