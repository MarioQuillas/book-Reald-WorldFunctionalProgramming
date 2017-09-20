namespace Chapter08_CSharp
{
    class IncomeTest
    {
        // Encapsulated mutable state of the receiver
        int minimalIncome;

        public IncomeTest()
        {
            this.minimalIncome = 30000;
        }

        // Modifies the mutable state
        public void SetMinimalIncome(int income)
        {
            this.minimalIncome = income;
        }

        // Operation used by the 'Command'
        public bool TestIncome(Client client)
        {
            return client.Income < this.minimalIncome;
        }
    }
}