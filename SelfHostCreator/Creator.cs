using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfToDoService;
using WcfToDoService.Repositories;

namespace SelfHostCreator
{
    public class Creator
    {
        private static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/toDoService");

            IRepository repository = new WcfRepository();
            IWcfProxyService service = new WcfProxyService(repository);

            using (ServiceHost host = new ServiceHost(service, baseAddress))
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true,
                    MetadataExporter = {PolicyVersion = PolicyVersion.Policy15}
                };
                host.Description.Behaviors.Add(smb);

                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
