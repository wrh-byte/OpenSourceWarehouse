using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using SolutionComponentSplit.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

namespace SolutionComponentSplit
{
    public partial class MyPluginControl : PluginControlBase
    {
        private Settings mySettings;

        private List<SolutionComponent> solutionComponentList;

        private SolutionOperation solutionHelper;

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));
            solutionHelper = new SolutionOperation((Microsoft.Xrm.Tooling.Connector.CrmServiceClient)Service);
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbRetrieve_Click(object sender, EventArgs e)
        {
            ExecuteMethod(RetrieveComponent);
        }

        private void RetrieveComponent()
        {
            //Retrieve Component In Solution
            if (string.IsNullOrEmpty(SolutionNameText.Text))
            {
                MessageBox.Show("Please give the solution name", "Error");
                return;
            }

            Guid primarySolutionId = solutionHelper.RetrieveSolution(SolutionNameText.Text);
            solutionComponentList = solutionHelper.GetSolutionComponets(primarySolutionId).OrderBy(c => c.ComponentType.Value).ToList();
            TotalCount.Text = "TotalCount:" + solutionComponentList.Count;

            //Get Component Type
            var componentList = solutionComponentList.Select(c => c.ComponentType.Value).Distinct();

            //Add solution 1 componet list
            foreach (var item in componentList)
            {
                if (!S1ComponentList.Items.Contains((componenttype)item))
                {
                    S1ComponentList.Items.Add((componenttype)item);
                    S2ComponentList.Items.Add((componenttype)item);
                }
            }

            //Add Component To List View
            List<ComponentView> componentDataGridViewList = new List<ComponentView>();
            foreach (SolutionComponent item in solutionComponentList)
            {
                componentDataGridViewList.Add(new ComponentView() { CompnetType = ((componenttype)(item.ComponentType.Value)).ToString(), ObjctId = item.ObjectId.ToString() });
            }
            if(componentDataGridViewList!=null&& componentDataGridViewList.Count > 0)
            {
                this.ComponentGridView.DataSource = new BindingList<ComponentView>(componentDataGridViewList);
            }
        }

        private void GetAccounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void SplitBtn_Click(object sender, EventArgs e)
        {
            if (solutionComponentList == null)
            {
                MessageBox.Show("Please Retrieve Solution First", "Error");
                return;
            }

            if (string.IsNullOrEmpty(Solution1Text.Text) && string.IsNullOrEmpty(Solution2Text.Text))
            {
                MessageBox.Show("Please add at least one solution name");
                return;
            }

            var solution1ContainSetting = S1ComponentList.SelectedItems;
            var solution2ContainSetting = S2ComponentList.SelectedItems;

            //Add Component In Solution 1
            foreach (SolutionComponent item in solutionComponentList)
            {
                if (solution1ContainSetting.Contains((componenttype)item.ComponentType.Value))
                {
                    solutionHelper.AddSolutionComponet(item.ComponentType.Value, (Guid)item.ObjectId, Solution1Text.Text);
                }

                if (solution2ContainSetting.Contains((componenttype)item.ComponentType.Value))
                {
                    solutionHelper.AddSolutionComponet(item.ComponentType.Value, (Guid)item.ObjectId, Solution2Text.Text);
                }
            }

            MessageBox.Show("Success");
        }
    }
}