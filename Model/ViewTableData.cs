using System;

namespace NHRM_Admin_API.Model
{
    public class ViewTableData
    {
        public string URNumber { get; set; }
        public DateTime DateTimeRecorded { get; set; }
        public double? EcogStatus { get; set; }
        public double? Breathlessness { get; set; }
        public double? LevelOfPain { get; set; }
        public double? FluidDrain { get; set; }
        public double? Mobility { get; set; }
        public double? SelfCare { get; set; }
        public double? UsualActivities { get; set; }
        public double? QolPainDiscomfort { get; set; }
        public double? AnxietyDepressinon { get; set; }
        public double? HealthSlider { get; set; }

        public ViewTableData(string uRNumber, DateTime dateTimeRecorded, double? ecogStatus, double? breathlessness, double? levelOfPain, double? fluidDrain, double? mobility, double? selfCare, double? usualActivities, double? qolPainDiscomfort, double? anxietyDepressinon, double? healthSlider)
        {
            URNumber = uRNumber;
            DateTimeRecorded = dateTimeRecorded;
            EcogStatus = ecogStatus;
            Breathlessness = breathlessness;
            LevelOfPain = levelOfPain;
            FluidDrain = fluidDrain;
            Mobility = mobility;
            SelfCare = selfCare;
            UsualActivities = usualActivities;
            QolPainDiscomfort = qolPainDiscomfort;
            AnxietyDepressinon = anxietyDepressinon;
            HealthSlider = healthSlider;
        }
    }
}