// PDFCreator.cs
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
using System.Collections.Generic;


namespace Couturier.Core.PDF
{
	public class PDFCreator : IPDFCreator
	{
		private static PDFCreator _instance = null;
		private IPDFCreator _iPdfCreator = null;
		
		private PDFCreator()
		{
			_iPdfCreator = new PDFCreatorIText();
			//_iPdfCreator = new PDFCreatorPDFTk();
		}
		
		public static IPDFCreator Instance
		{
			get 
			{
				if (_instance == null)
				{
					_instance = new PDFCreator();
				}
				
				return _instance;
			}
		}
		
		bool IPDFCreator.CreatePDF (List<string> FileList, string OutputFile)
		{
			List<string> files = new List<string>();
			
			foreach (String f in FileList)
			{
				String pdf;
				if (PDFUtils.Instance.ConvertToPDF(f, out pdf))
				{
					files.Add(pdf);
				}
			}
			
			return _iPdfCreator.CreatePDF(files, OutputFile);
		}

	}
}
