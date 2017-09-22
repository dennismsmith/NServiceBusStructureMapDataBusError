using StructureMap;

namespace NServiceBusStructureMapDataBusError
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint
    {
	    public void Customize(EndpointConfiguration endpointConfiguration)
        {
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendFailedMessagesTo("error");
	        endpointConfiguration.UseDataBus<FileShareDataBus>().BasePath(@"c:\temp\");
	        endpointConfiguration.UseContainer<StructureMapBuilder>(c => c.ExistingContainer(new Container().CreateChildContainer()));
        }
    }
}
