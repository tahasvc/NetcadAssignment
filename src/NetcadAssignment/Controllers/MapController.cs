using GeoJSON.Net.Geometry;
using NetcadAssignment.App_Start;
using NetcadAssignment.Base.Builtin;
using NetcadAssignment.Base.CoreGis.Geometry;
using NetcadAssignment.Base.Geometry;
using NetcadAssignment.Base.Style;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetcadAssignment.Controllers
{
    public class MapController : Controller
    {
        private DataManager DataManager = new DataManager();
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get a random circle instance
        /// </summary>
        /// <returns>
        /// Returns a value in geojson format
        /// </returns>
        public JsonResult DrawCircle()
        {
            Circle circle = GeometryCreator.CreateCircle();
            string json = circle.SerializeObject();
            try
            {
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                DataManager.SaveData(json);
            }
        }

        /// <summary>
        /// Get a random square instance
        /// </summary>
        /// <returns>
        /// Returns a value in geojson format
        /// </returns>
        public JsonResult DrawSquare()
        {
            Square square = GeometryCreator.CreateSquare();
            string json = square.SerializeObject();
            try
            {
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                DataManager.SaveData(json);
            }
        }

        /// <summary>
        /// Get a random triangle instance
        /// </summary>
        /// <returns>
        /// Returns a value in geojson format
        /// </returns>
        public JsonResult DrawTriangle()
        {
            Triangle triangle = GeometryCreator.CreateTriangle();
            string json = triangle.SerializeObject();
            try
            {
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                DataManager.SaveData(json);
            }
        }

        /// <summary>
        /// Get a random ellipse instance
        /// </summary>
        /// <returns>
        /// Returns a value in geojson format
        /// </returns>
        public JsonResult DrawEllipse()
        {
            Ellipse ellipse = GeometryCreator.CreateEllipse();
            string json = ellipse.SerializeObject();
            try
            {
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                DataManager.SaveData(json);
            }
        }
    }
}