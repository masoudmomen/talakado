using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talakado.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditOldPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 816, DateTimeKind.Local).AddTicks(3798),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 907, DateTimeKind.Local).AddTicks(8476));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 815, DateTimeKind.Local).AddTicks(9075),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 907, DateTimeKind.Local).AddTicks(3607));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 814, DateTimeKind.Local).AddTicks(4209),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 905, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 815, DateTimeKind.Local).AddTicks(3336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 906, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 813, DateTimeKind.Local).AddTicks(4292),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 904, DateTimeKind.Local).AddTicks(8909));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 812, DateTimeKind.Local).AddTicks(7317),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 904, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 810, DateTimeKind.Local).AddTicks(3952),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 901, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 812, DateTimeKind.Local).AddTicks(2339),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 903, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 811, DateTimeKind.Local).AddTicks(7773),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 903, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 811, DateTimeKind.Local).AddTicks(3415),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 902, DateTimeKind.Local).AddTicks(8623));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 809, DateTimeKind.Local).AddTicks(7337),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 901, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 808, DateTimeKind.Local).AddTicks(5447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 900, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 809, DateTimeKind.Local).AddTicks(1780),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 900, DateTimeKind.Local).AddTicks(8092));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 907, DateTimeKind.Local).AddTicks(8476),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 816, DateTimeKind.Local).AddTicks(3798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 907, DateTimeKind.Local).AddTicks(3607),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 815, DateTimeKind.Local).AddTicks(9075));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 905, DateTimeKind.Local).AddTicks(8199),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 814, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 906, DateTimeKind.Local).AddTicks(7998),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 815, DateTimeKind.Local).AddTicks(3336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 904, DateTimeKind.Local).AddTicks(8909),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 813, DateTimeKind.Local).AddTicks(4292));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 904, DateTimeKind.Local).AddTicks(2090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 812, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 901, DateTimeKind.Local).AddTicks(9483),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 810, DateTimeKind.Local).AddTicks(3952));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 903, DateTimeKind.Local).AddTicks(7315),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 812, DateTimeKind.Local).AddTicks(2339));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 903, DateTimeKind.Local).AddTicks(2868),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 811, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 902, DateTimeKind.Local).AddTicks(8623),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 811, DateTimeKind.Local).AddTicks(3415));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 901, DateTimeKind.Local).AddTicks(3485),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 809, DateTimeKind.Local).AddTicks(7337));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 900, DateTimeKind.Local).AddTicks(2045),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 808, DateTimeKind.Local).AddTicks(5447));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 900, DateTimeKind.Local).AddTicks(8092),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 18, 7, 809, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 9, 58, 53, 901, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 9, 58, 53, 901, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 9, 58, 53, 901, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 9, 58, 53, 901, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 9, 58, 53, 901, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 9, 58, 53, 904, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 9, 58, 53, 904, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 9, 58, 53, 904, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 9, 58, 53, 904, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 9, 58, 53, 904, DateTimeKind.Local).AddTicks(2090));
        }
    }
}
