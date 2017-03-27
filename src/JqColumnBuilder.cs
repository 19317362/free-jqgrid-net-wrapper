/****************************************************/
/*                  
/*                                                  
/* Date And Time Created: 3/24/2017 3:00:24 PM                    
/*                  
/****************************************************/

#region using directives
using JqGridWrapper.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

#endregion using directives

namespace JqGridWrapper
{
    public abstract class JqColumnBuilder
    {        
        private readonly IReadOnlyCollection<ColumnOptions> _columns;

        protected IList<ColumnOptions> _columnOptions;
        protected int _columnCount = 0;

        public JqColumnBuilder()
        {
            _columnOptions = new List<ColumnOptions>();
            _columns = new ReadOnlyCollection<ColumnOptions>(_columnOptions);
        }

        protected ColumnOptions LastColumn
        {
            get
            {
                return _columnOptions[_columnCount - 1];
            }
        }

        public int ColumnCount
        {
            get
            {
                return _columnCount;
            }
        }

        public IReadOnlyCollection<ColumnOptions> Columns
        {
            get
            {
                return _columns;
            }
        }

        /**
        Settings 
        */

        public JqColumnBuilder Add(string columnName)
        {            
            var column = ColumnOptions.Default(columnName);

            // Add column to collection.
            _columnOptions.Add(column);
            _columnCount = _columnOptions.Count;

            return this;
        }

        public JqColumnBuilder HeaderText(string headerText)
        {
            LastColumn.HeaderText = headerText;

            return this;
        }

        public JqColumnBuilder Width(int width)
        {
            LastColumn.Width = width;

            return this;
        }

        public JqColumnBuilder LabelAlign(Alignment alignment)
        {
            LastColumn.LabelAlign = alignment;

            return this;
        }

        public JqColumnBuilder TextAlign(Alignment alignment)
        {
            LastColumn.TextAlign = alignment;

            return this;
        }

        public JqColumnBuilder IsAutoresizable(bool isAutoresizable)
        {
            LastColumn.Autoresizable = isAutoresizable;

            return this;
        }

        public JqColumnBuilder IsHidden(bool isHidden)
        {
            LastColumn.Hidden = isHidden;

            return this;
        }

        public JqColumnBuilder Template(ColumnTemplate template)
        {
            LastColumn.Template = template;

            return this;
        }
    }

    public class JqColumnBuilder<T> : JqColumnBuilder
    {                
        public JqColumnBuilder<T> Add<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            var name = (expression.Body as MemberExpression).Member.Name; 

            base.Add(name);

            return this;
        }
    }
}
