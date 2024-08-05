namespace Nager.FineDustSensor.Sps30.Helpers
{
    public static class ChecksumHelper
    {
        /// <summary>
        /// Calculate Checksum
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte CalculateChecksum(Span<byte> data)
        {
            var sum = 0;

            foreach (byte b in data)
            {
                sum += b;
            }

            var lsb = (byte)(sum & 0xFF);

            return (byte)~lsb;
        }
    }
}
