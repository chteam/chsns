namespace CHSNS.DataContext
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using CHSNS.Models;

    public class ContextInitializer : IDatabaseInitializer<SqlServerEntities>
    {

        public void InitializeDatabase(SqlServerEntities context)
        {

            if (context.Database.Exists())
            {

                if (context.Wikis.Count() == 0)
                {
                    var wiki = new Wiki()
                                   {
                                       CreatorId = 1,
                                       CreatedTime = DateTime.Now,
                                       Ext = "",
                                       IsTitleDisplay = true,
                                       Status = (int) WikiStatus.Common,
                                       Url = "index"
                                   };
                    context.Wikis.Add(wiki);
                    context.SaveChanges();
                    var version = new WikiVersion
                                      {
                                          WikiId = wiki.Id,
                                          AddTime = DateTime.Now,
                                          Description = "content",
                                          Ext = "",
                                          Reason = "",
                                          Reference = "",
                                          Status = (int) WikiVersionStatus.Common,
                                          Title = "index page",
                                          UserId = 1
                                      };
                    context.WikiVersions.Add(version);
                    context.SaveChanges();
                }

            }
            else
            {
            }

        }
    }


}