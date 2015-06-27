using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public Service1()
        {
           string url = HttpContext.Current.Request.Url.ApplicationPath.ToString();
           string original = getLargerUrl(url);
           if (original != null)
               Response.Redirect(original);
           else
               Response.Redirect(url);
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public static List<Class1> list=new List<Class1>();
        public void insertURL(string longURL,string ShortURL )
        {
            

            list.Add(new Class1{OriginalURL=longURL,ShortForm=ShortURL});
        }
        public string getLargerUrl(string shortUrl)
        {
            string LongURL=null;
            foreach (Class1 item in list)
            {
                if (item.ShortForm == shortUrl)
                    LongURL = item.OriginalURL;
            }
            return LongURL;
        }
    }
}
