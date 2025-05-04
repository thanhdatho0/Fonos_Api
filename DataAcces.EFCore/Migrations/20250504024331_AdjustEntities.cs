using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcces.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AdjustEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_UserListeningProgresses_Audiobooks_AudiobookId",
                table: "UserListeningProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserListeningProgresses_PlaylistItems_PlaylistItemId",
                table: "UserListeningProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserListeningProgresses",
                table: "UserListeningProgresses");

            migrationBuilder.DropIndex(
                name: "IX_UserListeningProgresses_AudiobookId",
                table: "UserListeningProgresses");

            migrationBuilder.DropColumn(
                name: "RatingNums",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "AduioQuality",
                table: "Audiobooks");

            migrationBuilder.RenameColumn(
                name: "AudiobookId",
                table: "UserListeningProgresses",
                newName: "AudiobookChapterId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "UserPlaylists",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlaylistItemId",
                table: "UserListeningProgresses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserListeningProgressId",
                table: "UserListeningProgresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "UserListeningProgresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CurrentPosition",
                table: "UserListeningProgresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "UserListeningProgresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserListeningProgresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Ratings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<double>(
                name: "RatingValue",
                table: "Ratings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "FoundedYear",
                table: "Publishers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DownloadDate",
                table: "Downloads",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "DisplayOrder",
                table: "Categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublisherId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "PageCount",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "Authors",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Audiobooks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "Audiobooks",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Audiobooks",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "AudioQuality",
                table: "Audiobooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "AudiobookChapters",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "AudiobookChapters",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserListeningProgresses",
                table: "UserListeningProgresses",
                column: "UserListeningProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserListeningProgresses_AppUserId",
                table: "UserListeningProgresses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserListeningProgresses_AudiobookChapterId",
                table: "UserListeningProgresses",
                column: "AudiobookChapterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserListeningProgresses_PlaylistItemId",
                table: "UserListeningProgresses",
                column: "PlaylistItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserListeningProgresses_AspNetUsers_AppUserId",
                table: "UserListeningProgresses",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserListeningProgresses_AudiobookChapters_AudiobookChapterId",
                table: "UserListeningProgresses",
                column: "AudiobookChapterId",
                principalTable: "AudiobookChapters",
                principalColumn: "AudiobookChapterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserListeningProgresses_PlaylistItems_PlaylistItemId",
                table: "UserListeningProgresses",
                column: "PlaylistItemId",
                principalTable: "PlaylistItems",
                principalColumn: "PlaylistItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_UserListeningProgresses_AspNetUsers_AppUserId",
                table: "UserListeningProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserListeningProgresses_AudiobookChapters_AudiobookChapterId",
                table: "UserListeningProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserListeningProgresses_PlaylistItems_PlaylistItemId",
                table: "UserListeningProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserListeningProgresses",
                table: "UserListeningProgresses");

            migrationBuilder.DropIndex(
                name: "IX_UserListeningProgresses_AppUserId",
                table: "UserListeningProgresses");

            migrationBuilder.DropIndex(
                name: "IX_UserListeningProgresses_AudiobookChapterId",
                table: "UserListeningProgresses");

            migrationBuilder.DropIndex(
                name: "IX_UserListeningProgresses_PlaylistItemId",
                table: "UserListeningProgresses");

            migrationBuilder.DropColumn(
                name: "UserListeningProgressId",
                table: "UserListeningProgresses");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "UserListeningProgresses");

            migrationBuilder.DropColumn(
                name: "CurrentPosition",
                table: "UserListeningProgresses");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "UserListeningProgresses");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserListeningProgresses");

            migrationBuilder.DropColumn(
                name: "RatingValue",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AudioQuality",
                table: "Audiobooks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AudiobookChapterId",
                table: "UserListeningProgresses",
                newName: "AudiobookId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "UserPlaylists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PlaylistItemId",
                table: "UserListeningProgresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "RatingNums",
                table: "Ratings",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<int>(
                name: "FoundedYear",
                table: "Publishers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DownloadDate",
                table: "Downloads",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayOrder",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublisherId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PageCount",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "Authors",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ReleaseDate",
                table: "Audiobooks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "FileSize",
                table: "Audiobooks",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Duration",
                table: "Audiobooks",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "AduioQuality",
                table: "Audiobooks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "FileSize",
                table: "AudiobookChapters",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Duration",
                table: "AudiobookChapters",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserListeningProgresses",
                table: "UserListeningProgresses",
                columns: new[] { "PlaylistItemId", "AudiobookId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserListeningProgresses_AudiobookId",
                table: "UserListeningProgresses",
                column: "AudiobookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserListeningProgresses_Audiobooks_AudiobookId",
                table: "UserListeningProgresses",
                column: "AudiobookId",
                principalTable: "Audiobooks",
                principalColumn: "AudiobookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserListeningProgresses_PlaylistItems_PlaylistItemId",
                table: "UserListeningProgresses",
                column: "PlaylistItemId",
                principalTable: "PlaylistItems",
                principalColumn: "PlaylistItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
