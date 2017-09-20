namespace Chapter08_CSharp
{
    using System;

    class DecisionQuery : Decision
    {
        public Decision Negative { get; set; }

        public Decision Positive { get; set; }

        // Primitive operation to be provided by the user
        public Func<Client, bool> Test { get; set; }

        public string Title { get; set; }

        public override void Evaluate(Client client)
        {
            // Test a client using the primitive operation
            bool res = this.Test(client);
            Console.WriteLine("  - {0}? {1}", this.Title, res ? "yes" : "no");

            // Select a branch to follow
            if (res) this.Positive.Evaluate(client);
            else this.Negative.Evaluate(client);
        }
    }
}