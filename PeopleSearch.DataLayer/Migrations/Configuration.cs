namespace PeopleSearch.DataLayer.Migrations
{
    using Newtonsoft.Json;
    using Repository;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<PeopleSearch.DataLayer.EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PeopleSearch.DataLayer.EntityContext";
        }
    }
}
