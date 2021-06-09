namespace Workout_Tracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationOne : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exercise", "RoutineID", "dbo.Routine");
            DropIndex("dbo.Exercise", new[] { "RoutineID" });
            RenameColumn(table: "dbo.Exercise", name: "RoutineID", newName: "Routine_RoutineId");
            CreateTable(
                "dbo.ExerciseEquipment",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        ExerciseEquipmentName = c.String(nullable: false),
                        ExerciseEquipmentDescription = c.String(nullable: false),
                        TimeLenght = c.DateTime(nullable: false),
                        ExerciseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentID)
                .ForeignKey("dbo.Exercise", t => t.ExerciseId, cascadeDelete: true)
                .Index(t => t.ExerciseId);
            
            AlterColumn("dbo.Exercise", "Routine_RoutineId", c => c.Int());
            CreateIndex("dbo.Exercise", "Routine_RoutineId");
            AddForeignKey("dbo.Exercise", "Routine_RoutineId", "dbo.Routine", "RoutineId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercise", "Routine_RoutineId", "dbo.Routine");
            DropForeignKey("dbo.ExerciseEquipment", "ExerciseId", "dbo.Exercise");
            DropIndex("dbo.Exercise", new[] { "Routine_RoutineId" });
            DropIndex("dbo.ExerciseEquipment", new[] { "ExerciseId" });
            AlterColumn("dbo.Exercise", "Routine_RoutineId", c => c.Int(nullable: false));
            DropTable("dbo.ExerciseEquipment");
            RenameColumn(table: "dbo.Exercise", name: "Routine_RoutineId", newName: "RoutineID");
            CreateIndex("dbo.Exercise", "RoutineID");
            AddForeignKey("dbo.Exercise", "RoutineID", "dbo.Routine", "RoutineId", cascadeDelete: true);
        }
    }
}
