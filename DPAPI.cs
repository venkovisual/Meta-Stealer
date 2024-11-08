using System;
using System.Security.Cryptography;
using System.Text;

// Token: 0x02000011 RID: 17
public static class DPAPI
{
	// Token: 0x0600004C RID: 76 RVA: 0x000086DC File Offset: 0x000068DC
	public static string Unprotect(string encryptedString, DataProtectionScope scope, string optionalEntropy = null)
	{
		return Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(encryptedString), (optionalEntropy != null) ? Encoding.UTF8.GetBytes(optionalEntropy) : null, scope));
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00008705 File Offset: 0x00006905
	public static string Protect(string stringToEncrypt, DataProtectionScope scope, string optionalEntropy = null)
	{
		return Convert.ToBase64String(ProtectedData.Protect(Encoding.UTF8.GetBytes(stringToEncrypt), (optionalEntropy != null) ? Encoding.UTF8.GetBytes(optionalEntropy) : null, scope));
	}
}
