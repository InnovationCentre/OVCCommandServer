using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;
using OVCMobileService.DataObjects;
using OVCMobileService.Models;

namespace OVCMobileService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            HttpConfiguration config = new HttpConfiguration();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            Database.SetInitializer(new OVCMobileInitializer());
        }
    }

    public class OVCMobileInitializer : ClearDatabaseSchemaAlways<OVCMobileContext>
    {
        protected override void Seed(OVCMobileContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = "1243214", Text = "First item", Complete = false },
                new TodoItem { Id = "456789", Text = "Second item", Complete = false },
            };

            UnitType Type1 = new UnitType { Id = Guid.NewGuid().ToString(), Name = "Vacuum Cleaner robots" };
            UnitType Type2 = new UnitType { Id = Guid.NewGuid().ToString(), Name = "Inspection robots" };

            List<UnitType> unitTypes = new List<UnitType>
            {
               Type1, Type2,
            };


            Type1 = context.Set<UnitType>().Add(Type1);
            Type2 = context.Set<UnitType>().Add(Type1);



            List<Unit> units = new List<Unit>
            {
                new Unit { Id = Guid.NewGuid().ToString(), Serial = "vrc-001" , Name="Dev robot Erwin", Type=Type1},
                new Unit { Id = Guid.NewGuid().ToString(), Serial = "vrc-002" , Name="RC Robot", UnitTypeId=Type1.Id},
                new Unit { Id = Guid.NewGuid().ToString(), Serial = "drone-001" , Name="Drone Inspector", Type=Type2},
            };


            foreach (Unit unit in units)
            {
                context.Set<Unit>().Add(unit);
            }

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }
        

            base.Seed(context);
        }
    }
}

