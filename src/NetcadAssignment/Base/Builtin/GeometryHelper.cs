using GeoJSON.Net.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetcadAssignment.Base.Builtin
{
    public class GeometryHelper
    {
        /// <summary>
        /// Returns a distance between 2 points
        /// </summary>
        /// <param name="origin">The first point</param>
        /// <param name="destination">The second point</param>
        public static double GetDistanceFromLatLonInKm(IPosition origin, IPosition destination)
        {
            var R = 6371; // Radius of the earth in km
            var dLat = degToRad(destination.Latitude - origin.Latitude);  // deg2rad below
            var dLon = degToRad(destination.Longitude - origin.Longitude);
            var a =
              Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(degToRad(origin.Latitude)) * Math.Cos(degToRad(destination.Latitude)) *
              Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
              ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c; // Distance in km
            return d;
        }

        /// <summary>
        /// Returns a degree to radian
        /// </summary>
        /// <param name="deg">The point degree value</param>
        /// <returns></returns>
        public static double degToRad(double deg)
        {
            return deg * (Math.PI / 180);
        }

        /// <summary>
        /// Returns points based on angle and radius
        /// </summary>
        /// <param name="position">The point</param>
        /// <param name="angle">Angle value of point</param>
        /// <param name="radius">Radius value of point</param>
        public static IPosition GetLatLong(IPosition position, double angle, double radius)
        {
            var rEarth = 6371000; // meters

            var x0 = position.Latitude * Math.PI / 180; // convert to radians.
            var y0 = position.Latitude * Math.PI / 180;

            var y1 = Math.Asin(Math.Sin(y0) * Math.Cos(radius / rEarth) + Math.Cos(y0) * Math.Sin(radius / rEarth) * Math.Cos(angle));
            var x1 = x0 + Math.Atan2(Math.Sin(angle) * Math.Sin(radius / rEarth) * Math.Cos(y0), Math.Cos(radius / rEarth) - Math.Sin(y0) * Math.Sin(y1));

            y1 = y1 * 180 / Math.PI;
            x1 = x1 * 180 / Math.PI;

            return new Position(x1, y1);
        }
    }
}