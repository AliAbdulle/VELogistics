using Microsoft.EntityFrameworkCore.Migrations;

namespace VELogistics.Migrations
{
    public partial class initialMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "db7e6182-b11f-4c03-926d-eaa6825fc9c4", "AQAAAAEAACcQAAAAEPYczjSV88I+Oo0MqFEAANCLvF8+Ivm6xCN9iHFYy/KycaBD2Uk6FV5ywx1s14sYkQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-fffs-fffd-ffffffffffss",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7cc5cfa-d128-4432-8deb-7a3eb9ae9a59", "AQAAAAEAACcQAAAAEICqhWA02tnalbhAwDkabinrD7Uw62VLJkzZv6udbmS/crWSFYuxCp+Doz5EkLwtAA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "628010bf-c392-44cd-9630-07cac4ef412e", "AQAAAAEAACcQAAAAED+CRrFzFXPhgBjKSidQQaGCrt2NOPqoCop92QcRdERrYlrFhHLeNW3m4KwHgns4dw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-fffs-fffd-ffffffffffss",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "52b3d11f-20af-4514-8622-a8cbc222c803", "AQAAAAEAACcQAAAAEJLBcHHLtpo1Gpu0i0AgUNW25qvPl6E/bG7v6pgwni1Gdjt0ZQIzjY+SmiyC5PhHGA==" });
        }
    }
}
