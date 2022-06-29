using System;

namespace Store
{
    internal class Shop
    {
        private string shopName;
        private string shopAdress;
        private string shopDescription;
        private string shopPhoneNumber;
        private string shopEmail;

        public string ShopName
        {
            get { return shopName; }
            set { shopName = value; }
        }
        public string ShopAdress
        {
            get { return shopAdress; }
            set { shopAdress = value; }
        }
        public string ShopDescription
        {
            get { return shopDescription; }
            set { shopDescription = value; }
        }
        public string ShopPhoneNumber
        {
            get { return shopPhoneNumber; }
            set { shopPhoneNumber = value; }
        }
        public string ShopEmail
        {
            get { return shopEmail; }
            set { shopEmail = value; }
        }

        public Shop()
        {
            this.ShopName = String.Empty;
            this.ShopAdress = String.Empty;
            this.ShopDescription = String.Empty;
            this.ShopPhoneNumber = String.Empty;
            this.ShopEmail = String.Empty;
        }
        public Shop(string shop_name, string shop_adress, string shop_description, string shop_phone_number, string shop_email)
        {
            this.ShopName = shop_name;
            this.ShopAdress = shop_adress;
            this.ShopDescription = shop_description;
            this.ShopPhoneNumber = shop_phone_number;
            this.ShopEmail = shop_email;
        }
        public Shop(Shop shop)
        {
            this.ShopName = shop.ShopName;
            this.ShopAdress = shop.ShopAdress;
            this.ShopDescription = shop.ShopDescription;
            this.ShopPhoneNumber = shop.ShopPhoneNumber;
            this.ShopEmail = shop.ShopEmail;
        }

        public void ChangeAllData()
        {
            Console.Write("Write the shop name: ");
            ShopName = Console.ReadLine();
            Console.Write("Write the shop adress: ");
            ShopAdress = Console.ReadLine();
            Console.Write("Write the shop description: ");
            ShopDescription = Console.ReadLine();
            Console.Write("Write the shop phone number: ");
            ShopPhoneNumber = Console.ReadLine();
            Console.Write("Write the shop email: ");
            ShopEmail = Console.ReadLine();
        }
        public void WriteAllData()
        {
            Console.WriteLine($"The shop name: {ShopName}");
            Console.WriteLine($"The shop adress: {ShopAdress}");
            Console.WriteLine($"The shop description: {ShopDescription}");
            Console.WriteLine($"The shop phone number: {ShopPhoneNumber}");
            Console.WriteLine($"The shop email: {ShopEmail}");
        }
    }
}
