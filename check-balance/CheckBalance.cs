using System;
using System.Threading.Tasks;
using Nethereum.Web3;

class Program
{
    static async Task Main(string[] args)
    {
        // อ่าน ETH_ADDRESS จาก environment variable (ควร map กับ secrets)
        var ethAddress = Environment.GetEnvironmentVariable("ETH_ADDRESS");
        if (string.IsNullOrEmpty(ethAddress))
        {
            Console.WriteLine("ETH_ADDRESS environment variable is not set.");
            return;
        }

        var web3 = new Web3("https://eth.llamarpc.com");
        var balance = await web3.Eth.GetBalance.SendRequestAsync(ethAddress);
        Console.WriteLine($"Balance: {Web3.Convert.FromWei(balance.Value)} ETH");
    }
}
