namespace EntityFrameworkTests.SqlQueries {
    using EntityFramework.SqlQueries;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MyDbContextTest {
        private readonly MyDbContext myDbContext;

        public MyDbContextTest() {
            myDbContext = new MyDbContextFactory().CreateDbContext();
            myDbContext.Database.EnsureCreated();
        }

        [Fact]
        public void FromSqlQuery() {
            int id = 1;

            var g = myDbContext.Orders.ToQueryString();

            var where = "Id IN (2,4)";

            string query = $"{g} WHERE {where}";

            var o = myDbContext.Orders.FromSqlRaw(query)
                .ToList();
        }
    }
}
