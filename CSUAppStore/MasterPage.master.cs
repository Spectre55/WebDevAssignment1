using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Net;
using System.Diagnostics;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected string client_id = "997845644823-0b7bp0crakhs24p8rqbtnto482q35sf3.apps.googleusercontent.com";    // Replace this with your Client ID
    protected string client_sceret = "yuz9ePmPH_Yk7RNbg6Gz-3zC";                                                // Replace this with your Client Secret
    protected string redirect_url = "http://localhost:61700/Default.aspx";                                         // Replace this with your Redirect URL; Your Redirect URL from your developer.google application should match this URL.
    protected string Parameters;
    protected string hd = "columbusstate.edu";

    protected void Page_Load(object sender, EventArgs e)
    {
        //   { "web":{ "client_id":"997845644823-0b7bp0crakhs24p8rqbtnto482q35sf3.apps.googleusercontent.com","project_id":"tactile-catcher-149622","auth_uri":"https://accounts.google.com/o/oauth2/auth","token_uri":"https://accounts.google.com/o/oauth2/token","auth_provider_x509_cert_url":"https://www.googleapis.com/oauth2/v1/certs","client_secret":"yuz9ePmPH_Yk7RNbg6Gz-3zC","redirect_uris":["https://localhost:44300/signin-google"],"javascript_origins":["https://localhost:44300"]}}
        if (Session.Contents.Count > 0)
        {
            if (Session["loginWith"] != null)
            {
                Debug.WriteLine("~~~~~~~ with: " + Session["hd"] );
                if (Session["loginWith"].ToString() == "google")
                {
                    try
                    {
                        var url = Request.Url.Query;
                        Debug.WriteLine("~~~~~~~ url: " + url);
                        if (url != "")
                        {
                            string queryString = url.ToString();
                            char[] delimiterChars = { '=' };
                            string[] words = queryString.Split(delimiterChars);
                            string code = words[1];
                            System.Diagnostics.Debug.WriteLine("~~~~~code: " + code + "   " + words[0]);
                            if (code != null)
                            {
                                //get the access token 
                                System.Net.HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create("https://accounts.google.com/o/oauth2/token");
                                webRequest.Method = "POST";
                                Parameters = "code=" + code + "&client_id=" + client_id + "&client_secret=" + client_sceret + "&redirect_uri=" + redirect_url + "&grant_type=authorization_code";
                                byte[] byteArray = Encoding.UTF8.GetBytes(Parameters);
                                webRequest.ContentType = "application/x-www-form-urlencoded";
                                webRequest.ContentLength = byteArray.Length;
                                Stream postStream = webRequest.GetRequestStream();
                                // Add the post data to the web request
                                postStream.Write(byteArray, 0, byteArray.Length);
                                postStream.Close();

                                System.Net.WebResponse response = webRequest.GetResponse();
                                postStream = response.GetResponseStream();
                                StreamReader reader = new StreamReader(postStream);
                                string responseFromServer = reader.ReadToEnd();

                                GooglePlusAccessToken serStatus = JsonConvert.DeserializeObject<GooglePlusAccessToken>(responseFromServer);

                                if (serStatus != null)
                                {
                                    string accessToken = string.Empty;
                                    accessToken = serStatus.access_token;

                                    if (!string.IsNullOrEmpty(accessToken))
                                    {
                                        // This is where you want to add the code if login is successful.
                                        // getgoogleplususerdataSer(accessToken);
                                    }
                                    else
                                    { }
                                }
                                else
                                { }
                            }
                            else
                            { }
                        }
                    }
                    catch (Exception ex)
                    {
                        //throw new Exception(ex.Message, ex);
                        Response.Redirect("Default.aspx");
                    }
                }
            }
        }
    }

    protected void Google_Click(object sender, EventArgs e)
    {
        //var Googleurl = "https://accounts.google.com/o/oauth2/auth?response_type=code&redirect_uri=" + googleplus_redirect_url + "&scope=https://www.googleapis.com/auth/userinfo.email%20https://www.googleapis.com/auth/userinfo.profile" ;
        //Session["loginWith"] = "google";
        //Response.Redirect(Googleurl);
        //-gapi.auth2.init(client_id: cliet)
    }

}
