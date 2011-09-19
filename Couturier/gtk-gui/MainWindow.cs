// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------



public partial class MainWindow {
    
    private Gtk.UIManager UIManager;
    
    private Gtk.Action DocumentAction;
    
    private Gtk.Action HelpAction;
    
    private Gtk.Action DocumentAction1;
    
    private Gtk.Action HelpAction3;
    
    private Gtk.Action HelpAction2;
    
    private Gtk.Action CouturierAction;
    
    private Gtk.Action ReportABugAction;
    
    private Gtk.Action NewAction;
    
    private Gtk.Action QuitAction;
    
    private Gtk.Action ILoveCouturierAction;
    
    private Gtk.Action EditAction;
    
    private Gtk.Action AddDocumentAction;
    
    private Gtk.Action RemoveDocumentAction;
    
    private Gtk.Action AboutAction;
    
    private Gtk.VBox vbox1;
    
    private Gtk.MenuBar menubar1;
    
    private Gtk.Statusbar statusbar1;
    
    private Gtk.VBox vbox2;
    
    private Gtk.Frame frame1;
    
    private Gtk.Alignment GtkAlignment;
    
    private Gtk.HBox hbox1;
    
    private Gtk.VBox vbox3;
    
    private Gtk.Image imageDocument;
    
    private Gtk.Label labelPages;
    
    private Gtk.Table table1;
    
    private Gtk.CheckButton checkbuttonPassword;
    
    private Gtk.Entry entryDocumentName;
    
    private Gtk.Entry entryPassword;
    
    private Gtk.FileChooserButton filechooserbuttonOutput;
    
    private Gtk.Label label3;
    
    private Gtk.Label label4;
    
    private Gtk.Label label5;
    
    private Gtk.Label GtkLabel5;
    
    private Gtk.Label labelHintAddDocuments;
    
    private Gtk.ScrolledWindow GtkScrolledWindow;
    
    private Gtk.TreeView treeviewDocuments;
    
    private Gtk.HBox hbox2;
    
    private Gtk.HBox hbox3;
    
    private Gtk.Button buttonAdd;
    
    private Gtk.Image imageAddDocument;
    
    private Gtk.Button buttonRemove;
    
    private Gtk.Image imageRemoveDocument;
    
    private Gtk.Button buttonClearAll;
    
    private Gtk.Image imageClearList;
    
    private Gtk.Button buttonDoit;
    
    protected virtual void Build() {
        Stetic.Gui.Initialize(this);
        // Widget MainWindow
        this.UIManager = new Gtk.UIManager();
        Gtk.ActionGroup w1 = new Gtk.ActionGroup("Default");
        this.DocumentAction = new Gtk.Action("DocumentAction", Mono.Unix.Catalog.GetString("Document"), null, null);
        this.DocumentAction.ShortLabel = Mono.Unix.Catalog.GetString("Document");
        w1.Add(this.DocumentAction, null);
        this.HelpAction = new Gtk.Action("HelpAction", Mono.Unix.Catalog.GetString("Help"), null, null);
        this.HelpAction.ShortLabel = Mono.Unix.Catalog.GetString("Help");
        w1.Add(this.HelpAction, null);
        this.DocumentAction1 = new Gtk.Action("DocumentAction1", Mono.Unix.Catalog.GetString("Document"), null, null);
        this.DocumentAction1.ShortLabel = Mono.Unix.Catalog.GetString("Document");
        w1.Add(this.DocumentAction1, null);
        this.HelpAction3 = new Gtk.Action("HelpAction3", Mono.Unix.Catalog.GetString("Help"), null, null);
        this.HelpAction3.ShortLabel = Mono.Unix.Catalog.GetString("Help");
        w1.Add(this.HelpAction3, null);
        this.HelpAction2 = new Gtk.Action("HelpAction2", Mono.Unix.Catalog.GetString("_Help"), null, "gtk-help");
        this.HelpAction2.ShortLabel = Mono.Unix.Catalog.GetString("_Help");
        w1.Add(this.HelpAction2, "F1");
        this.CouturierAction = new Gtk.Action("CouturierAction", Mono.Unix.Catalog.GetString("_Couturier"), null, "Web");
        this.CouturierAction.ShortLabel = Mono.Unix.Catalog.GetString("Donate");
        w1.Add(this.CouturierAction, null);
        this.ReportABugAction = new Gtk.Action("ReportABugAction", Mono.Unix.Catalog.GetString("_Report a bug"), null, "Call");
        this.ReportABugAction.ShortLabel = Mono.Unix.Catalog.GetString("_Report a bug");
        w1.Add(this.ReportABugAction, null);
        this.NewAction = new Gtk.Action("NewAction", Mono.Unix.Catalog.GetString("_New"), null, "gtk-new");
        this.NewAction.ShortLabel = Mono.Unix.Catalog.GetString("_New");
        w1.Add(this.NewAction, null);
        this.QuitAction = new Gtk.Action("QuitAction", Mono.Unix.Catalog.GetString("_Quit"), null, "gtk-quit");
        this.QuitAction.ShortLabel = Mono.Unix.Catalog.GetString("_Quit");
        w1.Add(this.QuitAction, null);
        this.ILoveCouturierAction = new Gtk.Action("ILoveCouturierAction", Mono.Unix.Catalog.GetString("I _Love Couturier"), null, "Favorite");
        this.ILoveCouturierAction.ShortLabel = Mono.Unix.Catalog.GetString("_Couturier Love");
        w1.Add(this.ILoveCouturierAction, null);
        this.EditAction = new Gtk.Action("EditAction", Mono.Unix.Catalog.GetString("Edit"), null, null);
        this.EditAction.ShortLabel = Mono.Unix.Catalog.GetString("Edit");
        w1.Add(this.EditAction, null);
        this.AddDocumentAction = new Gtk.Action("AddDocumentAction", Mono.Unix.Catalog.GetString("_Add Document"), null, "gtk-add");
        this.AddDocumentAction.ShortLabel = Mono.Unix.Catalog.GetString("_Add Document");
        w1.Add(this.AddDocumentAction, null);
        this.RemoveDocumentAction = new Gtk.Action("RemoveDocumentAction", Mono.Unix.Catalog.GetString("_Remove Document"), null, "gtk-delete");
        this.RemoveDocumentAction.ShortLabel = Mono.Unix.Catalog.GetString("_Remove Document");
        w1.Add(this.RemoveDocumentAction, null);
        this.AboutAction = new Gtk.Action("AboutAction", Mono.Unix.Catalog.GetString("_About"), null, "gtk-about");
        this.AboutAction.ShortLabel = Mono.Unix.Catalog.GetString("_About");
        w1.Add(this.AboutAction, null);
        this.UIManager.InsertActionGroup(w1, 0);
        this.AddAccelGroup(this.UIManager.AccelGroup);
        this.Name = "MainWindow";
        this.Title = Mono.Unix.Catalog.GetString("Couturier - New Document");
        this.WindowPosition = ((Gtk.WindowPosition)(1));
        // Container child MainWindow.Gtk.Container+ContainerChild
        this.vbox1 = new Gtk.VBox();
        this.vbox1.Name = "vbox1";
        this.vbox1.Spacing = 6;
        // Container child vbox1.Gtk.Box+BoxChild
        this.UIManager.AddUiFromString("<ui><menubar name='menubar1'><menu name='DocumentAction1' action='DocumentAction1'><menuitem name='NewAction' action='NewAction'/><menuitem name='QuitAction' action='QuitAction'/></menu><menu name='HelpAction3' action='HelpAction3'><menuitem name='HelpAction2' action='HelpAction2'/><menuitem name='ReportABugAction' action='ReportABugAction'/><menuitem name='CouturierAction' action='CouturierAction'/><menuitem name='ILoveCouturierAction' action='ILoveCouturierAction'/><menuitem name='AboutAction' action='AboutAction'/></menu></menubar></ui>");
        this.menubar1 = ((Gtk.MenuBar)(this.UIManager.GetWidget("/menubar1")));
        this.menubar1.Name = "menubar1";
        this.vbox1.Add(this.menubar1);
        Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox1[this.menubar1]));
        w2.Position = 0;
        w2.Expand = false;
        w2.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.statusbar1 = new Gtk.Statusbar();
        this.statusbar1.Name = "statusbar1";
        this.statusbar1.Spacing = 6;
        this.vbox1.Add(this.statusbar1);
        Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox1[this.statusbar1]));
        w3.PackType = ((Gtk.PackType)(1));
        w3.Position = 1;
        w3.Expand = false;
        w3.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.vbox2 = new Gtk.VBox();
        this.vbox2.Name = "vbox2";
        this.vbox2.Spacing = 6;
        this.vbox2.BorderWidth = ((uint)(6));
        // Container child vbox2.Gtk.Box+BoxChild
        this.frame1 = new Gtk.Frame();
        this.frame1.Name = "frame1";
        this.frame1.ShadowType = ((Gtk.ShadowType)(0));
        this.frame1.BorderWidth = ((uint)(5));
        // Container child frame1.Gtk.Container+ContainerChild
        this.GtkAlignment = new Gtk.Alignment(0F, 0F, 1F, 1F);
        this.GtkAlignment.Name = "GtkAlignment";
        this.GtkAlignment.LeftPadding = ((uint)(12));
        // Container child GtkAlignment.Gtk.Container+ContainerChild
        this.hbox1 = new Gtk.HBox();
        this.hbox1.Name = "hbox1";
        this.hbox1.Spacing = 6;
        this.hbox1.BorderWidth = ((uint)(10));
        // Container child hbox1.Gtk.Box+BoxChild
        this.vbox3 = new Gtk.VBox();
        this.vbox3.Name = "vbox3";
        this.vbox3.Spacing = 6;
        // Container child vbox3.Gtk.Box+BoxChild
        this.imageDocument = new Gtk.Image();
        this.imageDocument.WidthRequest = 130;
        this.imageDocument.HeightRequest = 130;
        this.imageDocument.Sensitive = false;
        this.imageDocument.Name = "imageDocument";
        this.imageDocument.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gnome-pdf", Gtk.IconSize.Dialog, 48);
        this.vbox3.Add(this.imageDocument);
        Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox3[this.imageDocument]));
        w4.Position = 0;
        w4.Expand = false;
        w4.Fill = false;
        // Container child vbox3.Gtk.Box+BoxChild
        this.labelPages = new Gtk.Label();
        this.labelPages.Name = "labelPages";
        this.labelPages.LabelProp = Mono.Unix.Catalog.GetString("No Pages");
        this.labelPages.UseMarkup = true;
        this.vbox3.Add(this.labelPages);
        Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox3[this.labelPages]));
        w5.Position = 1;
        w5.Expand = false;
        w5.Fill = false;
        this.hbox1.Add(this.vbox3);
        Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbox3]));
        w6.Position = 0;
        w6.Expand = false;
        w6.Fill = false;
        // Container child hbox1.Gtk.Box+BoxChild
        this.table1 = new Gtk.Table(((uint)(4)), ((uint)(2)), false);
        this.table1.Name = "table1";
        this.table1.RowSpacing = ((uint)(6));
        this.table1.ColumnSpacing = ((uint)(6));
        // Container child table1.Gtk.Table+TableChild
        this.checkbuttonPassword = new Gtk.CheckButton();
        this.checkbuttonPassword.CanFocus = true;
        this.checkbuttonPassword.Name = "checkbuttonPassword";
        this.checkbuttonPassword.Label = Mono.Unix.Catalog.GetString("Show Password");
        this.checkbuttonPassword.DrawIndicator = true;
        this.checkbuttonPassword.UseUnderline = true;
        this.table1.Add(this.checkbuttonPassword);
        Gtk.Table.TableChild w7 = ((Gtk.Table.TableChild)(this.table1[this.checkbuttonPassword]));
        w7.TopAttach = ((uint)(2));
        w7.BottomAttach = ((uint)(3));
        w7.LeftAttach = ((uint)(1));
        w7.RightAttach = ((uint)(2));
        w7.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.entryDocumentName = new Gtk.Entry();
        this.entryDocumentName.CanFocus = true;
        this.entryDocumentName.Name = "entryDocumentName";
        this.entryDocumentName.Text = Mono.Unix.Catalog.GetString("Document All.pdf");
        this.entryDocumentName.IsEditable = true;
        this.entryDocumentName.InvisibleChar = '●';
        this.table1.Add(this.entryDocumentName);
        Gtk.Table.TableChild w8 = ((Gtk.Table.TableChild)(this.table1[this.entryDocumentName]));
        w8.LeftAttach = ((uint)(1));
        w8.RightAttach = ((uint)(2));
        w8.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.entryPassword = new Gtk.Entry();
        this.entryPassword.CanFocus = true;
        this.entryPassword.Name = "entryPassword";
        this.entryPassword.IsEditable = true;
        this.entryPassword.Visibility = false;
        this.entryPassword.InvisibleChar = '●';
        this.table1.Add(this.entryPassword);
        Gtk.Table.TableChild w9 = ((Gtk.Table.TableChild)(this.table1[this.entryPassword]));
        w9.TopAttach = ((uint)(1));
        w9.BottomAttach = ((uint)(2));
        w9.LeftAttach = ((uint)(1));
        w9.RightAttach = ((uint)(2));
        w9.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.filechooserbuttonOutput = new Gtk.FileChooserButton(Mono.Unix.Catalog.GetString("Select directory"), ((Gtk.FileChooserAction)(2)));
        this.filechooserbuttonOutput.Name = "filechooserbuttonOutput";
        this.filechooserbuttonOutput.LocalOnly = false;
        this.table1.Add(this.filechooserbuttonOutput);
        Gtk.Table.TableChild w10 = ((Gtk.Table.TableChild)(this.table1[this.filechooserbuttonOutput]));
        w10.TopAttach = ((uint)(3));
        w10.BottomAttach = ((uint)(4));
        w10.LeftAttach = ((uint)(1));
        w10.RightAttach = ((uint)(2));
        w10.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.label3 = new Gtk.Label();
        this.label3.Name = "label3";
        this.label3.Xalign = 0F;
        this.label3.LabelProp = Mono.Unix.Catalog.GetString("Name:");
        this.table1.Add(this.label3);
        Gtk.Table.TableChild w11 = ((Gtk.Table.TableChild)(this.table1[this.label3]));
        w11.XOptions = ((Gtk.AttachOptions)(4));
        w11.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.label4 = new Gtk.Label();
        this.label4.Name = "label4";
        this.label4.Xalign = 0F;
        this.label4.LabelProp = Mono.Unix.Catalog.GetString("Save in directory:");
        this.table1.Add(this.label4);
        Gtk.Table.TableChild w12 = ((Gtk.Table.TableChild)(this.table1[this.label4]));
        w12.TopAttach = ((uint)(3));
        w12.BottomAttach = ((uint)(4));
        w12.XOptions = ((Gtk.AttachOptions)(4));
        w12.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.label5 = new Gtk.Label();
        this.label5.Name = "label5";
        this.label5.Xalign = 0F;
        this.label5.LabelProp = Mono.Unix.Catalog.GetString("Password:");
        this.table1.Add(this.label5);
        Gtk.Table.TableChild w13 = ((Gtk.Table.TableChild)(this.table1[this.label5]));
        w13.TopAttach = ((uint)(1));
        w13.BottomAttach = ((uint)(2));
        w13.XOptions = ((Gtk.AttachOptions)(4));
        w13.YOptions = ((Gtk.AttachOptions)(4));
        this.hbox1.Add(this.table1);
        Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.hbox1[this.table1]));
        w14.PackType = ((Gtk.PackType)(1));
        w14.Position = 1;
        w14.Fill = false;
        this.GtkAlignment.Add(this.hbox1);
        this.frame1.Add(this.GtkAlignment);
        this.GtkLabel5 = new Gtk.Label();
        this.GtkLabel5.Name = "GtkLabel5";
        this.GtkLabel5.LabelProp = Mono.Unix.Catalog.GetString("<b>Document Summary</b>");
        this.GtkLabel5.UseMarkup = true;
        this.frame1.LabelWidget = this.GtkLabel5;
        this.vbox2.Add(this.frame1);
        Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.vbox2[this.frame1]));
        w17.Position = 0;
        w17.Expand = false;
        w17.Fill = false;
        // Container child vbox2.Gtk.Box+BoxChild
        this.labelHintAddDocuments = new Gtk.Label();
        this.labelHintAddDocuments.Name = "labelHintAddDocuments";
        this.labelHintAddDocuments.LabelProp = Mono.Unix.Catalog.GetString("<b>Add your documents to the list below.</b>");
        this.labelHintAddDocuments.UseMarkup = true;
        this.vbox2.Add(this.labelHintAddDocuments);
        Gtk.Box.BoxChild w18 = ((Gtk.Box.BoxChild)(this.vbox2[this.labelHintAddDocuments]));
        w18.Position = 1;
        w18.Expand = false;
        w18.Fill = false;
        w18.Padding = ((uint)(8));
        // Container child vbox2.Gtk.Box+BoxChild
        this.GtkScrolledWindow = new Gtk.ScrolledWindow();
        this.GtkScrolledWindow.Name = "GtkScrolledWindow";
        this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
        // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
        this.treeviewDocuments = new Gtk.TreeView();
        this.treeviewDocuments.CanFocus = true;
        this.treeviewDocuments.Name = "treeviewDocuments";
        this.treeviewDocuments.EnableSearch = false;
        this.treeviewDocuments.Reorderable = true;
        this.GtkScrolledWindow.Add(this.treeviewDocuments);
        this.vbox2.Add(this.GtkScrolledWindow);
        Gtk.Box.BoxChild w20 = ((Gtk.Box.BoxChild)(this.vbox2[this.GtkScrolledWindow]));
        w20.Position = 2;
        // Container child vbox2.Gtk.Box+BoxChild
        this.hbox2 = new Gtk.HBox();
        this.hbox2.Name = "hbox2";
        this.hbox2.Spacing = 6;
        this.hbox2.BorderWidth = ((uint)(6));
        // Container child hbox2.Gtk.Box+BoxChild
        this.hbox3 = new Gtk.HBox();
        this.hbox3.Name = "hbox3";
        this.hbox3.Homogeneous = true;
        this.hbox3.Spacing = -1;
        // Container child hbox3.Gtk.Box+BoxChild
        this.buttonAdd = new Gtk.Button();
        this.buttonAdd.CanFocus = true;
        this.buttonAdd.Name = "buttonAdd";
        // Container child buttonAdd.Gtk.Container+ContainerChild
        this.imageAddDocument = new Gtk.Image();
        this.imageAddDocument.Name = "imageAddDocument";
        this.imageAddDocument.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-add", Gtk.IconSize.SmallToolbar, 18);
        this.buttonAdd.Add(this.imageAddDocument);
        this.buttonAdd.Label = null;
        this.hbox3.Add(this.buttonAdd);
        Gtk.Box.BoxChild w22 = ((Gtk.Box.BoxChild)(this.hbox3[this.buttonAdd]));
        w22.Position = 0;
        w22.Expand = false;
        w22.Fill = false;
        // Container child hbox3.Gtk.Box+BoxChild
        this.buttonRemove = new Gtk.Button();
        this.buttonRemove.CanFocus = true;
        this.buttonRemove.Name = "buttonRemove";
        // Container child buttonRemove.Gtk.Container+ContainerChild
        this.imageRemoveDocument = new Gtk.Image();
        this.imageRemoveDocument.Name = "imageRemoveDocument";
        this.imageRemoveDocument.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-remove", Gtk.IconSize.SmallToolbar, 18);
        this.buttonRemove.Add(this.imageRemoveDocument);
        this.buttonRemove.Label = null;
        this.hbox3.Add(this.buttonRemove);
        Gtk.Box.BoxChild w24 = ((Gtk.Box.BoxChild)(this.hbox3[this.buttonRemove]));
        w24.Position = 1;
        w24.Expand = false;
        w24.Fill = false;
        this.hbox2.Add(this.hbox3);
        Gtk.Box.BoxChild w25 = ((Gtk.Box.BoxChild)(this.hbox2[this.hbox3]));
        w25.Position = 0;
        w25.Expand = false;
        w25.Fill = false;
        // Container child hbox2.Gtk.Box+BoxChild
        this.buttonClearAll = new Gtk.Button();
        this.buttonClearAll.TooltipMarkup = "Clear list";
        this.buttonClearAll.CanFocus = true;
        this.buttonClearAll.Name = "buttonClearAll";
        // Container child buttonClearAll.Gtk.Container+ContainerChild
        this.imageClearList = new Gtk.Image();
        this.imageClearList.Name = "imageClearList";
        this.imageClearList.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-clear", Gtk.IconSize.SmallToolbar, 18);
        this.buttonClearAll.Add(this.imageClearList);
        this.buttonClearAll.Label = null;
        this.hbox2.Add(this.buttonClearAll);
        Gtk.Box.BoxChild w27 = ((Gtk.Box.BoxChild)(this.hbox2[this.buttonClearAll]));
        w27.Position = 1;
        w27.Expand = false;
        w27.Fill = false;
        // Container child hbox2.Gtk.Box+BoxChild
        this.buttonDoit = new Gtk.Button();
        this.buttonDoit.CanFocus = true;
        this.buttonDoit.Name = "buttonDoit";
        this.buttonDoit.UseUnderline = true;
        this.buttonDoit.Label = Mono.Unix.Catalog.GetString("Combine");
        this.hbox2.Add(this.buttonDoit);
        Gtk.Box.BoxChild w28 = ((Gtk.Box.BoxChild)(this.hbox2[this.buttonDoit]));
        w28.PackType = ((Gtk.PackType)(1));
        w28.Position = 2;
        w28.Expand = false;
        w28.Fill = false;
        this.vbox2.Add(this.hbox2);
        Gtk.Box.BoxChild w29 = ((Gtk.Box.BoxChild)(this.vbox2[this.hbox2]));
        w29.PackType = ((Gtk.PackType)(1));
        w29.Position = 3;
        w29.Expand = false;
        w29.Fill = false;
        this.vbox1.Add(this.vbox2);
        Gtk.Box.BoxChild w30 = ((Gtk.Box.BoxChild)(this.vbox1[this.vbox2]));
        w30.PackType = ((Gtk.PackType)(1));
        w30.Position = 2;
        this.Add(this.vbox1);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 483;
        this.DefaultHeight = 604;
        this.Show();
        this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
        this.HelpAction2.Activated += new System.EventHandler(this.OnHilfeActionActivated);
        this.CouturierAction.Activated += new System.EventHandler(this.OnWebActionActivated);
        this.ReportABugAction.Activated += new System.EventHandler(this.OnReportABugActionActivated);
        this.NewAction.Activated += new System.EventHandler(this.OnNeuActionActivated);
        this.QuitAction.Activated += new System.EventHandler(this.OnBeendenActionActivated);
        this.ILoveCouturierAction.Activated += new System.EventHandler(this.OnCouturierLoveAction1Activated);
        this.AboutAction.Activated += new System.EventHandler(this.OnAboutActionActivated);
        this.entryDocumentName.Changed += new System.EventHandler(this.OnEntryDocumentNameChanged);
        this.checkbuttonPassword.Toggled += new System.EventHandler(this.OnCheckbuttonPasswordToggled);
        this.treeviewDocuments.DragDataReceived += new Gtk.DragDataReceivedHandler(this.OnTreeviewDocumentsDragDataReceived);
        this.treeviewDocuments.DragDataGet += new Gtk.DragDataGetHandler(this.OnTreeviewDocumentsDragDataGet);
        this.treeviewDocuments.DragBegin += new Gtk.DragBeginHandler(this.OnTreeviewDocumentsDragBegin);
        this.buttonAdd.Clicked += new System.EventHandler(this.OnButtonAddClicked);
        this.buttonRemove.Clicked += new System.EventHandler(this.OnButtonRemoveClicked);
        this.buttonClearAll.Clicked += new System.EventHandler(this.OnButtonClearAllClicked);
        this.buttonDoit.Clicked += new System.EventHandler(this.OnButtonDoitClicked);
    }
}