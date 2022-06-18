namespace TestTask.Business
{
    public class OilModel
    {
        public string RunName { get; set; }
        public string? ItemTag { get; set; }
        public int NPD { get; set; }
        public double? RunLength { get; set; }
        public double? LineWeight { get; set; }
        public double? RunDiam { get; set; }
        public double? PressureRating { get; set; }
        public string? FluidCode { get; set; }
        public double? Temp { get; set; }
    }
}