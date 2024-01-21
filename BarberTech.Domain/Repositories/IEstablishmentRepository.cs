﻿using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IEstablishmentRepository : IRepository<Establishment>
    {
        Task<Establishment> GetByIdWithBarbersAsync(Guid id);
    }
}
