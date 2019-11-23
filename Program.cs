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
            Console.WriteLine("MQTT Connected Succesfully.");
            while(args.Length == 0)
            {          
                client.Publish($"node/{id}/led-strip/-/color/set", Encoding.ASCII.GetBytes(Console.ReadLine()));

            }

            if(args.Length > 0)
            {
                if (args.Length > 1)
                    id = args[1];
                client.Publish($"node/{id}/led-strip/-/color/set", Encoding.ASCII.GetBytes(args[0]));
            }
        }
        else
        {
            Console.WriteLine("Unable to establish MQTT conection.");
        }
        

        Console.ReadKey();

        client.Disconnect();
    }
}



