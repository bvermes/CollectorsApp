using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectorsApp.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Collection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoughtFor = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    SellingPrice = table.Column<int>(type: "int", nullable: false),
                    ForSale = table.Column<bool>(type: "bit", nullable: false),
                    Sold = table.Column<bool>(type: "bit", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teamname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matches_played = table.Column<int>(type: "int", nullable: false),
                    Overall = table.Column<double>(type: "float", nullable: false),
                    AttackingRating = table.Column<double>(type: "float", nullable: false),
                    MidfieldRating = table.Column<double>(type: "float", nullable: false),
                    DefenceRating = table.Column<double>(type: "float", nullable: false),
                    ClubWorth = table.Column<double>(type: "float", nullable: false),
                    XIAverageAge = table.Column<double>(type: "float", nullable: false),
                    DefenceWidth = table.Column<double>(type: "float", nullable: false),
                    DefenceDepth = table.Column<double>(type: "float", nullable: false),
                    OffenceWidth = table.Column<double>(type: "float", nullable: false),
                    Likes = table.Column<double>(type: "float", nullable: false),
                    Dislikes = table.Column<double>(type: "float", nullable: false),
                    avgoals = table.Column<double>(type: "float", nullable: false),
                    avconceded = table.Column<double>(type: "float", nullable: false),
                    avgoalattempts = table.Column<double>(type: "float", nullable: false),
                    avshotsongoal = table.Column<double>(type: "float", nullable: false),
                    avshotsoffgoal = table.Column<double>(type: "float", nullable: false),
                    avblockedshots = table.Column<double>(type: "float", nullable: false),
                    avpossession = table.Column<double>(type: "float", nullable: false),
                    avfreekicks = table.Column<double>(type: "float", nullable: false),
                    avGoalDiff = table.Column<double>(type: "float", nullable: false),
                    avwins = table.Column<double>(type: "float", nullable: false),
                    avdraws = table.Column<double>(type: "float", nullable: false),
                    avloses = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "AttackingRating", "ClubWorth", "DefenceDepth", "DefenceRating", "DefenceWidth", "Dislikes", "Likes", "Matches_played", "MidfieldRating", "OffenceWidth", "Overall", "Teamname", "XIAverageAge", "avGoalDiff", "avblockedshots", "avconceded", "avdraws", "avfreekicks", "avgoalattempts", "avgoals", "avloses", "avpossession", "avshotsoffgoal", "avshotsongoal", "avwins" },
                values: new object[,]
                {
                    { 1, 75.0, 13.0, 30.0, 75.0, 50.0, 15.0, 45.0, 190, 73.0, 70.0, 74.0, "Alaves", 28.640000000000001, 0.28947368421052599, 2.1631578947368402, 1.3631578947368399, 0.24210526315789499, 15.526315789473699, 9.8315789473684205, 1.0, 0.43684210526315798, 42.073684210526302, 4.5263157894736796, 3.1421052631578901, 0.32105263157894698 },
                    { 2, 73.0, 150.0, 37.0, 71.0, 45.0, 5.0, 32.0, 76, 70.0, 54.0, 72.0, "Almeria", 25.18, 0.40789473684210498, 2.3815789473684199, 1.7763157894736801, 0.197368421052632, 15.2631578947368, 10.407894736842101, 1.0263157894736801, 0.55263157894736903, 43.868421052631597, 4.5526315789473699, 3.4736842105263199, 0.25 },
                    { 3, 80.0, 250.0, 50.0, 78.0, 50.0, 31.0, 148.0, 304, 79.0, 70.0, 78.0, "Ath_Bilbao", 27.640000000000001, 0.47368421052631599, 2.4342105263157898, 1.125, 0.28289473684210498, 16.351973684210499, 11.598684210526301, 1.2763157894736801, 0.32565789473684198, 50.789473684210499, 5.0394736842105301, 4.125, 0.39144736842105299 },
                    { 4, 84.0, 1200.0, 60.0, 83.0, 60.0, 113.0, 400.0, 303, 84.0, 40.0, 84.0, "Atl_Madrid", 27.91, 0.39933993399339901, 2.56435643564356, 0.66996699669966997, 0.23432343234323399, 13.891089108910901, 12.1353135313531, 1.67656765676568, 0.13531353135313501, 49.046204620462099, 4.9537953795379499, 4.6171617161716201, 0.63036303630363 },
                    { 5, 81.0, 3200.0, 80.0, 80.0, 60.0, 541.0, 1449.0, 304, 84.0, 30.0, 83.0, "Barcelona", 25.09, 0.457236842105263, 3.32894736842105, 0.85855263157894701, 0.17105263157894701, 16.842105263157901, 15.605263157894701, 2.625, 0.115131578947368, 66.226973684210506, 5.4802631578947398, 6.7960526315789496, 0.71381578947368396 },
                    { 6, 79.0, 175.0, 70.0, 77.0, 60.0, 49.0, 165.0, 266, 80.0, 60.0, 79.0, "Betis", 30.27, 0.360902255639098, 2.9172932330827099, 1.56766917293233, 0.23684210526315799, 17.657894736842099, 11.699248120300799, 1.1766917293233099, 0.43984962406014999, 53.428571428571402, 4.6766917293233101, 4.1052631578947398, 0.32330827067669199 },
                    { 7, 76.0, 3.5, 50.0, 73.0, 70.0, 8.0, 31.0, 38, 74.0, 80.0, 74.0, "Cadiz_CF", 27.73, -0.105263157894737, 1.15789473684211, 1.5263157894736801, 0.28947368421052599, 17.421052631578899, 8.0, 0.94736842105263197, 0.42105263157894701, 34.2368421052632, 4.1578947368421098, 2.6842105263157898, 0.28947368421052599 },
                    { 8, 80.0, 110.0, 60.0, 75.0, 70.0, 11.0, 62.0, 304, 76.0, 40.0, 76.0, "Celta_Vigo", 28.449999999999999, 0.355263157894737, 2.7302631578947398, 1.4934210526315801, 0.269736842105263, 15.608552631579, 11.3684210526316, 1.32894736842105, 0.39802631578947401, 54.042763157894697, 4.5296052631579, 4.1085526315789496, 0.332236842105263 },
                    { 9, 72.0, 12.6, 38.0, 70.0, 52.0, 0.0, 9.0, 38, 71.0, 59.0, 71.0, "Cordoba", 25.359999999999999, 0.105263157894737, 2.1842105263157898, 1.7894736842105301, 0.28947368421052599, 16.315789473684202, 10.394736842105299, 0.57894736842105299, 0.63157894736842102, 46.368421052631597, 5.0, 3.2105263157894699, 0.078947368421052599 },
                    { 10, 79.0, 100.0, 47.0, 77.0, 66.0, 11.0, 61.0, 152, 77.0, 78.0, 77.0, "Dep_La_Coruna", 29.09, 0.32236842105263203, 2.6578947368421102, 1.6973684210526301, 0.36184210526315802, 15.532894736842101, 11.664473684210501, 1.05921052631579, 0.44736842105263203, 47.190789473684198, 5.25, 3.7565789473684199, 0.19078947368421101 },
                    { 11, 76.0, 29.0, 80.0, 74.0, 50.0, 8.0, 34.0, 266, 75.0, 60.0, 76.0, "Eibar", 28.550000000000001, 0.37593984962406002, 2.61278195488722, 1.40977443609023, 0.266917293233083, 14.462406015037599, 11.687969924812, 1.1165413533834601, 0.44360902255639101, 48.289473684210499, 5.1992481203007497, 3.8759398496240598, 0.28947368421052599 },
                    { 12, 76.0, 4.7999999999999998, 50.0, 73.0, 50.0, 3.0, 23.0, 114, 75.0, 50.0, 75.0, "Elche", 29.0, 0.31578947368421101, 1.9912280701754399, 1.4649122807017501, 0.28947368421052599, 16.157894736842099, 9.4736842105263204, 0.86842105263157898, 0.464912280701754, 47.543859649122801, 4.4736842105263204, 3.0087719298245599, 0.24561403508771901 },
                    { 13, 78.0, 60.0, 50.0, 76.0, 60.0, 28.0, 75.0, 266, 77.0, 60.0, 77.0, "Espanyol", 28.0, 0.30827067669172897, 2.4511278195488702, 1.4135338345864701, 0.266917293233083, 15.853383458646601, 10.609022556391, 1.0827067669172901, 0.42481203007518797, 46.154135338345903, 4.5075187969924801, 3.6503759398496198, 0.30827067669172897 },
                    { 14, 75.0, 45.0, 70.0, 76.0, 40.0, 21.0, 50.0, 266, 77.0, 70.0, 76.0, "Getafe", 26.18, 0.46240601503759399, 2.53383458646617, 1.25187969924812, 0.27067669172932302, 16.560150375939799, 10.6278195488722, 1.0, 0.41729323308270699, 43.345864661654097, 4.6278195488721803, 3.46616541353383, 0.31203007518796999 },
                    { 15, 75.0, 17.0, 45.0, 73.0, 41.0, 6.0, 24.0, 76, 73.0, 43.0, 74.0, "Gijon", 25.449999999999999, 0.36842105263157898, 2.3684210526315801, 1.76315789473684, 0.25, 14.5, 9.8026315789473699, 1.07894736842105, 0.52631578947368396, 43.7631578947368, 4.0526315789473699, 3.3815789473684199, 0.22368421052631601 },
                    { 16, 79.0, 9.8000000000000007, 50.0, 76.0, 40.0, 8.0, 38.0, 76, 76.0, 40.0, 77.0, "Girona", 25.91, 0.144736842105263, 2.3947368421052602, 1.4736842105263199, 0.25, 16.407894736842099, 11.289473684210501, 1.1447368421052599, 0.44736842105263203, 47.460526315789501, 4.8815789473684204, 4.0131578947368398, 0.30263157894736797 },
                    { 17, 77.0, 55.0, 50.0, 76.0, 40.0, 10.0, 48.0, 227, 77.0, 70.0, 77.0, "Granada_CF", 27.09, 0.48017621145374501, 2.5330396475770902, 1.6784140969162999, 0.22026431718061701, 15.7973568281938, 10.568281938326001, 1.03964757709251, 0.506607929515419, 44.748898678414101, 4.6696035242290801, 3.3656387665198202, 0.27312775330396499 },
                    { 18, 73.0, 4.5, 50.0, 73.0, 60.0, 6.0, 22.0, 76, 73.0, 60.0, 73.0, "Huesca", 27.18, 0.27631578947368401, 2.5526315789473699, 1.5526315789473699, 0.32894736842105299, 16.105263157894701, 11.592105263157899, 1.01315789473684, 0.48684210526315802, 46.302631578947398, 5.2763157894736796, 3.7631578947368398, 0.18421052631578899 },
                    { 19, 77.0, 38.0, 47.0, 75.0, 38.0, 8.0, 48.0, 114, 74.0, 55.0, 75.0, "Las_Palmas", 25.82, 0.570175438596491, 2.2543859649122799, 1.76315789473684, 0.21052631578947401, 19.4385964912281, 11.1140350877193, 1.0701754385964899, 0.55263157894736903, 56.1929824561403, 4.7105263157894699, 4.1491228070175401, 0.23684210526315799 },
                    { 20, 75.0, 10.800000000000001, 70.0, 75.0, 40.0, 11.0, 27.0, 151, 75.0, 70.0, 75.0, "Leganes", 27.640000000000001, 0.34437086092715202, 2.4503311258278102, 1.32450331125828, 0.278145695364238, 14.9403973509934, 10.9072847682119, 0.887417218543046, 0.47019867549668898, 43.443708609271503, 4.8675496688741697, 3.5894039735099299, 0.25165562913907302 },
                    { 21, 79.0, 49.0, 60.0, 74.0, 50.0, 13.0, 39.0, 266, 77.0, 70.0, 77.0, "Levante", 28.27, 0.360902255639098, 2.6052631578947398, 1.55639097744361, 0.28195488721804501, 15.451127819548899, 10.7631578947368, 1.13533834586466, 0.43984962406014999, 44.9962406015038, 4.6654135338345899, 3.4924812030075199, 0.278195488721804 },
                    { 22, 75.0, 105.0, 44.0, 75.0, 35.0, 25.0, 86.0, 190, 75.0, 47.0, 75.0, "Malaga", 26.91, 0.42631578947368398, 2.6421052631578901, 1.2894736842105301, 0.231578947368421, 16.378947368421102, 12.0, 1.0105263157894699, 0.47894736842105301, 47.994736842105297, 5.2842105263157899, 4.07368421052632, 0.28947368421052599 },
                    { 23, 75.0, 6.7999999999999998, 50.0, 73.0, 50.0, 14.0, 49.0, 38, 74.0, 60.0, 74.0, "Mallorca", 26.73, 0.81578947368420995, 2.57894736842105, 1.7105263157894699, 0.157894736842105, 15.921052631579, 11.0526315789474, 1.0526315789473699, 0.60526315789473695, 44.552631578947398, 5.0526315789473699, 3.42105263157895, 0.23684210526315799 },
                    { 24, 78.0, 15.0, 70.0, 75.0, 70.0, 2.0, 29.0, 152, 77.0, 60.0, 76.0, "Osasuna", 27.82, 0.33552631578947401, 2.3421052631578898, 1.6973684210526301, 0.28289473684210498, 14.8223684210526, 10.967105263157899, 1.0197368421052599, 0.46710526315789502, 44.052631578947398, 4.9868421052631602, 3.6381578947368398, 0.25 },
                    { 25, 78.0, 10.0, 70.0, 72.0, 60.0, 7.0, 40.0, 152, 74.0, 60.0, 74.0, "Rayo_Vallecano", 27.82, 0.5, 3.0526315789473699, 1.9144736842105301, 0.177631578947368, 16.967105263157901, 13.0592105263158, 1.21710526315789, 0.52631578947368396, 55.210526315789501, 5.5460526315789496, 4.4605263157894699, 0.29605263157894701 },
                    { 26, 83.0, 3100.0, 80.0, 83.0, 50.0, 451.0, 959.0, 304, 86.0, 50.0, 84.0, "Real_Madrid", 28.09, 0.38815789473684198, 3.5888157894736801, 0.96710526315789502, 0.17434210526315799, 15.1940789473684, 17.1184210526316, 2.4078947368421102, 0.14144736842105299, 58.661184210526301, 6.7993421052631602, 6.7302631578947398, 0.68421052631579005 },
                    { 27, 82.0, 150.0, 50.0, 77.0, 40.0, 31.0, 146.0, 304, 80.0, 60.0, 80.0, "Real_Sociedad", 25.18, 0.41447368421052599, 2.8651315789473699, 1.30921052631579, 0.25328947368421101, 16.963815789473699, 12.101973684210501, 1.43421052631579, 0.355263157894737, 53.578947368421098, 5.0855263157894699, 4.1513157894736796, 0.39144736842105299 },
                    { 28, 80.0, 540.0, 70.0, 83.0, 70.0, 48.0, 180.0, 303, 82.0, 80.0, 82.0, "Sevilla", 28.640000000000001, 0.57095709570957098, 2.8019801980198, 1.2046204620462, 0.224422442244224, 14.8448844884488, 12.8844884488449, 1.57755775577558, 0.27062706270627102, 54.174917491749198, 5.4455445544554504, 4.6369636963696399, 0.50495049504950495 },
                    { 29, 77.0, 530.0, 40.0, 78.0, 40.0, 45.0, 248.0, 304, 77.0, 40.0, 78.0, "Valencia", 26.82, 0.47368421052631599, 2.5526315789473699, 1.2401315789473699, 0.28289473684210498, 17.023026315789501, 11.519736842105299, 1.4309210526315801, 0.32236842105263203, 49.368421052631597, 4.8256578947368398, 4.1414473684210504, 0.394736842105263 },
                    { 30, 76.0, 8.9000000000000004, 40.0, 74.0, 40.0, 11.0, 43.0, 152, 76.0, 60.0, 75.0, "Valladolid", 27.640000000000001, 0.29605263157894701, 2.2171052631578898, 1.38815789473684, 0.375, 15.9868421052632, 10.0592105263158, 0.89473684210526305, 0.42105263157894701, 45.756578947368403, 4.5394736842105301, 3.3026315789473699, 0.20394736842105299 },
                    { 31, 83.0, 370.0, 50.0, 79.0, 60.0, 36.0, 123.0, 304, 79.0, 60.0, 80.0, "Villarreal", 27.09, 0.292763157894737, 2.7269736842105301, 1.1315789473684199, 0.26315789473684198, 14.792763157894701, 11.779605263157899, 1.4375, 0.30592105263157898, 49.819078947368403, 4.7138157894736796, 4.3388157894736796, 0.43092105263157898 }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
