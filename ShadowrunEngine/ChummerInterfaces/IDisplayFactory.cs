using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chummer
{
    public interface ITreeNode
    {
        string Name { get; set; }
        string Text { get; set; }
        object Tag { get; set; }
        IContextMenuStrip ContextMenuStrip { get; set; }
        string ToolTipText { get; set; }


        void Expand();
        List<ITreeNode> Nodes { get; }
        ITreeView TreeView { get; }
    }

    public interface ITreeView
    {
        List<ITreeNode> Nodes { get; }
    }

    public interface IListViewItem
    {
        string Text { get; }
        List<IListViewItem> SubItems { get; }
    }

    public interface IContextMenuStrip
    {

    }

    public interface IDisplayFactory
    {
        ITreeNode CreateTreeNode();
    }
}
