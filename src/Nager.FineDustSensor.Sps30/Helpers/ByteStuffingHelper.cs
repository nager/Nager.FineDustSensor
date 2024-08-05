namespace Nager.FineDustSensor.Sps30.Helpers
{
    public static class ByteStuffingHelper
    {
        private const byte EscapeCharacter = 0x7D;

        public static byte[] Add(byte[] data)
        {
            using var memoryStream = new MemoryStream();

            for (var i = 0; i < data.Length; i++)
            {
                // Ignore first and last byte
                if (i == 0 || i == data.Length - 1)
                {
                    memoryStream.WriteByte(data[i]);
                    continue;
                }

                if (data[i] == 0x7E)
                {
                    memoryStream.WriteByte(EscapeCharacter);
                    memoryStream.WriteByte(0x5E);
                    continue;
                }

                if (data[i] == 0x7D)
                {
                    memoryStream.WriteByte(EscapeCharacter);
                    memoryStream.WriteByte(0x5D);
                    continue;
                }

                if (data[i] == 0x11)
                {
                    memoryStream.WriteByte(EscapeCharacter);
                    memoryStream.WriteByte(0x31);
                    continue;
                }

                if (data[i] == 0x13)
                {
                    memoryStream.WriteByte(EscapeCharacter);
                    memoryStream.WriteByte(0x33);
                    continue;
                }

                memoryStream.WriteByte(data[i]);
            }

            return memoryStream.ToArray();
        }

        public static byte[] Remove(byte[] data)
        {
            using var memoryStream = new MemoryStream();

            for (var i = 0; i < data.Length; i++)
            {
                if (data[i] == EscapeCharacter)
                {
                    var nextIndex = i + 1;
                    if (nextIndex == data.Length)
                    {
                        memoryStream.WriteByte(data[i]);
                        break;
                    }

                    var nextByte = data[nextIndex];

                    switch (nextByte)
                    {
                        case 0x5E:
                            memoryStream.WriteByte(0x7E);
                            break;
                        case 0x5D:
                            memoryStream.WriteByte(0x7D);
                            break;
                        case 0x31:
                            memoryStream.WriteByte(0x11);
                            break;
                        case 0x33:
                            memoryStream.WriteByte(0x13);
                            break;
                    }

                    i++;
                    continue;
                }


                memoryStream.WriteByte(data[i]);
            }

            return memoryStream.ToArray();
        }
    }
}
