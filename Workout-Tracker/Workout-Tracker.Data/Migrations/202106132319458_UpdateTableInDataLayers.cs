namespace Workout_Tracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableInDataLayers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExerciseEquipment", "ExerciseId", "dbo.Exercise");
            DropForeignKey("dbo.Exercise", "RoutineID", "dbo.Routine");
            DropForeignKey("dbo.Routine", "WorkoutID", "dbo.Workout");
            DropIndex("dbo.ExerciseEquipment", new[] { "ExerciseId" });
            DropIndex("dbo.Exercise", new[] { "RoutineID" });
            DropIndex("dbo.Routine", new[] { "WorkoutID" });
            AlterColumn("dbo.ExerciseEquipment", "ExerciseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Exercise", "RoutineID", c => c.Int(nullable: false));
            AlterColumn("dbo.Routine", "WorkoutID", c => c.Int(nullable: false));
            CreateIndex("dbo.ExerciseEquipment", "ExerciseId");
            CreateIndex("dbo.Exercise", "RoutineID");
            CreateIndex("dbo.Routine", "WorkoutID");
            AddForeignKey("dbo.ExerciseEquipment", "ExerciseId", "dbo.Exercise", "ExerciseId", cascadeDelete: true);
            AddForeignKey("dbo.Exercise", "RoutineID", "dbo.Routine", "RoutineId", cascadeDelete: true);
            AddForeignKey("dbo.Routine", "WorkoutID", "dbo.Workout", "WorkoutID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routine", "WorkoutID", "dbo.Workout");
            DropForeignKey("dbo.Exercise", "RoutineID", "dbo.Routine");
            DropForeignKey("dbo.ExerciseEquipment", "ExerciseId", "dbo.Exercise");
            DropIndex("dbo.Routine", new[] { "WorkoutID" });
            DropIndex("dbo.Exercise", new[] { "RoutineID" });
            DropIndex("dbo.ExerciseEquipment", new[] { "ExerciseId" });
            AlterColumn("dbo.Routine", "WorkoutID", c => c.Int());
            AlterColumn("dbo.Exercise", "RoutineID", c => c.Int());
            AlterColumn("dbo.ExerciseEquipment", "ExerciseId", c => c.Int());
            CreateIndex("dbo.Routine", "WorkoutID");
            CreateIndex("dbo.Exercise", "RoutineID");
            CreateIndex("dbo.ExerciseEquipment", "ExerciseId");
            AddForeignKey("dbo.Routine", "WorkoutID", "dbo.Workout", "WorkoutID");
            AddForeignKey("dbo.Exercise", "RoutineID", "dbo.Routine", "RoutineId");
            AddForeignKey("dbo.ExerciseEquipment", "ExerciseId", "dbo.Exercise", "ExerciseId");
        }
    }
}
