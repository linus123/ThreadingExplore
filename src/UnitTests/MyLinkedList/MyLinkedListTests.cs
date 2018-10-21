using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FluentAssertions;
using Xunit;

namespace ThreadingExplore.UnitTests.MyLinkedList
{
    public class MyLinkedListTests
    {
        [Fact]
        public void GetShouldErrorWhenLinkedListIsEmpty()
        {
            var ll = new MyLinkedList();

            Assert.Throws<Exception>(() =>
            {
                ll.Get(0);
            });
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void AddShouldAddSingleItem(
            int value)
        {
            var ll = new MyLinkedList();

            ll.Add(value);

            var result = ll.Get(0);

            result.Should().Be(value);
        }

        [Fact]
        public void AddShouldHandleMoreThanOneAdd()
        {
            var ll = new MyLinkedList();

            ll.Add(10);
            ll.Add(11);
            ll.Add(12);

            int result;

            result = ll.Get(0);
            result.Should().Be(10);

            result = ll.Get(1);
            result.Should().Be(11);

            result = ll.Get(2);
            result.Should().Be(12);
        }

        [Fact]
        public void ShouldSupportEnumerator()
        {
            var ll = new MyLinkedList();

            ll.Add(10);
            ll.Add(11);
            ll.Add(12);

            var enumerator = ll.GetEnumerator();

            enumerator.MoveNext();
            enumerator.Current.Should().Be(10);

            enumerator.MoveNext();
            enumerator.Current.Should().Be(11);

            enumerator.MoveNext();
            enumerator.Current.Should().Be(12);

            enumerator.Dispose();
        }
    }

    public class MyLinkedList : IEnumerable<int>
    {
        private Node _first;

        public int Get(int index)
        {
            var currentNode = _first;
            int counter = 0;

            while (currentNode != null)
            {
                if (counter == index)
                    return currentNode.Value;

                currentNode = currentNode.Next;
                counter++;
            }

            throw new Exception("No values in the list.");

            return 0;
        }

        public void Add(int value)
        {
            var newNode = new Node()
            {
                Value = value
            };

            if (_first == null)
            {
                _first = newNode;
                return;
            }

            var lastNode = _first;

            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }

            lastNode.Next = newNode;
        }

        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
        }

        public IEnumerator<int> GetEnumerator()
        {
            var currentNode = _first;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var currentNode = _first;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.Next;
            }
        }
    }
}