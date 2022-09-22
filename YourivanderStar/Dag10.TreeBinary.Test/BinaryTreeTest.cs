using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dag10.TreeBinary.Test;

[TestClass]
public class BinaryTreeTest
{
    [TestMethod]
    public void Depth_is0_OnEmptyTree()
    {
        BinaryTree<int> tree = BinaryTree<int>.Empty();

        int depth = tree.Depth();

        Assert.AreEqual(0, depth);
    }
    
    [TestMethod]
    public void Count_is0_OnEmptyTree()
    {
        BinaryTree<int> tree = BinaryTree<int>.Empty();

        int count = tree.Count();

        Assert.AreEqual(0, count);
    }
    

    [TestMethod]
    public void Add_Int8ToEmptyTree_DepthIs1()
    {
        BinaryTree<int> tree = BinaryTree<int>.Empty();

        BinaryTree<int> resultTree = tree.Add(8);

        Assert.AreEqual(1, resultTree.Depth());
    }
    
    [TestMethod]
    public void Add_TwoLayersToEmptyTree_DepthIs2()
    {
        BinaryTree<int> tree = BinaryTree<int>.Empty();

        BinaryTree<int> resultTree = tree.Add(1).Add(2);

        Assert.AreEqual(2, resultTree.Depth());
    }
    
    [TestMethod]
    public void Add_TwoLayersToEmptyTree_CountIs2()
    {
        BinaryTree<int> tree = BinaryTree<int>.Empty();

        BinaryTree<int> resultTree = tree.Add(1).Add(2);

        Assert.AreEqual(2, resultTree.Count());
    }
    
    [TestMethod]
    public void Add_GreaterItemToRight_LeftIsEmpty()
    {
        BinaryTree<int> sut = BinaryTree<int>.Empty().Add(1).Add(2);
        
        BinaryTree<int> leftArm = ((Branch<int>)sut).Left;
        
        Assert.IsTrue(leftArm is Empty<int>);
    }
    
    [TestMethod]
    public void Add_ThreeLevelsToRight_DepthAndCountAreCorrect()
    {
        BinaryTree<int> sut = BinaryTree<int>.Empty().Add(1).Add(2).Add(3);

        Assert.AreEqual(3, sut.Depth());
        Assert.AreEqual(3, sut.Count());
    }
    
    [TestMethod]
    public void Add_DuplicateValue_DepthAndCountAreCorrect()
    {
        BinaryTree<int> sut = BinaryTree<int>.Empty().Add(1).Add(1);

        Assert.AreEqual(1, sut.Depth());
        Assert.AreEqual(1, sut.Count());
    }
    
    [TestMethod]
    public void Contains_ValueOnEmptyTree_isFalse()
    {
        BinaryTree<int> sut = BinaryTree<int>.Empty();

        bool result = sut.Contains(1);
        
        Assert.AreEqual(false, result);
    }
    
    [TestMethod]
    public void Contains_ValueThreeLevelsDeep_isTrue()
    {
        BinaryTree<int> sut = BinaryTree<int>.Empty().Add(1).Add(2).Add(3);

        bool result = sut.Contains(3);
        
        Assert.AreEqual(true, result);
    }
    
    [TestMethod]
    public void Contains_ValueNotInTree_isFalse()
    {
        BinaryTree<int> sut = BinaryTree<int>.Empty().Add(1);

        bool result = sut.Contains(2);
        
        Assert.AreEqual(false, result);
    }
    
    
}