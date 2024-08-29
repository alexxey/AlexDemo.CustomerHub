using AlexDemo.CustomerHub.Presentation.WebUI.Contracts.Customer;
using AlexDemo.CustomerHub.Presentation.WebUI.Models.ViewModels.Customer.Company;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        // GET: CompanyController
        public async Task<ActionResult> Index()
        {
            var model = await _companyService.GetList();

            return View(model);
        }

        // GET: CompanyController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _companyService.GetDetailsById(id);

            return View(model);
        }

        // GET: CompanyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCompanyVm createCompanyVm)
        {
            try
            {
                var response = await _companyService.CreateCompany(createCompanyVm);
                if (response.IsSuccessful)
                {
                    return RedirectToAction(nameof(Details), new { id = response.Data });
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

        // GET: CompanyController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var companyDetailsDto = await _companyService.GetDtoDetailsById(id);
            UpdateCompanyVm updateVm = _mapper.Map<UpdateCompanyVm>(companyDetailsDto);

            return View(updateVm);
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateCompanyVm updateCompanyVm)
        {
            try
            {
                var response = await _companyService.UpdateCompany(id, updateCompanyVm);
                if (response.IsSuccessful)
                {
                    return RedirectToAction(nameof(Details), new { id = response.Data });
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

        // POST: CompanyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var deleteResponse = await _companyService.DeleteCompany(id);
                if (deleteResponse.IsSuccessful)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", deleteResponse.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return BadRequest();
        }
    }
}
