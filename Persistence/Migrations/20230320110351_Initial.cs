using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
	/// <inheritdoc />
	public partial class Initial : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Products",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
					Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Products", x => x.Id);
				});

			migrationBuilder.InsertData(
				table: "Products",
				columns: new[] { "Id", "Barcode", "Description", "Name", "Rate" },
				values: new object[] { 1, "5412", "Description about", "Tractor", 45m });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Products");
		}
	}
}
