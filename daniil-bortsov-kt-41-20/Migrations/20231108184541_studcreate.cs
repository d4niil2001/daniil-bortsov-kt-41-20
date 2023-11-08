using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace daniil_bortsov_kt_41_20.Migrations
{
    /// <inheritdoc />
    public partial class studcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор группы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName) group_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор предмета")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName) subject_id", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    stud_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор студента")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stud_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя студента"),
                    stud_surname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    stud_midname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Отчество студента"),
                    group_id = table.Column<int>(type: "int", maxLength: 100, nullable: false, comment: "Идентификатор группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName) stud_id", x => x.stud_id);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.group_id,
                        principalTable: "Groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор оценки")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mark = table.Column<int>(type: "int", maxLength: 100, nullable: false, comment: "Оценка"),
                    subject_id = table.Column<int>(type: "int", maxLength: 100, nullable: false, comment: "Идентификатор предмета"),
                    stud_id = table.Column<int>(type: "int", maxLength: 100, nullable: false, comment: "Идентификатор студента")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName) grade_id", x => x.grade_id);
                    table.ForeignKey(
                        name: "fk_f_stud_id",
                        column: x => x.stud_id,
                        principalTable: "Students",
                        principalColumn: "stud_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_subject_id",
                        column: x => x.subject_id,
                        principalTable: "Subjects",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_Grades_fk_f_stud_id",
                table: "Grades",
                column: "stud_id");

            migrationBuilder.CreateIndex(
                name: "idx_Grades_fk_f_subject_id",
                table: "Grades",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "idx_Students_fk_f_group_id",
                table: "Students",
                column: "group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
