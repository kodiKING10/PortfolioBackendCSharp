using Microsoft.AspNetCore.Mvc;
using PortfolioBackendCSharp.DAL;
using PortfolioBackendCSharp.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PortfolioBackendCSharp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        #region [Get Routes]

        [HttpGet]
        public List<Certificate> Get()
        {
            Connection conn = new Connection();
            List<Certificate> listCertificates = new List<Certificate>();
            StringBuilder strQuery = new StringBuilder("SELECT * FROM Certificate");

            SqlDataReader data = conn.ExecuteWithReturn(strQuery.ToString());

            while (data.Read())
            {
                Certificate certificate = new Certificate();
                certificate.ID = data.GetInt32(0);
                certificate.Institution = data.GetString(1).ToString();
                certificate.CourseName = data.GetString(2).ToString();
                certificate.Date = data.GetDateTime(3);
                certificate.Description = conn.CheckString(data, 4);
                certificate.Image = conn.CheckString(data, 5);

                listCertificates.Add(certificate);
            }
            return listCertificates;
        }

        [HttpGet("{id:int}")]
        public List<Certificate> Get(int id)
        {
            Connection conn = new Connection();
            List<Certificate> listCertificates = new List<Certificate>();
            StringBuilder strQuery = new StringBuilder("SELECT * FROM Certificate");
            strQuery.Append(" WHERE ID = " + id);

            SqlDataReader data = conn.ExecuteWithReturn(strQuery.ToString());

            while (data.Read())
            {
                Certificate certificate = new Certificate();
                certificate.ID = data.GetInt32(0);
                certificate.Institution = data.GetString(1).ToString();
                certificate.CourseName = data.GetString(2).ToString();
                certificate.Date = data.GetDateTime(3);
                certificate.Description = conn.CheckString(data, 4);
                certificate.Image = conn.CheckString(data, 5);

                listCertificates.Add(certificate);
            }
            return listCertificates;
        }
        #endregion

        #region [Post Route]

        [HttpPost]
        public string Post([FromBody] Certificate certificate)
        {
            Connection conn = new Connection();

            StringBuilder strQuery = new StringBuilder("INSERT INTO Certificate( Institution, CourseName, Date, Description, Image )");
            strQuery.Append(string.Format(" VALUES('{0}','{1}','{2}','{3}','{4}')",
                certificate.Institution,
                certificate.CourseName,
                certificate.Date.ToString("MM/dd/yyyy"),
                certificate.Description,
                certificate.Image));

            conn.ExecuteWithoutReturn(strQuery.ToString());

            return "Certificate inserted successfully!";
        }

        #endregion

        #region [Delete Route]

        [HttpDelete("{id:int}")]
        public string Delete(int id)
        {
            Connection conn = new Connection();
            List<Certificate> listCertificates = new List<Certificate>();
            StringBuilder strQuery = new StringBuilder("DELETE FROM Certificate");
            strQuery.Append(" WHERE ID = " + id);

            conn.ExecuteWithoutReturn(strQuery.ToString());

            return "Certificate deleted successfully!";
        }

        #endregion

        #region [Update Route]

        [HttpPut("{id:int}")]
        public string Put([FromBody] Certificate certificate, int id)
        {
            Connection conn = new Connection();

            StringBuilder strQuery = new StringBuilder("UPDATE Certificate");
            strQuery.Append(string.Format(" SET Institution = '{0}', CourseName = '{1}', Date = '{2}', Description = '{3}', Image = '{4}' WHERE ID = '{5}'",
                certificate.Institution,
                certificate.CourseName,
                certificate.Date.ToString("MM/dd/yyyy"),
                certificate.Description,
                certificate.Image,
                id));

            conn.ExecuteWithoutReturn(strQuery.ToString());

            return "Certificate with ID "+ id +" updated successfully!";
        }

        #endregion
    }
}