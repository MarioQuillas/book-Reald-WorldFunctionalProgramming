// --------------------------------------------------------------------------
// Functional Programming in .NET - Chapter 8
// --------------------------------------------------------------------------
namespace Chapter08_CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        // --------------------------------------------------------------------------
        // Section 8.1 Using collections of behaviors

        // Listing 8.1 Loan suitability tests using object oriented style

        // Each test is represented by a single class

        // Listing 8.2 Loan suitability tests using a list of functions
        static List<Func<Client, bool>> GetTests()
        {
            // Returns a list of tests
            // Create new list using collection initializer
            return new List<Func<Client, bool>>()
                       {
                           // Several test checking loan suitability
                           cl => cl.CriminalRecord == true,
                           cl => cl.Income < 30000,
                           cl => cl.UsesCreditCard == false,
                           cl => cl.YearsInJob < 2
                       };
        }

        // --------------------------------------------------------------------------
        // Entry-point: Select the example you're interested in
        private static void Main(string[] args)
        {
            // MainCollections();
            // MainCommand();
            MainDecisionTrees();
        }

        static void MainCollections()
        {
            // Create client using object initializer
            var john = new Client
                           {
                               Name = "John Doe",
                               Income = 40000,
                               YearsInJob = 1,
                               UsesCreditCard = true,
                               CriminalRecord = false
                           };

            // Offer a loan to the client?
            TestClient(GetTests(), john);
        }

        // --------------------------------------------------------------------------
        // Section 8.2.1 Command design pattern    

        // Listing 8.6 Income test using Command pattern 

        // Corresponds to the 'Receiver' class
        static void MainCommand()
        {
            // List of tests & sample client
            var tests = GetTests();
            var john = new Client
                           {
                               Name = "John Doe",
                               Income = 40000,
                               YearsInJob = 1,
                               UsesCreditCard = true,
                               CriminalRecord = false
                           };

            // Create 'Receiver' with the state
            IncomeTest incomeTst = new IncomeTest();

            // Create the 'Command' as a lambda function
            Func<Client, bool> command1 = (cl) => incomeTst.TestIncome(cl);

            // Add command to the list of tests ('Invoker')
            // tests.Add(command)

            // We don't have to create lambda function explicitly:
            tests.Add(incomeTst.TestIncome);

            // Run some tests..
            TestClient(tests, john);
            incomeTst.SetMinimalIncome(45000);
            TestClient(tests, john);
        }

        // --------------------------------------------------------------------------
        // Section 8.4.2 Decision trees in C#

        // Listing 8.15 Object oriented decision tree (C#)

        // Listing 8.16 Simplified implementation of Template method
        static void MainDecisionTrees()
        {
            // The tree is constructed from a query
            var tree = new DecisionQuery
                           {
                               Title = "More than $40k",

                               // Test is specified using a lambda function
                               Test = (client) => client.Income > 40000,

                               // Sub-trees can be 'DecisionResult' or 'DecisionQuery'
                               Positive = new DecisionResult { Result = true },
                               Negative = new DecisionResult { Result = false }
                           };

            // Test a client using this tree
            // Create client using object initializer
            var john = new Client
                           {
                               Name = "John Doe",
                               Income = 40000,
                               YearsInJob = 1,
                               UsesCreditCard = true,
                               CriminalRecord = false
                           };
            tree.Evaluate(john);
        }

        // --------------------------------------------------------------------------
        // Section 8.1.2 Executing behaviors in C#

        // Listing 8.3 Executing tests
        static void TestClient(List<Func<Client, bool>> tests, Client client)
        {
            // How many tests the client fails?
            int issuesCount = tests.Count(f => f(client));

            // Print the results of testing
            bool suitable = issuesCount <= 1;
            Console.WriteLine("Client: {0}\nOffer a loan: {1}", client.Name, suitable ? "YES" : "NO");
        }
    }
}