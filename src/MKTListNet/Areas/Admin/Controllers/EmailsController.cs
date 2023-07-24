using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKTListNet.Application.Interface;
using MKTListNet.Application.ViewModel;
using MKTListNet.Areas.Admin.Models;
using MKTListNet.Domain.Interface.Repository;
using System.Collections.ObjectModel;

namespace MKTListNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class EmailsController : Controller
    {
        private readonly IEmailAppService _emailAppService;
        private readonly IEmailListAppService _emailListAppService;
        private readonly IEmailEmailListAppServive _emailEmlLstAppServive;

        public EmailsController(IEmailAppService emailAppService, IEmailListAppService emailListAppService, IEmailEmailListAppServive emailEmlLstAppService)
        {
            _emailAppService = emailAppService;
            _emailListAppService = emailListAppService;
            _emailEmlLstAppServive = emailEmlLstAppService;
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


        internal IEnumerable<EmailListDataModel>? ConvertToListDataModel(IEnumerable<EmailListViewModel>? lst)
        {
            if (lst == null)
                return null;

            var ret = new Collection<EmailListDataModel>();
            foreach (var i in lst)
            {
                var t = _emailEmlLstAppServive.GetByEmailListId(i.id)!.Count();
                ret.Add(new EmailListDataModel { Id = i.id, Name = i.Name, Type = i.Type, totalEmailCount = t });
            }

            return ret;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExportEmails(string? emails)
        {
            if (emails != null)
                ViewBag.lstEmails = emails;

            var model = new EmailListModel() { EmailLists = ConvertToListDataModel(_emailListAppService.GetAllAsync().Result) };

            return View("AddEmails", model);
        }

        public IActionResult AddEmails()
        {
            var model = new EmailListModel() { EmailLists = ConvertToListDataModel(_emailListAppService.GetAllAsync().Result) };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmails(string emails, int? idList)
        {
            var retModel = new EmailListModel();

            if (string.IsNullOrEmpty(emails))
                return View(retModel);

            var lstEmail = emails.Trim().Replace("\r\n", ";").Split(';').ToList<string>();

            retModel.RetAddEmail!.EmailAdd = await _emailAppService.AddBulkAsync(lstEmail, idList);

            retModel.RetAddEmail.EmailReject = lstEmail.Count - retModel.RetAddEmail.EmailAdd;

            return View(retModel);
        }
    }
}
