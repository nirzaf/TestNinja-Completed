using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ArgIsNull_ThrowArgNullException()
        {
            var stack = new Stack<string>();
            
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }
        
        [Test]
        public void Push_ValidArg_AddTheObjectToTheStack()
        {
            var stack = new Stack<string>();
            
            stack.Push("a");
            
            Assert.That(stack.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Stack<string>();
            
            Assert.That(stack.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();
            
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }
        
        [Test]
        public void Pop_StackWithAFewObjects_ReturnObjectOnTheTop()
        {
            // Arrange 
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            
            // Act
            var result = stack.Pop();
            
            // Assert
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Pop_StackWithAFewObjects_RemoveObjectOnTheTop()
        {
            // Arrange 
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            
            // Act
            stack.Pop();
            
            // Assert
            Assert.That(stack.Count, Is.EqualTo(2));
        }
        
        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();
            
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }
        
        [Test]
        public void Peek_StackWithObjects_ReturnObjectOnTopOfTheStack()
        {
            // Arrange 
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            
            // Act
            var result = stack.Peek();
            
            // Assert
            Assert.That(result, Is.EqualTo("c"));
        }
        
        [Test]
        public void Peek_StackWithObjects_DoesNotRemoveTheObjectOnTopOfTheStack()
        {
            // Arrange 
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            
            // Act
            stack.Peek();
            
            // Assert
            Assert.That(stack.Count, Is.EqualTo(3));
        }
    }
}