using System.ComponentModel.DataAnnotations;

namespace PolyCharge_DAT.Models
{
    public class PRDCTest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Run_Number { get; set; }
        public int Card { get; set; }
        public int Lane { get; set; }
        public string Note_A { get; set; }
        public string? Note_B { get; set; }
        public string Date_Time { get; set; }
        public int Series { get; set; }
        public int Part_Size { get; set; }
        public float Cap_120Hz_uF { get; set; }
        public float Cap_1kHz_uF { get; set; }
        public float DF_1kHz { get; set; }
        public float ESR1_10kHZ_mOhm { get; set; }
        public float ESR2_20kHZ_mOhm { get; set; }
        public float ESR3_100kHz_mOhm { get; set; }
    }
}
