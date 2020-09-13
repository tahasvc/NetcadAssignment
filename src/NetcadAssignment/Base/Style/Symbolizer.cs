using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetcadAssignment.Base.Style
{
    public class Symbolizer : ISymbolizer
    {

        /// <summary>
        /// Gets the graphical-symbolization parameter to use to fill the area of the geometry.
        /// </summary>
        /// <value>
        /// Sets the graphical-symbolization parameter to use to fill the area of the geometry.
        /// </value>
        public IFill Fill { get; set; }

        /// <summary>
        /// Gets the graphical-symbolization parameter to use for the outline of a geometry.
        /// </summary>
        /// <value>
        /// Sets the graphical-symbolization parameter to use for the outline of a geometry.
        /// </value>
        public IStroke Stroke { get; set; }

        /// <summary>
        /// Setting default variables
        /// </summary>
        public Symbolizer()
        {
            this.Fill = new Fill();
            this.Stroke = new Stroke();
        }
    }
}