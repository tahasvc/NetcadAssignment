using NetcadAssignment.Base.Builtin;
using NetcadAssignment.Base.Style;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace NetcadAssignment.Base.Converters
{
    /// <summary>
    ///     Converter to read and write an <see cref="ISymbolizer" />, that is,
    ///     the symbolizer of a <see cref="Symbolizer" />.
    /// </summary>
    public class SymbolizerConverter : JsonConverter
    {
        /// <summary>
        ///     Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        ///     <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Symbolizer);
        }

        /// <summary>
        ///     Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        ///     The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Symbolizer symbolizer;
            try
            {
                symbolizer = serializer.Deserialize<Symbolizer>(reader);
            }
            catch (Exception e)
            {
                throw new JsonReaderException("error parsing symbolizer", e);
            }
            return symbolizer?.Equals(null) ?? throw new JsonReaderException("symbolizer cannot be null");
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is ISymbolizer symbolizer)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("fill");
                writer.WriteValue(Helper.ConvertHtml(symbolizer.Fill.Color));
                writer.WritePropertyName("fill-opacity");
                writer.WriteValue(symbolizer.Fill.Opacity);
                writer.WritePropertyName("stroke");
                writer.WriteValue(Helper.ConvertHtml(symbolizer.Stroke.Color));
                writer.WritePropertyName("stroke-opacity");
                writer.WriteValue(symbolizer.Stroke.Opacity);
                writer.WritePropertyName("stroke-width");
                writer.WriteValue(symbolizer.Stroke.Width);
                writer.WriteEndObject();
            }
        }
    }
}