using Microsoft.AspNetCore.Mvc;
using TARge25Shop.Core.Dto;
using TARge25Shop.Core.ServiceInterface;
using TARge25Shop.Data;
using TARge25Shop.Models.Kindergarden;

namespace TARge25Shop.Controllers
{
    public class KindergardenController : Controller
    {
        private readonly IKindergardenServices _kindergardenServices;
        private readonly TARge25ShopContext _context;

        public KindergardenController(
            IKindergardenServices kindergardenServices,
            TARge25ShopContext context)
        {
            _kindergardenServices = kindergardenServices;
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Kindergarden
                .Select(y => new KindergardenIndexViewModel
                {
                    Id = y.Id,
                    GroupName = y.GroupName,
                    ChildrenCount = y.ChildrenCount,
                    KindergartenName = y.KindergartenName,
                    TeacherName = y.TeacherName,
                    CreatedAt = y.CreatedAt,
                    UpdatedAt = y.UpdatedAt
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            KindergardenCreateUpdateViewModel result = new();

            return View("CreateUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(KindergardenCreateUpdateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateUpdate", vm);
            }

            var dto = new KindergardenDto
            {
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                TeacherName = vm.TeacherName,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
            };

            var result = await _kindergardenServices.Create(dto);

            if (result == null)
            {
                return View("CreateUpdate", vm);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var kindergarden = await _kindergardenServices.DetailAsync(id);

            if (kindergarden == null)
            {
                return NotFound();
            }

            var vm = new KindergardenCreateUpdateViewModel
            {
                Id = kindergarden.Id,
                GroupName = kindergarden.GroupName,
                ChildrenCount = kindergarden.ChildrenCount,
                KindergartenName = kindergarden.KindergartenName,
                TeacherName = kindergarden.TeacherName,
                CreatedAt = kindergarden.CreatedAt,
                UpdatedAt = kindergarden.UpdatedAt
            };

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(KindergardenCreateUpdateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateUpdate", vm);
            }

            var dto = new KindergardenDto
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                TeacherName = vm.TeacherName,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
            };

            var result = await _kindergardenServices.Update(dto);

            if (result == null)
            {
                return View("CreateUpdate", vm);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var kindergarden = await _kindergardenServices.DetailAsync(id);

            if (kindergarden == null)
            {
                return NotFound();
            }

            var vm = new KindergardenDeleteViewModel
            {
                Id = kindergarden.Id,
                GroupName = kindergarden.GroupName,
                ChildrenCount = kindergarden.ChildrenCount,
                KindergartenName = kindergarden.KindergartenName,
                TeacherName = kindergarden.TeacherName,
                CreatedAt = kindergarden.CreatedAt,
                UpdatedAt = kindergarden.UpdatedAt
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var kindergarden = await _kindergardenServices.Delete(id);

            if (kindergarden == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var kindergarden = await _kindergardenServices.DetailAsync(id);

            if (kindergarden == null)
            {
                return NotFound();
            }

            var vm = new KindergardenDetailsViewModel
            {
                Id = kindergarden.Id,
                GroupName = kindergarden.GroupName,
                ChildrenCount = kindergarden.ChildrenCount,
                KindergartenName = kindergarden.KindergartenName,
                TeacherName = kindergarden.TeacherName,
                CreatedAt = kindergarden.CreatedAt,
                UpdatedAt = kindergarden.UpdatedAt
            };

            return View(vm);
        }
    }
}