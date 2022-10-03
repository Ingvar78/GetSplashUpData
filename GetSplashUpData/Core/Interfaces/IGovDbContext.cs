﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetSplashUpData.Database.DB;

using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace GetSplashUpData.Core.Interfaces
{
    public interface IGovDbContext : IDisposable
    {
        
        /// <summary>
        /// Справочник оснований признания процедуры несостоявшейся
        /// </summary>
        DbSet<NsiAbandonedReason> NsiAReasons { get; set; }

        /// <summary>
        /// Справочник: Электронные площадки
        /// </summary>
        DbSet<NsiEtps> NsiEtps { get; set; }

        /// <summary>
        /// Справочник: Способы размещения заказов
        /// </summary>
        DbSet<NsiPlacingWays> NsiPlacingWays { get; set; }

        /// <summary>
        /// Справочник: Организации зарегестрированные в ЕИС
        /// </summary>
        DbSet<NsiOrganizations> NsiOrganizations { get; set; }

        /// <summary>
        /// Все типы извещений по аукционам 44 ФЗ
        /// </summary>
        DbSet<Notifications> Notifications { get; set; }

        /// <summary>
        /// Данные процедур контрактов по 44 ФЗ 
        /// </summary>
        DbSet<Contracts> Contracts { get; set; }

        /// <summary>
        /// Данные протоколов по 44ФЗ
        /// </summary>
        DbSet<Protocols> Protocols { get; set; }
        int SaveChanges();
    }

}
