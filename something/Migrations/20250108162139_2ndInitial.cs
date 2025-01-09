using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

#nullable disable

namespace something.Migrations
{
    /// <inheritdoc />
    public partial class _2ndInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_grants_info",
                table: "grants_info");

            migrationBuilder.AlterColumn<string>(
                name: "grant_name",
                table: "grants_info",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "grant_name_id",
                table: "grants_info",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "year_of_admission",
                table: "facultys",
                type: "integer",
                nullable: false,
                oldClrType: typeof(NpgsqlRange<DateTime>),
                oldType: "tstzrange");

            migrationBuilder.AddPrimaryKey(
                name: "PK_grants_info",
                table: "grants_info",
                column: "grant_name_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_grants_info",
                table: "grants_info");

            migrationBuilder.DropColumn(
                name: "grant_name_id",
                table: "grants_info");

            migrationBuilder.AlterColumn<string>(
                name: "grant_name",
                table: "grants_info",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<NpgsqlRange<DateTime>>(
                name: "year_of_admission",
                table: "facultys",
                type: "tstzrange",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_grants_info",
                table: "grants_info",
                column: "grant_name");
        }
    }
}
