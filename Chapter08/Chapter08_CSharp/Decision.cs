namespace Chapter08_CSharp
{
    abstract class Decision
    {
        // Tests the given client 
        public abstract void Evaluate(Client client);
    }
}