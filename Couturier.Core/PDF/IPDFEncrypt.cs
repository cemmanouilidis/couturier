using System;

namespace Couturier.Core
{	
	public interface IPDFEncrypt
	{
		bool EncryptPDF (string File, string Passwd);
	}
}
