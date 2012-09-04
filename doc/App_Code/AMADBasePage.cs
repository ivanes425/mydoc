using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

/// <summary>
/// Summary description for AMADGeneral
/// </summary>
public class AMADBasePage : System.Web.UI.Page, IListBuilder
{
    public virtual Dictionary<string, string> BuildListOfValues()
    {
        return null;
    }

    public virtual Dictionary<string, string> BuildListOfValues(DataTable dt)
    {
        return null;
    }


    public string GenerateRandomString()
    {
        int size = 30;
        string allowedChars = "";
        allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
        allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
        allowedChars += "1,2,3,4,5,6,7,8,9,0,-,_";
        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);
        string randomString = "";
        string temp = "";
        Random rand = new Random();
        for (int i = 0; i < size; i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            randomString += temp;
        }
        return randomString;
    }

    public string GeneratePassword()
    {
        int size = 8;
        string allowedChars = "";
        allowedChars = "n,o,p,q,r,s,t,u,v,w,x,y,z,";
        allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,";
        allowedChars += "1,2,3,4,5,6,7,8,9,0,_,#,@,*,$";
        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);
        string randomString = "";
        string temp = "";
        Random rand = new Random();
        for (int i = 0; i < size; i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            randomString += temp;
        }
        return randomString;
    }

    public string Encrypt(string strToEncrypt, string strKey)
    {
        try
        {
            TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
            byte[] byteHash, byteBuff;
            string strTempKey = strKey;
            byteHash = objHashMD5.ComputeHash(UTF32Encoding.UTF32.GetBytes(strTempKey));
            objHashMD5 = null;
            objDESCrypto.Key = byteHash;
            objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = ASCIIEncoding.ASCII.GetBytes(strToEncrypt);
            return Convert.ToBase64String(objDESCrypto.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
        }
        catch (Exception ex)
        {
            return "Wrong Input. " + ex.Message;
        }
    }

    public string Decrypt(string strEncrypted, string strKey)
    {
        try
        {
            strEncrypted = strEncrypted.Replace(" ", "+");
            TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
            byte[] byteHash, byteBuff;
            string strTempKey = strKey;
            byteHash = objHashMD5.ComputeHash(UTF32Encoding.UTF32.GetBytes(strTempKey));
            objHashMD5 = null;
            objDESCrypto.Key = byteHash;
            objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Convert.FromBase64String(strEncrypted);
            string strDecrypted = ASCIIEncoding.ASCII.GetString(objDESCrypto.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            objDESCrypto = null;
            return strDecrypted;
        }
        catch (Exception ex)
        {
            return "Wrong Input. " + ex.Message;
        }
    }

    private string BuildXML(Dictionary<string, string> ProspectValues)
    {
        XDocument xml = new XDocument();
        XElement root = new XElement("Attributes");
        xml.Add(root);

        foreach (KeyValuePair<string, string> entry in ProspectValues)
        {
            XElement xe = new XElement("Attribute",
            new XAttribute("Name", entry.Key),
            new XAttribute("Value", entry.Value)
            );
            root.Add(xe);
        }

        return xml.ToString();
    }

    public string ImageSlider(ArrayList arr)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("var flashyshow = new flashyslideshow({ wrapperid: 'myslideshow', wrapperclass: 'flashclass',");
        sb.Append("imagearray: [");
        for (int i = 0; i <= arr.Count - 2; i++)
        {
            sb.Append("['" + arr[i] + "', '#', '_new', 'some text goes here.'],");    
        }
        sb.Append("['" + arr[arr.Count-1] + "', '#', '_new', 'last item goes here.']");
        sb.Append("],pause: 2000, transduration: 1000 })");
        sb.Append("</script>");

        return sb.ToString();
    }

    public string ImageSlider(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("var flashyshow = new flashyslideshow({ wrapperid: 'myslideshow', wrapperclass: 'flashclass',");
        sb.Append("imagearray: [");
        for (int i = 0; i <= dt.Rows.Count - 2; i++)
        {
            sb.Append("['" + dt.Rows[i]["FileName"] + "', '" + dt.Rows[i]["URL"] + "', '" + dt.Rows[i]["URLTarget"] + "', '" + dt.Rows[i]["Text"] + "'],");
        }
        sb.Append("['" + dt.Rows[dt.Rows.Count - 1]["FileName"] + "', '"+dt.Rows[dt.Rows.Count - 1]["URL"]+"', '"+dt.Rows[dt.Rows.Count - 1]["URLTarget"]+"', '" + dt.Rows[dt.Rows.Count - 1]["Text"] + "']");
        sb.Append("],pause: 2000, transduration: 1000 })");
        sb.Append("</script>");

        return sb.ToString();
    }

    public void ConvertTabletoXML()
    {
        //DataTable dt = new DataTable("FindDoctor");
        //dt.Columns.Add(new DataColumn("FileName"));
        //dt.Columns.Add(new DataColumn("Text"));
        //dt.Columns.Add(new DataColumn("URL"));
        //dt.Columns.Add(new DataColumn("URLTarget"));

        //for (int i = 0; i <= 4; i++)
        //{
        //    DataRow dr = dt.NewRow();
        //    dr["FileName"] = "imagename";
        //    dr["Text"] = "description";
        //    dr["URL"] = "http";
        //    dr["URLTarget"] = "_blank";
        //    dt.Rows.Add(dr);
        //}

        //string result;
        //using (StringWriter sw = new StringWriter())
        //{
        //    dt.WriteXml(sw);
        //    result = sw.ToString();
        //}

        //XPathDocument result1;
        //using (MemoryStream ms = new MemoryStream())
        //{
        //    dt.WriteXml(ms);
        //    ms.Position = 0;
        //    result1 = new XPathDocument(ms);
        //}
    }
}
