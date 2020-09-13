using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace NetcadAssignment.Base.Style
{
    public class Stroke : IStroke
    {
        /// <summary>
        /// Gets the solid color that will be used for this stroke color.
        /// </summary>
        /// <value>
        /// Sets the solid color that will be used for this stroke color.
        /// </value>
        public Color Color { get; set; }

        /// <summary>
        /// Gets the absolute width (thickness) of a stroke in pixels.
        /// </summary>
        /// <value>
        /// Sets the absolute width (thickness) of a stroke in pixels.
        /// </value>
        public int Width { get; set; }

        /// <summary>
        /// Gets the level of translucency to use when rendering the stroke.
        /// </summary>
        /// <value>
        /// Sets the level of translucency to use when rendering the stroke.
        /// </value>
        public double Opacity { get; set; }

        /// <summary>
        /// Setting default variables
        /// </summary>
        public Stroke()
        {
            this.Color = Color.Blue;
            this.Width = 1;
            this.Opacity = 1;
        }
    }
}