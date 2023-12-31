﻿using Domain.Interfaces.Data;

namespace Infra.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonalFinanceDbContext _db;

        public UnitOfWork(PersonalFinanceDbContext posterrDb)
        {
            this._db = posterrDb;
        }

        public async Task BeginTransactionAsync()
        {
            if (_db.Database.CurrentTransaction == null)
                await _db.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_db.Database.CurrentTransaction != null)
                await _db.Database.CommitTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            if (_db.Database.CurrentTransaction != null)
                await _db.Database.RollbackTransactionAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
