﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Services.DataService
{
    public interface IDataService
    {
        void Save(JObject obj);
    }
}
