﻿using GetSplashUpData.Core.Interfaces;
using GetSplashUpData.Database.DB;
using GetSplashUpData.Database.Extention;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetSplashUpData.Core.Context
{
    internal class AimDbContext : DbContext, IGovDbContext
    {
        private readonly string _connectionString;
        private readonly ILoggerFactory _loggerFactory;
        public AimDbContext(string connectionString, ILoggerFactory loggerFactory)
        {
            _connectionString = connectionString;
            _loggerFactory = loggerFactory;
        }


        public AimDbContext(DbContextOptions<AimDbContext> options)
        : base(options)
        {
            //For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
        }

        //public GovDbContext()
        //{
        //    //Для миграции   
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if true && DEBUG
            optionsBuilder.UseLoggerFactory(_loggerFactory);
#endif
            optionsBuilder.UseNpgsql("Host=192.168.7.15;Port=5432;Database=AimDbtest;Username=zak;Password=Zaq1Xsw2;Pooling=True;ApplicationName=test").UseSnakeCaseNamingConvention();
            
            //optionsBuilder.UseNpgsql(_connectionString).UseSnakeCaseNamingConvention(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.UsePostgresConventions();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<NsiAbandonedReason> NsiAReasons { get; set; }
        public DbSet<NsiEtps> NsiEtps { get; set; }

        public DbSet<NsiPlacingWays> NsiPlacingWays { get; set; }
        public DbSet<NsiOrganizations> NsiOrganizations { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Contracts> Contracts { get; set; }
        public DbSet<Protocols> Protocols { get; set; }

        public DbSet<ContractProject> ContractProjects { get; set; }
        int IGovDbContext.SaveChanges()
        {
            return this.SaveChangesInternal();
        }

        private int SaveChangesInternal()
        {
            var result = base.SaveChanges();
            return result;
        }

    }
}
