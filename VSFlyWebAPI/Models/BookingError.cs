using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSFlyWebAPI.Models
{
    public class BookingError
    {
        public BookingError(int Code, string Message) {
            this.Message = Message;
            this.Code = Code;
        }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
