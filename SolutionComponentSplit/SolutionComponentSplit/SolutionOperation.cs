using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Windows;
using static SolutionComponentSplit.Model.OptionSets;

namespace SolutionComponentSplit
{
    public class SolutionOperation
    {
        private IOrganizationService _serviceProxy = null;

        public SolutionOperation(CrmServiceClient service)
        {
            this._serviceProxy = service;
        }

        public Guid RetrieveSolution(string solutionUniqueName)
        {
            Entity solution = null;
            // Retrieve a solution
            QueryExpression querySampleSolution = new QueryExpression
            {
                EntityName = Solution.EntityLogicalName,
                ColumnSet = new ColumnSet(new string[] { "uniquename", "publisherid", "installedon", "version", "versionnumber", "friendlyname" }),
                Criteria = new FilterExpression()
            };

            querySampleSolution.Criteria.AddCondition("uniquename", ConditionOperator.Equal, solutionUniqueName);
            EntityCollection result = _serviceProxy.RetrieveMultiple(querySampleSolution);
            if (result != null && result.Entities.Count > 0)
            {
                solution = result.Entities.FirstOrDefault();
                if (solution.Id != null && solution.Id != Guid.Empty)
                {
                    return solution.Id;
                }
            }
            else
            {
                MessageBox.Show($"The solution :{solutionUniqueName} does not exist", "Error");
            }
            return Guid.Empty;
        }

        public List<Entity> GetSolutionComponets(Guid primarySolutionId)
        {
            List<Entity> solutionComponents = new List<Entity>();
            ////Get All Components in Solution
            QueryByAttribute componentQuery = new QueryByAttribute
            {
                EntityName = SolutionComponent.EntityLogicalName,
                ColumnSet = new ColumnSet("componenttype", "objectid", "solutioncomponentid", "solutionid"),
                Attributes = { "solutionid" },

                // In your code, this value would probably come from another query.
                Values = { primarySolutionId }
            };

            EntityCollection allComponents = _serviceProxy.RetrieveMultiple(componentQuery);
            if (allComponents != null && allComponents.Entities.Count > 0)
            {
                foreach (Entity component in allComponents.Entities)
                {
                    solutionComponents.Add(component);
                    Console.WriteLine($"objectId:{component.GetAttributeValue<Guid>("objectid")} | ComponentType:{GetEnumNameByKey(component.GetAttributeValue<OptionSetValue>("componenttype").Value)} | ComponentId:{component.Id} ");
                }
            }
            return solutionComponents;
        }

        public void AddSolutionComponet(int componetType, Guid componentId, string solutionUniqueName)
        {
            // Add an existing Solution Component

            AddSolutionComponentRequest addReq = new AddSolutionComponentRequest()
            {
                ComponentType = componetType,
                ComponentId = componentId,
                SolutionUniqueName = solutionUniqueName,
                AddRequiredComponents = false
            };
            if (componetType == (int)componenttype.Entity)
            {
                addReq.DoNotIncludeSubcomponents = true;
            }
            _serviceProxy.Execute(addReq);
        }

        public string GetEnumNameByKey(int key)
        {
            return Enum.GetName(typeof(componenttype), key);
        }
    }
}
