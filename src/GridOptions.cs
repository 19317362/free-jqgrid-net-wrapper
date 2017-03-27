/****************************************************/
/*                  
/*                                                  
/* Date And Time Created: 3/24/2017 3:07:14 PM                    
/*                  
/****************************************************/

#region using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion using directives

namespace JqGridWrapper
{
    public class GridOptions
    {
        public static GridOptions Default
        {
            get
            {
                return new GridOptions();
            }
        }

        #region free-jqgrid options.

        public string Url { get; set; }

        public string DataType { get; set; }

        public string HttpMethod { get; set; }

        #endregion free-jqgrid options.

        private GridOptions()
        {
            // Set all default settings here.
            Url = "http://127.0.0.1/REST_POC/api/test";
        }
    }
}
