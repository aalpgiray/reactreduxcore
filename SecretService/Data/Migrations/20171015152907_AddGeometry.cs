using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SecretService.Data.Migrations
{
    public partial class AddGeometry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeometryId",
                table: "Stops",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Geometry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Shape = table.Column<Geometry>(type: "geometry", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geometry", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stops_GeometryId",
                table: "Stops",
                column: "GeometryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stops_Geometry_GeometryId",
                table: "Stops",
                column: "GeometryId",
                principalTable: "Geometry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stops_Geometry_GeometryId",
                table: "Stops");

            migrationBuilder.DropTable(
                name: "Geometry");

            migrationBuilder.DropIndex(
                name: "IX_Stops_GeometryId",
                table: "Stops");

            migrationBuilder.DropColumn(
                name: "GeometryId",
                table: "Stops");
        }
    }
}
