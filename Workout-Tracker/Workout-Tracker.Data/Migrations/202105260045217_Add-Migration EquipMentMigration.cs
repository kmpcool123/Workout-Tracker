namespace Workout_Tracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationEquipMentMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExerciseEquipment",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        ExerciseEquipmentName = c.String(nullable: false),
                        ExerciseEquipmentDescription = c.String(nullable: false),
                        TimeLenght = c.DateTime(nullable: false),
                        ExericeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentID)
                .ForeignKey("dbo.Exercise", t => t.ExericeId, cascadeDelete: true)
                .Index(t => t.ExericeId);
            
            CreateTable(
                "dbo.Exercise",
                c => new
                    {
                        ExerciseId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ExerciseName = c.String(nullable: false),
                        ExerciseDescription = c.String(nullable: false),
                        RoutineID = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        Workout_WorkoutID = c.Int(),
                    })
                .PrimaryKey(t => t.ExerciseId)
                .ForeignKey("dbo.Routine", t => t.RoutineID, cascadeDelete: true)
                .ForeignKey("dbo.Workout", t => t.Workout_WorkoutID)
                .Index(t => t.RoutineID)
                .Index(t => t.Workout_WorkoutID);
            
            CreateTable(
                "dbo.Routine",
                c => new
                    {
                        RoutineId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        RoutineName = c.String(nullable: false),
                        RoutineDescription = c.String(),
                        WorkoutID = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.RoutineId)
                .ForeignKey("dbo.Workout", t => t.WorkoutID, cascadeDelete: true)
                .Index(t => t.WorkoutID);
            
            CreateTable(
                "dbo.Workout",
                c => new
                    {
                        WorkoutID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        WorkoutName = c.String(nullable: false),
                        Workout_Description = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.WorkoutID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.ExerciseEquipment", "ExericeId", "dbo.Exercise");
            DropForeignKey("dbo.Exercise", "Workout_WorkoutID", "dbo.Workout");
            DropForeignKey("dbo.Exercise", "RoutineID", "dbo.Routine");
            DropForeignKey("dbo.Routine", "WorkoutID", "dbo.Workout");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Routine", new[] { "WorkoutID" });
            DropIndex("dbo.Exercise", new[] { "Workout_WorkoutID" });
            DropIndex("dbo.Exercise", new[] { "RoutineID" });
            DropIndex("dbo.ExerciseEquipment", new[] { "ExericeId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Workout");
            DropTable("dbo.Routine");
            DropTable("dbo.Exercise");
            DropTable("dbo.ExerciseEquipment");
        }
    }
}
