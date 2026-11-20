using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectAStar
{
    internal class PathFinding
    {
        private List<Node> openList;    // store unprocessed node
        private List<Node> closedList;  // store processed node
        private Node startNode;
        private Node endNode;
        private List<Node> grid;        // store all nodes in the grid
        public Action<Node> OnNodeProcessed;

        public PathFinding(Node start, Node end, List<Node> grid)
        {
            this.startNode = start;
            this.endNode = end;
            this.grid = grid;
            openList = new List<Node>();
            closedList = new List<Node>();
        }

        public List<Node> FindPath()
        {
            openList.Add(startNode);

            while (openList.Count > 0)
            {
                Node currentNode = openList.OrderBy(node => node.F).First();        // Get the node with the lowest F value

                OnNodeProcessed?.Invoke(currentNode);           // Notify the UI that this node is being processed

                // If reached the target node, reconstruct the path
                if (currentNode == endNode)
                {
                    return ReconstructPath(currentNode);
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                // Get neighbors of the current node
                foreach (Node neighbor in GetNeighbors(currentNode))
                {
                    if (!neighbor.Walkable || closedList.Contains(neighbor))
                        continue;

                    float tentativeCost = currentNode.Cost + neighbor.Weight;       // Calculate the cost to reach this neighbor

                    // If neighbor is not in the open list or the new cost is lower, update its values
                    if (!openList.Contains(neighbor) || tentativeCost < neighbor.Cost)
                    {
                        neighbor.Parent = currentNode;
                        neighbor.Cost = tentativeCost;
                        neighbor.DistanceToTarget = Vector2.Distance(neighbor.Position, endNode.Position);

                        // If not in the open list, add it
                        if (!openList.Contains(neighbor))
                        {
                            openList.Add(neighbor);
                        }
                    }
                }
            }
            return new List<Node>();         // Return an empty list if no path is found
        }

        private List<Node> ReconstructPath(Node currentNode)
        {
            List<Node> path = new List<Node>();
            while (currentNode != null)
            {
                path.Add(currentNode);
                currentNode = currentNode.Parent;
            }
            path.Reverse();
            return path;
        }

        private List<Node> GetNeighbors(Node node)
        {
            List<Node> neighbors = new List<Node>();

            // Get the potential neighboring positions
            Vector2[] directions = {
                new Vector2(0, -1),     // Up
                new Vector2(0, 1),      // Down
                new Vector2(-1, 0),     // Left
                new Vector2(1, 0)       // Right
            };

            foreach (var direction in directions)
            {
                Vector2 neighborPosition = node.Position + direction;
                Node neighbor = grid.FirstOrDefault(n => n.Position == neighborPosition);

                if (neighbor != null)
                {
                    neighbors.Add(neighbor);
                }
            }
            return neighbors;
        }
    }
}