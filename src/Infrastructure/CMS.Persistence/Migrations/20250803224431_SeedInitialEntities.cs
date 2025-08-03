using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Doctor", "DOCTOR" },
                    { 3, null, "Receptionist", "RECEPTIONIST" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LastModifiedAt", "LastModifiedBy", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 1, 13, 0, 0, 0, DateTimeKind.Utc), null, "كشف أولي", null, null, "كشف", 100.00m },
                    { 2, new DateTime(2025, 8, 1, 13, 0, 0, 0, DateTimeKind.Utc), null, "جلسة متابعة", null, null, "متابعه", 50.00m },
                    { 3, new DateTime(2025, 8, 1, 13, 0, 0, 0, DateTimeKind.Utc), null, "استشارة طبية", null, null, "استشاره", 75.00m }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "أطفال" },
                    { 2, "أمراض الجلد والشعر", "جلدية" },
                    { 3, null, "باطنة" },
                    { 4, "أمراض القلب والأوعية الدموية", "قلب" },
                    { 5, null, "أنف وأذن وحنجرة" },
                    { 6, "رعاية الحمل والولادة", "نساء وتوليد" },
                    { 7, null, "جراحة عامة" },
                    { 8, "تشخيص وعلاج أمراض العين", "عيون" },
                    { 9, "مشاكل المفاصل والهيكل العظمي", "عظام" },
                    { 10, null, "مخ وأعصاب" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImagePath", "SecondName", "SecurityStamp", "ThirdName", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "ee76eecb-cb58-4113-909e-5079f3f6c9f2", new DateTime(2025, 8, 1, 13, 0, 0, 0, DateTimeKind.Utc), null, null, null, "admin@clinic.com", true, "خالد", "موسى", false, null, "ADMIN@CLINIC.COM", "ADMIN", "AQAAAAIAAYagAAAAEKlDQPebJpmZtvrSmfp96ueOlyPNfq8ODXtLoiLEjHO5C034I2s6eTYo18aTd5EWGw==", null, false, null, "علي", "f3b2c1d4-5e6f-4a8b-9c0d-7e8f9a0b1c2d", "احمد", false, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
