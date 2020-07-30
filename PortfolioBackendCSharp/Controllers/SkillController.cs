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
    public class SkillController : ControllerBase
    {
        #region [Get Routes]

        [HttpGet]
        public List<Skill> Get()
        {
            Connection conn = new Connection();
            List<Skill> listSkill = new List<Skill>();
            StringBuilder strQuery = new StringBuilder("SELECT * FROM Skill");

            SqlDataReader data = conn.ExecuteWithReturn(strQuery.ToString());

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

            StringBuilder strQuery = new StringBuilder("SELECT * FROM Skill");
            strQuery.Append(" WHERE ID = " + id);

            SqlDataReader data = conn.ExecuteWithReturn(strQuery.ToString());

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

            StringBuilder strQuery = new StringBuilder(string.Format("INSERT INTO Skill( SkillName, Percentage )"));
            strQuery.Append(string.Format(" VALUES('{0}','{1}')",
                skill.SkillName,
                skill.Percentage));

            conn.ExecuteWithoutReturn(strQuery.ToString());

            return "Skill inserted successfully!";
        }

        #endregion

        #region [Delete Route]

        [HttpDelete("{id:int}")]
        public string Delete(int id)
        {
            Connection conn = new Connection();
            List<Skill> listSkill = new List<Skill>();
            StringBuilder strQuery = new StringBuilder("DELETE FROM Skill");
            strQuery.Append(" WHERE ID = " + id);

            conn.ExecuteWithoutReturn(strQuery.ToString());

            return "Skill deleted successfully!";
        }

        #endregion

        #region [Update Route]

        [HttpPut("{id:int}")]
        public string Put([FromBody] Skill skill, int id)
        {
            Connection conn = new Connection();

            StringBuilder strQuery = new StringBuilder("UPDATE Skill");
            strQuery.Append(string.Format(" SET SkillName = '{0}', Percentage = '{1}' WHERE ID = '{2}'",
                skill.SkillName,
                skill.Percentage,
                id));
                
            conn.ExecuteWithoutReturn(strQuery.ToString());

            return "Skill with ID " + id + " updated successfully!";
        }

        #endregion
    }
}