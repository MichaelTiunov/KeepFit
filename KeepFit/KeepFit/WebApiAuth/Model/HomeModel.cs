using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthentication.Model
{
    public class HomeModel
    {
        public string UserName { get; set; }

        public IEnumerable<ClaimModel> Claims { get; set; }
    }
}