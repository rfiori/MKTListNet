using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKTListNet.Application.Interface;
using MKTListNet.Application.ViewModel;
using MKTListNet.Areas.Admin.Models;
using NuGet.Protocol.Core.Types;

namespace MKTListNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class EmailListController : Controller
    {
        private IEmailListAppService _emailListAppService;
        public EmailListModel emailListModel = new();

        public EmailListController(IEmailListAppService emailListAppService)
        {
            _emailListAppService = emailListAppService;
        }


        public async Task<IActionResult> Index(string? search)
        {
            if (!string.IsNullOrEmpty(search) && search.Length > 2)
            {
                ViewBag.Search = search;
                emailListModel.lstEmailList = _emailListAppService.GetByListName(search);
                return View(emailListModel);
            }
            emailListModel.lstEmailList = await GetAllListAsync();
            return View(emailListModel);
        }

        private Task<IEnumerable<EmailListViewModel>?> GetAllListAsync()
        {
            return _emailListAppService.GetAllAsync();
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

            emailListModel.lstEmailList = GetAllListAsync().Result;
            return View("Index", emailListModel);
        }
    }
}
