using GeoJSON.Net.Geometry;
using NetcadAssignment.Base.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace NetcadAssignment.Base.Builtin
{
    public class Helper
    {
        private static readonly Random rnd = new Random();

        /// <summary>
        /// Returns a value that converts html value from color
        /// </summary>
        /// <param name="color">Type of the color</param>
        /// <returns></returns>
        public static string ConvertHtml(Color color)
        {
            return ColorTranslator.ToHtml(Color.FromArgb(color.ToArgb()));
        }

        /// <summary>
        /// Returns a random position with close to Turkey />
        /// </summary>
        public static IPosition CreateRandomPosition()
        {
            double randomLatitude = CreateRandomLatitude();
            double randomLongitude = CreateRandomLongitude();

            return new Position(randomLatitude, randomLongitude);
        }

        /// <summary>
        ///  Returns a random longitude value.The longitude ranges for the values close to Turkey
        /// </summary>
        public static double CreateRandomLongitude()
        {
            double MIN_VALUE_lng = 26.0;
            double MAX_VALUE_lng = 45.0;
            double randomLongitude = rnd.NextDouble() * (MAX_VALUE_lng - MIN_VALUE_lng) + MIN_VALUE_lng;

            return randomLongitude;
        }

        /// <summary>
        ///   Returns a random latitude value.The latitude ranges for the values close to Turkey
        /// </summary>
        public static double CreateRandomLatitude()
        {
            double MIN_VALUE_lat = 36.0;
            double MAX_VALUE_lat = 42.0;
            double randomLatitude = rnd.NextDouble() * (MAX_VALUE_lat - MIN_VALUE_lat) + MIN_VALUE_lat;

            return randomLatitude;
        }

        /// <summary>
        /// Returns a random geometry symbolizer
        /// </summary>
        public static ISymbolizer CreateRandomSymbolizer()
        {
            Symbolizer symbolizer = new Symbolizer();
            symbolizer.Fill.Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            symbolizer.Fill.Opacity = rnd.NextDouble();
            symbolizer.Stroke.Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            symbolizer.Stroke.Opacity = 1;
            symbolizer.Stroke.Width = rnd.Next(1, 5);

            return symbolizer;
        }
    }
}