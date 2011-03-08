// PDFCreatorPDFTk.cs
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
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Couturier.Core.PDF
{
	public class PDFCreatorIText : IPDFCreator
	{
		public PDFCreatorIText()
		{
		}
		
		bool IPDFCreator.CreatePDF (List<string> FileList, string OutputFile)
		{
			System.Console.WriteLine("----------------------------------------------------");
			int f = 0;
			// we create a reader for a certain document
			String path = FileList[f];
			System.Console.WriteLine(String.Format("Processing file {0}", path));
			PdfReader reader = new PdfReader(path);
			// we retrieve the total number of pages
			int n = reader.NumberOfPages;
			Console.WriteLine("There are " + n + " pages in the original file.");
			// step 1: creation of a document-object
			
			Document document = new Document(reader.GetPageSizeWithRotation(1));
			document.SetMargins(0, 0, 0, 0);
			
			// step 2: we create a writer that listens to the document
			PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(OutputFile, FileMode.Create));
			// step 3: we open the document
			document.Open();
			PdfContentByte cb = writer.DirectContent;
			PdfImportedPage page;
			int rotation;
			
			// step 4: we add content
			while (f < FileList.Count)
			{
				int i = 0;
				while (i < n)
				{
					i++;
					document.SetPageSize(reader.GetPageSizeWithRotation(i));
					document.NewPage();
					
					page = writer.GetImportedPage(reader, i);
					rotation = reader.GetPageRotation(i);
					if (rotation == 90 || rotation == 270)
					{
						cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
					}
					else
					{
						cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
					}
					
					Console.WriteLine("Processed page " + i);
				}
				f++;

				if (f < FileList.Count)
				{
					path = FileList[f];
					reader = new PdfReader(path);
					// we retrieve the total number of pages
					n = reader.NumberOfPages;
					Console.WriteLine("There are " + n + " pages in the original file.");
					System.Console.WriteLine(String.Format("Processing file {0}", path));
				}
			}

			// step 5: we close the document
			document.Close();
			System.Console.WriteLine("----------------------------------------------------\n");
			return true;
		}	
	}
}
