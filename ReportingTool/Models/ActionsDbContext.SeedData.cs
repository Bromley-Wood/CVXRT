using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportingTool.Models
{
    public static class ActionsDbContextSeedData
    {
        static object synchlock = new object();
        static volatile bool seeded = false;

        public static void EnsureSeedData(this ActionsDbContext context)
        {
            if (!seeded && context.Actions.Count() == 0)
            {
                lock (synchlock)
                {
                    if (!seeded)
                    {
                        var actions = GenerateActions();
                        context.Actions.AddRange(actions);
                        context.SaveChanges();
                        seeded = true;
                    }
                }
            }
        }

        public static Action[] GenerateActions()
        {
            return new Action[] {
                new Action {
                    Id = 9999,
                    Description = "Hello",
                    FaultTypeId = 8888,
                    IsActive = true,
                    Order = 7777,
                },
            };
        }
    }
}

