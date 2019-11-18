using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Day1.BLL.DTObjects;
using Day1.BLL.Interfaces;
using AutoMapper;

namespace Day1.WEB.Controllers
{
    public class VehicleController : Controller
    {
        private IVehicleService service;
        private IMapper mapper;
        private UserDTO userDTO;

        public VehicleController(IVehicleService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            userDTO = new UserDTO { Name = User.Identity.Name };
            return View(await service.GetAll(userDTO));
        }

        [HttpGet]
        public IActionResult Create()
        {
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
    }
}