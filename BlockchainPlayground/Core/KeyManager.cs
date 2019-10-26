using BlockchainPlayground.Util;
using Nethereum.Signer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPlayground.Core
{
    public static class KeyManager
    {
        public static string GeneratePrivateKey()
        {
            RSACryptoServiceProvider RSAO = new RSACryptoServiceProvider();
            string privateKey = RSAO.ToXmlString(true);
            return privateKey.To64();
        }

        public static string GeneratePublicKey(string privateKey)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(privateKey.From64String());

            return RSA.ToXmlString(false).To64();
        }

        public static (string, string) GenerateKeys()
        {
            string @private = GeneratePrivateKey();
            string @public = GeneratePublicKey(@private);

            return (@private.To64(), @public.To64());
        }

        public static string SignMessage(string message, string privateKey)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(privateKey.From64String());
            RSAPKCS1SignatureFormatter RSAFormatter = new RSAPKCS1SignatureFormatter(RSA);
            RSAFormatter.SetHashAlgorithm("SHA256");
            var messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] messageHash = messageBytes.GetSHA256();
            byte[] SignedHashValue = RSAFormatter.CreateSignature(messageHash);

            string signature = System.Convert.ToBase64String(SignedHashValue);


            return signature;
        }


        public static bool ValidateMessage(string publicKey, string message, string signature)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(publicKey.From64String());
            RSAPKCS1SignatureDeformatter RSADeformatter = new RSAPKCS1SignatureDeformatter(RSA);
            RSADeformatter.SetHashAlgorithm("SHA256");


            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] messageHash = messageBytes.GetSHA256();
            return RSADeformatter.VerifySignature(messageHash, signature.From64());
        }

    }
}
