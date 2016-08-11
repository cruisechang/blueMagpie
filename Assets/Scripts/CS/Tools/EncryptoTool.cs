using System;
using System.Security.Cryptography;
using System.Text;

public class EncryptoTool
{
	public static string GetMD5SumPadLeft (string stringToEncrypt)
	{
		//String to bytes.
		UTF8Encoding ue = new UTF8Encoding ();
		byte[] bytes = ue.GetBytes (stringToEncrypt);

		// encrypt bytes
		MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider ();
		byte[] hashBytes = md5.ComputeHash (bytes);

		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";

		for (int i = 0; i < hashBytes.Length; i++) {
			hashString += Convert.ToString (hashBytes [i], 16).PadLeft (2, '0');
		}

		return hashString.PadLeft (32, '0');
	}

	public static string GetMD5Sum (string stringToEncrypt)
	{
		MD5 md5 = MD5.Create ();
		//String to utf8 Byte[]
		byte[] source = Encoding.UTF8.GetBytes (stringToEncrypt);

		//Compute MD5 sum
		byte[] crypto = md5.ComputeHash (source);

		//Encrypted byte[] to string.
		return  Convert.ToBase64String (crypto);
	}

	public static string SHA1Encryption (string stringToEncrypt)
	{
		SHA1 sha1 = new SHA1CryptoServiceProvider ();

		//String to Byte[]
		byte[] source = Encoding.UTF8.GetBytes (stringToEncrypt);

		//SHA1 encryption
		byte[] crypto = sha1.ComputeHash (source);

		//Byte[] to string
		return  Convert.ToBase64String (crypto);
	}

	public static string SHA256Encryption (string stringToEncrypt)
	{
//		SHA256 sha256 = System.Security.Cryptography.SHA256CryptoServiceProvider ();
		SHA256 sha256 = SHA256.Create ();
		byte[] source = Encoding.UTF8.GetBytes (stringToEncrypt);
		byte[] crypto = sha256.ComputeHash (source);
		return  Convert.ToBase64String (crypto);

	}

	public static string SHA384Encryption (string stringToEncrypt)
	{
//		SHA384 sha384 = new SHA384CryptoServiceProvider ();
		SHA384 sha384 = SHA384.Create ();
		byte[] source = Encoding.UTF8.GetBytes (stringToEncrypt);
		byte[] crypto = sha384.ComputeHash (source);
		return Convert.ToBase64String (crypto);

	}

	public static string SHA512Encryption (string stringToEncrypt)
	{
//		SHA512 sha512 = new SHA512CryptoServiceProvider ();
		SHA512 sha512 = SHA512.Create ();
		byte[] source = Encoding.UTF8.GetBytes (stringToEncrypt);
		byte[] crypto = sha512.ComputeHash (source);
		return Convert.ToBase64String (crypto);

	}

	/// <summary>
	/// Triples the DES encryption.
	/// Key size must be 16bytes or 24bytes.
	/// CipherMode ECB
	/// PaddingMode PKCS7
	/// Convert result byte array to base64 string.
	/// </summary>
	/// <returns>The DES encryption.</returns>
	/// <param name="stringToEncrypt">String to encrypt.</param>
	/// <param name="keyStr">Key string.</param>
	public static string TripleDESEncryption (string stringToEncrypt, string keyStr)
	{
		byte[] strAry = Encoding.UTF8.GetBytes (stringToEncrypt);
	

		TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider () {
			Key = Encoding.UTF8.GetBytes (keyStr),
			Mode = CipherMode.ECB,
//			Padding = PaddingMode.PKCS7
			Padding = PaddingMode.ISO10126
		};

		//Create encryptor
		ICryptoTransform ct = tdes.CreateEncryptor ();
		byte[] encryptAry = ct.TransformFinalBlock (strAry, 0, strAry.Length);

		//Release resources held by TripleDes Encryptor 
		tdes.Clear ();

		return Convert.ToBase64String (encryptAry);
	}

	public static string TripleDESDecryption (string stringToDecrypt, string keyStr)
	{
		//Encrypt string is a base64 converted string, now convert to encrypt array.
		byte[] encryptAry = Convert.FromBase64String (stringToDecrypt);

		//Create 3DES provider
		TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider () {

			Key = Encoding.UTF8.GetBytes (keyStr),
			Mode = CipherMode.ECB,
//			Padding = PaddingMode.PKCS7
			Padding = PaddingMode.ISO10126
		};

		//Create decryptor
		ICryptoTransform ct = tdes.CreateDecryptor ();
		byte[] strAry = ct.TransformFinalBlock (encryptAry, 0, encryptAry.Length);

		//Release resources held by TripleDes Encryptor                
		tdes.Clear ();

		//return the Clear decrypted TEXT
		return Encoding.UTF8.GetString (strAry);
	}
}
