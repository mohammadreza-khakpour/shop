using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Migration.Migrations
{
    [Migration(202103171251)]
    public class _202103171251_AddProductEntryWarehouse : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("FK_ProductEntries_Products").OnTable("ProductEntries");
            Delete.ForeignKey("FK_Warehouses_Products").OnTable("Warehouses");
            Delete.Table("ProductEntries");
            Delete.Table("Warehouses");
        }

        public override void Up()
        {
            Create.Table("ProductEntries")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ProductCount").AsInt32().NotNullable()
                .WithColumn("EntryDate").AsDateTime()
                .WithColumn("EntrySerialNumber").AsString(20).Unique()
                .WithColumn("ProductId").AsInt32().ForeignKey("FK_ProductEntries_Products", "Products", "Id")
                .OnDelete(System.Data.Rule.None);

            Create.Table("Warehouses")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ProductCount").AsInt32()
                .WithColumn("ProductId").AsInt32().ForeignKey("FK_Warehouses_Products", "Products", "Id")
                .OnDelete(System.Data.Rule.None);
        }
    }
}
