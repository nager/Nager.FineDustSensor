namespace Nager.FineDustSensor.Sps30.Responses
{
    public class MeasurementCommandResponse : ICommandResponse
    {
        /// <summary>
        /// Mass Concentration PM1 µg/m³
        /// </summary>
        public float MassConcentrationPm1 { get; set; }

        /// <summary>
        /// Mass Concentration PM2.5 µg/m³
        /// </summary>
        public float MassConcentrationPm2_5 { get; set; }

        /// <summary>
        /// Mass Concentration PM4 µg/m³
        /// </summary>
        public float MassConcentrationPm4 { get; set; }

        /// <summary>
        /// Mass Concentration PM10 µg/m³
        /// </summary>
        public float MassConcentrationPm10 { get; set; }


        /// <summary>
        /// Number Concentration PM0.5 particles/cm³
        /// </summary>
        public float NumberConcentrationPm0_5 { get; set; }

        /// <summary>
        /// Number Concentration PM1 particles/cm³
        /// </summary>
        public float NumberConcentrationPm1 { get; set; }

        /// <summary>
        /// Number Concentration PM2.5 particles/cm³
        /// </summary>
        public float NumberConcentrationPm2_5 { get; set; }

        /// <summary>
        /// Number Concentration PM4 particles/cm³
        /// </summary>
        public float NumberConcentrationPm4 { get; set; }

        /// <summary>
        /// Number Concentration PM10 particles/cm³
        /// </summary>
        public float NumberConcentrationPm10 { get; set; }


        /// <summary>
        /// Typical Particle Size µm
        /// </summary>
        public float TypicalParticleSize { get; set; }
    }
}
