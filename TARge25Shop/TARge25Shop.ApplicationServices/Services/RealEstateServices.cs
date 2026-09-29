﻿using Microsoft.EntityFrameworkCore;
using System.Xml;
using TARge25Shop.Core.Domain;
using TARge25Shop.Core.Dto;
using TARge25Shop.Core.ServiceInterface;
using TARge25Shop.Data;


namespace TARge25Shop.ApplicationServices.Services
{
    public class RealEstateServices : IRealEstateServices
    {
        private readonly TARge25ShopContext _context;

        public RealEstateServices
            (
                TARge25ShopContext context
            )
        {
            _context = context;
        }

        //see meetod on vaja controlleris esile kutsuda
        //peab lisama interface, et kutsuda see meetod välja
        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            //siin peab tegema vaheinstansi dto ja domain vahel,
            //et andmed liiguvad dto-st domain objekt
            RealEstate realestate = new();

            realestate.Id = dto.Id;
            realestate.Area = dto.Area;
            realestate.Location = dto.Location;
            realestate.RoomNumber = dto.RoomNumber;
            realestate.BuildingType = dto.BuildingType;
            realestate.CreatedAt = dto.CreatedAt;
            realestate.ModifiedAt = DateTime.Now;

            //andmete salvestamine andmebaasi
            await _context.RealEstates.AddAsync(realestate);
            await _context.SaveChangesAsync();

            return realestate;
        }

        //teha update meetod, mis võtab vastu dto ja uuendab olemasolevat kosmoselaeva
        public async Task<RealEstate> Update(RealEstateDto dto)
        {
            //siin peab tegema vaheinstansi dto ja domain vahel,
            //et andmed liiguvad dto-st domain objekt
            RealEstate realestate = new();

            realestate.Id = dto.Id;
            realestate.Area = dto.Area;
            realestate.Location = dto.Location;
            realestate.RoomNumber = dto.RoomNumber;
            realestate.BuildingType = dto.BuildingType;
            realestate.CreatedAt = dto.CreatedAt;
            realestate.ModifiedAt = DateTime.Now;

            //andmete uuendamine andmebaasis
            _context.RealEstates.Update(realestate);
            await _context.SaveChangesAsync();

            return realestate;
        }

        public async Task<RealEstate> DetailAsync(Guid id)
        {
            var realestate = await _context.RealEstates
                .FirstOrDefaultAsync(y => y.Id == id);

            return realestate;
        }
        public async Task<RealEstate> Delete(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(y => y.Id == id);

            _context.RealEstates.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}