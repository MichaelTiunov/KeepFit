using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeepFit.Core.Services;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    public class CalculationController : BaseController
    {
        // GET: Calculation
        public CalculationController(IAccountService accountService, IIdentityService identityService) : base(accountService, identityService)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}