using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "app_language",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    is_default = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("app_language_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "entry_type",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("entry_type_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    user_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "template_entry_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    app_language_id = table.Column<short>(type: "smallint", nullable: false),
                    entry_type_id = table.Column<short>(type: "smallint", nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("template_entry_category_pk", x => x.id);
                    table.ForeignKey(
                        name: "template_entry_category_fk_app_language",
                        column: x => x.app_language_id,
                        principalTable: "app_language",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "template_entry_category_fk_entry_type",
                        column: x => x.entry_type_id,
                        principalTable: "entry_type",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "balance",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    reference_month = table.Column<string>(type: "character(6)", fixedLength: true, maxLength: 6, nullable: false, comment: "Information with format YYYYMM"),
                    balance = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("balance_pk", x => x.user_id);
                    table.ForeignKey(
                        name: "balance_fk_user",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "entry",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    entry_type_id = table.Column<short>(type: "smallint", nullable: false),
                    issuer_id = table.Column<long>(type: "bigint", nullable: false),
                    value = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    note = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    entry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("entry_pk", x => x.id);
                    table.ForeignKey(
                        name: "entry_fk_entry_type",
                        column: x => x.entry_type_id,
                        principalTable: "entry_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "entry_fk_user",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "entry_category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    entry_type_id = table.Column<short>(type: "smallint", nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("entry_category_pk", x => x.id);
                    table.ForeignKey(
                        name: "entry_category_fk_entry_type",
                        column: x => x.entry_type_id,
                        principalTable: "entry_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "entry_category_fk_user",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "template_entry_subcategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    app_language_id = table.Column<short>(type: "smallint", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("template_entry_subcategory_pk", x => x.id);
                    table.ForeignKey(
                        name: "template_entry_subcategory_fk_app_language",
                        column: x => x.app_language_id,
                        principalTable: "app_language",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "template_entry_subcategory_fk_category",
                        column: x => x.category_id,
                        principalTable: "template_entry_category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "entry_subcategory",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("entry_subcategory_pk", x => x.id);
                    table.ForeignKey(
                        name: "entry_subcategory_fk_category",
                        column: x => x.category_id,
                        principalTable: "entry_category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "entry_subcategory_fk_user",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "issuer",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    entry_subcategory_id = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("issuer_pk", x => x.id);
                    table.ForeignKey(
                        name: "issuer_fk_subcategory",
                        column: x => x.entry_subcategory_id,
                        principalTable: "entry_subcategory",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "issuer_fk_user",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_entry_entry_type_id",
                table: "entry",
                column: "entry_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_entry_user_id",
                table: "entry",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_entry_category_entry_type_id",
                table: "entry_category",
                column: "entry_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_entry_category_user_id",
                table: "entry_category",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_entry_subcategory_category_id",
                table: "entry_subcategory",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_entry_subcategory_user_id",
                table: "entry_subcategory",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_issuer_entry_subcategory_id",
                table: "issuer",
                column: "entry_subcategory_id");

            migrationBuilder.CreateIndex(
                name: "ix_issuer_user_id",
                table: "issuer",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_entry_category_app_language_id",
                table: "template_entry_category",
                column: "app_language_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_entry_category_entry_type_id",
                table: "template_entry_category",
                column: "entry_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_entry_subcategory_app_language_id",
                table: "template_entry_subcategory",
                column: "app_language_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_entry_subcategory_category_id",
                table: "template_entry_subcategory",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "balance");

            migrationBuilder.DropTable(
                name: "entry");

            migrationBuilder.DropTable(
                name: "issuer");

            migrationBuilder.DropTable(
                name: "template_entry_subcategory");

            migrationBuilder.DropTable(
                name: "entry_subcategory");

            migrationBuilder.DropTable(
                name: "template_entry_category");

            migrationBuilder.DropTable(
                name: "entry_category");

            migrationBuilder.DropTable(
                name: "app_language");

            migrationBuilder.DropTable(
                name: "entry_type");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
