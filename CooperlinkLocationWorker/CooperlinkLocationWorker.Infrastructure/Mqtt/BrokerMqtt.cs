using CooperlinkLocationWorker.Infrastructure.Interfaces;
using System;
using System.Net;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using static uPLibrary.Networking.M2Mqtt.MqttClient;

namespace CooperlinkLocationWorker.Infrastructure.Mqtt
{
    public class BrokerMqtt : IBrokerMqtt
    {
        private readonly IBrokerMqttConfig _brokerMqttConfig;
        private readonly MqttClient _client;
        private readonly string _topic;

        public BrokerMqtt(IBrokerMqttConfig brokerMqttConfig)
        {
            _brokerMqttConfig = brokerMqttConfig;
            _client = new MqttClient(_brokerMqttConfig.Server, _brokerMqttConfig.Port, false, null, null, MqttSslProtocols.None);
            _client.Connect(Guid.NewGuid().ToString(), _brokerMqttConfig.Username, _brokerMqttConfig.Password);
            _topic = _brokerMqttConfig.Topic;
        }

        public void PublishMessageDefaultTopic(string message)
        {
            if (_client.IsConnected)
                _client.Publish(_topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
        }

        public void PublishMessage(string topic, string message)
        {
            _client.Publish(topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
        }

        public void SubscribeTopic(string topic)
        {
            _client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        }

        public void MessagePublishReceived(MqttMsgPublishEventHandler eventHandler)
        {
            _client.MqttMsgPublishReceived += eventHandler;
        }

    }
}
