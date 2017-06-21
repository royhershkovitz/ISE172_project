using System.Net.Http;
using MarketClient.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System;

public class SimpleHTTPClient
{
    private string user;
    private string privateKey;
    private myNonceSet setOfNonce = new myNonceSet();
    //define the user
    public SimpleHTTPClient(string initUser, string initPrivateKey)
    {
        user = initUser;
        privateKey = initPrivateKey;
    }

    private static readonly Random random = new Random();
    private static readonly object randLock = new object();

    //returns a random number for nonce uses
    public string GenerateNonce()
    {
        int output = 0;
        lock (randLock)
        {
            output = random.Next(1, Int32.MaxValue);
            while (!setOfNonce.Add(output))
                output = random.Next(1, Int32.MaxValue);
        }
        return output.ToString();
    }

    /// <summary>
    /// Send an object of type T1, @item, parsed as json string embedded with the 
    /// authentication token, that is build using @user and @token, 
    /// as an HTTP post request to server at address @url.
    /// This method parse the reserver response using JSON to object of type T2.
    /// </summary>
    /// <typeparam name="T1">Type of the data object to send</typeparam>
    /// <typeparam name="T2">Type of the return object</typeparam>
    /// <param name="url">address of the server</param>
    /// <param name="item">the data item to send in the reuqest</param>
    /// <returns>the server response parsed as T2 object in json format</returns>
    public T2 SendPostRequest<T1, T2>(string url, T1 item) where T2 : class
    {
        var response = SendPostRequest(url, item);
        //Trace.WriteLine("after dec " + response);
        return response == null ? null : FromJson<T2>(response);
    }

    /// <summary>
    /// Send an object of type T1, @item, parsed as json string embedded with the 
    /// authentication token, that is build using @user and @token, 
    /// as an HTTP post request to server at address @url.
    /// This method reutens the server response as is.
    /// </summary>
    /// <typeparam name="T1">Type of the data object to send</typeparam>
    /// <param name="url">address of the server</param>
    /// <param name="item">the data item to send in the reuqest</param>
    /// <returns>the server response</returns>
    /*
     *Enhanced authenticated request example
     * {"price": 5, "amount": 10, "type": "sell", "commodity": 2, 
     *      "auth": {"token": privateKey.sign("user99_12345"), “nonce”: “12345”, "user": "user99"}}
     *      
    */
    public string SendPostRequest<T1>(string url, T1 item)
    {
        string nonce = GenerateNonce();
        string token = SimpleCtyptoLibrary.CreateToken(user + "_" + nonce, privateKey);
        var auth = new { user, nonce, token };
        JObject jsonItem = JObject.FromObject(item);// create a json object from our item
        jsonItem.Add("auth", JObject.FromObject(auth));// add the author data
                                                       //Trace.WriteLine(jsonItem.ToString());
        StringContent content = new StringContent(jsonItem.ToString());
        //StringContent content = new StringContent(SimpleCtyptoLibrary.RSASignWithSHA256(jsonItem.ToString(), privateKey));//encrypt
        //Trace.WriteLine(SimpleCtyptoLibrary.RSASignWithSHA256(jsonItem.ToString(), privateKey));
        using (var client = new HttpClient())
        {
            var result = client.PostAsync(url, content).Result;//comunicate with the server
                                                               //Trace.WriteLine("passed sending "+result.ToString());
            var responseContent = result.Content.ReadAsStringAsync().Result;
            //Trace.WriteLine("passed2 " + responseContent);
            //Trace.WriteLine("before dec " + response);
            return SimpleCtyptoLibrary.decrypt(responseContent, privateKey);
        }
    }

    //Try to build an item from the server response
    private static T FromJson<T>(string response) where T : class
    {
        if (response == null)
        {
            return null;
        }
        try
        {
            Trace.WriteLine("Json response: " + response);
            return JsonConvert.DeserializeObject<T>(response, new JsonSerializerSettings
            {
                Error = delegate {
                    throw new JsonException(response);
                }
            });
        }
        catch
        {
            throw new MarketException(response);
        }
    }
}

