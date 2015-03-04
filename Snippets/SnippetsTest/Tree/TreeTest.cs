using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;

namespace SnippetsTest.Tree
{
    [TestFixture]
    public class TreeTest
    {
        private static TreeNode BuildTree()
        {
            var un = new TreeNode { Value = 1 };
            var deux = new TreeNode { Value = 2 };
            var trois = new TreeNode { Value = 3 };
            var quatre = new TreeNode { Value = 4 };
            var cinq = new TreeNode { Value = 5 };

            deux.Left = un;
            deux.Right = quatre;
            quatre.Left = trois;
            quatre.Right = cinq;

            return deux;
        }      

        [Test]
        public void DisplayPreOrderRecursif()
        {
            Action<TreeNode> func = null;
            func = (TreeNode node) =>
                {
                    if (node == null)
                        return;
                    Debug.Write(node.Value + " ");
                    func(node.Left);
                    func(node.Right);
                };

            func(BuildTree()); // 2 1 4 3 5
        }

        [Test]
        public void DisplayPreOrderIteratif()
        {
            Action<TreeNode> func = null;
            func = (TreeNode node) =>
            {
                Stack<TreeNode> nextNodes = new Stack<TreeNode>();
                while (node != null || nextNodes.Any())
                {
                    if (node != null)
                    {
                        Debug.Write(node.Value + " ");
                        if (node.Right != null)
                            nextNodes.Push(node.Right);

                        node = node.Left;
                    }
                    else
                    {
                        node = nextNodes.Pop();
                    }
                }
            };

            func(BuildTree()); // 2 1 4 3 5
        }

        [Test]
        public void DisplayInOrderRecursif()
        {
            Action<TreeNode> func = null;
            func = (TreeNode node) =>
            {
                if (node == null)
                    return;
                
                func(node.Left);
                Debug.Write(node.Value + " ");
                func(node.Right);
            };

            func(BuildTree()); // 1 2 3 4 5
        }

        [Test]
        public void DisplayInOrderIteratif()
        {
            Action<TreeNode> func = null;
            func = (TreeNode node) =>
            {
                Stack<TreeNode> nextNodes = new Stack<TreeNode>();
                while (node != null || nextNodes.Any())
                {
                    if (node != null)
                    {
                        nextNodes.Push(node);
                        node = node.Left;
                    }
                    else
                    {
                        node = nextNodes.Pop();
                        Debug.Write(node.Value + " ");
                        node = node.Right;
                    }
                }
            };

            func(BuildTree()); // 1 2 3 4 5
        }

        [Test]
        public void MaxDepthRecursive()
        {
            Func<TreeNode, int> func = null;
            func = (TreeNode node) =>
            {
                if (node == null)
                    return 0;

                return(Math.Max(func(node.Left) + 1, func(node.Right) + 1));
            };

            Assert.AreEqual(3, func(BuildTree()));
        }

        [Test]
        public void MaxDepthIterative()
        {
            Func<TreeNode, int> func = null;
            // The idea is to go level by level
            // At each level, we increment the depth by one
            func = (TreeNode node) =>
            {
                Stack<TreeNode> nextNodes = new Stack<TreeNode>();
                int depth = 0;

                if (node != null)
                    nextNodes.Push(node); // 1st level

                while (true)
                {
                    var nodeCount = nextNodes.Count;
                    if(nodeCount == 0) // no deeper level
                        return depth;
                    else
                        ++depth;

                    while (nodeCount > 0) // Remove current level and add next level (childs)
                    {
                        var iNode = nextNodes.Pop();
                        if (iNode.Left != null)
                            nextNodes.Push(iNode.Left);
                        if (iNode.Right != null)
                            nextNodes.Push(iNode.Right);
                        --nodeCount;
                    }
                }
            };

            Assert.AreEqual(3, func(BuildTree()));
        }
    }
}
