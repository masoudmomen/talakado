using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talakado.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 907, DateTimeKind.Local).AddTicks(8476),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 603, DateTimeKind.Local).AddTicks(9298));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 907, DateTimeKind.Local).AddTicks(3607),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 603, DateTimeKind.Local).AddTicks(6898));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 905, DateTimeKind.Local).AddTicks(8199),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 602, DateTimeKind.Local).AddTicks(9689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 906, DateTimeKind.Local).AddTicks(7998),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 603, DateTimeKind.Local).AddTicks(4070));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 904, DateTimeKind.Local).AddTicks(8909),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 602, DateTimeKind.Local).AddTicks(5085));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 904, DateTimeKind.Local).AddTicks(2090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 602, DateTimeKind.Local).AddTicks(1747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 901, DateTimeKind.Local).AddTicks(9483),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 601, DateTimeKind.Local).AddTicks(325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 903, DateTimeKind.Local).AddTicks(7315),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 601, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 903, DateTimeKind.Local).AddTicks(2868),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 601, DateTimeKind.Local).AddTicks(6967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 902, DateTimeKind.Local).AddTicks(8623),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 601, DateTimeKind.Local).AddTicks(4797));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 901, DateTimeKind.Local).AddTicks(3485),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 600, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 900, DateTimeKind.Local).AddTicks(2045),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 600, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 900, DateTimeKind.Local).AddTicks(8092),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 600, DateTimeKind.Local).AddTicks(4570));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 603, DateTimeKind.Local).AddTicks(9298),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 907, DateTimeKind.Local).AddTicks(8476));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 603, DateTimeKind.Local).AddTicks(6898),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 907, DateTimeKind.Local).AddTicks(3607));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 602, DateTimeKind.Local).AddTicks(9689),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 905, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 603, DateTimeKind.Local).AddTicks(4070),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 906, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 602, DateTimeKind.Local).AddTicks(5085),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 904, DateTimeKind.Local).AddTicks(8909));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 602, DateTimeKind.Local).AddTicks(1747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 904, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 601, DateTimeKind.Local).AddTicks(325),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 901, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 601, DateTimeKind.Local).AddTicks(9180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 903, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 601, DateTimeKind.Local).AddTicks(6967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 903, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 601, DateTimeKind.Local).AddTicks(4797),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 902, DateTimeKind.Local).AddTicks(8623));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 600, DateTimeKind.Local).AddTicks(7287),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 901, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 600, DateTimeKind.Local).AddTicks(1503),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 900, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 19, 58, 13, 600, DateTimeKind.Local).AddTicks(4570),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 9, 58, 53, 900, DateTimeKind.Local).AddTicks(8092));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 19, 58, 13, 600, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 19, 58, 13, 600, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 19, 58, 13, 600, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 19, 58, 13, 600, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 19, 58, 13, 600, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 19, 58, 13, 602, DateTimeKind.Local).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 19, 58, 13, 602, DateTimeKind.Local).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 19, 58, 13, 602, DateTimeKind.Local).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 19, 58, 13, 602, DateTimeKind.Local).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 19, 58, 13, 602, DateTimeKind.Local).AddTicks(1747));
        }
    }
}
