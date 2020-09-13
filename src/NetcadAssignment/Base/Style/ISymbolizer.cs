using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetcadAssignment.Base.Style
{
    public interface ISymbolizer
    {
        /// <summary>
        /// Gets the graphical-symbolization parameter to use to fill the area of the geometry.
        /// </summary>
        /// <value>
        /// Sets the graphical-symbolization parameter to use to fill the area of the geometry.
        /// </value>
        IFill Fill { get; set; }

        /// <summary>
        /// Gets the graphical-symbolization parameter to use for the outline of a geometry.
        /// </summary>
        /// <value>
        /// Sets the graphical-symbolization parameter to use for the outline of a geometry.
        /// </value>
        IStroke Stroke { get; set; }
    }
}
