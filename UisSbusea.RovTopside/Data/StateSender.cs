using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace UisSubsea.RovTopside.Data
{
    class StateSender : IDisposable
    {

        private IList <PacketBuilder> packetBuilder;
        private SerialPort port;

        private const byte startByte1 = 155;
        private const byte startByte2 = 185;

        public StateSender(IList <PacketBuilder> pb)
        {
            this.packetBuilder = pb;
            port = SerialPortSingleton.Instance;

            if (!port.IsOpen)
                port.Open();
        }


        // create the byte sequence to send
        public byte[] WriteState() 
        {
            
            List<byte> state = new List<byte>();

            byte packageLength = 0; // temp filler

            state.Add(startByte1);
            state.Add(startByte2);
            state.Add(0x11);
            state.Add(packageLength);

            foreach ( PacketBuilder builder in packetBuilder)
            {
                byte[] package = builder.BuildJoystickStatePacket();
                foreach (byte b in package)
                {
                    state.Add(b);
                    packageLength++;
                }
            }

            state.Add(0);
            state.Add(0);
            packageLength++;
            packageLength++;

            state.Insert(2, packageLength);
            //state.Insert(2, (byte)(state.Count - 3)); // updates the packetLength


            byte[] finaleState = state.ToArray();
            port.Write(finaleState, 0, state.Count);
            return finaleState;
        }
      

        public void Dispose()
        {
            if (port != null)
                port.Dispose();
        }

    }
}
