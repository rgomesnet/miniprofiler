using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProfilerSample
{
    public interface IRepository
    {
        Task<IEnumerable<Order>> List();
    }

    public class Repository : IRepository
    {
        private readonly DbConnection dBConnection;

        private readonly string query = @"select orderid
                                                ,custid
                                                ,empid
                                                ,orderdate
                                                ,requireddate
                                                ,shippeddate
                                                ,shipperid
                                                ,freight
                                                ,shipname
                                                ,shipaddress
                                                ,shipcity
                                                ,shipregion
                                                ,shippostalcode
                                                ,shipcountry
                                          from sales.Orders";

        public Repository(DbConnection dBConnection)
        {
            this.dBConnection = dBConnection;
        }

        public async Task<IEnumerable<Order>> List()
        {
            return await this.dBConnection.QueryAsync<Order>(query);
        }
    }

    public class Order
    {
        public int orderid { get; set; }
        public int? custid { get; set; }
        public int empid { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime? shippeddate { get; set; }
        public int shipperid { get; set; }
        public decimal freight { get; set; }
        public string shipname { get; set; }
        public string shipaddress { get; set; }
        public string shipcity { get; set; }
        public string shipregion { get; set; }
        public string shippostalcode { get; set; }
        public string shipcountry { get; set; }
    }
}
