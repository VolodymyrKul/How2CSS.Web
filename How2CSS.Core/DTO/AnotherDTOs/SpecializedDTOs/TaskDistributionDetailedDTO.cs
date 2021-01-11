namespace How2CSS.Core.DTO.AnotherDTOs.SpecializedDTOs
{
    public class TaskDistributionDetailedDTO
    {
        public string TaskDifficulty { get; set; }
        public int TaskOrder { get; set; }
        public CSSTaskDetailedDTO Task { get; set; }
    }
}
