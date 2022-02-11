﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace G9L.Data.Migrations
{
    public partial class Intal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Export",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsExport = table.Column<int>(type: "int", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Export", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExportDetails",
                columns: table => new
                {
                    ExportID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportDetails", x => new { x.ExportID, x.ProductID });
                });

            migrationBuilder.CreateTable(
                name: "Import",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderID = table.Column<int>(type: "int", nullable: false),
                    ImportDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Import", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ImportDetails",
                columns: table => new
                {
                    ImportID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantily = table.Column<int>(type: "int", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsUnit = table.Column<int>(type: "int", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportDetails", x => new { x.ImportID, x.ProductID });
                });

            migrationBuilder.CreateTable(
                name: "Manufacture",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacture", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ManufactureOfProduct",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ManufactureID = table.Column<int>(type: "int", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufactureOfProduct", x => new { x.ProductID, x.ManufactureID });
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufactureID = table.Column<int>(type: "int", nullable: false),
                    Quantily = table.Column<int>(type: "int", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StorageLocations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Export");

            migrationBuilder.DropTable(
                name: "ExportDetails");

            migrationBuilder.DropTable(
                name: "Import");

            migrationBuilder.DropTable(
                name: "ImportDetails");

            migrationBuilder.DropTable(
                name: "Manufacture");

            migrationBuilder.DropTable(
                name: "ManufactureOfProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Provider");
        }
    }
}
