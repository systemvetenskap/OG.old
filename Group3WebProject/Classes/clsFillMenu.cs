using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml;
using System.Diagnostics;

namespace Group3WebProject.Classes
{
    public class clsFillMenu
    {
        public DataTable readXML(string qID, string xmlPath)
        {
            Debug.WriteLine("Aa");
            DataTable dt = new DataTable();           
            dt.Columns.Add("name");
            dt.Columns.Add("id");
            try
            {
                
                XmlTextReader reader = new XmlTextReader(xmlPath);
                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "question":                           
                            dt.Rows.Add();
                            dt.Rows[dt.Rows.Count - 1]["id"] = reader.GetAttribute("value").ToUpper();
                            Random random = new Random();
                            dt.Rows[dt.Rows.Count - 1]["name"] = random.Next(0, 100).ToString();
                            reader.Skip();
                            break;                            
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["name"] = "Fråga " + (i+ 1).ToString();
            }
            return dt;
        }
    }
}