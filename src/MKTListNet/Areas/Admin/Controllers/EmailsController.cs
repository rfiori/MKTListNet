using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKTListNet.Application.AppViewModel;
using MKTListNet.Application.Interface;
using MKTListNet.Areas.Admin.Models;
using NUglify.Helpers;
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


        public IActionResult Index(string? search, int pageSize = 100, int page = 1, int codEmailList = 1)
        {
            var retLstEmail = new EmailModel();

            _emailListAppService.GetAllAsync().Result.ForEach(
                    x => retLstEmail?.EmailListDM.Add(
                    new EmailListDataModel()
                    {
                        EmailList = x
                    })
                );
            retLstEmail.EmailListSelected = codEmailList;

            if (!string.IsNullOrEmpty(search) && search.Length > 2)
            {
                retLstEmail.SearchData = search;
                retLstEmail.PagingReult = _emailAppService.GetEmails(search.ToLower(), codEmailList, pageSize, page);
                return View(retLstEmail);
            }

            retLstEmail.PagingReult = _emailAppService.GetEmails("", codEmailList, 100, page);
            return View(retLstEmail);
        }


        internal IEnumerable<EmailListDataModel>? NewEmailListDataModel()
        {
            var lst = _emailListAppService.GetAllAsync().Result;

            if (lst == null)
                return null;

            var ret = new Collection<EmailListDataModel>();
            foreach (var i in lst)
            {
                var t = _emailEmlLstAppServive.GetByEmailListId(i.Id)!.Count();
                ret.Add(new EmailListDataModel
                {
                    EmailList = new EmailListViewModel { Id = i.Id, Name = i.Name, Type = i.Type },
                    TotalEmailCount = t
                });
            }

            return ret;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExportEmails(string? emails)
        {
            if (emails != null)
                ViewBag.lstEmails = emails;

            var model = new EmailListModel() { EmailLists = NewEmailListDataModel() };

            return View("AddEmails", model);
        }

        public IActionResult AddEmails()
        {
            var model = new EmailListModel() { EmailLists = NewEmailListDataModel() };
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
