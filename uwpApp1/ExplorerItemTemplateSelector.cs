using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace uwpApp1
{
    public class ExplorerItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FolderTemplate { get; set; }
        public DataTemplate FileTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            var explorerItem = (FolderInfo)item;
            if (explorerItem.IsFolder == true) return FolderTemplate;

            return FileTemplate;
        }
    }

    public class ExplorerItemTemplateSelectorX : DataTemplateSelector
    {
        public DataTemplate FolderTemplateX { get; set; }
        public DataTemplate FileTemplateX { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            var explorerItem = (FolderInfo)item;
            if (explorerItem.IsFolder == true) return FolderTemplateX;

            return FileTemplateX;
        }

    }
}
