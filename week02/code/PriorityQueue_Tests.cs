using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities: Bob (1), Tim (5), Sue (3), then dequeue once.
    // Expected Result: Tim is returned because it has the highest priority value.
    // Defect(s) Found: The original dequeue search skipped the last item in the queue and did not remove the returned item from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Tim", result);
        Assert.AreEqual("[Bob (Pri:1), Sue (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue three items where two share the highest priority: Bob (5), Tim (5), Sue (3), then dequeue twice.
    // Expected Result: Bob is returned first and Tim is returned second because tied highest-priority items must follow FIFO order.
    // Defect(s) Found: The original dequeue logic used >= while scanning, which selected the later tied item instead of the earlier one.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();

        Assert.AreEqual("Bob", first);
        Assert.AreEqual("Tim", second);
        Assert.AreEqual("[Sue (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue Bob (1), Tim (3), Sue (5), then dequeue once.
    // Expected Result: Sue is returned because the highest-priority item can be at the back of the queue.
    // Defect(s) Found: The original dequeue loop stopped before checking the last element, so a highest-priority item at the back was ignored.
    public void TestPriorityQueue_HighestPriorityAtBack()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 3);
        priorityQueue.Enqueue("Sue", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Sue", result);
        Assert.AreEqual("[Bob (Pri:1), Tim (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: No defect found in this scenario. The required exception type and message were already correct.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }
}
