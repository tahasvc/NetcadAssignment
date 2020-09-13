using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetcadAssignment.Base.Style
{
    public interface IFill
    {
        /// <summary>
        /// Gets the solid color that will be used for this fill.
        /// </summary>
        /// <value>
        /// Sets the solid color that will be used for this fill.
        /// </value>
        Color Color { get; set; }

        /// <summary>
        /// Gets the level of translucency to use when rendering the fill.
        /// </summary>
        /// <value>
        /// Sets the level of translucency to use when rendering the fill.
        /// </value>
        double Opacity { get; set; }
    }
}
