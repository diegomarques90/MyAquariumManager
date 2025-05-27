using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyAquariumManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeCientifico = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LocalAquisicao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataAquisicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Especie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FaixaDoPH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Origem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comportamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cardumeiro = table.Column<bool>(type: "bit", nullable: false),
                    QuantidadeMinima = table.Column<int>(type: "int", nullable: false),
                    LitragemMinima = table.Column<int>(type: "int", nullable: false),
                    TipoDeAlimentacao = table.Column<int>(type: "int", nullable: false),
                    FaixaDeTamanho = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FaixaDeTemperatura = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TipoDeAgua = table.Column<int>(type: "int", nullable: false),
                    InformacoesAdicionais = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    CodigoConta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioExclusao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoDeManutencao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    DataManutencao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoDeManutencao = table.Column<int>(type: "int", nullable: false),
                    TanqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoConta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioExclusao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoDeManutencao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeCientifico = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TipoDeEfeitoNoPH = table.Column<int>(type: "int", nullable: false),
                    CodigoConta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioExclusao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeCientifico = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LocalAquisicao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataAquisicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FaixaDeTamanho = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TipoDeCrescimento = table.Column<int>(type: "int", nullable: false),
                    TipoDeIluminacao = table.Column<int>(type: "int", nullable: false),
                    FaixaDoPH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FaixaDeTemperatura = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NivelDeCutivo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TipoDePlantio = table.Column<int>(type: "int", nullable: false),
                    FormaDeReproducao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExigeCO2 = table.Column<bool>(type: "bit", nullable: false),
                    InformacoesAdicionais = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    CodigoConta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioExclusao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LocalAquisicao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataAquisicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataGarantia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoProduto = table.Column<int>(type: "int", nullable: false),
                    TipoVoltagem = table.Column<int>(type: "int", nullable: false),
                    TipoDeArmazenamento = table.Column<int>(type: "int", nullable: false),
                    InformacoesAdicionais = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    CodigoConta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioExclusao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Substrato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Composicao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TipoDeEfeitoNoPH = table.Column<int>(type: "int", nullable: false),
                    TipoDeAgua = table.Column<int>(type: "int", nullable: false),
                    InformacoesAdicionais = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    CodigoConta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioExclusao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substrato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tanque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Largura = table.Column<double>(type: "float", nullable: false),
                    Comprimento = table.Column<double>(type: "float", nullable: false),
                    Altura = table.Column<double>(type: "float", nullable: false),
                    Litragem = table.Column<double>(type: "float", nullable: false),
                    LocalAquisicao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataAquisicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataMontagem = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmOperacao = table.Column<bool>(type: "bit", nullable: false),
                    TipoDeAgua = table.Column<int>(type: "int", nullable: false),
                    TipoDoTanque = table.Column<int>(type: "int", nullable: false),
                    InformacoesAdicionais = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    CodigoConta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioExclusao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadeDeMedida",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Abreviacao = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CodigoConta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioExclusao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeDeMedida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodigoConta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioExclusao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conta_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemNoTanque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnidadeDeMedidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TanqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<double>(type: "float", nullable: false),
                    TipoDoItem = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoConta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioExclusao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemNoTanque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemNoTanque_UnidadeDeMedida_UnidadeDeMedidaId",
                        column: x => x.UnidadeDeMedidaId,
                        principalTable: "UnidadeDeMedida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1518fb70-4074-41e8-8b84-606c00b6a380", null, "administrador", "ADMINISTRADOR" },
                    { "fcf4125d-f6b6-4638-b6d5-08ca5448ad34", null, "convidado", "CONVIDADO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_UsuarioId",
                table: "Conta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemNoTanque_UnidadeDeMedidaId",
                table: "ItemNoTanque",
                column: "UnidadeDeMedidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "HistoricoDeManutencao");

            migrationBuilder.DropTable(
                name: "ItemNoTanque");

            migrationBuilder.DropTable(
                name: "Pedra");

            migrationBuilder.DropTable(
                name: "Planta");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Substrato");

            migrationBuilder.DropTable(
                name: "Tanque");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UnidadeDeMedida");
        }
    }
}
