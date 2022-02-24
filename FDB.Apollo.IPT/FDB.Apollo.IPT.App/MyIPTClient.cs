using FDB.Apollo.IPT.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDB.Apollo.IPT.App
{
    internal static class MyIPTClient
    {
        private static IPTClient _iptClient;

        public static IPTClient IPTClient
        {
            get
            {
                if (_iptClient == null)
                {
                    using (var ap = new ApiPrompt())
                    {
                        var dr = ap.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            string baseURL = ap.ReturnValue;
                            _iptClient = new IPTClient(baseURL, new HttpClient());
                        }
                    }
                }

                return _iptClient;
            }
        }
    }
}
