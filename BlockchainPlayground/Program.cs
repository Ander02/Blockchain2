using Nethereum.Signer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Util;
using Nethereum.Utils;
using Nethereum.Hex;
using Nethereum.Model;
using Nethereum.Signer.Crypto;
using Nethereum.Hex.HexConvertors.Extensions;
using System.IO;
using BlockchainPlayground.Core;
using System.Threading;

namespace BlockchainPlayground
{
    public delegate void Nome(int a, int b);
    
    class Program
    {
        static void Main(string[] args)
        {

            //KeyManager m = new KeyManager();


            //var privateKey = m.GeneratePrivateKey();
            //var secondPrivateKey = m.GeneratePrivateKey();

            //var publicKey = m.GeneratePublicKey(privateKey);
            //var secondPublicKey = m.GeneratePublicKey(secondPrivateKey);

            //Console.WriteLine($"Private Key:");
            //Console.WriteLine($"{privateKey}");
            //Console.WriteLine();
            //Console.WriteLine($"Public Key:");
            //Console.WriteLine($"{publicKey}");
            //Console.WriteLine();
            //string message = "";
            //do
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("Type a message (Just enter to leave):");
            //    message = Console.ReadLine();

            //    Console.WriteLine();
            //    Console.WriteLine("Type a fake message");
            //    string message2 = Console.ReadLine();

            //    string signature = m.SignMessage(message, privateKey);
            //    string signature2 = m.SignMessage(message2, secondPrivateKey);

            //    Console.WriteLine($"Message signature: {signature}");
            //    Console.WriteLine();
            //    Console.WriteLine($"Is Valid: {m.ValidateMessage(publicKey, message, signature)}");
            //    Console.WriteLine();
            //    Console.WriteLine($"Is Valid with second public key : {m.ValidateMessage(secondPublicKey, message, signature)}");





            //    Console.WriteLine($"Fake message Is Valid with message signature ({signature}): {m.ValidateMessage(publicKey, message2, signature)}");
            //    Console.WriteLine($"Fake message Is Valid with message signature ({signature}): {m.ValidateMessage(secondPublicKey, message2, signature2)}");

            //}
            //while (!string.IsNullOrWhiteSpace(message));



            //RSACryptoServiceProvider RSAO = new RSACryptoServiceProvider();
            //string publicKey = RSAO.ToXmlString(false);
            //string privateKey = RSAO.ToXmlString(true);


            //RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            //RSA.FromXmlString(privateKey);
            //RSAPKCS1SignatureFormatter RSAFormatter = new RSAPKCS1SignatureFormatter(RSA);
            //RSAFormatter.SetHashAlgorithm("SHA256");
            //SHA256Managed SHhash = new SHA256Managed();
            //byte[] SignedHashValue = RSAFormatter.CreateSignature(SHhash.ComputeHash(new UnicodeEncoding().GetBytes("message")));
            //string signaturer = System.Convert.ToBase64String(SignedHashValue);


            //RSACryptoServiceProvider RSA2 = new RSACryptoServiceProvider();
            //RSA2.FromXmlString(publicKey);
            //RSAPKCS1SignatureDeformatter RSADeformatter = new RSAPKCS1SignatureDeformatter(RSA2);
            //RSADeformatter.SetHashAlgorithm("SHA1");
            //SHA1Managed SHhash2 = new SHA1Managed();
            //if (RSADeformatter.VerifySignature(
            // SHhash2.ComputeHash(new UnicodeEncoding().GetBytes("message")),
            // System.Convert.FromBase64String(signaturer))
            // )
            //{
            //    /// The signature is valid.
            //}
            //else
            //{
            //    /// The signature is not valid.
            //}



            ////var privKey = EthECKey.GenerateKey();
            //var privKey = new EthECKey("adf2");
            //var privKey2 = new EthECKey("adf3");
            //byte[] pubKeyCompressed = new ECKey(privKey.GetPrivateKeyAsBytes(), true).GetPubKey(true);
            //Console.WriteLine("Private key: {0}", privKey.GetPrivateKey().Substring(4));
            //Console.WriteLine("Public key: {0}", privKey.GetPubKey().ToHex().Substring(2));
            //Console.WriteLine("Public key (compressed): {0}", pubKeyCompressed.ToHex());

            //Console.WriteLine();

            //string msg = "Message for signing";
            //byte[] msgBytes = Encoding.UTF8.GetBytes(msg);
            //byte[] msgHash = new Sha3Keccack().CalculateHash(msgBytes);
            //var signature = privKey.SignAndCalculateV(msgHash);
            //Console.WriteLine("Msg: {0}", msg);
            //Console.WriteLine("Msg hash: {0}", msgHash.ToHex());
            //Console.WriteLine("Signature: [v = {0}, r = {1}, s = {2}]",
            //    signature.V[0] - 27, signature.R.ToHex(), signature.S.ToHex());

            //Console.WriteLine();

            //var pubKeyRecovered = EthECKey.RecoverFromSignature(signature, msgHash);
            //Console.WriteLine("Recovered pubKey: {0}", pubKeyRecovered.GetPubKey().ToHex().Substring(2));

            //bool validSig = pubKeyRecovered.Verify(msgHash, signature);
            //Console.WriteLine("Signature valid? {0}", validSig);
        }

        private static void teste(int a, int b)
        {
            throw new NotImplementedException();
        }

        private static string GenerateSHA(string data, bool deepEncode = true)
        {
            string result = "";
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(data));

                foreach (var b in bytes)
                    result += b.ToString("x");

                Console.WriteLine(result);

                sha.Dispose();
            }

            return result;
        }
    }
}
