using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace uwpApp1
{

    public class AdvancedButton : Button
    {
        public static readonly DependencyProperty IconContentProperty =
          DependencyProperty.Register("Icon", typeof(string), typeof(AdvancedButton), new PropertyMetadata(default(FontIcon)));

        public string Icon
        {
            get { return (string)GetValue(IconContentProperty); }
            set { SetValue(IconContentProperty, value); }
        }
    }

    public class MyTreeView : TreeView
    {

        public FolderInfo SelectedItem
        {
            get { return (FolderInfo)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(FolderInfo), typeof(MyTreeView), new PropertyMetadata(null, changedItemCallback));


        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SlectedIndexProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(MyTreeView), new PropertyMetadata(0, changedIndexCallback));

        private static void changedIndexCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var a = d as MyTreeView;

            if (a != null)
            {
                TreeViewList tvL = a.GetTemplateChild("ListControl") as TreeViewList;

                if (tvL != null)
                {
                    tvL.SelectedIndex = (int)e.NewValue;//

                    //FolderInfo b = e.NewValue as FolderInfo;
                    //int count = 0;
                    //foreach (FolderInfo obj in tvL.Items)
                    //{
                    //    if (obj.FolderName == b.FolderName)
                    //    {
                    //        tvL.SelectedIndex = e.NewValue;// count;
                    //        break;
                    //    }
                    //    count++;
                    //}

                    //tvL.SelectedItem = b;
                }
            }
        }

        private static void changedItemCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var a = d as MyTreeView;

            if(a!=null)
            {
                TreeViewList tvL = a.GetTemplateChild("ListControl") as TreeViewList;

                if (tvL != null)
                {
                    FolderInfo b = e.NewValue as FolderInfo;
                    tvL.SelectedItem = b;

                        //int count = 0;
                    //foreach(FolderInfo obj in tvL.Items)
                    //{
                    //    if(obj.FolderName == b.FolderName)
                    //    {
                    //        tvL.SelectedIndex = count;
                    //        break;
                    //    }
                    //    count++;
                    //}

                    //tvL.SelectedItem = b;
                }
            }
        }

        TreeViewList treeViewList;
        public MyTreeView()
        {
            //this.Loaded += MyTreeView_Loaded;
            //this.SizeChanged += MyTreeView_SizeChanged;
            //this.ItemInvoked += MyTreeView_ItemInvoked;

            this.DragItemsStarting += MyTreeView_DragItemsStarting;
            this.DragItemsCompleted += MyTreeView_DragItemsCompleted;
            this.DragEnter += MyTreeView_DragEnter;
            //this.DragLeave += MyTreeView_DragLeave;
            //this.Drop += MyTreeView_Drop;
            //this.DragOver += MyTreeView_DragOver;
            //this.DragStarting += MyTreeView_DragStarting;

            
            

            
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
        }

        private void TvL_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {

            }
        }

        private void MyTreeView_DragStarting(UIElement sender, DragStartingEventArgs args)
        {
            if (args.OriginalSource != null)
            {

            }
        }

        private void MyTreeView_DragOver(object sender, DragEventArgs e)
        {
            if(e.Data!=null)
            {

            }
        }

        private void MyTreeView_Drop(object sender, DragEventArgs e)
        {
            if(e.Data!=null)
            {

            }
        }

        private void MyTreeView_DragLeave(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {

            }
        }

        private void MyTreeView_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data!=null)
            {

            }
        }

        private void MyTreeView_DragItemsCompleted(TreeView sender, TreeViewDragItemsCompletedEventArgs args)
        {
            if (args.Items.Count > 0)
            {

                foreach (var item in args.Items)
                {
                    FolderInfo inf = item as FolderInfo;

                        var tem = item as TreeViewNode;
                        //var parent = tem.Parent;//tem is null


                    if (inf != null)
                    {
                        Debug.WriteLine(inf.FolderName);
                        //args.DropResult = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;

                    }


                }
                
            }
        }

        private void MyTreeView_DragItemsStarting(TreeView sender, TreeViewDragItemsStartingEventArgs args)
        {
            if(args.Items.Count > 0)
            {
                if (args.Items.Count > 0)
                {
                    foreach (var item in args.Items)
                    {
                        FolderInfo inf = item as FolderInfo;

                        if (inf != null)
                        {
                            Debug.WriteLine(inf.FolderName);
                        }


                    }

                }
            }
        }

        private void MyTreeView_ItemInvoked(TreeView sender, TreeViewItemInvokedEventArgs args)
        {
            if (args.InvokedItem is FolderInfo)
            {
                this.SetValue(SelectedItemProperty, args.InvokedItem);
            }

            
            //TreeViewList tvL = sender.GetTemplateChild("ListControl") as TreeViewList;

            //if (tvL != null)
            //{ }

            //this.SetValue(SelectedIndexProperty, ((TreeViewList)sender).SelectedIndex);

        }

        private void MyTreeView_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            //hrow new NotImplementedException();
            if (treeViewList != null)
            {
                if (treeViewList.Items.Count > 0)
                {
                    treeViewList.SelectedIndex = 0;
                }
            }
        }

        private void MyTreeView_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        //protected override void OnApplyTemplate()
        //{
        //    base.OnApplyTemplate();
        //    treeViewList = this.GetTemplateChild("ListControl") as TreeViewList;

        //    //if (treeViewList != null)
        //    //{
        //    //    treeViewList.DragOver += TvL_DragOver;
        //    //    treeViewList.DragEnter += TreeViewList_DragEnter;
        //    //}

        //}

        private void TreeViewList_DragEnter(object sender, DragEventArgs e)
        {
            
        }
    }
}
