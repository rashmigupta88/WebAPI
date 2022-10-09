using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {

            using (SqlConnection conn = new SqlConnection("Data Source=sc-y-db-bms-1;Initial Catalog=OMSDEV3;Integrated Security=true;Connection Timeout=60"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO temp.DBTest (LoginDateTime) VALUES (GETDATE())", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                }
            }
            return new string[] { "Success", "Login Successfully" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post(string value)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=sc-y-db-bms-1;Initial Catalog=OMSDEV3;Integrated Security=true;Connection Timeout=60"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO temp.DBTest (LoginDateTime) VALUES (GETDATE())", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                }
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
