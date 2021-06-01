namespace Workout_Tracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExEquipThirdMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ExerciseEquipment", name: "ExericeId", newName: "ExerciseId");
            RenameIndex(table: "dbo.ExerciseEquipment", name: "IX_ExericeId", newName: "IX_ExerciseId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ExerciseEquipment", name: "IX_ExerciseId", newName: "IX_ExericeId");
            RenameColumn(table: "dbo.ExerciseEquipment", name: "ExerciseId", newName: "ExericeId");
        }
    }
}
