﻿using AlexDemo.CustomerHub.Core.Entities;

namespace AlexDemo.CustomerHub.Core.Application.Persistence.Contracts
{
    public interface IGenericRepository<T, TId> where T : BaseEntity
    {
        /// <summary>
        /// method to return entity's metadata
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetById(TId id);

        /// <summary>
        /// method to ensure that Entity with provided Id and not deleted status (or other validation rules) ie available in the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> CheckExistAndValid(TId id);

        Task<IReadOnlyList<T>> GetAll();

        Task<T> Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task DeleteById(TId entity);
    }
}
