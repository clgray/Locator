using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;

namespace CertApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateCert("localhost");
            CreateCert(Dns.GetHostName());

            IPAddress[] addr = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            for (int i = 0; i < addr.Length; i++)
            {
                CreateCert(addr[i].ToString());
            }
        }

        public static void CreateCert(string name)
        {
            Process ps = new Process();
            ps.StartInfo.FileName = "makecert.exe";
            ps.StartInfo.Arguments = String.Format(@"-n CN={0} -ss My -pe -sky exchange -sr LocalMachine", name);
            ps.Start();

            Process ps2 = new Process();
            ps2.StartInfo.FileName = "winhttpcertcfg.exe";
            ps2.StartInfo.Arguments = String.Format(@"-g -c Local_Machine\My -s {0} -a NetworkService", name);
            ps2.Start();
        }
    }
}
