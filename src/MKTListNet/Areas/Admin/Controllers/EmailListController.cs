using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKTListNet.Application.Interface;
using MKTListNet.Application.ViewModel;
using MKTListNet.Areas.Admin.Models;
using System.Collections.ObjectModel;
using System.Security.AccessControl;

namespace MKTListNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class EmailListController : Controller
    {
        private IEmailListAppService _emailListAppService;
        private IEmailEmailListAppServive _emailEmlLstAppServive;

        internal EmailListModel emailListModel = new();

        public EmailListController(IEmailListAppService emailListAppService, IEmailEmailListAppServive emailEmlLstAppServive)
        {
            _emailListAppService = emailListAppService;
            _emailEmlLstAppServive = emailEmlLstAppServive;
        }


        public async Task<IActionResult> Index(string? search)
        {
            if (!string.IsNullOrEmpty(search) && search.Length > 2)
            {
                ViewBag.Search = search;
                emailListModel.EmailLists = ConvertToListDataModel(_emailListAppService.GetByListName(search)!);
                return View(emailListModel);
            }
            emailListModel.EmailLists = ConvertToListDataModel(await GetAllListAsync());
            return View(emailListModel);
        }

        private Task<IEnumerable<EmailListViewModel>?> GetAllListAsync()
        {
            return _emailListAppService.GetAllAsync();
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
        public IActionResult NewList(string newList)
        {
            if (string.IsNullOrEmpty(newList))
            {
                emailListModel.ViewMSG = "Não foi informado o nome da lista";
            }
            else
            {
                _emailListAppService.Add(new EmailListViewModel { Name = newList });
            }

            emailListModel.EmailLists = ConvertToListDataModel(GetAllListAsync().Result);
            return View("Index", emailListModel);
        }
    }
}
