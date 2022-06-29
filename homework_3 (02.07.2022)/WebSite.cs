using System;

namespace WebSite
{
    internal class Website
    {
        private string webSiteName;
        private string webSitePath;
        private string webSiteDescription;
        private string webSiteIP;

        public string WebSiteName
        {
            get { return webSiteName; }
            set { webSiteName = value; }
        }
        public string WebSitePath
        {
            get { return webSitePath; }
            set { webSitePath = value; }
        }
        public string WebSiteDescription
        {
            get { return webSiteDescription; }
            set { webSiteDescription = value; }
        }
        public string WebSiteIP
        {
            get { return webSiteIP; }
            set { webSiteIP = value; }
        }

        public Website()
        {
            this.WebSiteName = String.Empty;
            this.WebSitePath = String.Empty;
            this.WebSiteDescription = String.Empty;
            this.WebSiteIP = String.Empty;
        }
        public Website(string web_site_name, string web_site_path, string web_site_description, string web_site_ip)
        {
            this.WebSiteName = web_site_name;
            this.WebSitePath = web_site_path;
            this.WebSiteDescription = web_site_description;
            this.WebSiteIP = web_site_ip;
        }
        public Website(Website website)
        {
            this.WebSiteName = website.WebSiteName;
            this.WebSitePath = website.WebSitePath;
            this.WebSiteDescription = website.WebSiteDescription;
            this.WebSiteIP = website.WebSiteIP;
        }

        public void ChangeAllData()
        {
            Console.Write("Write the website name: ");
            WebSiteName = Console.ReadLine();
            Console.Write("Write the website path: ");
            WebSitePath = Console.ReadLine();
            Console.Write("Write the website description: ");
            WebSiteDescription = Console.ReadLine();
            Console.Write("Write the website ip: ");
            WebSiteIP = Console.ReadLine();
        }
        public void WriteAllData()
        {
            Console.WriteLine($"The website name: {WebSiteName}");
            Console.WriteLine($"The website path: {WebSitePath}");
            Console.WriteLine($"The website description: {WebSiteDescription}");
            Console.WriteLine($"The website ip: {WebSiteIP}");
        }
    }
}
