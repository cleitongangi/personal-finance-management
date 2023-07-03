using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial_DB : Migration
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
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                    entry_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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

            migrationBuilder.InsertData(
                table: "app_language",
                columns: new[] { "id", "description", "is_default" },
                values: new object[,]
                {
                    { (short)1, "English", true },
                    { (short)2, "Portuguese", false }
                });

            migrationBuilder.InsertData(
                table: "entry_type",
                columns: new[] { "id", "description" },
                values: new object[,]
                {
                    { (short)1, "Incoming" },
                    { (short)2, "Expense" }
                });

            migrationBuilder.InsertData(
                table: "template_entry_category",
                columns: new[] { "id", "active", "app_language_id", "created", "description", "entry_type_id", "updated" },
                values: new object[,]
                {
                    { 1, true, (short)1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1096), "Fixed Incomings", (short)1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1105) },
                    { 2, true, (short)1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1107), "Variable Incomings", (short)1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1107) },
                    { 3, true, (short)1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1109), "Housing", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1109) },
                    { 4, true, (short)1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1110), "Health", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1111) },
                    { 5, true, (short)1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1112), "Transportation", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1112) },
                    { 6, true, (short)1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1114), "Personal", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1114) },
                    { 7, true, (short)1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1115), "Education", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1116) },
                    { 8, true, (short)1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1117), "Leisure", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1118) },
                    { 9, true, (short)1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1119), "Others", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1120) },
                    { 10, true, (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1121), "Receitas Fixas", (short)1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1121) },
                    { 11, true, (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1122), "Receitas Variáveis", (short)1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1124) },
                    { 12, true, (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1125), "Habitação", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1125) },
                    { 13, true, (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1126), "Saúde", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1127) },
                    { 14, true, (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1128), "Transporte", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1128) },
                    { 15, true, (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1129), "Pessoais", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1130) },
                    { 16, true, (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1131), "Educação", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1131) },
                    { 17, true, (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1132), "Lazer", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1133) },
                    { 18, true, (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1134), "Outras", (short)2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(1135) }
                });

            migrationBuilder.InsertData(
                table: "template_entry_subcategory",
                columns: new[] { "id", "active", "app_language_id", "category_id", "created", "description", "updated" },
                values: new object[,]
                {
                    { 1, true, (short)1, 1, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4751), "Salary", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4755) },
                    { 2, true, (short)1, 2, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4757), "Extras", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4757) },
                    { 3, true, (short)1, 3, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4758), "Rental", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4759) },
                    { 4, true, (short)1, 3, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4760), "Condominium fee", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4761) },
                    { 5, true, (short)1, 3, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4762), "Other fees", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4762) },
                    { 6, true, (short)1, 3, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4763), "Energy", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4764) },
                    { 7, true, (short)1, 3, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4765), "Water", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4766) },
                    { 8, true, (short)1, 3, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4767), "Gas", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4767) },
                    { 9, true, (short)1, 3, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4768), "Phones", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4769) },
                    { 10, true, (short)1, 3, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4770), "Internet", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4770) },
                    { 11, true, (short)1, 3, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4771), "Supermarket", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4772) },
                    { 12, true, (short)1, 3, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4773), "Employees", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4773) },
                    { 13, true, (short)1, 3, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4774), "Others", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4776) },
                    { 14, true, (short)1, 4, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4777), "Health insurance", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4777) },
                    { 15, true, (short)1, 4, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4778), "Expense with doctors", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4779) },
                    { 16, true, (short)1, 4, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4780), "Dentist", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4780) },
                    { 17, true, (short)1, 4, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4781), "Drugstore", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4782) },
                    { 18, true, (short)1, 6, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4783), "Academy", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4783) },
                    { 19, true, (short)1, 5, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4784), "Taxes and Fees", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4785) },
                    { 20, true, (short)1, 5, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4786), "Insurance", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4786) },
                    { 21, true, (short)1, 5, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4787), "Fuel", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4788) },
                    { 22, true, (short)1, 5, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4789), "Parking", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4789) },
                    { 23, true, (short)1, 5, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4790), "Washing", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4791) },
                    { 24, true, (short)1, 5, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4792), "Maintenance", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4792) },
                    { 25, true, (short)1, 5, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4793), "Traffic ticket", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4794) },
                    { 26, true, (short)1, 5, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4795), "Taxi", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4795) },
                    { 27, true, (short)1, 5, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4796), "Toll", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4797) },
                    { 28, true, (short)1, 6, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4798), "Personal Hygiene (nails, waxing, etc.)", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4798) },
                    { 29, true, (short)1, 6, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4799), "Hairdresser", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4800) },
                    { 30, true, (short)1, 6, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4801), "Clothing", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4802) },
                    { 31, true, (short)1, 6, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4803), "Other Purchases", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4803) },
                    { 32, true, (short)1, 7, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4804), "School / College", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4805) },
                    { 33, true, (short)1, 7, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4806), "Courses", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4806) },
                    { 34, true, (short)1, 7, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4807), "Languages ​​course", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4808) },
                    { 35, true, (short)1, 7, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4809), "Restaurants", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4809) },
                    { 36, true, (short)1, 7, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4810), "Fast food", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4811) },
                    { 37, true, (short)1, 7, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4812), "Games", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4812) },
                    { 38, true, (short)1, 7, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4813), "Tours", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4814) },
                    { 39, true, (short)1, 7, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4815), "Trips", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4815) },
                    { 40, true, (short)1, 7, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4816), "Donations / Tithes / Offerings", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4816) },
                    { 41, true, (short)1, 7, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4817), "Gifts", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4818) },
                    { 42, true, (short)1, 7, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4819), "Others", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4819) },
                    { 43, true, (short)2, 10, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4820), "Salário", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4821) },
                    { 44, true, (short)2, 11, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4822), "Extras", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4822) },
                    { 45, true, (short)2, 12, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4824), "Aluguel", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4824) },
                    { 46, true, (short)2, 12, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4825), "Condomínio", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4826) },
                    { 47, true, (short)2, 12, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4827), "IPTU / Taxas", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4827) },
                    { 48, true, (short)2, 12, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4828), "Energia", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4829) },
                    { 49, true, (short)2, 12, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4830), "Água", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4830) },
                    { 51, true, (short)2, 12, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4831), "Gás", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4832) },
                    { 52, true, (short)2, 12, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4833), "Telefone", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4833) },
                    { 53, true, (short)2, 12, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4834), "Internet", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4835) },
                    { 54, true, (short)2, 12, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4836), "Supermercado", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4836) },
                    { 55, true, (short)2, 12, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4837), "Empregados", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4838) },
                    { 56, true, (short)2, 12, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4838), "Outros", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4839) },
                    { 57, true, (short)2, 13, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4840), "Plano de Saúde", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4840) },
                    { 58, true, (short)2, 13, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4841), "Médicos", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4842) },
                    { 59, true, (short)2, 13, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4843), "Dentista", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4843) },
                    { 61, true, (short)2, 13, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4844), "Drogaria", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4845) },
                    { 62, true, (short)2, 13, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4846), "Academia", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4846) },
                    { 63, true, (short)2, 14, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4848), "IPVA / Seguro Obrigatório / Licenciamento", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4848) },
                    { 64, true, (short)2, 14, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4849), "Seguro", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4850) },
                    { 65, true, (short)2, 14, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4851), "Comnbustível", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4851) },
                    { 66, true, (short)2, 14, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4852), "Estacionamentos", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4853) },
                    { 67, true, (short)2, 14, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4854), "Lavagens", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4854) },
                    { 68, true, (short)2, 14, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4855), "Mecânico/Manutenções", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4856) },
                    { 69, true, (short)2, 14, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4856), "Multas", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4857) },
                    { 70, true, (short)2, 14, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4858), "Taxi", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4859) },
                    { 71, true, (short)2, 14, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4859), "Pedágios", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4860) },
                    { 72, true, (short)2, 15, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4861), "Higiene Pessoal (unha, depilação etc.)", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4861) },
                    { 73, true, (short)2, 15, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4862), "Cabeleireiro", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4863) },
                    { 74, true, (short)2, 15, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4864), "Vestuário", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4864) },
                    { 75, true, (short)2, 15, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4865), "Demais Compras", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4866) },
                    { 76, true, (short)2, 15, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4867), "Outros/Não identificado", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4867) },
                    { 77, true, (short)2, 16, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4868), "Escola / Faculdade", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4869) },
                    { 78, true, (short)2, 16, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4870), "Cursos", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4870) },
                    { 79, true, (short)2, 16, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4871), "Curso de Idiomas", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4872) },
                    { 80, true, (short)2, 17, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4873), "Restaurantes", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4873) },
                    { 81, true, (short)2, 17, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4874), "Fast food", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4875) },
                    { 82, true, (short)2, 17, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4875), "Games", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4876) },
                    { 83, true, (short)2, 17, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4877), "Passeios", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4877) },
                    { 84, true, (short)2, 17, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4878), "Viagens", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4879) },
                    { 85, true, (short)2, 18, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4880), "Doações / dízimos / ofertas", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4880) },
                    { 86, true, (short)2, 18, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4881), "Presentes", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4881) },
                    { 87, true, (short)2, 18, new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4882), "Others", new DateTime(2023, 6, 27, 18, 49, 59, 706, DateTimeKind.Local).AddTicks(4883) }
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
