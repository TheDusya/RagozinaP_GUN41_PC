namespace Task
{
    internal class TwoSidedNode
    {
        public int Value;
        public TwoSidedNode Next = null;
        public TwoSidedNode Prev = null;

        public TwoSidedNode(int value) 
        { 
            Value = value;
        }

        public void AddLast(TwoSidedNode otherNode)
        {
            if (Next == null)
            {
                this.Next = otherNode;
                otherNode.Prev = this;
            }
            else 
                Next.AddLast(otherNode);
        }

        public void Print()
        {
            Console.Write(Value + " ");
            if (Next != null) 
                Next.Print();
            else 
                Console.WriteLine();
        }

        public void PrintBackwards()
        {
            Console.Write(Value + " ");
            if (Prev != null) 
                Prev.PrintBackwards();
            else 
                Console.WriteLine();
        }
    }
}
