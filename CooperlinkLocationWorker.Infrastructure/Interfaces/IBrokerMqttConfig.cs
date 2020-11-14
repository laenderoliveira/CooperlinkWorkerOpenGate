namespace CooperlinkLocationWorker.Infrastructure.Interfaces
{
    public interface IBrokerMqttConfig
    {
        public string Server { get; }
        public int Port { get; }
        public string Topic { get;  }
        public string Username { get;  }
        public string Password { get;  }
        public string Payload { get; }
    }
}
