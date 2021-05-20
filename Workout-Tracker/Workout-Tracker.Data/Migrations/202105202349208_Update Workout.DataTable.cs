namespace Workout_Tracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWorkoutDataTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workout", "WorkoutName", c => c.String(nullable: false));
            AddColumn("dbo.Workout", "Workout_Description", c => c.String(nullable: false));
            DropColumn("dbo.Workout", "NameOfWorkout");
            DropColumn("dbo.Workout", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workout", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Workout", "NameOfWorkout", c => c.String(nullable: false));
            DropColumn("dbo.Workout", "Workout_Description");
            DropColumn("dbo.Workout", "WorkoutName");
        }
    }
}
