using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dbo.Models;
using Microsoft.SqlServer;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Dbo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [ActionName("GetEmpbyId")]
        public AUser GetUser(int id)
        {
            SqlDataReader? reader = null;
            SqlConnection con = new SqlConnection("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt = false;");
            SqlCommand cmd = new SqlCommand("Select * from AryanUser where UserId=" + id + "", con);
            con.Open();
            reader = cmd.ExecuteReader();
            AUser? user = null;
            while (reader.Read())
            {
                user = new AUser();
                user.Id = Convert.ToInt32(reader.GetValue(0));
                user.UserName = reader.GetValue(1).ToString();
                user.Password = reader.GetValue(2).ToString();
            }
            con.Close();

            return user;
        }
    }
}