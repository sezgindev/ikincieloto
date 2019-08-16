using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ikincieloto.Migrations
{
    [Migration(1)]
    public class _001_Users_and_Roles : Migration
    {
        public override void Down()
        {
            Delete.Table("kullanıcı");


        }

        public override void Up()
        {
            Create.Table("Kullanıcı")
              .WithColumn("id").AsInt32().Identity().PrimaryKey().NotNullable()
              .WithColumn("ad").AsString(32)
              .WithColumn("soyad").AsString(32)
               .WithColumn("kullanıcıAdı").AsString(32)
              .WithColumn("eposta").AsString(128)
              .WithColumn("telefon").AsString(128)
              .WithColumn("şifre_hash").AsString(256);


            Create.Table("Roller")
                .WithColumn("RolId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("RolAdı").AsString(32);

            Create.Table("Kullanıcı_Rolleri")
                .WithColumn("KullancıId").AsInt32().ForeignKey("Kullanıcı", "id").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("RolId").AsInt32().ForeignKey("Roller", "RolId").OnDelete(System.Data.Rule.Cascade);

        }
    }
}