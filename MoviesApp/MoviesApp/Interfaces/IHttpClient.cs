﻿using MoviesApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Interfaces
{
    public interface IHttpClient
    {
        HttpClient GetClient();
    }
}
