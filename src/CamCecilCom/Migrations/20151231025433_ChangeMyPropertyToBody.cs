using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace CamCecilCom.Migrations
{
    public partial class ChangeMyPropertyToBody : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "MyProperty", table: "BlogPost");
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "BlogPost",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Body", table: "BlogPost");
            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "BlogPost",
                nullable: true);
        }
    }
}
