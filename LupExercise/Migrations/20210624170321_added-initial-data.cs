using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LupExercise.Migrations
{
    public partial class addedinitialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventName = table.Column<string>(type: "TEXT", nullable: false),
                    EventDescription = table.Column<string>(type: "TEXT", nullable: false),
                    EventTimezone = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "CreatedDate", "EndDate", "EventDescription", "EventName", "EventTimezone", "ModifiedDate", "StartDate" },
                values: new object[] { 1, new DateTime(2021, 6, 24, 17, 3, 21, 229, DateTimeKind.Utc).AddTicks(800), new DateTime(2021, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Party stuff", "Christmas Party", "GMT+10", new DateTime(2021, 6, 24, 17, 3, 21, 229, DateTimeKind.Utc).AddTicks(1052), new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "CreatedDate", "EndDate", "EventDescription", "EventName", "EventTimezone", "ModifiedDate", "StartDate" },
                values: new object[] { 2, new DateTime(2021, 6, 24, 17, 3, 21, 229, DateTimeKind.Utc).AddTicks(1279), new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event 2", "Event 2", "GMT+8", new DateTime(2021, 6, 24, 17, 3, 21, 229, DateTimeKind.Utc).AddTicks(1280), new DateTime(2021, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "CreatedDate", "EndDate", "EventDescription", "EventName", "EventTimezone", "ModifiedDate", "StartDate" },
                values: new object[] { 3, new DateTime(2021, 6, 24, 17, 3, 21, 229, DateTimeKind.Utc).AddTicks(1282), new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event 3", "Event 3", "GMT+8", new DateTime(2021, 6, 24, 17, 3, 21, 229, DateTimeKind.Utc).AddTicks(1283), new DateTime(2021, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
