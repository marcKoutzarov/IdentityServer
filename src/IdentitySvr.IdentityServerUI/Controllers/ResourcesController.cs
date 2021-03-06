﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentitySvr.IdentityServerUI.Models;

namespace IdentitySvr.IdentityServerUI.Controllers
{
    public class ResourcesController : Controller
    {  
        public IActionResult Resources()
        {
            var repo = new IdentitySvr.Repositories.ResourceRepo();
            var apis = repo.GetAllApiRecourcesAsync().Result;
            return View(apis);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}