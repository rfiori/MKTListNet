using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKTListNet.Application.Interface;

namespace MKTListNet.Areas.Admin.Controllers
{
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
            var ret = 0;
            if (string.IsNullOrEmpty(emails))
                return View(ret);

            var lstE = emails.Replace("\r\n", ";").Split(';').ToList<string>();
            ret = _emailAppService.AddBulk(lstE);
            return View(ret);
        }
    }
}
