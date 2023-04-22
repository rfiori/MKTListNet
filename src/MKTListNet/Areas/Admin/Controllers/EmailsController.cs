using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKTListNet.Application.Interface;

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


        public async Task<IActionResult> Index()
        {
            var lstEmail = await _emailAppService.GetAllAsync();
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
