﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResources.Web.Migrations
{
    /// <inheritdoc />
    public partial class RelateEmpDep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
