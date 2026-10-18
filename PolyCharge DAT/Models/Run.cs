using System.ComponentModel.DataAnnotations;

namespace PolyCharge_DAT.Models
{
    public class Run
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Run_Number { get; set; }
        public string Customer_Product { get; set; }
        public string? Project_Number { get; set; }
        public string? Date_Run { get; set; }
        public string? Pre_Run_Notes { get; set; }
        public float? Oiler_Offset { get; set; }
        public int? Evap_Tank_Temp { get; set; }
        public int? Evap_Nozzel_Temp { get; set; }
        public string? Slit_Gap { get; set; }
        public int? Target_Thickness { get; set; }
        public int? Mono_Flow_Rate { get; set; }
        public string? Mono_Pump { get; set; }
        public int? Wire_Inner_Speed { get; set; }
        public string? Wire_Outer_Boat { get; set; }
        public string? Wire_2nd_Outer_Boat { get; set; }
        public float? Target_OD { get; set; }
        public int? E_Gun_KV { get; set; }
        public int? E_Gun_mA { get; set; }
        public int? E_Gun_Ar_Flow { get; set; }
        public string? Magnetron_Supply { get; set; }
        public string? Magnetron_Power { get; set; }
        public int? Magnetron_Ar_Gas_Flow { get; set; }
        public int? Magnetron_O2_Gas_Flow { get; set; }
        public string? Shadow_Mask { get; set; }
        public float? Shadow_Mask_Start_Position { get; set; }
        public int? Shadow_Mask_Movement { get; set; }
        public string? Oiler_Faceplates { get; set; }
        public int? Oiler_Temperature { get; set; }
        public int? Oiler_Gas_Flow { get; set; }
        public int? Oiler_Start_Position { get; set; }
        public float? Oiler_Shift { get; set; }
        public int? Oiler_Step_back { get; set; }
        public int? Drum_Temp { get; set; }
        public int? Web_Speed { get; set; }
        public string? Film { get; set; }
        public string? Release { get; set; }
        public int? Bottom_Mono_Only_Layers { get; set; }
        public int? Bottom_Inactive_Layers { get; set; }
        public int? Active_Layers { get; set; }
        public int? Top_Inactive_Layers { get; set; }
        public int? Top_Mono_Only_Layers { get; set; }
        public int? Total_layers { get; set; }
    }
}
