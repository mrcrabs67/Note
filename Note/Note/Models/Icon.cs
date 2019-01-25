using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Note.Models
{
    public class Icon
    {
        public async Task<string> GetIconTask(string name)
        {
            Random rnd = new Random();
            
            string attachmentUrl = "https://avatars.dicebear.com/v2/identicon/:" + name +rnd.Next(0,10000)+ ".svg";
            string html = "";
                    using (WebClient clients = new WebClient())
                    {
                        html = clients.DownloadString(attachmentUrl);
                    }
                    return html;
        }
            
        

    }
}
