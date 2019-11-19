using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Day1.BLL.DTObjects;
using Day1.BLL.Interfaces;
using Day1.BLL.SearchModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day1.WEB.Controllers
{
    public class VehicleController : Controller
    {
        private IVehicleService service;
        private IModelService modelService;
        private IBrandService brandService;
        private IMapper mapper;
        private UserDTO userDTO;
        private static IEnumerable<VehicleDTO> searchVehicles = null;
        public VehicleController(IVehicleService service, IModelService modelService, IBrandService brandService, IMapper mapper)
        {
            this.service = service;
            this.modelService = modelService;
            this.brandService = brandService;
            this.mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            userDTO = new UserDTO { Name = User.Identity.Name };
            if (userDTO.Name == null) return RedirectToAction("Index", "Home");
            ViewBag.Models = new SelectList(await modelService.GetAll(userDTO), "Id", "Name");
            ViewBag.Brands = new SelectList(await brandService.GetAll(userDTO), "Id", "Name");
            if (searchVehicles == null)
                return View(await service.GetAll(userDTO));
            else
                return View(searchVehicles);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            userDTO = new UserDTO { Name = User.Identity.Name };
            if(userDTO.Name == null) return RedirectToAction("Index");
            ViewBag.Models = new SelectList(await modelService.GetAll(userDTO), "Id", "Name");
            ViewBag.Brands = new SelectList(await brandService.GetAll(userDTO), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] VehicleDTO vehicle)
        {
            userDTO = new UserDTO { Name = User.Identity.Name };
            if (service.Add(vehicle, userDTO) != null)
                return RedirectToAction("Index");
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Edit(int id)
        {
            userDTO = new UserDTO { Name = User.Identity.Name };
            if (userDTO.Name == null) return RedirectToAction("Index");
            var vehicle = await service.Get(id);
            ViewData["Name"] = vehicle.Name;
            ViewData["CreateDate"] = vehicle.CreateDate;
            ViewData["GovernmentNumber"] = vehicle.GovernmentNumber;
            ViewData["Id"] = id;
            ViewBag.Models = new SelectList(await modelService.GetAll(userDTO), "Id", "Name", vehicle.ModelId);
            ViewBag.Brands = new SelectList(await brandService.GetAll(userDTO), "Id", "Name", vehicle.BrandId);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] VehicleDTO vehicle)
        {
            userDTO = new UserDTO { Name = User.Identity.Name };
            if (service.Update(vehicle, userDTO) != null)
                return RedirectToAction("Index");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Search(string name, DateTime? beforeDate, DateTime? fromDate, int? modelId, int? brandId)
        {
            userDTO = new UserDTO { Name = User.Identity.Name };
            VehicleSearchModel vehicleSearchModel = new VehicleSearchModel { Name = name, BeforeDate = beforeDate, BrandId = brandId, FromDate = fromDate, ModelId = modelId };

            searchVehicles = await service.GetVehicleDTOs(vehicleSearchModel, userDTO);

            return RedirectToAction("Index");
        }
    }
}