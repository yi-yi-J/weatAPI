using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WeatAPImodels.WeatAPIEntities
{
    public partial class WContext:DbContext
    {
        public WContext()
        { 
        }
        public WContext(DbContextOptions<WContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        
        public static string ConStr { get; set; }//用于接收数据库连接字符串
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConStr);//设置数据库连接字符串
            }
        }
        


    }
}
