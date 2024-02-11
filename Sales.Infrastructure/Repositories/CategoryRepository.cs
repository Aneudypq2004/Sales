﻿using Sales.Domain.Entities.Production;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Interfaces;

namespace Sales.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SalesContext context;

        public CategoryRepository(SalesContext context)
        {
            this.context = context;
        }
        public void Create(Category category)
        {
            try
            {
                this.context.Categoria.Add(category);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Category? GetCategory(int id)
        {
            return this.context.Categoria.Find();
        }

        public List<Category> GetCategories()
        {
            return this.context.Categoria.Where(ca => !ca.Eliminado).ToList();
        }

        public void Remove(Category category)
        {
            try
            {
                var CategoryToRemove = this.GetCategory(category.Id);

                CategoryToRemove.Eliminado = true;
                CategoryToRemove.FechaElimino = category.FechaElimino;
                CategoryToRemove.IdUsuarioElimino = category.IdUsuarioElimino;

                this.context.Categoria.Update(CategoryToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Category category)
        {
            try
            {
                var CategoryToUpdate = this.GetCategory(category.Id);

                CategoryToUpdate.Id = category.Id;
                CategoryToUpdate.Descripcion = category.Descripcion;
                CategoryToUpdate.IdUsuarioMod = category.IdUsuarioMod;
                CategoryToUpdate.FechaMod = category.FechaMod;

                this.context.Categoria.Update(CategoryToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
