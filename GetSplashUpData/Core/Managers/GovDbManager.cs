﻿using GetSplashUpData.Core.Interfaces;
using GetSplashUpData.Configurations;
using Microsoft.Extensions.Options;

namespace GetSplashUpData.Core.Managers
{
    internal class GovDbManager : IGovDbManager
    {
        private readonly string _govDbConnectionString;
        private readonly ILoggerFactory _loggerFactory;
        public GovDbManager(IOptions<ConnectionStrings> settings, ILoggerFactory loggerFactory)
        {
            _govDbConnectionString = settings.Value.ConnectionGDB;
            _loggerFactory = loggerFactory;
        }

        void IDbManager.InitDb()
        {
            DbContextManager.InitGovDb(_govDbConnectionString, _loggerFactory);
        }
        public IGovDbContext GetContext()
        {
            return DbContextManager.CreateGovContext(_govDbConnectionString, _loggerFactory);
        }

    }
}
