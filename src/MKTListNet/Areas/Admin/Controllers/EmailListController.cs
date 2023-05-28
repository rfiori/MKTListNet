using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKTListNet.Application.Interface;
using MKTListNet.Domain.Entities;

namespace MKTListNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class EmailListController : Controller
    {
        private IEmailListAppService _emailListAppService;

        public EmailListController(IEmailListAppService emailListAppService)
        {
            _emailListAppService = emailListAppService;
        }


        public async Task<IActionResult> Index(string? search)
        {
            IEnumerable<EmailListViewModel>? elVM;

            if (!string.IsNullOrEmpty(search) && search.Length > 2)
            {
                elVM = _emailListAppService.GetByListName(search);
                return View(elVM);
            }
            elVM = await _emailListAppService.GetAllAsync();
            return View(elVM);
        }
    }
}
