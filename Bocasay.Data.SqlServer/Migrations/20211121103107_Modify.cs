using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bocasay.Data.SqlServer.Migrations
{
    public partial class Modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoleMaps",
                keyColumn: "ID",
                keyValue: new Guid("600fad5b-d9cb-469f-a165-708677289506"));

            migrationBuilder.DeleteData(
                table: "UserRoleMaps",
                keyColumn: "ID",
                keyValue: new Guid("688fad5b-d9cb-469f-a165-708677289506"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("6a4fad5b-d9cb-469f-a165-708677289506"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("6f8fad5b-d9cb-469f-a165-708677289506"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("6f8fad5b-d9cb-469f-a165-70867728950e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("6f8fad5b-d9cb-469f-a165-70867728ab56"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "ModifiedBy", "ModifiedDate", "RoleCategory", "RoleCode" },
                values: new object[,]
                {
                    { new Guid("6f8fad5b-d9cb-469f-a165-708677289506"), null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", false, null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Admin" },
                    { new Guid("6a4fad5b-d9cb-469f-a165-708677289506"), null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viewer", false, null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Viewer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "Company", "CreatedBy", "CreatedDate", "Email", "FullName", "IsDeleted", "ModifiedBy", "ModifiedDate", "Role" },
                values: new object[,]
                {
                    { new Guid("6f8fad5b-d9cb-469f-a165-70867728950e"), "1A - HHT st", null, null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Davidtommy.bocasy.com", "David Tommy", false, null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("6f8fad5b-d9cb-469f-a165-70867728ab56"), "13B - HHT st", null, null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sakcaphonel.bocasy.com", "Sakca Phonel", false, null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "UserRoleMaps",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "RoleID", "UserID" },
                values: new object[] { new Guid("688fad5b-d9cb-469f-a165-708677289506"), null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f8fad5b-d9cb-469f-a165-708677289506"), new Guid("6f8fad5b-d9cb-469f-a165-70867728950e") });

            migrationBuilder.InsertData(
                table: "UserRoleMaps",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "RoleID", "UserID" },
                values: new object[] { new Guid("600fad5b-d9cb-469f-a165-708677289506"), null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6a4fad5b-d9cb-469f-a165-708677289506"), new Guid("6f8fad5b-d9cb-469f-a165-70867728ab56") });
        }
    }
}
