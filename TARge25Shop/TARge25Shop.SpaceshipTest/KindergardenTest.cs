using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using TARge25Shop.Core.Dto;
using TARge25Shop.Core.ServiceInterface;
using TARge25Shop.SpaceshipTest;
using Xunit;

namespace TARge25Shop.KindergardenTest
{
    public class kindergardenTest : TestBase
    {
        [Fact]
        // Fact tähistab ära ühte testi xUnit raamistikus
        // 1 - Kirjeldatakse ära kas test on tavaline, või negatiivne.
        // 2 - Kirjeldatakse ära mida parasjagu üritatakse testialuse objektiga teha
        // 3 - Mis tingimustel tulemust kontrollitakse, peale tegevust
        //
        // Selles testis kontrollitakse et (2) Kosmoselaeva lisamisel
        // (1) Ei tohiks (3) saadud tulemus olla tühi. Jälgi seda sõnastusviisi:
        //
        //                  1           2               3
        //                  \/          \/              \/
        public async Task ShouldNot_AddEmptyKindergarden_WhenResultIsReturned()
        {
            // Ülesseade
            KindergardenDto dto = new KindergardenDto()
            {

                GroupName = "X AE a L 12 menuornvöerv",
                ChildrenCount = 67,
                KindergartenName = "Yes",
                TeacherName = "Verdik",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            // tegutsemine
            var result = await Svc<IKindergardenServices>().Create(dto);

            // kontroll
            Assert.NotNull(result);
        }
    }
}
