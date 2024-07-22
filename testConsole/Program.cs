using Exchange.Business;
using Exchange.Common;
using Exchange.Data;
using Exchange.Data.Models;
using Exchange.Data.Repository;

namespace testConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
          var cusRepo = new CustomerRepository();
            Customer customer = cusRepo.GetCustomerByEmailAndPass("tran.thi.b@example.com", "password123");
            if (customer == null)
            {
                Console.WriteLine("ko thay");
            }
            else {
                Console.WriteLine("thay");
            }
        }
    }
}
