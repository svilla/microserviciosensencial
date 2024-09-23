﻿using Lil.Search.Models;

namespace Lil.Search.Interfaces
{
    public interface ICustomersService
    {
        Task<Customer?> GetAsync(string id);
    }
}
