﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace StuFinanced.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StuFinancedContext : DbContext
    {
        public StuFinancedContext()
            : base("name=StuFinancedContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<SF_AD> SF_AD { get; set; }
        public DbSet<SF_Download> SF_Download { get; set; }
        public DbSet<SF_Notice> SF_Notice { get; set; }
        public DbSet<SF_NoticeCategory> SF_NoticeCategory { get; set; }
        public DbSet<SF_WB_LoginLog> SF_WB_LoginLog { get; set; }
        public DbSet<SF_WB_OperateLog> SF_WB_OperateLog { get; set; }
        public DbSet<SF_Admin> SF_Admin { get; set; }
    }
}
