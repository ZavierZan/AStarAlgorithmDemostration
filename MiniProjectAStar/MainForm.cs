using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProjectAStar
{
    public partial class MainForm : Form
    {
        private const int GridSize = 25; // 25x25 grid
        private const int NodeSize = 20; // Size of each button 20x20
        private List<Node> grid;
        private Node startNode;
        private Node endNode;
        private PathFinding pathFinding;
        private Button[,] buttons; // 2D array to store buttons representing grid cells

        public MainForm()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            grid = new List<Node>();
            buttons = new Button[GridSize, GridSize];

            // Create the grid of buttons
            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    var button = new Button
                    {
                        Size = new System.Drawing.Size(NodeSize, NodeSize),
                        Location = new System.Drawing.Point(x * NodeSize, y * NodeSize),
                        Tag = new Node(new Vector2(x, y), true)         // Initialize each button with a walkable node
                    };
                    button.Click += Button_Click;       // Attach the click event handler
                    buttons[x, y] = button;
                    Controls.Add(button);
                    grid.Add((Node)button.Tag);         // Add node to the grid list
                }
            }
            pathFinding = new PathFinding(null, null, grid);        // Initialize pathfinding with the grid
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Node clickedNode = (Node)clickedButton.Tag;

            // Set start or end node based on user interaction
            if (clickedNode == endNode)
            {
                // If the clicked node is the end node, remove it
                endNode = null;
                clickedButton.BackColor = System.Drawing.Color.White; // Reset to default color
            }

            else if (clickedNode == startNode)
            {
                // If the clicked node is the start node, remove it
                startNode = null;
                clickedButton.BackColor = System.Drawing.Color.White; // Reset to default color
            }

            else if (startNode == null)
            {
                startNode = clickedNode;
                clickedButton.BackColor = System.Drawing.Color.Green; // Start node color
            }
            else if (endNode == null)
            {
                endNode = clickedNode;
                clickedButton.BackColor = System.Drawing.Color.Red; // End node color
            }
            else
            {
                // Toggle walkable status
                clickedNode.Walkable = !clickedNode.Walkable;
                clickedButton.BackColor = clickedNode.Walkable ? System.Drawing.Color.White : System.Drawing.Color.Black;
            }
        }

        private void FindAndDisplayPath()
        {
            // Find the path if both start and end nodes are defined
            if (startNode != null && endNode != null)
            {
                List<Node> path = pathFinding.FindPath();

                ResetButtonColors();         // Reset all button colors

                // If a path is found, display it
                foreach (var node in path)
                {
                    Button button = buttons[(int)node.Position.X, (int)node.Position.Y];

                    if (node != startNode && node != endNode)
                    {
                        button.BackColor = System.Drawing.Color.Blue;   // Path color
                    }
                }
            }
        }

        private void ResetButtonColors()
        {
            // Reset all button colors to default (white)
            foreach (var button in buttons)
            {
                Node node = (Node)button.Tag;
                if (node.Walkable)
                {
                    button.BackColor = System.Drawing.Color.White; // Walkable nodes
                }
                else
                {
                    button.BackColor = System.Drawing.Color.Black; // Blocked nodes
                }

                // Maintain the start and end colors
                if (node == startNode)
                    button.BackColor = System.Drawing.Color.Green; // Start node color
                if (node == endNode)
                    button.BackColor = System.Drawing.Color.Red; // End node color
            }
        }

        private void btnFindPath_Click(object sender, EventArgs e)
        {
            if (startNode == null || endNode == null)
            {
                MessageBox.Show("Please select a start and end node before finding the path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update the pathfinding instance
            pathFinding = new PathFinding(startNode, endNode, grid);

            pathFinding.OnNodeProcessed = (Node node) =>
            {
                Button button = buttons[(int)node.Position.X, (int)node.Position.Y];

                if (node != startNode && node != endNode)
                {
                    button.BackColor = System.Drawing.Color.Yellow;     // Mark processed node
                    Application.DoEvents();         // Update UI immediately
                }
            };

            List<Node> path = pathFinding.FindPath();
            FindAndDisplayPath();       // Recalculate and display the path

            // Calculate the travel distance (cost) if a path is found
            if (path.Count > 0)
            {
                float travelDistance = path.Sum(node => node.Weight);           // Sum up weights of nodes in the path
                lblTravelDis.Text = $"Travel Distance: {travelDistance}";       // Display the distance
            }
            else
            {
                lblTravelDis.Text = "No path found.";       // Handle case where no path exists
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear the start and end nodes
            startNode = null;
            endNode = null;

            // Reset all nodes in the grid
            foreach (var button in buttons)
            {
                Node node = (Node)button.Tag;
                node.Walkable = true;       
                node.Cost = float.MaxValue; 
                node.DistanceToTarget = 0;  
                node.Parent = null;         

                button.BackColor = System.Drawing.Color.White;
            }
        }

        private void btnRdmMaze_Click(object sender, EventArgs e)
        {
            // Make random node unwalkable (35%)
            Random rdn = new Random();
            foreach (var button in buttons)
            {
                Node node = (Node)button.Tag;
                if (node != startNode && node != endNode)
                {
                    int num = rdn.Next(0, 100);
                    if (num < 65)
                    {
                        node.Walkable = true;
                        button.BackColor = System.Drawing.Color.White;
                    }

                    else
                    {
                        node.Walkable = false;
                        button.BackColor = System.Drawing.Color.Black;
                    }
                }
            }
        }
    }
}