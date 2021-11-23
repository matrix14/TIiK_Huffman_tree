using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIiK_Huffman_tree
{
    public static class HuffmanAlgorithm
    {
        public class Node
        {
            public string character = null;
            public float propability = 0;
            public Node rightNode = null;
            public Node leftNode = null;

            public Node(float propability = 0, string character = null)
            {
                this.character = character;
                this.propability = propability;
            }

            public Node(Node node)
            {
                this.character = node.character;
                this.propability = node.propability;
            }

            public void addNode(Node addedNode)
            {
                if (this.leftNode == null)
                {
                    this.leftNode = addedNode;
                }
                else if (this.rightNode == null)
                {
                    this.rightNode = addedNode;
                }
                else
                {
                    throw new Exception("Nodes already occupied");
                }

                this.propability += addedNode.propability;
            }
        }

        private static List<Node> findTwoSmallestPropabilities(List<Node> trees)
        {
            Node smallest = new Node(2);
            Node secSmallest = new Node(2);

            foreach (Node e in trees)
            {
                if (smallest.propability > e.propability)
                {
                    secSmallest = smallest;
                    smallest = e;
                }
                else if (secSmallest.propability > e.propability)
                {
                    secSmallest = e;
                }
            }

            return new List<Node> { smallest, secSmallest };
        }

        public static Node buildHuffmansTree(List<Node> nodes)
        {
            List<Node> nodesCopy = new List<Node>();

            foreach (Node e in nodes)
            {
                nodesCopy.Add(new Node(e));
            }

            return buildHuffmansTreeIteration(nodesCopy)[0];
        }

        private static List<Node> buildHuffmansTreeIteration(List<Node> trees)
        {
            Node newTree = new Node();

            List<Node> smallersNodes = findTwoSmallestPropabilities(trees);
            newTree.addNode(smallersNodes[0]);
            newTree.addNode(smallersNodes[1]);
            trees.Remove(smallersNodes[0]);
            trees.Remove(smallersNodes[1]);
            trees.Add(newTree);

            if (trees.Count == 1)
            {
                return trees;
            }
            else
            {
                return buildHuffmansTreeIteration(trees);
            }
        }

        public static Dictionary<string, string> codeDFS(Node node, string actualCode, Dictionary<string, string> letters)
        {
            if ((node.leftNode == null) && (node.rightNode == null))
            {
                letters.Add(node.character, actualCode);
            }
            else
            {
                if (node.leftNode.propability > node.rightNode.propability)
                {
                    codeDFS(node.leftNode, actualCode + "1", letters);
                    codeDFS(node.rightNode, actualCode + "0", letters);
                }
                else
                {
                    codeDFS(node.leftNode, actualCode + "0", letters);
                    codeDFS(node.rightNode, actualCode + "1", letters);
                }
            }

            return letters;
        }



    }
}
