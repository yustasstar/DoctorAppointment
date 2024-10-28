using Domain.Enums;

namespace Domain.Entities
{
    public class Patient : UserBase
    {
        public IllnessTypes IllnessType { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? Address { get; set; }
    }
}
