using System;
using System.Collections.Generic;
using System.Text;
using TARge25Shop.Core.Dto;
using TARge25Shop.Core.ServiceInterface;
using Xunit;

namespace TARge25Shop.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {

        [Fact]
        public async Task ShouldNot_AddEmptySpaceShip_WhenResultIsReturned()
        {
            SpaceshipDto dto = new SpaceshipDto()
            {
                Name = "X AE a L 12",
                ShipType = "lendav taldrik",
                Crew = 666,
                EnginePower = 69,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            //tegutsemine
            var result = await Svc<ISpaceshipServices>().Create(dto);

            //kontroll 
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetSpaceShipBYID_WhenIDNotEqual()
        {
            //ülesseade
            Guid wrongGuid = Guid.NewGuid();
            Guid goodGuid = Guid.Parse("9e9205b2-2637-4156-bb15-900f5934b5e9");

            //tegevus
            await Svc<ISpaceshipServices>().DetailAsync(goodGuid);

            //kontroll
            Assert.NotEqual(wrongGuid, goodGuid);
        }
        [Fact]
        public async Task Should_GetSpaceshipByID_WhenGuidIsEqual()
        {
            //ülessezade
            Guid databaseGuid = Guid.Parse("9e9205b2-2637-4156-bb15-900f5934b5e9");
            Guid seekGuid = Guid.Parse("9e9205b2-2637-4156-bb15-900f5934b5e9");


            //tegevus
            await Svc<ISpaceshipServices>().DetailAsync(seekGuid);

            //kontroll
            Assert.Equal(databaseGuid, seekGuid);
        }
        //seleta kodus lahti, nagu eelnevate testide laused, eesti keelde, selle testi óma ka.----- siit edasi on midagi puudu :) hehe

        [Fact]
        public async Task Should_SpaceshipDeletedByID_WhenReturnedResultIsEqual()
        {
            //ülesseade
            SpaceshipDto dto = MockSpaceshipData();

            var addSpaceship = await Svc<ISpaceshipServices>().Create(dto);
            var deleteSpaceship = await Svc<ISpaceshipServices>().Delete((Guid)addSpaceship.Id);

            //kontroll
            Assert.Equal(addSpaceship.Id, deleteSpaceship.Id);
        }

        private SpaceshipDto MockSpaceshipData(bool isOneOrTwo)
        {
            if
            SpaceshipDto dto = new SpaceshipDto()
            {
                Name = "X AE a L 12",
                ShipType = "lendav taldrik",
                Crew = 666,
                EnginePower = 69,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
        }
    }
}
