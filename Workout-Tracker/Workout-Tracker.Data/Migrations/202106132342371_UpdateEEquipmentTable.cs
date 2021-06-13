namespace Workout_Tracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEEquipmentTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExerciseEquipment", "ExerciseId", "dbo.Exercise");
            DropIndex("dbo.ExerciseEquipment", new[] { "ExerciseId" });
            AlterColumn("dbo.ExerciseEquipment", "ExerciseId", c => c.Int());
            CreateIndex("dbo.ExerciseEquipment", "ExerciseId");
            AddForeignKey("dbo.ExerciseEquipment", "ExerciseId", "dbo.Exercise", "ExerciseId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExerciseEquipment", "ExerciseId", "dbo.Exercise");
            DropIndex("dbo.ExerciseEquipment", new[] { "ExerciseId" });
            AlterColumn("dbo.ExerciseEquipment", "ExerciseId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExerciseEquipment", "ExerciseId");
            AddForeignKey("dbo.ExerciseEquipment", "ExerciseId", "dbo.Exercise", "ExerciseId", cascadeDelete: true);
        }
    }
}
