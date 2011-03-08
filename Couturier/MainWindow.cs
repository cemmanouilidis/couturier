// MainWindow.cs created with MonoDevelop
// User: charemma at 10:41 AM 4/8/2009
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Mono.Unix;
using Gtk;
using Gdk;
using Couturier;
using Gnome;
using Couturier.Core.PDF;

public partial class MainWindow: Gtk.Window
{
	Gtk.ListStore _documentStore = null;
	private int _nrOfDocuments = 0;

	private String _folderSelectImport = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
	private String _folderSave =  Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    
    delegate void VoidDelegateString (String str);
	
	~MainWindow ()
	{
		Gnome.Vfs.Vfs.Shutdown();
	}

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Gnome.Vfs.Vfs.Initialize();
		treeviewDocuments.Model = DocumentStore;

		DocumentStore.RowInserted += OnRowInserted;
		DocumentStore.RowDeleted += OnRowDeleted;
		DocumentStore.RowChanged += OnRowChanged;
		
		
		try {
			this.imageDocument.Pixbuf = Gnome.IconTheme.Default.LoadIcon("gnome-mime-application-pdf", 128, Gtk.IconLookupFlags.GenericFallback);
            this.Icon = Gnome.IconTheme.Default.LoadIcon("couturier", 128, Gtk.IconLookupFlags.GenericFallback);
		}
		catch (Exception err)
		{
			System.Console.WriteLine(err.Message);
			System.Console.WriteLine(err.StackTrace);
		}
		
		treeviewDocuments.AppendColumn (Mono.Unix.Catalog.GetString("Preview"), new Gtk.CellRendererPixbuf(), "pixbuf", 0);
		treeviewDocuments.AppendColumn (Mono.Unix.Catalog.GetString("Document"), new Gtk.CellRendererText(), "markup", 1);
        	
		TargetEntry[] Targets = new TargetEntry[]{ 
            new TargetEntry("text/uri-list", TargetFlags.OtherApp, 0),
			new TargetEntry("application/couturier-row", TargetFlags.Widget, 1),
		};

        TargetEntry[] Sources = new TargetEntry[]{ 
            new TargetEntry("application/couturier-row", TargetFlags.Widget, 0),
        };
        
		this.labelPages.Text = Catalog.GetString("No Pages");
		this.imageAddDocument.TooltipMarkup = Catalog.GetString ("Add new document");
		this.imageRemoveDocument.TooltipMarkup = Catalog.GetString("Remove selected document");
    	this.imageClearList.TooltipMarkup = Catalog.GetString ("Clear list");
		  
		treeviewDocuments.EnableModelDragSource (Gdk.ModifierType.Button1Mask, Sources, (Gdk.DragAction.Default|Gdk.DragAction.Move));
		treeviewDocuments.EnableModelDragDest (Targets, Gdk.DragAction.Default);
		treeviewDocuments.Show();
		
		LoadDefaults();
        
        ShowAll();
	}
	
#region Properties	
	private int NrOfDocuments
	{
		get
		{
			return _nrOfDocuments;
		}
		set
		{
			_nrOfDocuments = value;
            CheckReadyness();
			UpdateNumberOfPages();
		}
	}
	
    private void CheckReadyness ()
    {
        bool _docsReady = false;
        bool _nameReady = !String.IsNullOrEmpty(entryDocumentName.Text);
        bool _ready = false;
        
        if (_nrOfDocuments == 0)
        {
            labelHintAddDocuments.Visible = true;
        }
        else
        {
            _docsReady = true;
            labelHintAddDocuments.Visible = false;
        }
        
        _ready = (_docsReady && _nameReady);
        
        this.buttonDoit.Sensitive = _ready;
        this.imageDocument.Sensitive = _ready;
    }
    
    
	private Gtk.ListStore DocumentStore
	{
		get 
		{
			if (_documentStore == null)
			{
				_documentStore = new ListStore(typeof(Gdk.Pixbuf), typeof(string), typeof(CouturierFile));		
			}
			
			return _documentStore;
		}
	}
#endregion	
	
	
	
#region EventHandler
	
	public void OnRowInserted (object sender, RowInsertedArgs args)
	{
		++NrOfDocuments;
	}
	
	public void OnRowDeleted (object sender, RowDeletedArgs args)
	{
		--NrOfDocuments;
	}
	
	public void OnRowChanged (object sender, RowChangedArgs args)
	{
		//UpdateNumberOfPages();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;		
	}

	//TODO: Allow DnD from outside. Don't now, how to receive the data dropped into the widget...
	protected virtual void OnTreeviewDocumentsDragDataReceived (object o, Gtk.DragDataReceivedArgs args)
	{
        bool success = false;
        
        try
        {
            // Gtk.Widget source = Gtk.Drag.GetSourceWidget (args.Context);
            switch (args.Info)
            {
            case 0: //uri-list
                string data = System.Text.Encoding.UTF8.GetString (args.SelectionData.Data);
                string [] uri_list = Regex.Split (data, "\r\n");
                foreach (string u in uri_list)
                {
                    if (!String.IsNullOrEmpty(u))
                    {
                        Gnome.Vfs.Uri uri = new Gnome.Vfs.Uri(u);
                        this.AppendFile(uri.Path.Replace("%20", " "));
                    }
                }
                success = true;
                break;
            
            case 1: //row dragged
                 TreeIter sourceIter = new TreeIter();
    
                TreeModel model;    
                Gtk.TreeSelection selection = this.treeviewDocuments.Selection;
                //int row_pos = 0;
                if (selection.GetSelected (out model, out sourceIter)) 
                {
                    //TreePath[] paths = selection.GetSelectedRows (out model);
                    //row_pos = paths[0].Indices[0];
                }
          
                TreePath path;
                TreeViewDropPosition pos;
                bool dropInfo = treeviewDocuments.GetDestRowAtPos(args.X, args.Y, out path, out pos);
                
				if (dropInfo)
                {
                    TreeIter iter;
                    DocumentStore.GetIter(out iter, path);  
                
                    if (pos == TreeViewDropPosition.Before || pos == TreeViewDropPosition.IntoOrBefore)
                    {
                        DocumentStore.MoveBefore(sourceIter, iter);
                    }
                    else
                    {
                        DocumentStore.MoveAfter(sourceIter, iter);
                    }
                }
				/*
                else
                {
                    RemoveDocument(ref sourceIter);
                }
                */
                
                
                success = true;
                break;
                
            }
        }
        catch (Exception err)
        {
            success = false;
            System.Console.WriteLine (Catalog.GetString("DragNDrop failed") + ": " + err.Message +  "\n" + err.StackTrace );
        }
            
		Gtk.Drag.Finish (args.Context, success, false, args.Time);
	}

	protected virtual void OnButtonAddClicked (object sender, System.EventArgs e)
	{
		Gtk.FileChooserDialog fc = new Gtk.FileChooserDialog(
		                            Catalog.GetString("Choose document to open"),
		                            this,
		                            FileChooserAction.Open,
		                            Catalog.GetString("Cancel"), ResponseType.Cancel,
		                            Catalog.GetString("Open"), ResponseType.Accept);
		fc.SelectMultiple = true;
		fc.PreviewWidgetActive = true;
		fc.SetCurrentFolder (_folderSelectImport);
		
		FileFilter filterSupported = new FileFilter();
		filterSupported.Name = Catalog.GetString("Documents supported by Couturier");
		filterSupported.AddMimeType("application/pdf");
		filterSupported.AddMimeType("image/*");
		
		FileFilter filterPDF = new FileFilter();
		filterPDF.Name = Catalog.GetString("PDF Files");
		filterPDF.AddMimeType("application/pdf");		
		
		FileFilter filterImages = new FileFilter();
		filterImages.Name = Catalog.GetString("Image Files");
		
		filterImages.AddMimeType("image/*");
		
		FileFilter filterAll = new FileFilter();
		filterAll.Name = Catalog.GetString("All Files");
		filterAll.AddPattern("*");

		fc.AddFilter(filterSupported);
		fc.AddFilter(filterPDF);
		fc.AddFilter(filterImages);
		fc.AddFilter(filterAll);
	
		if (fc.Run() == (int) ResponseType.Accept) 
		{
			foreach (String file in fc.Filenames)
			{
				AppendFile(file);
			}
			
			if (! String.IsNullOrEmpty(fc.CurrentFolder))
				_folderSelectImport = fc.CurrentFolder;
		}
		
		//Don't forget to call Destroy() or the FileChooserDialog window won't get closed
		fc.Destroy();		
		
	}

    void RemoveDocument (ref TreeIter iter)
    {
        
        if (DocumentStore.IterIsValid(iter))
        {
            DocumentStore.Remove(ref iter);             
        }
    
        //Set the selection to the next available item
        if (! DocumentStore.IterIsValid(iter))
        {               
            DocumentStore.GetIterFirst(out iter);
            
            //Find the last available iter
            if (DocumentStore.IterIsValid(iter))
            {
                TreeIter current = iter;
                
                while (DocumentStore.IterNext(ref iter))
                {
                    if (DocumentStore.IterIsValid(iter))
                    {
                        current = iter;             
                    }
                }
                iter = current;
            }
        }

        if (DocumentStore.IterIsValid(iter))
        {
            this.treeviewDocuments.Selection.SelectIter(iter);          
        }
        
        UpdateNumberOfPages();    
    }
    
    void RemoveDocument ()
    {
        TreeModel model;
        TreeIter iter;
        
        Gtk.TreeSelection selection = this.treeviewDocuments.Selection;
                    
        if (selection.GetSelected (out model, out iter)) 
        {
            RemoveDocument (ref iter);
        }
    }
	
    protected virtual void OnButtonRemoveClicked (object sender, System.EventArgs e)
	{
	   RemoveDocument();
	}

	
	protected virtual void OnButtonDoitClicked (object sender, System.EventArgs e)
	{   
        CreatePDF();
	}
#endregion
	

#region Helper
	protected void SetNewDocumentName ()
	{
        entryDocumentName.Text = Catalog.GetString("Documents All.pdf");
        entryDocumentName.Text = (new FileInfo(GetNextSaveFileName())).Name;
		entryPassword.Text = "";
		Title = Catalog.GetString("Couturier - New Document");
		
        FileInfo info = new FileInfo(entryDocumentName.Text);
        entryDocumentName.SelectRegion(0, (info.Name.Length - info.Extension.Length));
	}
	
	protected void ClearDocumentList ()
	{
		DocumentStore.Clear();
        NrOfDocuments = 0;
		labelPages.Text = Catalog.GetString("No pages");
	}
	
	protected void LoadDefaults ()
	{
        filechooserbuttonOutput.SetCurrentFolder(_folderSave);
        
		SetNewDocumentName();
		ClearDocumentList();
	}
	
	protected void AppendFile (string _File)
	{
		AppendFile (_File, -1); //append to the end
	}
	
	protected void AppendFile (string _File, int index)
	{
		CouturierFile couFile = new CouturierFile(_File);
		
		if (! couFile.Exists || !couFile.IsValid)
		{
            if (!String.IsNullOrEmpty (couFile.LastError))
            {
				string msg1 = Catalog.GetString("Could not add document \"{0}\".");
			    string msg2 = Catalog.GetString("The following error occurred:");
				
                MessageDialog md = new MessageDialog (null, 
                                      DialogFlags.DestroyWithParent,
                                      MessageType.Error, 
                                      ButtonsType.Ok, 
				                      String.Format(msg1 + "\n\n" + msg2 +  "\n{1}\n", _File, couFile.LastError));
                md.Run ();
                md.Destroy();      
            }
            
			return;
		}
			
		TreeModel model;
		TreeIter iter;
		
		Gtk.TreeSelection selection = this.treeviewDocuments.Selection;
		
		try
		{
			string info = String.Format("<b>{0}</b>\n<small>\n{1}: {2}\n{3}: {4}</small>", 
			                            couFile.Name, Catalog.GetString("Document"), couFile.FullName, Catalog.GetString("Pages"), couFile.NumberOfPages.ToString());
			
			if (selection.GetSelected (out model, out iter)) 
			{
				TreePath[] path = selection.GetSelectedRows (out model);
				int pos = path[0].Indices[0];
				
				if (pos >= 0)
				{
					this.treeviewDocuments.Selection.SelectIter(DocumentStore.InsertWithValues(pos+1, couFile.GetThumbnail(), info, couFile));
				}			
			}
			else
			{
				this.treeviewDocuments.Selection.SelectIter(DocumentStore.AppendValues(couFile.GetThumbnail(), info, couFile));
			}
			
		}
		catch (Exception err)
		{
			System.Console.WriteLine(err.Message);
			System.Console.WriteLine(err.StackTrace);
		}
		finally
		{
			UpdateNumberOfPages();
		}
	}

    
    private string GetNextSaveFileName ()
    {
        string path = (filechooserbuttonOutput.Filename==null) ? _folderSave : filechooserbuttonOutput.Filename;
        string file = entryDocumentName.Text;
       
        string abspath =  System.IO.Path.Combine(path, file);
        FileInfo info = new FileInfo(abspath);
        
        int i = 1;
        
        while (info.Exists)
        {
            info = new FileInfo(System.IO.Path.Combine(path, file.Substring(0, (file.Length - info.Extension.Length)) + "-" + i.ToString()  + info.Extension));
            abspath = info.FullName;    
            i++;
        }
        
        return abspath;
    }
        

	private void CreatePDF()
	{
        buttonDoit.Sensitive = false;
        string path = (filechooserbuttonOutput.Filename==null) ? _folderSave : filechooserbuttonOutput.Filename;
        string file = entryDocumentName.Text;
        string _File =  System.IO.Path.Combine(path, file);
        
        if ((new FileInfo(_File)).Exists)
        {
			string msg1 = Catalog.GetString("A document with the name \"{0}\" exists already.");
			string msg2 = Catalog.GetString("Do you wan't to replace this document?");
			
           MessageDialog md = new MessageDialog (this, 
                                      DialogFlags.DestroyWithParent,
                                      MessageType.Question, 
                                      ButtonsType.OkCancel,
			                          String.Format (msg1 + "\n" + msg2, file));
			                                      
            ResponseType result = (ResponseType)md.Run ();
            md.Destroy();
            
            if (result == ResponseType.Cancel)
            {
                buttonDoit.Sensitive = true;
                FileInfo info = new FileInfo(entryDocumentName.Text);
                entryDocumentName.SelectRegion(0, (info.Name.Length - info.Extension.Length));
                return;
            }
        }
        
		try
		{
			List<String> files = new List<String>();
			foreach (CouturierFile f in this.GetFiles())
			{
				files.Add(f.FullName);
			}
			
			PDFCreator.Instance.CreatePDF(files, _File);
			
			if (File.Exists(_File))
			{
                this.entryDocumentName.Text = new FileInfo(_File).Name;
                
				if (! String.IsNullOrEmpty(entryPassword.Text))
				{
					PDFUtils.Instance.EncryptPDF(_File, entryPassword.Text);
				}
				
				this.Title = "Couturier - " + new FileInfo(_File).Name;
				
				System.Diagnostics.Process proc = new System.Diagnostics.Process();
				proc.EnableRaisingEvents = false;		
				
				proc.StartInfo.FileName = "gnome-open";
				proc.StartInfo.Arguments = "\"" + _File + "\"";
				proc.Start();
				proc.WaitForExit();
			}
		}
		catch (Exception err)
		{
			 string msg1 = Catalog.GetString("Could not create PDF Document.");
			 string msg2 = Catalog.GetString("The following error occurred:");
			 string msg3 = Catalog.GetString("Please check your settings and try again.");
			
             MessageDialog md = new MessageDialog (this,
                                      DialogFlags.DestroyWithParent,
                                      MessageType.Error, 
                                      ButtonsType.Ok, 
			                          String.Format(msg1 + "\n\n" + msg2 + "\n{0}\n\n" + msg3, err.Message));
    
            md.Run ();
            md.Destroy();
            
			System.Console.WriteLine(err.Message + "\n" + err.StackTrace);		
		}
        finally
        {
            buttonDoit.Sensitive = true;
        }
	}
	
	private List<CouturierFile> GetFiles ()
	{
		List<CouturierFile> files = new List<CouturierFile>();
		
		TreeIter iter;
		DocumentStore.GetIterFirst(out iter);
		CouturierFile current = null;
		
		
		if (DocumentStore.IterIsValid(iter))
		{
			current =  (DocumentStore.GetValue(iter, 2)) as CouturierFile;
			if (current != null)
				files.Add(current);
			
			
			while (DocumentStore.IterNext(ref iter))
			{
				current =  (DocumentStore.GetValue(iter, 2)) as CouturierFile;
				if (current != null)
					files.Add(current);
			}
		}
		
		return files;
	}
	
	private void UpdateNumberOfPages ()
	{
		int sumNrOfPages = 0;
		
		foreach (CouturierFile f in GetFiles())
		{
			sumNrOfPages += f.NumberOfPages;
		}
		
		if (sumNrOfPages == 0)
		{
			this.labelPages.Text = Catalog.GetString("No pages");
		}
		else
		{
			string pageString = (sumNrOfPages > 1) ? Catalog.GetString("Pages") : Catalog.GetString("Page");
			
			this.labelPages.Text = String.Format("{0} {1}", sumNrOfPages.ToString(), pageString);
		}
	}

	
#endregion

	protected virtual void OnReportABugActionActivated (object sender, System.EventArgs e)
	{
		string url = "https://bugs.launchpad.net/couturier/+filebug/+login";
		
		System.Diagnostics.Process proc = new System.Diagnostics.Process();
		proc.EnableRaisingEvents = false;		
				
		proc.StartInfo.FileName = "gnome-open";
		proc.StartInfo.Arguments = url;
		proc.Start();
		proc.WaitForExit();	
	}

	protected virtual void OnWebActionActivated (object sender, System.EventArgs e)
	{
		string url = "http://sites.google.com/site/couturierapp/";
		
		System.Diagnostics.Process proc = new System.Diagnostics.Process();
		proc.EnableRaisingEvents = false;		
				
		proc.StartInfo.FileName = "gnome-open";
		proc.StartInfo.Arguments = url;
		proc.Start();
		proc.WaitForExit();	
	}

	protected virtual void OnDonateActionActivated (object sender, System.EventArgs e)
	{
	
	}

	protected virtual void OnBeendenActionActivated (object sender, System.EventArgs e)
	{
		Gtk.Main.Quit();
	}

	protected virtual void OnNeuActionActivated (object sender, System.EventArgs e)
	{
        MessageDialog md = new MessageDialog (this, 
                          DialogFlags.DestroyWithParent,
                          MessageType.Question, 
                          ButtonsType.OkCancel, 
		                  Catalog.GetString("If you continue, all changes will be lost"));

        ResponseType result = (ResponseType)md.Run ();
        md.Destroy();
        
        if (result == ResponseType.Ok)
            this.LoadDefaults ();
	}

	protected virtual void OnCouturierLoveAction1Activated (object sender, System.EventArgs e)
	{
		string url = "http://www.gtk-apps.org/content/donate.php?content=102837";
		
		System.Diagnostics.Process proc = new System.Diagnostics.Process();
		proc.EnableRaisingEvents = false;		
				
		proc.StartInfo.FileName = "gnome-open";
		proc.StartInfo.Arguments = url;
		proc.Start();
		proc.WaitForExit();	
	}

	protected virtual void OnHilfeActionActivated (object sender, System.EventArgs e)
	{
		string url = "https://answers.launchpad.net/couturier";
		
		System.Diagnostics.Process proc = new System.Diagnostics.Process();
		proc.EnableRaisingEvents = false;		
				
		proc.StartInfo.FileName = "gnome-open";
		proc.StartInfo.Arguments = url;
		proc.Start();
		proc.WaitForExit();	
	}

    protected virtual void OnCheckbuttonPasswordToggled (object sender, System.EventArgs e)
    {
        entryPassword.Visibility = checkbuttonPassword.Active;
    }

    protected virtual void OnEntryDocumentNameChanged (object sender, System.EventArgs e)
    {
          CheckReadyness();
    }

    protected virtual void OnTreeviewDocumentsDragDataGet (object o, Gtk.DragDataGetArgs args)
    {
    }

    protected virtual void OnTreeviewDocumentsDragBegin (object o, Gtk.DragBeginArgs args)
    {
        //Gtk.Drag.SetIconPixbuf (args.Context, pixbbuf_selected_row, 0, 0); //TODO: 
    }

    protected virtual void OnButtonClearAllClicked (object sender, System.EventArgs e)
    {
		ClearDocumentList();
	}

    protected virtual void OnAboutActionActivated (object sender, System.EventArgs e)
    {
		AboutDialog about = new Gtk.AboutDialog();
		
		about.Version = "0.5";
		about.License =  Catalog.GetString("Licensed under the terms of GPLv3");
		about.License += "\nhttp://www.gnu.org/licenses/gpl-3.0.html";
		
		about.Copyright += Catalog.GetString("(c) 2009 by Couturier contributors");
		about.Copyright += "\n";
		about.Copyright += Catalog.GetString("(c) 1999-2009 by itextsharp.sourceforge.net");
		
		about.TranslatorCredits += "Charalampos Emmanouilidis <C.Emmanouilidis@yahoo.de>\n";
		about.TranslatorCredits += "Emmanuel <info@simple-linux.com>\n";
		about.TranslatorCredits += "Kleomenis Katevas <Minos.Tmp@gmail.com>\n";

		about.Artists = new String[] { "Charalampos Emmanouilidis <C.Emmanouilidis@yahoo.de>" };
		about.Authors = new String[] { "Charalampos Emmanouilidis <C.Emmanouilidis@yahoo.de>" };
		about.Website = "http://sites.google.com/site/couturierapp/";
		
		about.Run();
		about.Destroy();
    }
}
