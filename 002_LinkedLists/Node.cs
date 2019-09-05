﻿namespace _002_LinkedLists
{
    public class Node
    {
        public int Data { get; private set; }

        public Node Next { get; set; } = null;

        public Node(int data)
        {
            Data = data;
        }
    }
}
