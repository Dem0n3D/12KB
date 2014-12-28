using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Servis
{
    [MessageContract]
    public class DivInputMessage
    {
        [MessageHeader]
        public string Header { get; set; }

        [MessageBodyMember]
        public int A { get; set; }

        [MessageBodyMember]
        public int B { get; set; }
    }
}
