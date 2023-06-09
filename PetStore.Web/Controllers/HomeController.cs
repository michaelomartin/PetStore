﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetStore.Services.Data;
using PetStore.Web.Models;
using PetStoreEFData.Models;
using System.Diagnostics;
using System.Text.Json;

namespace PetStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IPetProcessor _petProcessor;
        private readonly IPetRepository _petRepository;
        private readonly IPetTypeRepository _petTypeRepository;

        public HomeController(ILogger<HomeController> logger, IPetProcessor petProcessor, IPetRepository petRepository, IPetTypeRepository petTypeRepository)
        {
            _logger = logger;
            _petProcessor = petProcessor;
            _petRepository = petRepository;
            _petTypeRepository = petTypeRepository;
        }

        public IActionResult Index(string petName, int? petTypeId, string sortOrder)
        {
            var viewModel = new ListViewModel();
            var pets = _petRepository.GetPets(petTypeId, null, null, null, petName,sortOrder);
            var petTypes = _petTypeRepository.GetPetTypes().ToList();


            var petTypesSelectList = petTypes
                          .Select(a => new SelectListItem()
                          {
                              Value = a.Id.ToString(),
                              Text = a.Name
                          })
                          .ToList();
            petTypesSelectList.Insert(0, new SelectListItem { Value = "", Text = "" }); // Add empty row to start of drop down list


            viewModel.PetName = petName;
            viewModel.PetTypeId = petTypeId;
            //if (!String.IsNullOrEmpty(petName))
            //{
            //    pets = pets.Where(s => s.Name.Contains(petName, StringComparison.InvariantCultureIgnoreCase));
            //}

            viewModel.Pets = pets;
            viewModel.PetTypes = petTypesSelectList;

            return View(viewModel);
        }



        public IActionResult Create() {
            
            var viewModel = new PetAddEditViewModel();

            var petTypes = _petTypeRepository.GetPetTypes();

            ViewBag.PetTypes = petTypes;

            return View(viewModel);
        }

            
        [HttpPost]
        //public async Task<IActionResult> Create(PetAddEditViewModel viewModel)
        public IActionResult Create(PetAddEditViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Does the Pet already exist?
                    var existingPets = _petRepository.GetPetsByNameDOB(viewModel.Name, viewModel.DateOfBirth);

                    if ((existingPets != null) && (existingPets.Count() > 0))
                    {
                        var errorMessage = "Unable to create new pet record. Pet with the same Name and Date Of Birth already exists.";
                        _logger.LogError(errorMessage);
                        ModelState.AddModelError("", errorMessage);
                        return View(viewModel);
                    }

                    var id = _petProcessor.Insert(viewModel.Name, viewModel.PetTypeId, viewModel.DateOfBirth, viewModel.Weight);

                    //await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "New pet successfully added. Id:"+id;

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var errorMessage = "Unable to create new pet record. " + string.Join(" - ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)); 
                    _logger.LogError(errorMessage);
                    ModelState.AddModelError("", errorMessage);
                }


            }
            catch (Exception ex)
            {
                var errorMessage = "Unable to create new pet record. " + ex.Message;
                _logger.LogError(errorMessage);
                ModelState.AddModelError("", errorMessage); 
            }

            var petTypes = _petTypeRepository.GetPetTypes();

            ViewBag.PetTypes = petTypes;

            return View(viewModel);
        }



        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                var errorMessage = "Missing pet Id";
                TempData["ErrorMessage"] = errorMessage;
                _logger.LogError(errorMessage);
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new PetAddEditViewModel();

            var pet = _petRepository.GetPet(id.Value);

            if (pet == null)
            {
                var errorMessage = "Unable to find a pet with the Id of " + id;
                TempData["ErrorMessage"] = errorMessage;
                _logger.LogError(errorMessage);
                return RedirectToAction(nameof(Index));
            }

            viewModel.Id = pet.Id;
            viewModel.Name = pet.Name;
            viewModel.PetTypeId = pet.PetType.Id;
            viewModel.DateOfBirth = pet.DateOfBirth;
            viewModel.Weight = pet.Weight;


            var petTypes = _petTypeRepository.GetPetTypes();

            ViewBag.PetTypes = petTypes;

            return View(viewModel);
        }


        [HttpPost]
        //public async Task<IActionResult> Update(PetAddEditViewModel viewModel)
        public IActionResult Edit(PetAddEditViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Does another Pet already exist with the same name and DOB?
                    var existingPets = _petRepository.GetPetsByNameDOB(viewModel.Name, viewModel.DateOfBirth);

                    if ((existingPets != null) && (existingPets.Any(p => p.Id != viewModel.Id))) // If theer are any pets with the same name and DOB as this one
                    {
                        var errorMessage = "Unable to update pet record. Pet with the same Name and Date Of Birth already exists in the system.";
                        // Serialise update pet to JSON and log
                        _logger.LogError(errorMessage + ". Details:" + JsonSerializer.Serialize(viewModel));
                        ModelState.AddModelError("", errorMessage);
                        return View(viewModel);
                    }

                    _petProcessor.Update(viewModel.Id,viewModel.Name, viewModel.PetTypeId, viewModel.DateOfBirth, viewModel.Weight);

                    var successMessage = "Pet successfully updated.";
                    TempData["SuccessMessage"] = successMessage;
                    //await _context.SaveChangesAsync();

                    // Serialise update pet to JSON and log
                    var serialise = JsonSerializer.Serialize(viewModel);
                    _logger.LogInformation(successMessage + ". Details:" + serialise);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var errorMessage = "Unable to update pet record. " + string.Join(" - ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    _logger.LogError(errorMessage);
                    ModelState.AddModelError("", errorMessage);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = "Unable to update pet record. " + ex.Message;
                _logger.LogError(errorMessage);
                ModelState.AddModelError("", errorMessage);
            }

            var petTypes = _petTypeRepository.GetPetTypes();

            ViewBag.PetTypes = petTypes;

            return View(viewModel);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                var errorMessage = "Missing pet Id";
                TempData["ErrorMessage"] = errorMessage;
                _logger.LogError(errorMessage);
                return RedirectToAction(nameof(Index));
            }

            // Get the Pet
            var pet = _petRepository.GetPet(id.Value);

            if (pet == null)
            {
                var errorMessage = "Unable to find a pet with the Id of " + id;
                TempData["ErrorMessage"] = errorMessage;
                _logger.LogError(errorMessage);
                return RedirectToAction(nameof(Index));
            }


            try
            {
                _petProcessor.Delete(pet.Id);
                var successMessage = "Pet successfully deleted.";
                TempData["SuccessMessage"] = successMessage;

                var serialise = JsonSerializer.Serialize(pet);

                _logger.LogInformation(successMessage + ". Details:" + serialise);

            }
            catch (Exception ex)
            {
                var errorMessage = "Unable to delete pet record. " + ex.Message;
                TempData["ErrorMessage"] = errorMessage;
                _logger.LogError(errorMessage);
            }

            return RedirectToAction(nameof(Index));
        }







        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}