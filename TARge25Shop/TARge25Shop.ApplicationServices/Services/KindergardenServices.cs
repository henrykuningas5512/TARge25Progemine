using Microsoft.EntityFrameworkCore;
using TARge25Shop.Core.Domain;
using TARge25Shop.Core.Dto;
using TARge25Shop.Core.ServiceInterface;
using TARge25Shop.Data;


namespace TARge25Shop.ApplicationServices.Services
{
    public class KindergardenServices : IKindergardenServices
    {
        private readonly TARge25ShopContext _context;
        private readonly IFileServices _fileServices;

        public KindergardenServices
            (
                TARge25ShopContext context,
                IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }

        //see meetod on vaja controlleris esile kutsuda
        //peab lisama interface, et kutsuda see meetod välja
        public async Task<Kindergarden> Create(KindergardenDto dto)
        {
            //siin peab tegema vaheinstansi dto ja domain vahel,
            //et andmed liiguvad dto-st domain objekt
            Kindergarden kindergarden = new();

            kindergarden.Id = Guid.NewGuid();
            kindergarden.GroupName = dto.GroupName;
            kindergarden.ChildrenCount = dto.ChildrenCount;
            kindergarden.KindergartenName = dto.KindergartenName;
            kindergarden.TeacherName = dto.TeacherName;
            kindergarden.CreatedAt = DateTime.Now;
            kindergarden.UpdatedAt = DateTime.Now;

            //andmete salvestamine andmebaasi
            _context.Kindergarden.Add(kindergarden);
            await _context.SaveChangesAsync();
            await _fileServices.FilesToApi(dto, kindergarden);

            return kindergarden;
        }

        //teha update meetod, mis võtab vastu dto ja uuendab olemasolevat kosmoselaeva
        public async Task<Kindergarden> Update(KindergardenDto dto)
        {
            //siin peab tegema vaheinstansi dto ja domain vahel,
            //et andmed liiguvad dto-st domain objekt
            var kindergarden = await _context.Kindergarden.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (kindergarden == null) return null;
            kindergarden.GroupName = dto.GroupName;
            kindergarden.ChildrenCount = dto.ChildrenCount;
            kindergarden.KindergartenName = dto.KindergartenName;
            kindergarden.TeacherName = dto.TeacherName;
            kindergarden.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            await _fileServices.FilesToApi(dto, kindergarden);

            return kindergarden;
        }

        public async Task<Kindergarden> DetailAsync(Guid id)
        {
            var kindergarden = await _context.Kindergarden
                .FirstOrDefaultAsync(y => y.Id == id);

            return kindergarden;
        }
        public async Task<Kindergarden> Delete(Guid id)
        {
            var result = await _context.Kindergarden
                .FirstOrDefaultAsync(y => y.Id == id);

            if (result == null) return null;

            var images = await _context.FileToApis
                .Where(x => x.KindergardenId == id)
                .Select(x => new FileToApiDto { Id = x.Id })
                .ToArrayAsync();
            await _fileServices.RemoveImagesFromApi(images);

            _context.Kindergarden.Remove(result);
            await _context.SaveChangesAsync();

            return result;

        }
    }
}
