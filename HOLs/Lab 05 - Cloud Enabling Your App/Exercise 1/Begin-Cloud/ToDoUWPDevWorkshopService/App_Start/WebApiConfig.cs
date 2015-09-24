using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;
using ToDoUWPDevWorkshopService.DataObjects;
using ToDoUWPDevWorkshopService.Models;

namespace ToDoUWPDevWorkshopService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            HttpConfiguration config = new HttpConfiguration();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            Database.SetInitializer(new ToDoUWPDevWorkshopInitializer());
        }
    }

    public class ToDoUWPDevWorkshopInitializer : ClearDatabaseSchemaIfModelChanges<ToDoUWPDevWorkshopContext>
    {
        protected override void Seed(ToDoUWPDevWorkshopContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

