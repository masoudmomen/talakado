using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talakado.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 420, DateTimeKind.Local).AddTicks(6933),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 917, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 420, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 420, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 419, DateTimeKind.Local).AddTicks(8140),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 917, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 418, DateTimeKind.Local).AddTicks(9083),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 916, DateTimeKind.Local).AddTicks(1364));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 419, DateTimeKind.Local).AddTicks(4951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 916, DateTimeKind.Local).AddTicks(9596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 419, DateTimeKind.Local).AddTicks(2534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 916, DateTimeKind.Local).AddTicks(6856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 418, DateTimeKind.Local).AddTicks(6326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 915, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 418, DateTimeKind.Local).AddTicks(1165),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 914, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 418, DateTimeKind.Local).AddTicks(3637),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 915, DateTimeKind.Local).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 7, 15, 19, 0, 40, 418, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 7, 15, 19, 0, 40, 418, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 7, 15, 19, 0, 40, 418, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 7, 15, 19, 0, 40, 418, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 7, 15, 19, 0, 40, 418, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 7, 15, 19, 0, 40, 419, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 7, 15, 19, 0, 40, 419, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 7, 15, 19, 0, 40, 419, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 7, 15, 19, 0, 40, 419, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 7, 15, 19, 0, 40, 419, DateTimeKind.Local).AddTicks(8140));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "OrderItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 917, DateTimeKind.Local).AddTicks(5930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 420, DateTimeKind.Local).AddTicks(6933));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 917, DateTimeKind.Local).AddTicks(2851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 419, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 916, DateTimeKind.Local).AddTicks(1364),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 418, DateTimeKind.Local).AddTicks(9083));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 916, DateTimeKind.Local).AddTicks(9596),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 419, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 916, DateTimeKind.Local).AddTicks(6856),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 419, DateTimeKind.Local).AddTicks(2534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 915, DateTimeKind.Local).AddTicks(6849),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 418, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 914, DateTimeKind.Local).AddTicks(8040),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 418, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 13, 18, 39, 37, 915, DateTimeKind.Local).AddTicks(2231),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 15, 19, 0, 40, 418, DateTimeKind.Local).AddTicks(3637));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 7, 13, 18, 39, 37, 915, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 7, 13, 18, 39, 37, 915, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 7, 13, 18, 39, 37, 915, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 7, 13, 18, 39, 37, 915, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 7, 13, 18, 39, 37, 915, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 7, 13, 18, 39, 37, 917, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 7, 13, 18, 39, 37, 917, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 7, 13, 18, 39, 37, 917, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 7, 13, 18, 39, 37, 917, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 7, 13, 18, 39, 37, 917, DateTimeKind.Local).AddTicks(2851));
        }
    }
}
