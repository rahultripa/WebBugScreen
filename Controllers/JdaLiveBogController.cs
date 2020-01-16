using screenshare3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace screenshare3.Controllers
{
    public class JdaLiveBogController : Controller
    {
        // GET: JdaLiveBog
        public ActionResult Index()
        {
            return View();
        }

    private screenshare3Context db = new screenshare3Context();

    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      try
      {
        string connetionString = null;
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adpter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //XmlReader xmlFile ;
        string sql = null;
        connetionString = "Password = myoxynova@987; Persist Security Info = True; User ID = myoxynova; Initial Catalog = oxynovaDB; Data Source = 118.67.248.175";
        connection = new SqlConnection(connetionString);
        SqlCommand cmd = new SqlCommand("select * from JDADebugActivityInfoes where 1!=1", connection);
        //SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //adp.Fill(ds);
      //  string dbDatabasePath = "G:\\Instances\\";

        string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/jDADebugActivityInfo.xml");
        XmlTextReader reader = new XmlTextReader(path);
        ds.ReadXml(reader);


        string study_site = "";
        string traditional_authority = "";
        string community = "";

       

        int i = 0;

        connection.Open();
        foreach(DataRow dr in ds.Tables[0].Rows)
        {
          cmd.CommandText = " INSERT INTO [dbo].[JDADebugActivityInfoes]  ([ScreenShot],[ActivityData] ,[NetworkData],[DeviceOrientation] ,[BugId] ,CPUUses ,MemoryUses ,[VirtualMemory])    VALUES  ('" + dr[0] + "' ,'" + dr[1]+ "','" + dr[2] + "','" + dr[3] + "','" + dr[5] + "','" + dr[7] + "','" + dr[8] + "','" + dr[9] + "')";
         int iii =   cmd.ExecuteNonQuery();
        }
        //using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
        //{
        //  connection.Open();
        //  bulkCopy.DestinationTableName = "[dbo].[JDADebugActivityInfoes]";
        //  try
        //  {
        //    bulkCopy.WriteToServer(ds.Tables[0]);
        //  }
        //  catch (Exception e)
        //  {
        //    Console.Write(e.Message);
        //  }
       // }
        connection.Close();
        //   MessageBox.Show("Record Inserted Successfully !!!", "Saving Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        //  MessageBox.Show(ex.Message);
      }
      JDADebugInfo jDADebugInfo = db.JDADebugInfoes.Find(id);
      if (jDADebugInfo == null)
      {
        return HttpNotFound();
      }
      return View(jDADebugInfo);
    }
  }
}
