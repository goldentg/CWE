﻿// <auto-generated> 
using Microsoft.EntityFrameworkCore.Migrations;

namespace CWE.Data.Migrations
{
    public partial class AddedMessageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "MessageId",
                table: "Requests",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Requests");
        }
    }
}
