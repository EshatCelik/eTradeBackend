﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Abstract.Storage
{
    public interface IStorage
    {
        Task<List<(string fileName, string pathOrContainerNane)>> UploadAsync(string pathOrContainerName, IFormFileCollection fileCollection);
        Task DeleteAsync(string pathOrContainerName, string fileName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}
