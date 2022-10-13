using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace EasyRunner.Utils
{
    enum Verbs {
        WILL = 251,
        WONT = 252,
        DO = 253,
        DONT = 254,
        IAC = 255
    }

    enum Options
    {
        SGA = 3
    }

    class TelnetClinet
    {
        TcpClient tcpSocket;

        int TimeOutMs = 100;

        public TelnetClinet()
        {
            tcpSocket = new TcpClient();
        }

        public async Task ConnectAsync(string Hostname, int Port)
        {
            
            try
            {
                await tcpSocket.ConnectAsync(Hostname, Port);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task LoginAsync(string Username,string Password,int LoginTimeOutMs)
        {
            int oldTimeOutMs = TimeOutMs;
            TimeOutMs = LoginTimeOutMs;
            string s = await ReadAsync();
            if (!s.TrimEnd().EndsWith(":"))
               throw new Exception("Failed to connect : no login prompt");
            await WriteLineAsync(Username);

            s = await ReadAsync();
            if (!s.TrimEnd().EndsWith(":"))
                throw new Exception("Failed to connect : no password prompt");
            await WriteLineAsync(Password);

            s = (await ReadAsync()).Trim();

            if (s.Equals(""))
                throw new Exception("��¼ʧ��");
            TimeOutMs = oldTimeOutMs;

            //return s;
        }

        public async Task WriteLineAsync(string cmd)
        {
            await Write(cmd + "\n");
        }

        public async Task Write(string cmd)
        {
            if (!tcpSocket.Connected) return;
            byte[] buf = ASCIIEncoding.ASCII.GetBytes(cmd.Replace("\0xFF","\0xFF\0xFF"));
            await tcpSocket.GetStream().WriteAsync(buf, 0, buf.Length);
        }

        public async Task<string> ReadAsync()
        {
            return await Task<string>.Run(() =>
            {
                if (!tcpSocket.Connected) return null;
                StringBuilder sb = new StringBuilder();
                do
                {
                    ParseTelnet(sb);
                    Thread.Sleep(TimeOutMs);
                } while (tcpSocket.Available > 0);

                string s = sb.ToString();
                var ss = s.Split("\n");
                if (ss.Length > 1)
                {
                    string res = "";
                    for (int i = 1; i < ss.Length; i++)
                    {
                        res += ss[i] + "\n";
                    }

                    return res.Remove(res.Length - 1);
                }
                return s;
            });
        }

        public bool IsConnected
        {
            get { return tcpSocket.Connected; }
        }

        void ParseTelnet(StringBuilder sb)
        {
            while (tcpSocket.Available > 0)
            {
                int input = tcpSocket.GetStream().ReadByte();
                switch (input)
                {
                    case -1 :
                        break;
                    case (int)Verbs.IAC:
                        // interpret as command
                        int inputverb = tcpSocket.GetStream().ReadByte();
                        if (inputverb == -1) break;
                        switch (inputverb)
                        {
                            case (int)Verbs.IAC: 
                                //literal IAC = 255 escaped, so append char 255 to string
                                sb.Append(inputverb);
                                break;
                            case (int)Verbs.DO: 
                            case (int)Verbs.DONT:
                            case (int)Verbs.WILL:
                            case (int)Verbs.WONT:
                                // reply to all commands with "WONT", unless it is SGA (suppres go ahead)
                                int inputoption = tcpSocket.GetStream().ReadByte();
                                if (inputoption == -1) break;
                                tcpSocket.GetStream().WriteByte((byte)Verbs.IAC);
                                if (inputoption == (int)Options.SGA )
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WILL:(byte)Verbs.DO); 
                                else
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WONT : (byte)Verbs.DONT); 
                                tcpSocket.GetStream().WriteByte((byte)inputoption);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        sb.Append( (char)input );
                        break;
                }
            }
        }
    }
}
