using Microsoft.EntityFrameworkCore.Migrations;

namespace OOPASU.Infrastructure.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Classes_ClassId",
                table: "Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Students_StudentId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Classes_ClassRoomId",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visit",
                table: "Visit");

            migrationBuilder.RenameTable(
                name: "Visit",
                newName: "Visits");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_StudentId",
                table: "Visits",
                newName: "IX_Visits_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visits",
                table: "Visits",
                columns: new[] { "ClassId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassRoomId",
                table: "Classes",
                column: "ClassRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Classes_ClassId",
                table: "Visits",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Students_StudentId",
                table: "Visits",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Classes_ClassId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Students_StudentId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Classes_ClassRoomId",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visits",
                table: "Visits");

            migrationBuilder.RenameTable(
                name: "Visits",
                newName: "Visit");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_StudentId",
                table: "Visit",
                newName: "IX_Visit_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visit",
                table: "Visit",
                columns: new[] { "ClassId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassRoomId",
                table: "Classes",
                column: "ClassRoomId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Classes_ClassId",
                table: "Visit",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Students_StudentId",
                table: "Visit",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
