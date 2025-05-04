using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandomPokemon.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PokedexId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeOne = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeTwo = table.Column<int>(type: "INTEGER", nullable: true),
                    Image = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Silhouette = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonPokemon",
                columns: table => new
                {
                    EvolutionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonPokemon", x => new { x.EvolutionsId, x.PokemonId });
                    table.ForeignKey(
                        name: "FK_PokemonPokemon_Pokemons_EvolutionsId",
                        column: x => x.EvolutionsId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonPokemon_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonPokemon_PokemonId",
                table: "PokemonPokemon",
                column: "PokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonPokemon");

            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
