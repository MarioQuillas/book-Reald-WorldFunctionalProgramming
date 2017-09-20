namespace Chapter08_CSharp
{
    using System;

    class DecisionResult : Decision
    {
        public bool Result { get; set; }

        public override void Evaluate(Client client)
        {
            // Print the final result
            Console.WriteLine("OFFER A LOAN: {0}", this.Result ? "YES" : "NO");
        }
    }
}