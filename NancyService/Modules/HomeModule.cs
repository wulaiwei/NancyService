using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace NancyService.Modules
{
    public class HomeModule : NancyModule
    {

        public HomeModule()
        {
            Get["/"] = _ => View["/home"];
        }
    }
}