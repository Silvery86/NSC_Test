using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordEncryptionExample
{
    public static void Main()
    {
        string username = "Admin";
        string password = "Adwx!@#$%xdwa";

        string hashedPassword = EncryptPassword(password);

        Console.WriteLine("Username: " + username);
        Console.WriteLine("Hashed Password (SHA-256): " + hashedPassword);
    }

    // Method to encrypt the password using SHA-256
    public static string EncryptPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // Compute hash from the password string
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert byte array to a string representation
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                builder.Append(hashedBytes[i].ToString("x2")); // Convert to hexadecimal format
            }

            return builder.ToString();
        }
    }
}