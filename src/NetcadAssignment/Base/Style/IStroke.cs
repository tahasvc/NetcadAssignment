using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetcadAssignment.Base.Style
{
    public interface IStroke
    {
        /// <summary>
        /// Gets the solid color that will be used for this stroke color.
        /// </summary>
        /// <value>
        /// Sets the solid color that will be used for this stroke color.
        /// </value>
        Color Color { get; set; }

        /// <summary>
        /// Gets the absolute width (thickness) of a stroke in pixels.
        /// </summary>
        /// <value>
        /// Sets the absolute width (thickness) of a stroke in pixels.
        /// </value>
        int Width { get; set; }

        /// <summary>
        /// Gets the level of translucency to use when rendering the stroke.
        /// </summary>
        /// <value>
        /// Sets the level of translucency to use when rendering the stroke.
        /// </value>
        double Opacity { get; set; }
    }
}
