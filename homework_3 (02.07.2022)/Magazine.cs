using System;

namespace MassMedia
{
    internal class Magazine
    {
        private string magazineName;
        private short magazineYear;
        private string magazineDescription;
        private string magazinePhoneNumber;
        private string magazineEmail;

        public string MagazineName
        {
            get { return magazineName; }
            set { magazineName = value; }
        }
        public short MagazineYear
        {
            get { return magazineYear; }
            set { magazineYear = value; }
        }
        public string MagazineDescription
        {
            get { return magazineDescription; }
            set { magazineDescription = value; }
        }
        public string MagazinePhoneNumber
        {
            get { return magazinePhoneNumber; }
            set { magazinePhoneNumber = value; }
        }
        public string MagazineEmail
        {
            get { return magazineEmail; }
            set { magazineEmail = value; }
        }

        public Magazine()
        {
            this.MagazineName = String.Empty;
            this.MagazineYear = 0;
            this.MagazineDescription = String.Empty;
            this.MagazinePhoneNumber = String.Empty;
            this.MagazineEmail = String.Empty;
        }
        public Magazine(string magazine_name, short magazine_year, string magazine_description, string magazine_phone_number, string magazine_email)
        {
            this.MagazineName = magazine_name;
            this.MagazineYear = magazine_year;
            this.MagazineDescription = magazine_description;
            this.MagazinePhoneNumber = magazine_phone_number;
            this.MagazineEmail = magazine_email;
        }
        public Magazine(Magazine magazine)
        {
            this.MagazineName = magazine.MagazineName;
            this.MagazineYear = magazine.MagazineYear;
            this.MagazineDescription = magazine.MagazineDescription;
            this.MagazinePhoneNumber = magazine.MagazinePhoneNumber;
            this.MagazineEmail = magazine.MagazineEmail;
        }

        public void ChangeAllData()
        {
            Console.Write("Write the magazine name: ");
            MagazineName = Console.ReadLine();
            Console.Write("Write the magazine opening year: ");
            MagazineYear = short.Parse(Console.ReadLine());
            Console.Write("Write the magazine description: ");
            MagazineDescription = Console.ReadLine();
            Console.Write("Write the magazine phone number: ");
            MagazinePhoneNumber = Console.ReadLine();
            Console.Write("Write the magazine email: ");
            MagazineEmail = Console.ReadLine();
        }
        public void WriteAllData()
        {
            Console.WriteLine($"The magazine name: {MagazineName}");
            Console.WriteLine($"The magazine opening year: {MagazineYear}");
            Console.WriteLine($"The magazine description: {MagazineDescription}");
            Console.WriteLine($"The magazine phone number: {MagazinePhoneNumber}");
            Console.WriteLine($"The magazine email: {MagazineEmail}");
        }
    }
}
