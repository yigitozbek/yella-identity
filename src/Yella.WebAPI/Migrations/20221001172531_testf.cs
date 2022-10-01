using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yella.WebAPI.Migrations
{
    public partial class testf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "Identity",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "Identity",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "Identity",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "Identity",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "Identity",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "Identity",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "Identity",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "Identity",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "Identity",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "Identity",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "Identity",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "Identity",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "Identity",
                table: "IdentityUserRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "Identity",
                table: "IdentityUserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "Identity",
                table: "IdentityUserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "Identity",
                table: "IdentityUserRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "IdentityUserRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "Identity",
                table: "IdentityUserRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "Identity",
                table: "IdentityUserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "Identity",
                table: "IdentityPermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "Identity",
                table: "IdentityPermissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "Identity",
                table: "IdentityPermissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "Identity",
                table: "IdentityPermissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "IdentityPermissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "Identity",
                table: "IdentityPermissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "Identity",
                table: "IdentityPermissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "Identity",
                table: "IdentityPermissionRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "Identity",
                table: "IdentityPermissionRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "Identity",
                table: "IdentityPermissionRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "Identity",
                table: "IdentityPermissionRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "IdentityPermissionRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "Identity",
                table: "IdentityPermissionRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "Identity",
                table: "IdentityPermissionRoles",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                schema: "Identity",
                table: "IdentityUserRoles");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                schema: "Identity",
                table: "IdentityUserRoles");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                schema: "Identity",
                table: "IdentityUserRoles");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "Identity",
                table: "IdentityUserRoles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Identity",
                table: "IdentityUserRoles");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "Identity",
                table: "IdentityUserRoles");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                schema: "Identity",
                table: "IdentityUserRoles");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                schema: "Identity",
                table: "IdentityPermissions");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                schema: "Identity",
                table: "IdentityPermissions");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                schema: "Identity",
                table: "IdentityPermissions");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "Identity",
                table: "IdentityPermissions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Identity",
                table: "IdentityPermissions");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "Identity",
                table: "IdentityPermissions");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                schema: "Identity",
                table: "IdentityPermissions");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                schema: "Identity",
                table: "IdentityPermissionRoles");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                schema: "Identity",
                table: "IdentityPermissionRoles");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                schema: "Identity",
                table: "IdentityPermissionRoles");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "Identity",
                table: "IdentityPermissionRoles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Identity",
                table: "IdentityPermissionRoles");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "Identity",
                table: "IdentityPermissionRoles");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                schema: "Identity",
                table: "IdentityPermissionRoles");
        }
    }
}
