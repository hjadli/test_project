using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;



public partial class UserRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        UserDAL dal = new UserDAL();
        List<User> users = dal.GetAllUsers();
        GridView1.DataSource = users;
        GridView1.DataBind();
    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        User newUser = new User
        {
            Fname = "John",
            Lname = "Doe",
            Email = "john.doe@example.com",
            Gender = "Male",
            Address = "123 Main St",
            Phone = "123-456-7890",
            Password = "password123",
            Role = "user"
        };

        UserDAL dal = new UserDAL();
        dal.InsertUser(newUser);
        BindGrid();
    }
}