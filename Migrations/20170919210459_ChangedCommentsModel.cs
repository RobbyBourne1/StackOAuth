using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StackOAuth.Migrations
{
    public partial class ChangedCommentsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnswersId",
                table: "Comments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionId",
                table: "Comments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionsModelId",
                table: "Comments",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_QuestionsModelId",
                table: "Comments",
                column: "QuestionsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Questions_QuestionsModelId",
                table: "Comments",
                column: "QuestionsModelId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Questions_QuestionsModelId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_QuestionsModelId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AnswersId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "QuestionsModelId",
                table: "Comments");
        }
    }
}
