using Planner.Models.EventsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Data;

namespace Planner.Services
{
    public class DeploymentService : SubItemService<Deployment>
    {
        public DeploymentService(ApplicationDbContext database) : base(database)
        {
        }

        public override void AddItem(Event ev, Deployment item)
        {
            ev.Deployments.Add(item);
        }
    }
}