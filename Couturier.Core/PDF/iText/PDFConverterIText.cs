// PDFUtilsImageMagick.cs
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
using Gnome;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Couturier.Core.PDF
{
	public class PDFConverterIText : IPDFConverter
	{		
		bool IPDFConverter.ConvertToPDF (string Src, out string PDFFile)
		{
			FileInfo info = new FileInfo(Src);
			PDFFile = Src;
			bool succeeded = true;
				
			Gnome.Vfs.Uri uri = new Gnome.Vfs.Uri(Gnome.Vfs.Uri.GetUriFromLocalPath(info.FullName));
			Gnome.Vfs.MimeType mime = new Gnome.Vfs.MimeType(uri);
				
			if (mime != null && mime.Name.ToLower().StartsWith("image"))
			{	
				Document document = null;
				try 
				{					
					PDFFile = String.Format("/tmp/{0}.pdf", info.Name);
					
					Image logo = Image.GetInstance(info.FullName);			
					// step 1: creation of a document-object
					//Rectangle pageSize = new Rectangle(logo.GetRectangle(0, 0));
				
					document = new Document();
					document.SetMargins(0, 0, 0, 0);
					document.SetPageSize(new Rectangle(logo.Width, logo.Height));
		        
					// step 2:
					// we create a writer that listens to the document
					// and directs a PDF-stream to a file
					PdfWriter.GetInstance(document, new FileStream(PDFFile, FileMode.Create));
		            
					// step 3: we open the document
					document.Open();
		            
					// step 4: we Add some paragraphs to the document
					document.Add(logo);
				}
				catch(DocumentException de) 
				{
					Console.Error.WriteLine(de.Message);
				}
				catch(IOException ioe) 
				{
					Console.Error.WriteLine(ioe.Message);
				}
		        
				// step 5: we close the document
				document.Close();	
			}	

			if (! File.Exists(PDFFile))
			{
				PDFFile = null;
				succeeded = false;
			}
			
			return succeeded;
		}		
	}
}
