﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApplicationAPI.Migrations
{
    /// <inheritdoc />
    public partial class addModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Products");
        }
    }
}
