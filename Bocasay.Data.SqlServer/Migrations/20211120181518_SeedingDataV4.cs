using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bocasay.Data.SqlServer.Migrations
{
    public partial class SeedingDataV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoleMaps",
                keyColumn: "ID",
                keyValue: new Guid("699fad5b-d9cb-469f-a165-708677289506"));

            migrationBuilder.UpdateData(
                table: "UserRoleMaps",
                keyColumn: "ID",
                keyValue: new Guid("600fad5b-d9cb-469f-a165-708677289506"),
                column: "RoleID",
                value: new Guid("6a4fad5b-d9cb-469f-a165-708677289506"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserRoleMaps",
                keyColumn: "ID",
                keyValue: new Guid("600fad5b-d9cb-469f-a165-708677289506"),
                column: "RoleID",
                value: new Guid("6f8fad5b-d9cb-469f-a165-708677289506"));

            migrationBuilder.InsertData(
                table: "UserRoleMaps",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "RoleID", "UserID" },
                values: new object[] { new Guid("699fad5b-d9cb-469f-a165-708677289506"), null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6a4fad5b-d9cb-469f-a165-708677289506"), new Guid("6f8fad5b-d9cb-469f-a165-70867728950e") });
        }
    }
}
