using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioBackendCSharp.DAL;
using PortfolioBackendCSharp.Models;

namespace PortfolioBackendCSharp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        #region [Get Routes]

        [HttpGet]
        public List<Skill> Get()
        {
            Connection conn = new Connection();
            List<Skill> listSkill = new List<Skill>();
            string strQuery = "SELECT * FROM Skill";

            SqlDataReader data = conn.ExecuteWithReturn(strQuery);

            while (data.Read())
            {
                Skill skill = new Skill();
                skill.ID = data.GetInt32(0);
                skill.SkillName = conn.CheckString(data, 1);
                skill.Percentage = data.GetInt32(2);

                listSkill.Add(skill);
            }
            return listSkill;
        }

        [HttpGet("{id:int}")]
        public List<Skill> Get(int id)
        {
            Connection conn = new Connection();
            List<Skill> listSkill = new List<Skill>();
            string strQuery = "SELECT * FROM Skill WHERE ID = " + id;

            SqlDataReader data = conn.ExecuteWithReturn(strQuery);

            while (data.Read())
            {
                Skill skill = new Skill();
                skill.ID = data.GetInt32(0);
                skill.SkillName = conn.CheckString(data, 1);
                skill.Percentage = data.GetInt32(2);

                listSkill.Add(skill);
            }
            return listSkill;
        }
        #endregion

        #region [Post Route]

        [HttpPost]
        public string Post([FromBody] Skill skill)
        {
            Connection conn = new Connection();

            string strQuery = string.Format("INSERT INTO Skill( SkillName, Percentage ) VALUES('{0}','{1}')",
                skill.SkillName,
                skill.Percentage
            );
            conn.ExecuteWithoutReturn(strQuery);

            return "Skill inserted successfully!";
        }

        #endregion

        #region [Delete Route]

        [HttpDelete("{id:int}")]
        public string Delete(int id)
        {
            Connection conn = new Connection();
            List<Skill> listSkill = new List<Skill>();
            string strQuery = "DELETE FROM Skill WHERE ID = " + id;

            conn.ExecuteWithoutReturn(strQuery);

            return "Skill deleted successfully!";
        }

        #endregion

        #region [Update Route]

        [HttpPut("{id:int}")]
        public string Put([FromBody] Skill skill, int id)
        {
            Connection conn = new Connection();

            string strQuery = string.Format("UPDATE Skill SET SkillName = '{0}', Percentage = '{1}' WHERE ID = '{2}'",
                skill.SkillName,
                skill.Percentage,
                id
            );

            conn.ExecuteWithoutReturn(strQuery);

            return "Skill with ID " + id + " updated successfully!";
        }

        #endregion
    }
}