using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MiniProjectAStar
{
    internal class Node
    {
        // Change this depending on what the desired size is for each element in the grid
        public Node Parent;
        public Vector2 Position;
        public float DistanceToTarget;      // H
        public float Cost;                  // G
        public float Weight;
        public float F
        {
            get
            {
                if (DistanceToTarget != -1 && Cost != -1)
                    return DistanceToTarget + Cost;
                else
                    return -1;
            }
        }
        public bool Walkable;

        public Node(Vector2 pos, bool walkable, float weight = 1)
        {
            Parent = null;
            Position = pos;
            DistanceToTarget = -1;
            Cost = 1;
            Weight = weight;
            Walkable = walkable;
        }
    }
}
