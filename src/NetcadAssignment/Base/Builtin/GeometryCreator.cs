using GeoJSON.Net.Geometry;
using NetcadAssignment.Base.Geometry;
using NetcadAssignment.Base.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetcadAssignment.Base.Builtin
{
    /// <summary>
    ///     This instance is random generator to respective geometry types
    /// </summary>
    public static class GeometryCreator
    {
        /// <summary>
        /// This function create a random circle 
        /// </summary>
        public static Circle CreateCircle()
        {
            IPosition position = Helper.CreateRandomPosition();
            ISymbolizer symbolizer = Helper.CreateRandomSymbolizer();
            Circle circle = new Circle(position);
            circle.Symbolizer = symbolizer;

            return circle;
        }

        /// <summary>
        /// This function create a random square 
        /// </summary>
        public static Square CreateSquare()
        {
            IPosition position1 = Helper.CreateRandomPosition();
            Position position2 = new Position(Helper.CreateRandomLatitude(), position1.Longitude);
            double distance = GeometryHelper.GetDistanceFromLatLonInKm(position1, position2); //distance between 2 points
            double newLongitude = position2.Longitude + (distance / 6378) * (180 / Math.PI) / Math.Cos(position2.Latitude * Math.PI / 180); // for vertex equality
            Position position3 = new Position(position2.Latitude, newLongitude);
            Position position4 = new Position(position1.Latitude, position3.Longitude);
            Square polygon = new Square(new List<LineString>
            {
                new LineString(new List<IPosition>
                {
                    position1,
                    position2,
                    position3,
                    position4,
                    position1
                })
            });
            polygon.Symbolizer = Helper.CreateRandomSymbolizer();

            return polygon;
        }

        /// <summary>
        /// This function create a random triangle 
        /// </summary>
        public static Triangle CreateTriangle()
        {
            IPosition position1 = Helper.CreateRandomPosition();
            IPosition position2 = Helper.CreateRandomPosition();
            IPosition position3 = Helper.CreateRandomPosition();

            Triangle polygon = new Triangle(new List<LineString>
            {
                new LineString(new List<IPosition>
                {
                    position1,
                    position2,
                    position3,
                    position1
                })
            });
            polygon.Symbolizer = Helper.CreateRandomSymbolizer();

            return polygon;
        }

        /// <summary>
        /// This function create a random ellipse 
        /// </summary>
        public static Ellipse CreateEllipse()
        {
            IPosition position = Helper.CreateRandomPosition();
            double x = position.Latitude;
            double y = position.Longitude;
            double a = 50000; //axes in meters
            double b = 22000; //axes in meters
            var rotation = 0;
            var k = Math.Ceiling(36 * (Math.Max(a / b, b / a)));
            List<IPosition> coords = new List<IPosition>();
            for (var i = 0; i <= k; i++)
            {
                // get the current angle
                var angle = Math.PI * 2 / k * i + rotation;

                // get the radius at that angle
                double r = a * b / Math.Sqrt(a * a * Math.Sin(angle) * Math.Sin(angle) + b * b * Math.Cos(angle) * Math.Cos(angle));

                coords.Add(GeometryHelper.GetLatLong(new Position(x, y), angle, r));
            }
            ISymbolizer symbolizer = Helper.CreateRandomSymbolizer();
            Ellipse ellipse = new Ellipse(new List<LineString>
            {
                new LineString(coords)
            });
            ellipse.Symbolizer = symbolizer;

            return ellipse;
        }
    }
}