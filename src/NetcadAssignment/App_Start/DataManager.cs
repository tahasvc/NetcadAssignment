using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NetcadAssignment.App_Start
{
    public class DataManager
    {
        private string DataPath = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"), "Data.txt");

        /// <summary>
        /// Saves to geojson data in text file
        /// </summary>
        /// <param name="json"></param>
        public void SaveData(string json)
        {
            if (!File.Exists(DataPath))
            {
                using (FileStream file = File.Create(DataPath))
                {
                    file.Close();
                }
            }
            File.AppendAllText(DataPath, "Log Date:  " + DateTime.Now.ToString() + "\tData:  " + json + Environment.NewLine);
        }
    }
}