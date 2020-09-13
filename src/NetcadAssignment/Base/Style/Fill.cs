using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace NetcadAssignment.Base.Style
{
    public class Fill : IFill
    {
        /// <summary>
        /// Gets the solid color that will be used for this fill.
        /// </summary>
        /// <value>
        /// Sets the solid color that will be used for this fill.
        /// </value>
        public Color Color { get; set; }

        /// <summary>
        /// Gets the level of translucency to use when rendering the fill.
        /// </summary>
        /// <value>
        /// Sets the level of translucency to use when rendering the fill.
        /// </value>
        public double Opacity { get; set; }

        /// <summary>
        /// Setting default variables
        /// </summary>
        public Fill()
        {
            this.Opacity = 1;
            this.Color = Color.Blue;
        }
    }
}