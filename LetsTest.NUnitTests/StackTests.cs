using System;
using LetsTest.Fundamentals;
using NUnit.Framework;

namespace LetsTest.NUnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Count_WhenObjPushed_ReturnCountIncrementByOne()
        {
            var count = _stack.Count;
            _stack.Push("a");
            var result = _stack.Count;

            Assert.That(result, Is.EqualTo(++count));
        }

        [Test]
        public void Count_WhenPopCalled_ReturnCountDecrementByOne()
        {
            _stack.Push("a");
            _stack.Push("b");
            var count = _stack.Count;
            _stack.Pop();
            var result = _stack.Count;

            Assert.That(result, Is.EqualTo(--count));
        }

        [Test]
        public void Count_WhenPeekCalled_ReturnTheSameCount()
        {
            _stack.Push("a");
            var count = _stack.Count;
            _stack.Peek();
            var result = _stack.Count;

            Assert.That(result, Is.EqualTo(count));
        }

        [Test]
        public void Push_WhenCalled_AddObj()
        {
            _stack.Push("a");
            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo("a"));
        }

        [Test]
        public void Push_ObjIsNull_ThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Pop_WhenCalled_ReturnLastObj()
        {
            _stack.Push("a");
            var result = _stack.Pop();

            Assert.That(result, Is.EqualTo("a"));
        }

        [Test]
        public void Pop_WhenCalled_DeleteLastObj()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Pop();
            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo("a"));
        }

        [Test]
        public void Pop_StackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_WhenCalled_ReturnLastObj()
        {
            _stack.Push("a");
            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo("a"));
        }

        [Test]
        public void Peek_StackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }
    }
}