﻿using Entities.UFP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Cache
{
    public static class LoginCache
    {
        public static string idUser { get; set; }
        public static string nombreUser { get; set; }
        public static List<FamiliaElement> permisos { get; set; }
    }
}
