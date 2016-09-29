using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace CryptoAPI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label.Text = "";
            this.labelResult.Text = "";

            string original = this.textBoxSource.Text;

            try
            {
                if (this.comboBoxType.SelectedIndex == 0)
                {
                    // Symmetric

                    // Create a new instance of the AesManaged class.
                    // This generates a new key and initialization vector (IV).
                    using (AesManaged myAes = new AesManaged())
                    {
                        // Encrypt the string to an array of bytes.
                        byte[] encrypted = Aes.EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

                        this.labelResult.Text = Convert.ToBase64String(encrypted);

                        // Decrypt the bytes to a string.
                        string roundtrip = Aes.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

                        //Display the original data and the decrypted data.
                        this.label.Text = roundtrip;
                    }
                }
                else if (this.comboBoxType.SelectedIndex == 1)
                {
                    // Asymmetric

                    //lets take a new CSP with a new 2048 bit rsa key pair
                    var csp = new RSACryptoServiceProvider(2048);

                    //how to get the private key
                    var privKey = csp.ExportParameters(true);

                    //and the public key ...
                    var pubKey = csp.ExportParameters(false);

                    //we have a public key ... let's get a new csp and load that key
                    csp = new RSACryptoServiceProvider();
                    csp.ImportParameters(pubKey);

                    //for encryption, always handle bytes...
                    var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(original);

                    //apply pkcs#1.5 padding and encrypt our data 
                    var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);

                    //we might want a string representation of our cypher text... base64 will do
                    var cypherText = Convert.ToBase64String(bytesCypherText);

                    this.labelResult.Text = cypherText;

                    //first, get our bytes back from the base64 string ...
                    bytesCypherText = Convert.FromBase64String(cypherText);

                    //we want to decrypt, therefore we need a csp and load our private key
                    csp = new RSACryptoServiceProvider();
                    csp.ImportParameters(privKey);

                    //decrypt and strip pkcs#1.5 padding
                    bytesPlainTextData = csp.Decrypt(bytesCypherText, false);

                    //get our original plainText back...
                    this.label.Text = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);
                }
                else if (this.comboBoxType.SelectedIndex == 2)
                {
                    // Hashing

                    byte[] bytes = Encoding.UTF8.GetBytes(original);

                    // Initialize a SHA256 hash object.
                    SHA256 mySHA256 = SHA256Managed.Create();
                    byte[] hash = mySHA256.ComputeHash(bytes);
                    
                    string hashString = string.Empty;
                    foreach (byte x in hash)
                    {
                        hashString += String.Format("{0:x2}", x);
                    }

                    this.labelResult.Text = hashString;
                }

            }
            catch (Exception ex)
            {
                this.label.Text = ex.Message;
            }
        }
    }


    class Aes
    {
        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        }
    }
}
