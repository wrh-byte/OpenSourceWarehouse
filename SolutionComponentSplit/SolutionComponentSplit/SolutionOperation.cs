using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            // Retrieve a solution
            QueryExpression querySampleSolution = new QueryExpression
            {
                EntityName = Solution.EntityLogicalName,
                ColumnSet = new ColumnSet(new string[] { "uniquename", "publisherid", "installedon", "version", "versionnumber", "friendlyname" }),
                Criteria = new FilterExpression()
            };

            querySampleSolution.Criteria.AddCondition("uniquename", ConditionOperator.Equal, solutionUniqueName);
            Solution solution = (Solution)_serviceProxy.RetrieveMultiple(querySampleSolution).Entities[0];
            if (solution.Id != null && solution.Id != Guid.Empty)
            {
                return solution.Id;
            }
            else
            {
                return Guid.Empty;
            }
        }

        public List<SolutionComponent> GetSolutionComponets(Guid primarySolutionId)
        {
            List<SolutionComponent> solutionComponents = new List<SolutionComponent>();
            ////Get All Components in Solution
            QueryByAttribute componentQuery = new QueryByAttribute
            {
                EntityName = SolutionComponent.EntityLogicalName,
                ColumnSet = new ColumnSet("componenttype", "objectid", "solutioncomponentid", "solutionid"),
                Attributes = { "solutionid" },

                // In your code, this value would probably come from another query.
                Values = { primarySolutionId }
            };

            IEnumerable<SolutionComponent> allComponents = _serviceProxy.RetrieveMultiple(componentQuery).Entities.Cast<SolutionComponent>();

            foreach (SolutionComponent component in allComponents)
            {
                solutionComponents.Add(component);
                Console.WriteLine($"objectId:{component.ObjectId} | ComponentType:{GetEnumNameByKey(component.ComponentType.Value)} | ComponentId:{component.Id} ");
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
