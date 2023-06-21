using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKTListNet.Application.Interface;
using MKTListNet.Application.ViewModel;
using MKTListNet.Domain.Interface.Repository;

namespace MKTListNet.Areas.Admin.Controllers
{
    public record RetAddEmail
    {
        public int EmailAdd { get; set; }
        public int EmailReject { get; set; }
    }

    //---------------------------------------------------------------------------//

    [Area("Admin")]
    [Authorize()]
    public class EmailsController : Controller
    {
        private readonly IEmailAppService _emailAppService;

        public EmailsController(IEmailAppService emailAppService)
        {
            _emailAppService = emailAppService;
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

        public IActionResult AddEmails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmails(string emails)
        {
            var ret = new RetAddEmail();

            if (string.IsNullOrEmpty(emails))
                return View(ret);

            var lstEmail = emails.Replace("\r\n", ";").Split(';').ToList<string>();
            ret.EmailAdd = await _emailAppService.AddBulkAsync(lstEmail);
            ret.EmailReject = lstEmail.Count - ret.EmailAdd;

            return View(ret);
        }
    }
}
