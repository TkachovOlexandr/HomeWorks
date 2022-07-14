namespace Medieval_Armies.Database
{
    internal sealed class Singleton /* Паттерн программирования "Одиночка" */
    {
        private string connection;
        private static Singleton _instance;

        public string Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        private Singleton(string connection) { this.connection = connection; }

        public static Singleton GetInstance(string connection)
        {
            if (_instance == null)
            {
                _instance = new Singleton(connection);
            }
            return _instance;
        }
    }
}