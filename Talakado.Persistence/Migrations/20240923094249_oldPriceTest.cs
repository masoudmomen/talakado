using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talakado.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class oldPriceTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 623, DateTimeKind.Local).AddTicks(367),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 539, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 622, DateTimeKind.Local).AddTicks(2442),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 538, DateTimeKind.Local).AddTicks(6509));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 620, DateTimeKind.Local).AddTicks(4760),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 537, DateTimeKind.Local).AddTicks(1107));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 621, DateTimeKind.Local).AddTicks(3887),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 538, DateTimeKind.Local).AddTicks(511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 619, DateTimeKind.Local).AddTicks(5421),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 536, DateTimeKind.Local).AddTicks(1309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 618, DateTimeKind.Local).AddTicks(8532),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 535, DateTimeKind.Local).AddTicks(2439));

            migrationBuilder.AlterColumn<float>(
                name: "OldPrice",
                table: "CatalogItems",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 616, DateTimeKind.Local).AddTicks(5359),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 532, DateTimeKind.Local).AddTicks(8232));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 618, DateTimeKind.Local).AddTicks(3588),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 534, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 617, DateTimeKind.Local).AddTicks(9219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 534, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 617, DateTimeKind.Local).AddTicks(4717),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 533, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 615, DateTimeKind.Local).AddTicks(8762),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 532, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 614, DateTimeKind.Local).AddTicks(7036),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 530, DateTimeKind.Local).AddTicks(9749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 615, DateTimeKind.Local).AddTicks(3143),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 531, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 13, 12, 48, 615, DateTimeKind.Local).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 13, 12, 48, 615, DateTimeKind.Local).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 13, 12, 48, 615, DateTimeKind.Local).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 13, 12, 48, 615, DateTimeKind.Local).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 13, 12, 48, 615, DateTimeKind.Local).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 13, 12, 48, 618, DateTimeKind.Local).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 13, 12, 48, 618, DateTimeKind.Local).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 13, 12, 48, 618, DateTimeKind.Local).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 13, 12, 48, 618, DateTimeKind.Local).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 9, 23, 13, 12, 48, 618, DateTimeKind.Local).AddTicks(8532));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 539, DateTimeKind.Local).AddTicks(1367),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 623, DateTimeKind.Local).AddTicks(367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 538, DateTimeKind.Local).AddTicks(6509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 622, DateTimeKind.Local).AddTicks(2442));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 537, DateTimeKind.Local).AddTicks(1107),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 620, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 538, DateTimeKind.Local).AddTicks(511),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 621, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 536, DateTimeKind.Local).AddTicks(1309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 619, DateTimeKind.Local).AddTicks(5421));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 535, DateTimeKind.Local).AddTicks(2439),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 618, DateTimeKind.Local).AddTicks(8532));

            migrationBuilder.AlterColumn<int>(
                name: "OldPrice",
                table: "CatalogItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 532, DateTimeKind.Local).AddTicks(8232),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 616, DateTimeKind.Local).AddTicks(5359));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 534, DateTimeKind.Local).AddTicks(7020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 618, DateTimeKind.Local).AddTicks(3588));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 534, DateTimeKind.Local).AddTicks(2377),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 617, DateTimeKind.Local).AddTicks(9219));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 533, DateTimeKind.Local).AddTicks(7945),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 617, DateTimeKind.Local).AddTicks(4717));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 532, DateTimeKind.Local).AddTicks(1879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 615, DateTimeKind.Local).AddTicks(8762));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 530, DateTimeKind.Local).AddTicks(9749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 614, DateTimeKind.Local).AddTicks(7036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 23, 10, 40, 29, 531, DateTimeKind.Local).AddTicks(6254),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 23, 13, 12, 48, 615, DateTimeKind.Local).AddTicks(3143));

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
    }
}
