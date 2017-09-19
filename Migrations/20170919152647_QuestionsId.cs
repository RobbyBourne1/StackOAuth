using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StackOAuth.Migrations
{
    public partial class QuestionsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionId",
                table: "Answers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionsModelId",
                table: "Answers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionsModelId",
                table: "Answers",
                column: "QuestionsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionsModelId",
                table: "Answers",
                column: "QuestionsModelId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionsModelId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionsModelId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuestionsModelId",
                table: "Answers");
        }
    }
}
