using Microsoft.EntityFrameworkCore.Migrations;

namespace Points.RestApi.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PointsListTitleId",
                table: "PointsList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PointsList_PointsListTitleId",
                table: "PointsList",
                column: "PointsListTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PointsList_Titles_PointsListTitleId",
                table: "PointsList",
                column: "PointsListTitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointsList_Titles_PointsListTitleId",
                table: "PointsList");

            migrationBuilder.DropIndex(
                name: "IX_PointsList_PointsListTitleId",
                table: "PointsList");

            migrationBuilder.DropColumn(
                name: "PointsListTitleId",
                table: "PointsList");
        }
    }
}
