// Main.cs
// Charalampos Emmanouilidis at 10:44 AM 4/8/2009
//
// All rights reserved
//


using System;
using System.IO;

using Mono.Unix;
using Gtk;

namespace Couturier
{
	class MainClass
	{
		public static void Main (string[] args)
		{	
            Gdk.Global.ProgramClass = "couturier";
            InitCatalog ("/usr/local/share/locale/", "/usr/share/locale/");
			
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
		
		static void InitCatalog (params string [] dirs)
        {
            foreach (var dir in dirs) {
                var test_file = Path.Combine (dir, "de/LC_MESSAGES/couturier.mo");
                if (File.Exists (test_file)) {
                    Catalog.Init ("couturier", dir);
                    break;
                }
            }
        }
	}
}