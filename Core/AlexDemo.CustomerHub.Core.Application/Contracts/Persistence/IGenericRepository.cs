﻿using AlexDemo.CustomerHub.Core.Entities;

namespace AlexDemo.CustomerHub.Core.Application.Contracts.Persistence
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
        /// method to ensure that Entity with provided Id has not deleted status (or other validation rules) ie available in the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> CheckExistAndValid(TId id);

        Task<IReadOnlyList<T>> GetAll();

        Task<T> Create(T entity);

        Task Update(T entity);

        /// <summary>
        /// this is a physical delete operation : only use it if you understand the logic behind
        /// for logical delete please use DeleteById method
        /// </summary>
        /// <param name="entity">entity to physically remove from data layer</param>
        /// <returns></returns>
        Task HardDelete(T entity);

        Task DeleteById(TId entity);
    }
}
