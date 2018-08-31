using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD_Razor_2_1.Migrations
{
    public partial class MakeBookNameNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"  PRAGMA foreign_keys = 0;

                    CREATE TABLE BOOKS_temp AS SELECT * FROM BOOKS;

                    DROP TABLE BOOKS;
                    
                    CREATE TABLE `Books` (
	                    `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                    `Name`	TEXT NOT NULL
                    );

                    INSERT INTO BOOKS (Id, Name) SELECT Id, Name FROM BOOKS_temp;

                    DROP TABLE BOOKS_temp;

                    PRAGMA foreign_keys = 1;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
