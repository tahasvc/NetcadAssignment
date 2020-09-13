using NetcadAssignment.Base.Style;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetcadAssignment.Base.CoreGis.Geometry
{
    public interface IGeometry
    {
        /// <summary>
        ///  Symbolizer describes how a feature should appear on a map.The symbolizer describes not just the shape
        ///  that should appear but also such graphical properties as color and opacity.
        /// </summary>
        ISymbolizer Symbolizer { get; set; }

        /// <summary>
        ///  Serialize object to geojson format
        /// </summary>
        /// <returns>
        /// Returns a serialize from <see cref="JsonConvert.SerializeObject"/> method
        /// </returns>
        string SerializeObject();
    }
}