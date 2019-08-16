using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ikincieloto.Migrations
{
    [Migration(2)]
    public class _002_Ilanlar : Migration
    {
        public override void Down()
        {
            Delete.Table("İlanlar");

            Delete.Table("Kullanıcı_ilan");
        }

        public override void Up()
        {
            Create.Table("İlanlar")
               .WithColumn("id").AsInt32().Identity().PrimaryKey()
               .WithColumn("kullanıcıilanı").AsString(50)
               .WithColumn("marka").AsString(50)
               .WithColumn("modeli").AsString(50)
               .WithColumn("yıl").AsString(20)
               .WithColumn("fiyat").AsString(20)
               .WithColumn("kilometre").AsString(20)
               .WithColumn("yakıt").AsString(30)
               .WithColumn("renk").AsString(30)
               .WithColumn("vites").AsString(20)
               .WithColumn("imagepath").AsString(240)
               .WithColumn("ilantarihi").AsString(20)
               .WithColumn("telefon").AsString(20)
               .WithColumn("Eposta").AsString(20)
               .WithColumn("açıklama").AsString(400);


            Create.Table("Kullanıcı_ilan")
                .WithColumn("kullanıcıid").AsInt32().ForeignKey("Kullanıcı", "id").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("ilanid").AsInt32().ForeignKey("İlanlar", "id").OnDelete(System.Data.Rule.Cascade);

        }
    }
    }
