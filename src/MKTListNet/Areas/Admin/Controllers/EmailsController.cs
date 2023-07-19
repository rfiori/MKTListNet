using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKTListNet.Application.Interface;
using MKTListNet.Application.ViewModel;
using MKTListNet.Areas.Admin.Models;
using MKTListNet.Domain.Interface.Repository;

namespace MKTListNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class EmailsController : Controller
    {
        private readonly IEmailAppService _emailAppService;
        private readonly IEmailListAppService _emailListAppService;

        public EmailsController(IEmailAppService emailAppService, IEmailListAppService emailListAppService)
        {
            _emailAppService = emailAppService;
            _emailListAppService = emailListAppService;
        }


        public async Task<IActionResult> Index(string? search, int pageSize, int page)
        {
            IPagingResult<EmailViewModel>? lstEmail;

            if (!string.IsNullOrEmpty(search) && search.Length > 2)
            {
                ViewBag.Search = search;
                lstEmail = _emailAppService.GetEmails(search.ToLower(), pageSize, page);
                return View(lstEmail);
            }

            lstEmail = await _emailAppService.GetAllPagingAsync(100, page);
            return View(lstEmail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExportEmails(string? emails)
        {
            if (emails != null)
                ViewBag.lstEmails = emails;
            return View("AddEmails");
        }

        public IActionResult AddEmails()
        {
            var model = new EmailListModel() { EmailLists = _emailListAppService.GetAllAsync().Result };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmails(string emails)
        {
            var retModel = new EmailListModel();

            if (string.IsNullOrEmpty(emails))
                return View(retModel);

            var lstEmail = emails.Trim().Replace("\r\n", ";").Split(';').ToList<string>();
            retModel.RetAddEmail!.EmailAdd = await _emailAppService.AddBulkAsync(lstEmail);
            retModel.RetAddEmail.EmailReject = lstEmail.Count - retModel.RetAddEmail.EmailAdd;

            return View(retModel);
        }
    }
}
