using System;
using System.Collections.Generic;
using System.Text;

namespace GetSplashUpData.Configurations
{
    public class ConnectionStrings
    {
        /// <summary>
        /// Настройки подключения к БД
        /// </summary>
        /// 
        public string DefaultConnection { get; set; }

        /// <summary>
        /// Основная БД
        /// </summary>
        public string ConnectionGDB { get; set; }
    }
}
