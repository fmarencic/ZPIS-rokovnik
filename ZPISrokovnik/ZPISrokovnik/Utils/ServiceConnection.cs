using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace ZPISrokovnik.Utils
{
    public static class ServiceConnection
    {
        public static EndpointAddress Endpoint = new EndpointAddress("http://zpiscloudservice.cloudapp.net/Service1.svc");

        public static BasicHttpBinding CreateBasicHttpBinding()
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "basicHttpBinding",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };

            //TimeSpan timeout = new TimeSpan(0, 0, 30);
            //binding.SendTimeout = timeout;
            //binding.OpenTimeout = timeout;
            //binding.ReceiveTimeout = timeout;
            return binding;
        }
    }
}
