using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
	/// <inheritdoc />
	public partial class Initial02 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Customers",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
					Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
					Family = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
					Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
					Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
					Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Customers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Orders",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					IsPayed = table.Column<bool>(type: "bit", nullable: false),
					IsSend = table.Column<bool>(type: "bit", nullable: false),
					PaymentCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
					CustomerId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Orders", x => x.Id);
					table.ForeignKey(
						name: "FK_Orders_Customers_CustomerId",
						column: x => x.CustomerId,
						principalTable: "Customers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Orders_CustomerId",
				table: "Orders",
				column: "CustomerId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Orders");

			migrationBuilder.DropTable(
				name: "Customers");
		}
	}
}
