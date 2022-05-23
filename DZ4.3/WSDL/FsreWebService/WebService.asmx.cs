using MySqlConnector;
using System.Data;
using System.Web.Services;

namespace FsreWebService
{
    /// <summary>
    /// Summary description for WebServis1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServis1 : System.Web.Services.WebService
    {

        public static DataTable SendQuerry(string querry)
        {
            string connString = "SERVER=localhost" + ";" +
                "DATABASE=movies;" +
                "UID=root;" +
                "PASSWORD=;";

            MySqlConnection cnMySQL = new MySqlConnection(connString);
            MySqlCommand cmdMySQL = cnMySQL.CreateCommand();
            MySqlDataReader reader;

            cmdMySQL.CommandText = querry;
            cnMySQL.Open();
            reader = cmdMySQL.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cnMySQL.Close();

            return dt;

        }


        [System.Web.Services.WebMethod]
        public DataTable getMovieBYIDNumber(string movie_id)
        {
            string querry = "select from movie where movie_id =" + movie_id;
            return SendQuerry(querry);
        }

    }
}
