using GeoJSON.Net.Geometry;
using NetcadAssignment.Base.Converters;
using NetcadAssignment.Base.CoreGis.Geometry;
using NetcadAssignment.Base.Style;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetcadAssignment.Base.Geometry
{
    public class Triangle : Polygon, IGeometry
    {
        public Triangle(IEnumerable<LineString> coordinates) : base(coordinates)
        {
        }

        /// <summary>
        /// Returns a symbolizer from instance
        /// </summary>
        [JsonProperty("properties", Required = Required.Default)]
        [JsonConverter(typeof(SymbolizerConverter))]
        public ISymbolizer Symbolizer { get; set; }

        /// <summary>
        /// Returns a serialize object from geojson
        /// </summary>
        public string SerializeObject()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}