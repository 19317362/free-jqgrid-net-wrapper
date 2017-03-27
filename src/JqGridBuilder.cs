using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace JqGridWrapper
{
    public abstract class JqGridBuilder
    {
        protected JqColumnBuilder _columnBuilder;

        public JqGridBuilder(JqColumnBuilder columnBuilder)
        {
            _columnBuilder = columnBuilder;

            Options = GridOptions.Default;                             
        }

        public GridOptions Options { get; private set; }

        public IEnumerable<ColumnOptions> ColumnOptions { get { return _columnBuilder.Columns; } }
    }

    /// <summary>
    /// Sets free-jqGrid's options that apply at the grid level.
    /// </summary>
    /// <typeparam name="T">Type parameter that provides better design time support and intellisense.</typeparam>
    public class JqGridBuilder<T> : JqGridBuilder
    {
        public JqGridBuilder(JqColumnBuilder<T> columnBuilder)
            : base(columnBuilder)
        {
        }

        public static JqGridBuilder<T> Model()
        {
            return new JqGridBuilder<T>(new JqColumnBuilder<T>());
        }

        /// <summary>
        /// Use this at design time to define the columns' properties.
        /// </summary>
        /// <param name="buildAction">Action that sets the properties.</param>
        /// <returns>JqBuilder instance for call chaining.</returns>
        public JqGridBuilder<T> Columns(Action<JqColumnBuilder<T>> buildAction)
        {            
            buildAction(_columnBuilder as JqColumnBuilder<T>);

            return this;
        }

        /// <summary>
        /// Non-generic method, you can use to manually enter property names.
        /// </summary>
        /// <param name="buildAction"></param>
        /// <returns></returns>
        public JqGridBuilder Columns(Action<JqColumnBuilder> buildAction)
        {            
            buildAction(_columnBuilder);

            return this;
        }

        public MvcHtmlString Render()
        {
            // Generate dynamic javascript file and make it available via a link.
            // Output the <script> tag with src set to the dynamic file.
            string js = new T4.JqGridServerJson(Options, ColumnOptions).TransformText();
            string id = Math.Abs(Guid.NewGuid().GetHashCode()).ToString();
            // Get server path to Scripts/Dynamic folder.
            string folder = HttpContext.Current.Server.MapPath("~/Scripts/Dynamic");

            if (folder.Substring(folder.Length - 1) != @"\")
                folder = folder + @"\";

            string fileName = "dynamic_jqGrid_" + id + ".js";

            string path = folder + fileName;

            if (File.Exists(path))
                File.Delete(path);

            using (var fileStream = File.CreateText(path))
            {
                fileStream.WriteLine(js);
                fileStream.Close();
            }

            TagBuilder builder = new TagBuilder("script");
            builder.MergeAttribute("type", "text/javascript");
            builder.MergeAttribute("src", new UrlHelper(HttpContext.Current.Request.RequestContext).Content("~/Scripts/Dynamic/" + fileName));

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
        
    }
}
