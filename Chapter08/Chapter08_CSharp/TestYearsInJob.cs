namespace Chapter08_CSharp
{
    class TestYearsInJob : IClientTest
    {
        public bool Test(Client client)
        {
            // Body of the concrete test
            return client.YearsInJob < 2;
        }
    }
}