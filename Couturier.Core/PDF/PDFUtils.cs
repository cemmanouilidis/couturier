// PDFUtils.cs
// 
// Copyright (C) 2009 Charalampos Emmanouilidis
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System;

namespace Couturier.Core.PDF
{
	public class PDFUtils : IPDFConverter, IPDFInfo, IPDFEncrypt
	{
		private static PDFUtils _instance = null;
		private IPDFConverter _iPDFConverter = null; 
		private IPDFInfo _iPDFInfo = null;
		private IPDFEncrypt _iPDFEncrypt = null;
		
		private PDFUtils()
		{
			_iPDFConverter = new PDFConverterIText();
			//_iPDFConverter = new PDFConverterImageMagick();
			_iPDFInfo = new PDFInfoIText();
			//_iPDFInfo = new PDFInfoPDFTk();
			_iPDFEncrypt = new PDFEncryptIText();
		}
		
		public static PDFUtils Instance
		{
			get 
			{
				if (_instance == null)
				{
					_instance = new PDFUtils();
				}
				return _instance;
			}
		}
				
		public bool ConvertToPDF (string Src, out string PDFFile)
		{
			return _iPDFConverter.ConvertToPDF(Src, out PDFFile);
		}

		public int GetNumberOfPages (string Src)
		{
			return _iPDFInfo.GetNumberOfPages(Src);
		}
		
		public bool EncryptPDF (string File, string Passwd)
		{
			return _iPDFEncrypt.EncryptPDF(File, Passwd);
		}
	}
}
