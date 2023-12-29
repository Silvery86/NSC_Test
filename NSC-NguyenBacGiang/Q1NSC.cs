using System;
using System.Security.Cryptography;
using System.Text;

public class AsymmetricEncryptionExample
{
    public static void Main()
    {
        // Create RSA encryption provider
        using (RSA rsa = RSA.Create())
        {
            // Get the public and private keys
            RSAParameters publicKey = rsa.ExportParameters(false); // false for public key
            RSAParameters privateKey = rsa.ExportParameters(true); // true for private key

            // Convert sample data to bytes
            string originalData = "Nguyen Bac Giang";
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(originalData);

            // Encrypt data using the public key
            byte[] encryptedData = EncryptData(dataToEncrypt, publicKey);

            // Decrypt data using the private key
            byte[] decryptedData = DecryptData(encryptedData, privateKey);

            // Convert decrypted bytes back to string
            string decryptedString = Encoding.UTF8.GetString(decryptedData);

            Console.WriteLine("Original: " + originalData);
            Console.WriteLine("Encrypted: " + Convert.ToBase64String(encryptedData));
            Console.WriteLine("Decrypted: " + decryptedString);
        }
    }

    // Method to encrypt data using the public key
    public static byte[] EncryptData(byte[] data, RSAParameters publicKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportParameters(publicKey);
            return rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1); // Changed padding mode to Pkcs1
        }
    }

    // Method to decrypt data using the private key
    public static byte[] DecryptData(byte[] data, RSAParameters privateKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportParameters(privateKey);
            return rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1); // Changed padding mode to Pkcs1
        }
    }
}
