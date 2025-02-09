﻿using Core.Repositories.EntityFramework.Abstract;
using Core.Repositories.EntityFramework.Concrete;
using QuizApp.Repositories.EntityFramework.Abstract;
using QuizApp.Repositories.EntityFramework.Concrete.Contexts;
using QuizApp.Repositories.EntityFramework.Concrete.Repositories;

namespace QuizApp.Repositories.EntityFramework.Concrete.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizContext _quizContext;

        #region Costume Repositories
        public IAppUserRepositories AppUserRepositories => new EfAppUserRepositories(_quizContext);
        #endregion
        
        public UnitOfWork(QuizContext quizContext)
        {
            _quizContext = quizContext;
        }


        public int SaveChanges()
        {
            return _quizContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _quizContext.SaveChangesAsync();
        }

        IEfGenericRepositories<T> IUnitOfWork.GetGenericRepositories<T>(T Entity)
        {
            return new EfGenericRepositories<T>(_quizContext);
        }
    }
}
