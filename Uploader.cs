using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;

class Motivation_Light_Uploader
{
    public static void Main(string[] args)
    {
        string id = "a5d91c0cc80d";
        MqttClient client = new MqttClient("127.0.0.1");

        client.Connect("id");

        if (client.IsConnected)
        {
            Console.WriteLine("MQTT Connected Succesfully");
            client.Publish($"node/{id}/led-strip/-/color/set", Encoding.ASCII.GetBytes(args[0]));
        }


        Console.ReadKey();

        client.Disconnect();
    }
}



