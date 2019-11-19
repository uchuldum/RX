using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Day1.BLL.DTObjects;
using Day1.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Day1.WEB.Controllers
{
    public class BrandController : Controller
    {
        private IBrandService service;
        private IMapper mapper;
        private UserDTO userDTO;

        public BrandController(IBrandService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            userDTO = new UserDTO { Name = User.Identity.Name };
            if (userDTO.Name == null) return RedirectToAction("Index", "Home");
            return View(await service.GetAll(userDTO));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BrandDTO brand)
        {
            userDTO = new UserDTO { Name = User.Identity.Name };
            if (service.Add(brand, userDTO) != null)
                return RedirectToAction("Index");
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(int id)
        {
            userDTO = new UserDTO { Name = User.Identity.Name };
            if (id == 0) return NotFound();
            await service.Remove(id, userDTO);
            return RedirectToAction("Index");
        }

    }
}