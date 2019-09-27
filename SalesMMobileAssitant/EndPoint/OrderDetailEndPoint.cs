using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.EndPoint
{
    public class OrderDetailEndPoint
    {
        private static OrderDetailEndPoint _Ins;

        public static OrderDetailEndPoint Ins
        {
            get
            {
                if (_Ins == null)
                    _Ins = new OrderDetailEndPoint();
                return OrderDetailEndPoint._Ins;
            }
            private set
            {
                OrderDetailEndPoint._Ins = value;
            }
        }
    }
}
