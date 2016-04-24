using System;
using System.Net;
using System.IO;
using System.Web;
using System.Collections.Generic;


public class UrlExpander
{

    private WebResponse RequestActions(Uri url)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        req.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
        req.Proxy = new WebProxy();
        req.AllowAutoRedirect = false;
        WebResponse resp = req.GetResponse();

        return resp;
    }

    public Uri isTransitive(Uri url)
    {
        try
        {
            string newurl = RequestActions(url).Headers["Location"];
            Uri newuri = new Uri(newurl);
            
            return newuri;
        }

        catch (System.UriFormatException ex)
        {
            Console.WriteLine("The entered short URL is invalid. Returning entered URL.");
            return url;
        }
    }


    public static void Main(String[] args)
    {
        UrlExpander ue = new UrlExpander();
        String shorturl = "";

        Console.WriteLine("Enter a shortened URL: ");
        shorturl = Console.ReadLine();
        Uri shorturi = new Uri(shorturl);
        Console.WriteLine("The expanded URL is: "+ue.isTransitive(shorturi));
    }
}
