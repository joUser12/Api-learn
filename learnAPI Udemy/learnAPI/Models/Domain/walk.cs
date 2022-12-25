namespace learnAPI.Models.Domain
{
    public class walk
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Length { get; set; }

        public Guid RegionId { get; set; }

        public Guid WalkDifficulty { get; set; }

        //Navigation properties

        public Region Regions { get; set; }

        public WalkDifficulty WalkDifficultys { get; set; }

    }
}
