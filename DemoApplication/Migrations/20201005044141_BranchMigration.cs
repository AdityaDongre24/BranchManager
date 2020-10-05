using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoApplication.Migrations
{
    public partial class BranchMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branchs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(nullable: false),
                    IFSCCode = table.Column<string>(nullable: false),
                    Bank = table.Column<int>(nullable: false),
                    District = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branchs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "Bank1", "Bank 1" },
                    { 2, "Bank2", "Bank 2" },
                    { 3, "Bank3", "Bank 3" },
                    { 4, "Bank4", "Bank 4" }
                });

            migrationBuilder.InsertData(
                table: "Branchs",
                columns: new[] { "Id", "Bank", "BranchName", "District", "IFSCCode", "State" },
                values: new object[] { 1, 1, "Default Branch", 1, "BR001", 1 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "Code", "Name", "StateID" },
                values: new object[,]
                {
                    { 1, "Amritsar", "Amritsar", 1 },
                    { 2, "Pathankot", "Pathankot", 1 },
                    { 3, "Indore", "Indore", 2 },
                    { 4, "Bhopal", "Bhopal", 2 },
                    { 5, "Pune", "Pune", 3 },
                    { 6, "Mumbai", "Mumbai", 3 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "Punjab", "Punjab" },
                    { 2, "MadhyaPradesh", "MadhyaPradesh" },
                    { 3, "Maharashtra", "Maharashtra" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1, "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Branchs");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
