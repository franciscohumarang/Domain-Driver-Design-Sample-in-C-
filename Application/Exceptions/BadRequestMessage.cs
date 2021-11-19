using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
   public  class BadRequestMessage
    {  public string Message { get; set; }
     

        public BadRequestMessage(Exception ex )
        {
            var message = "";
            if (ex.InnerException != null)
                message = ex.InnerException.Message;
            else
                message = ex.Message;

            this.Message = "API Error: " + message;
        }

    }
}
