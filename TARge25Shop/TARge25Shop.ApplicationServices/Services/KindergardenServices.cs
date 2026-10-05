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

        public KindergardenServices
            (
                TARge25ShopContext context
            )
        {
            _context = context;
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

            return kindergarden;
        }

        //teha update meetod, mis võtab vastu dto ja uuendab olemasolevat kosmoselaeva
        public async Task<Kindergarden> Update(KindergardenDto dto)
        {
            //siin peab tegema vaheinstansi dto ja domain vahel,
            //et andmed liiguvad dto-st domain objekt
            Kindergarden kindergarden = new();

            kindergarden.Id = dto.Id;
            kindergarden.GroupName = dto.GroupName;
            kindergarden.ChildrenCount = dto.ChildrenCount;
            kindergarden.KindergartenName = dto.KindergartenName;
            kindergarden.TeacherName = dto.TeacherName;
            kindergarden.CreatedAt = dto.CreatedAt;
            kindergarden.UpdatedAt = DateTime.Now;

            //andmete uuendamine andmebaasis
            _context.Kindergarden.Update(kindergarden);
            await _context.SaveChangesAsync();

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

            _context.Kindergarden.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}