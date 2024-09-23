using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talakado.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditOldPrice1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 539, DateTimeKind.Local).AddTicks(1367),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 816, DateTimeKind.Local).AddTicks(3798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 538, DateTimeKind.Local).AddTicks(6509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 815, DateTimeKind.Local).AddTicks(9075));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 537, DateTimeKind.Local).AddTicks(1107),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 814, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 538, DateTimeKind.Local).AddTicks(511),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 815, DateTimeKind.Local).AddTicks(3336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 536, DateTimeKind.Local).AddTicks(1309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 813, DateTimeKind.Local).AddTicks(4292));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 535, DateTimeKind.Local).AddTicks(2439),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 812, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 532, DateTimeKind.Local).AddTicks(8232),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 810, DateTimeKind.Local).AddTicks(3952));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 534, DateTimeKind.Local).AddTicks(7020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 812, DateTimeKind.Local).AddTicks(2339));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 534, DateTimeKind.Local).AddTicks(2377),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 811, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 533, DateTimeKind.Local).AddTicks(7945),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 811, DateTimeKind.Local).AddTicks(3415));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 532, DateTimeKind.Local).AddTicks(1879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 809, DateTimeKind.Local).AddTicks(7337));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 530, DateTimeKind.Local).AddTicks(9749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 808, DateTimeKind.Local).AddTicks(5447));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 531, DateTimeKind.Local).AddTicks(6254),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 809, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 40, 29, 532, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 40, 29, 532, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 40, 29, 532, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 40, 29, 532, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 40, 29, 532, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 40, 29, 535, DateTimeKind.Local).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 40, 29, 535, DateTimeKind.Local).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 40, 29, 535, DateTimeKind.Local).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 40, 29, 535, DateTimeKind.Local).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 40, 29, 535, DateTimeKind.Local).AddTicks(2439));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 816, DateTimeKind.Local).AddTicks(3798),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 539, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 815, DateTimeKind.Local).AddTicks(9075),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 538, DateTimeKind.Local).AddTicks(6509));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 814, DateTimeKind.Local).AddTicks(4209),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 537, DateTimeKind.Local).AddTicks(1107));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 815, DateTimeKind.Local).AddTicks(3336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 538, DateTimeKind.Local).AddTicks(511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 813, DateTimeKind.Local).AddTicks(4292),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 536, DateTimeKind.Local).AddTicks(1309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 812, DateTimeKind.Local).AddTicks(7317),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 535, DateTimeKind.Local).AddTicks(2439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 810, DateTimeKind.Local).AddTicks(3952),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 532, DateTimeKind.Local).AddTicks(8232));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 812, DateTimeKind.Local).AddTicks(2339),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 534, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 811, DateTimeKind.Local).AddTicks(7773),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 534, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 811, DateTimeKind.Local).AddTicks(3415),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 533, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 809, DateTimeKind.Local).AddTicks(7337),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 532, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 808, DateTimeKind.Local).AddTicks(5447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 530, DateTimeKind.Local).AddTicks(9749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 809, DateTimeKind.Local).AddTicks(1780),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 531, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 18, 7, 809, DateTimeKind.Local).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 18, 7, 809, DateTimeKind.Local).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 18, 7, 809, DateTimeKind.Local).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 18, 7, 809, DateTimeKind.Local).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 18, 7, 809, DateTimeKind.Local).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 18, 7, 812, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 18, 7, 812, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 18, 7, 812, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 18, 7, 812, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 10, 18, 7, 812, DateTimeKind.Local).AddTicks(7317));
        }
    }
}
