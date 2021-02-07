using Microsoft.EntityFrameworkCore.Migrations;

namespace Points.RestApi.Migrations
{
    public partial class updatePointsList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title_id",
                table: "PointsList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Title_id",
                table: "PointsList",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
