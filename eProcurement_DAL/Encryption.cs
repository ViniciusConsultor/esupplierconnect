using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace eProcurement_DAL
{
    public class Encryption
    {
        #region encryption constants

        //******************************************************************************************
        //Programmer Note: 
        //These constants can be changed if desired. Be aware that if these constants are changed,
        //any values previously encrypted will not be able to be unencrypted as these values are 
        //what was used to generate the encryption in the first place.
        //Change With Caution.
        //******************************************************************************************

        private const string C_KEY = "22515216714613359164620314164148123127244177";  //Any valid string 
        private const string C_INITVECTOR = "@Mh5Lj*%(i7qBr1d";  //Must be exactly 16 characters in length.
        private const string C_SALTVALUE = "3.14157284><;:nFesTfaGmTcJtAoBc?+|-";  //Any valid string
        private const string C_PASSPHRASE = "NeC!7&RuLeS-tHe-EaRtH.?!";
        private const string hashAlgorithm = "MD5";
        private const int passwordIterations = 2;
        private const int keySize = 128;

        #endregion

        /// <summary>
        /// Encrypts specified plaintext using Rijndael symmetric key algorithm
        /// and returns a base64-encoded result.
        ///
        /// Param StringToEncrypt 
        ///			Plain text value to be encrypted.
        /// Returns an Encrypted value formatted as a base64-encoded string.
        /// </summary>
        /// <param name="StringToEncrypt"></param>
        /// <returns></returns>
        public static string Encrypt(string StringToEncrypt)
        {
            ICryptoTransform encryptor = null;
            byte[] initVectorBytes = null;
            byte[] saltValueBytes = null;
            PasswordDeriveBytes password = null;
            byte[] plainTextBytes = null;
            byte[] keyBytes = null;
            RijndaelManaged symmetricKey = null;
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            byte[] bytEncryptedText = null;
            string strEncryptedText = "";

            try
            {
                // Convert strings into byte arrays.
                // Assumes that strings only contain ASCII codes.
                // If strings include Unicode characters, use Unicode, UTF7, or UTF8 encoding.

                initVectorBytes = Encoding.ASCII.GetBytes(C_INITVECTOR);


                saltValueBytes = Encoding.ASCII.GetBytes(C_SALTVALUE);

                // Convert plaintext into a byte array.
                // Assumes that plaintext contains UTF8-encoded characters.

                plainTextBytes = Encoding.UTF8.GetBytes(StringToEncrypt);

                // First, we must create a password, from which the key will be derived.
                // This password will be generated from the specified passphrase and 
                // salt value. The password will be created using the specified hash 
                // algorithm. Password creation can be done in several iterations.

                password = new PasswordDeriveBytes(C_PASSPHRASE, saltValueBytes, "MD5", passwordIterations);

                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).

                keyBytes = password.GetBytes(keySize / 8);

                // Create uninitialized Rijndael encryption object.

                symmetricKey = new RijndaelManaged();

                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = CipherMode.CBC;

                // Generate encryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.

                encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

                // Define memory stream which will be used to hold encrypted data.

                memoryStream = new MemoryStream();

                // Define cryptographic stream (always use Write mode for encryption).

                cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                // Start encrypting.
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                // Finish encrypting.
                cryptoStream.FlushFinalBlock();

                // Convert our encrypted data from a memory stream into a byte array.

                bytEncryptedText = memoryStream.ToArray();

                // Close both streams.
                memoryStream.Close();
                cryptoStream.Close();

                // Convert encrypted data into a base64-encoded string.

                strEncryptedText = Convert.ToBase64String(bytEncryptedText);

                // Return encrypted string.
                strEncryptedText = strEncryptedText.Replace("=", "EQUAL");
                strEncryptedText = strEncryptedText.Replace("+", "PLUS");
                return strEncryptedText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Cleanup and release objects.
                encryptor = null;
                initVectorBytes = null;
                saltValueBytes = null;
                password = null;
                plainTextBytes = null;
                keyBytes = null;
                symmetricKey = null;

                if (memoryStream != null)
                {
                    memoryStream.Close();
                    memoryStream.Dispose();
                }
                if (cryptoStream != null)
                {
                    cryptoStream.Close();
                    cryptoStream.Dispose();
                }
                strEncryptedText = null;
                bytEncryptedText = null;
            }
        }

        /// <summary>
        /// Encrypts specified plaintext using Rijndael symmetric key algorithm
        /// and returns a base64-encoded result.
        ///
        /// Param cipherText 
        ///			Base64-formatted ciphertext value.        
        /// Returns an Encrypted value formatted as a base64-encoded string.
        /// Returns Decrypted string value.
        ///
        ///Special Note:
        /// The logic in this function is similar to the Encrypt logic. In order for decryption 
        /// to work, all parameters of this function except cipherText value must match the corresponding 
        /// parameters of the Encrypt function which was called to generate the ciphertext.
        /// </summary>
        /// <param name="StringToDecrypt"></param>
        /// <returns></returns>
        public static string Decrypt(string StringToDecrypt)
        {
            byte[] initVectorBytes = null;
            byte[] saltValueBytes = null;
            byte[] bytEncryptedText = null;
            PasswordDeriveBytes password = null;
            byte[] keyBytes = null;
            RijndaelManaged symmetricKey = null;
            ICryptoTransform decryptor = null;
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            byte[] plainTextBytes = null;
            int decryptedByteCount = 0;
            string strUnencryptedText = null;

            try
            {
                // Convert strings defining encryption key characteristics into byte
                // arrays. Assumes that strings only contain ASCII codes.
                // If strings include Unicode characters, use Unicode, UTF7, or UTF8
                // encoding.

                initVectorBytes = Encoding.ASCII.GetBytes(C_INITVECTOR);


                saltValueBytes = Encoding.ASCII.GetBytes(C_SALTVALUE);

                StringToDecrypt = StringToDecrypt.Replace("PLUS", "+");
                StringToDecrypt = StringToDecrypt.Replace("EQUAL", "=");
                // Convert our ciphertext into a byte array.
                if (StringToDecrypt.Contains(" "))
                    StringToDecrypt = StringToDecrypt.Replace(" ", "+");

                bytEncryptedText = Convert.FromBase64String(StringToDecrypt);

                // First, we must create a password, from which the key will be 
                // derived. This password will be generated from the specified 
                // passphrase and salt value. The password will be created using
                // the specified hash algorithm. Password creation can be done in
                // several iterations.

                password = new PasswordDeriveBytes(C_PASSPHRASE, saltValueBytes, "MD5", passwordIterations);
                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).

                keyBytes = password.GetBytes(keySize / 8);

                // Create uninitialized Rijndael encryption object.

                symmetricKey = new RijndaelManaged();

                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = CipherMode.CBC;

                // Generate decryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.

                decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

                // Define memory stream which will be used to hold encrypted data.

                memoryStream = new MemoryStream(bytEncryptedText);

                // Define memory stream which will be used to hold encrypted data.

                cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                // Since at this point we don't know what the size of decrypted data
                // will be, allocate the buffer long enough to hold ciphertext;
                // plaintext is never longer than ciphertext.

                plainTextBytes = new byte[bytEncryptedText.Length];

                try
                {
                    decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                    // Convert decrypted data into a string. 
                    // Let us assume that the original plaintext string was UTF8-encoded.
                    strUnencryptedText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                    cryptoStream.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    if (cryptoStream != null)
                    {
                        cryptoStream.Close();
                        cryptoStream.Dispose();
                    }
                }
                return strUnencryptedText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Cleanup and release objects and variables.
                initVectorBytes = null;
                saltValueBytes = null;
                bytEncryptedText = null;
                password = null;
                keyBytes = null;
                symmetricKey = null;
                if (decryptor != null)
                {
                    decryptor.Dispose();
                }
                if (memoryStream != null)
                {
                    memoryStream.Close();
                    memoryStream.Dispose();
                }
                if (cryptoStream != null)
                {
                    cryptoStream.Close();
                    cryptoStream.Dispose();
                }
                plainTextBytes = null;
                strUnencryptedText = null;
            }
        }
    }
}
