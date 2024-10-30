using Domain.Enums;

namespace Domain.Entities
{
    public class Patient : UserBase
    {
        public IllnessTypes IllnessType { get; set; }
        public string AdditionalInfo { get; set; } = "N/A";
        public string Address { get; set; } = "N/A";
    }
}
