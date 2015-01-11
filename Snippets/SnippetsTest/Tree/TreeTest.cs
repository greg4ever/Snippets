using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace SnippetsTest.Tree
{
    [TestClass]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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
    }
}
