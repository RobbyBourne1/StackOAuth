using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StackOAuth.Migrations
{
    public partial class fixedIdNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswersId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "QuestionModelId",
                table: "Comments",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionModelId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "AnswersId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionId",
                table: "Comments",
                nullable: true);
        }
    }
}
