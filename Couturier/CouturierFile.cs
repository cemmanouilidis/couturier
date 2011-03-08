// CouturierFile.cs
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
using Gdk;
using Gtk;
using Gnome;
using Couturier.Core.PDF;

namespace Couturier
{
	public class CouturierFile
	{	
		public CouturierFile(String _File)
		{
			if (File.Exists(_File))
			{
				FileInfo info = new FileInfo(_File);
				
				this.Exists   = true;
				this.FullName = info.FullName;
				this.Name     = info.Name;
				this.Uri      = new Gnome.Vfs.Uri (Gnome.Vfs.Uri.GetUriFromLocalPath(info.FullName));
				this.MimeType = new Gnome.Vfs.MimeType (this.Uri);
                try
                {
				    this.NumberOfPages = PDFUtils.Instance.GetNumberOfPages (_File); 
                    this.IsValid = true;
                }
                catch (Exception err)
                {
                    this.IsValid = false;
                    this.LastError = err.Message;
                }
			}
			else
			{
				this.Exists = false;
			}
		}
        
        public Boolean IsValid 
        {
            get;
            internal set;
        }
		
        public String LastError
        {
            get;
            internal set;
        }
        
        public Boolean Exists
		{
			get;
			internal set;
		}
		
		public String FullName
		{
			get;
			internal set;
		}
		
		public String Name
		{
			get;
			internal set;
		}

		public Gnome.Vfs.Uri Uri
		{
			get;
			internal set;
		}

		public Gnome.Vfs.MimeType MimeType
		{
			get;
			internal set;
		}
		
		public int NumberOfPages
		{
			get;
			internal set;
		}
		
		public Gdk.Pixbuf GetThumbnail ()
		{
			return GetThumbnail(ThumbnailSize.Normal);
		}
		
		public Gdk.Pixbuf GetThumbnail (ThumbnailSize size)
		{
			ThumbnailFactory factory = new ThumbnailFactory(size);
			Gdk.Pixbuf thumb = null;
			
			if (factory.CanThumbnail(Uri.ToString(), MimeType.Name, DateTime.Now))
			{
				thumb = factory.GenerateThumbnail(Uri.ToString(), MimeType.Name);
/*				
				if (thumb != null)
				{
					factory.SaveThumbnail(thumb, Uri.ToString(), DateTime.Now);
				}
*/
			}
			else if (MimeType.Name.ToLower() == "application/pdf")
			{
				thumb = Gnome.IconTheme.Default.LoadIcon("application-pdf", 92, Gtk.IconLookupFlags.GenericFallback);
			}
			else if (MimeType.Name.ToLower().StartsWith("image"))
			{
				thumb = Gnome.IconTheme.Default.LoadIcon("image", 92, Gtk.IconLookupFlags.GenericFallback);
			}
			else
			{
				thumb = Gnome.IconTheme.Default.LoadIcon("file", 92, Gtk.IconLookupFlags.GenericFallback);
			}

			return thumb;
		}
		
		public override String ToString ()
		{
			return this.FullName;
		}
	}
}
