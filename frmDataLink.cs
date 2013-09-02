using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrayUsage
{
    public partial class frmDataLink : Form
    {

        private TrayIcon TargetIcon = null;

        public frmDataLink(TrayIcon aTargetIcon)
        {
            InitializeComponent();
            TargetIcon = aTargetIcon;
            PopulateSourceDataTree();
            PopulateTargetDataList();
            this.Icon = Properties.Resources.tray;
        }

        private void PopulateSourceDataTree()
        {
            clsDataManager.DataListItem[] tempList = Program.DataManager.GetDataNodesList();
            for (Int32 i = 0; i <= tempList.GetUpperBound(0); i++)
            {
                TreeNode tempNode1 = new TreeNode(tempList[i].Name);
                for (Int32 j = 0; j <= tempList[i].DataNodeName.GetUpperBound(0); j++)
                {
                    TreeNode tempNode2 = new TreeNode(tempList[i].DataNodeName[j]);
                    tempNode2.Tag = "Source";
                    tempNode1.Nodes.Add(tempNode2);
                }
                treeDataSources.Nodes.Add(tempNode1);
            }
            treeDataSources.ExpandAll();
        }

        private void PopulateTargetDataList()
        {
            listDataTarget.Items.Clear();
            if (TargetIcon.TargetData != null)
            {
                for (Int32 i = 0; i <= TargetIcon.TargetData.GetUpperBound(0); i++)
                {
                    if (TargetIcon.TargetData[i].DataIndex >= 0 && TargetIcon.TargetData[i].DataIndex <= TargetIcon.TargetData[i].DataClassRef.CurrentValue.Length - 1)
                    {
                        
                        listDataTarget.Items.Add(TargetIcon.TargetData[i].DataClassRef.DataName + " " +
                            TargetIcon.TargetData[i].DataClassRef.DataLabels[TargetIcon.TargetData[i].DataIndex]);
                    }
                    else
                    { listDataTarget.Items.Add(TargetIcon.TargetData[i].DataClassRef.DataName + " Out of range"); }
                }
            }
        }

        private void treeDataSources_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null) { return; }
            if (e.Node.Tag.ToString() == "Source")
            {
                AddDataSource(e.Node.Parent.Text,e.Node.Text);
            }
        }

        private void AddDataSource(string DataText,string DataLabelText)
        {
            DataLink tempLink = new DataLink();
            tempLink.DataClassRef = Program.DataManager.GetDataClassRef(DataText);
            for (Int32 i = 0; i <= tempLink.DataClassRef.DataLabels.GetUpperBound(0); i++)
            {
                if (tempLink.DataClassRef.DataLabels[i] == DataLabelText)
                {
                    tempLink.DataIndex = i;

                    break;
                }
            }
            TargetIcon.AddDataSource(tempLink);
            PopulateTargetDataList();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (treeDataSources.SelectedNode.Tag == null) { return; }
            if (treeDataSources.SelectedNode.Tag.ToString() == "Source")
            {
                AddDataSource(treeDataSources.SelectedNode.Parent.Text, treeDataSources.SelectedNode.Text);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listDataTarget.SelectedIndex == -1) { return; }
            TargetIcon.RemoveDataSource(listDataTarget.SelectedIndex);
            PopulateTargetDataList();
        }
    }
}
