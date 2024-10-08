﻿using Billder.API.Models;

namespace Billder.API.Services.Interfaces
{
    public interface ITrabajoService : IGenericService<Trabajo>
    {
        Task<List<Trabajo>> GetAllCustomerJobsAsync(int customerId);
    }
}
