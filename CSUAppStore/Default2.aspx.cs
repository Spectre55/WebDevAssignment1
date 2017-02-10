using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) // If this is the 1st time the page has been called
        {
            // yearChoice.DataSource = Enumerable.Range(2014, 3);
            // yearChoice.DataBind();

            courseChoice.DataBind();
            //genreChoice.DataBind();
            platformChoice.DataBind();
            yearChoice.DataBind();

            yearChoice.Items.Insert(0, new ListItem("All", "-1"));
            genreChoice.Items.Insert(0, new ListItem("All", "-l"));

            platformChoice.Items.Insert(0, new ListItem("All", "-1"));
            courseChoice.Items.Insert(0, new ListItem("All", "-1"));


            /*        gameTableDataSource.DataBind();
                    gameTableDataSource.SelectParameters.Add("course", DbType.Int32 ,courseChoice.SelectedValue);
                 //   gameTableDataSource.SelectParameters.Add("genre", DbType.Int32, genreChoice.SelectedValue);
                    gameTableDataSource.SelectParameters.Add("platform", DbType.Decimal, platformChoice.SelectedValue);
                    gameTableDataSource.SelectParameters.Add("yr", DbType.Decimal, yearChoice.SelectedValue);
              */
            gameTableDataSource.SelectCommand = genTableSelect();
        }
    }


    private String genTableSelect()
    {
        String str = "SELECT Games.id, Games.gameName, Games.icon, GamePlatforms.platformId, GameGenres.genreId FROM Games INNER JOIN GamePlatforms ON Games.id = GamePlatforms.gameId INNER JOIN GameGenres ON Games.id = GameGenres.gameId WHERE (1 = 1)";
        if(courseChoice.SelectedValue.ToString() != "-1")
        {
            str += " AND (Games.courseId = @course)";
        }
        /*  if (genreChoice.SelectedValue != "-1")
           {
               str += " AND (GameGenres.genreId = @genre)";
           }
         */
        if (platformChoice.SelectedValue != "-1")
        {
            str += " AND (GamePlatforms.platformId = @platform)";
        }
        if (yearChoice.SelectedValue != "-1")
        {
            str += " AND (Games.yr = @yr)";
        }

        return str + ";" ;
    }

    protected void search(object sender, EventArgs e)
    {
       // DataSourceSelectArguments args = new DataSourceSelectArguments()                  //gameTableDataSource.SelectParameters;
        gameTableDataSource.SelectCommand = genTableSelect();
        //gameTableDataSource.Select(new DataSourceSelectArguments());
     //   gameTableDataSource.DataBind();
       //gameTable.DataBind();
       
    }
}
