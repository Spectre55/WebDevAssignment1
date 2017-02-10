﻿using Newtonsoft.Json;
using System;
using System.Net.Http;

public class GooglePlusAccessToken
{
    public string access_token { get; set; }
    public string token_type { get; set; }
    public int expires_in { get; set; }
    public string id_token { get; set; }
    public string refresh_token { get; set; }



    private async void getgoogleplususerdataSer(string access_token)
    {
        try
        {
            HttpClient client = new HttpClient();
            var urlProfile = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + access_token;

            client.CancelPendingRequests();
            HttpResponseMessage output = await client.GetAsync(urlProfile);

            if (output.IsSuccessStatusCode)
            {
                string outputData = await output.Content.ReadAsStringAsync();
                GoogleUserOutputData serStatus = JsonConvert.DeserializeObject<GoogleUserOutputData>(outputData);

                if (serStatus != null)
                {
                    // You will get the user information here.
                }
            }
        }
        catch (Exception ex)
        {
            //catching the exception
        }
    }
}

public class GoogleUserOutputData
{
    public string id { get; set; }
    public string name { get; set; }
    public string given_name { get; set; }
    public string email { get; set; }
    public string picture { get; set; }
}

