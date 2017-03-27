/****************************************************/
/*                  
/*                                                  
/* Date And Time Created: 3/24/2017 2:58:53 PM                    
/*                  
/****************************************************/

#region using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion using directives

namespace JqGridWrapper.T4
{
    public partial class JqGridServerJson
    {
        public GridOptions Options { get; private set; }

        public IEnumerable<ColumnOptions> Columns { get; private set; }

        public JqGridServerJson(GridOptions options, IEnumerable<ColumnOptions> columns)
        {
            Options = options;
            Columns = columns;
        }
    }
}
