using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storemanager.Application.ViewModels.ResultView
{
   public class ResultViewModel
    {
        public ResultViewModel()
        {
            status = 1;
            message = "success";

        }

        public int status { get; set; }
        public string message { get; set; }
        public object response { get; set; }
        public int totalRecord { get; set; }
    }
}
