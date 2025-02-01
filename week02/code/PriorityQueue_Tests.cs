using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add item and verify FIFO when same priority (multiple items, same priority)
    // Expected Result: Items with same priority should be dequeued in FIFO order: A, B, C
    // Defect(s) Found: The Dequeue method is not correctly handling FIFO for same priorities and isn't removing items
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test priority ordering with mixed priorities
    // Expected Result: Items should be dequeued in priority order: C(5), B(3), A(1)
    // Defect(s) Found: 1) Loop in Dequeue ends too early (Count-1)
    //                  2) Items aren't being removed from queue after dequeue
    //                  3) Priority comparison is incorrect - should be > not >=
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from empty queue
    // Expected Result: Should throw InvalidOperationException
    // Defect(s) Found: Exception is working correctly
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mix of priorities with some same priorities
    // Expected Result: C(5), D(5), B(3), A(1) - with same priorities following FIFO
    // Defect(s) Found: Same defects as test 2, plus not maintaining FIFO order for same priorities
    public void TestPriorityQueue_MixedWithSamePriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 5);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }
}