// PDFInfoiText.cs
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
using System.IO;
using iTextSharp.text.pdf;

namespace Couturier.Core.PDF
{	
	public class PDFInfoIText : IPDFInfo
	{
		public PDFInfoIText()
		{
		}
		
		int IPDFInfo.GetNumberOfPages (string Src)
		{
			int pages = 1;
			FileInfo info = new FileInfo(Src);
			
			Gnome.Vfs.Uri uri = new Gnome.Vfs.Uri(Gnome.Vfs.Uri.GetUriFromLocalPath(info.FullName));
			Gnome.Vfs.MimeType mime = new Gnome.Vfs.MimeType(uri);
			
			if (mime.Name.ToLower() == "application/pdf")
			{	
				PdfReader reader = new PdfReader(Src);
				pages = reader.NumberOfPages;
				reader.Close();
			}
			
			return pages;
		}
	}
}
