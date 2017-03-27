/****************************************************/
/*                  
/*                                                  
/* Date And Time Created: 3/24/2017 3:03:10 PM                    
/*                  
/****************************************************/

#region using directives
using JqGridWrapper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion using directives

namespace JqGridWrapper
{
    public class ColumnOptions
    {
        private const int DefaultWidth = 150;
        private const Alignment DefaultAlignment = Alignment.Center;
        private const ColumnTemplate DefaultColumnTemplate = ColumnTemplate.None;

        private ColumnOptions(string name)
        {
            Name = name;

            // Set default values where underlying type does not have suitable default.
            HeaderText = name;
            Width = DefaultWidth;
            LabelAlign = TextAlign = DefaultAlignment;
            Template = DefaultColumnTemplate;
        }

        public static ColumnOptions Default(string name)
        {
            var result = new ColumnOptions(name);
                        
            return result;
        }

        public string Name { get; private set; }

        public string HeaderText { get; set; }

        public int Width { get; set; }

        public Alignment LabelAlign { get; set; }

        public Alignment TextAlign { get; set; }

        public bool Autoresizable { get; set; }

        public bool Hidden { get; set; }

        public ColumnTemplate Template { get; set; }
    }
}
