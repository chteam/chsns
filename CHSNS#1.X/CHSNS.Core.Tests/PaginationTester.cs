using System;
using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CHSNS.Core.Tests
{
	[TestClass]
	public class PaginationTester
	{
		[TestMethod]
		public void ShouldCreatePaginationWithDefaultPageSize()
		{
			var strings = new List<string> {"First", "Second", "Third"};
			var pagination = strings.Pager(1);
		    Assert.AreEqual(20, pagination.PageSize);
            Assert.AreEqual(20, strings.AsQueryable().Pager(1).PageSize);
		}

		[TestMethod]
		public void ShouldCreatePaginationWithCustomPageSize()
		{
			var strings = new List<string> {"First", "Second", "Third"};
            var pagination = strings.Pager(1, 5);
		    Assert.AreEqual(5, pagination.PageSize);
            Assert.AreEqual(5, strings.AsQueryable().Pager(1, 5).PageSize);
		}

		[TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ShouldThrowIfPageNumberIsLessThan1()
		{
			var strings = new List<string>();
			strings.Pager(0);
		}
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowIfPageNumberIsLessThan1Query() {
            var strings = new List<string>().AsQueryable();
            strings.Pager(0);
        }
        [TestMethod]
        public void ShouldExecuteQuery()
        {
            var strings = new List<string> {"First", "Second", "Third", "Fourth"};
            Assert.AreEqual(4, strings.Pager(1, 2).TotalCount);
            Assert.AreEqual(2, strings.Pager(1, 2).TotalPages);
            Assert.AreEqual(1, strings.Pager(1, 2).CurrentPage);
            Assert.AreEqual(2, strings.Pager(1, 2).Count);

            Assert.AreEqual(4, strings.AsQueryable().Pager(1, 2).TotalCount);
            Assert.AreEqual(2, strings.AsQueryable().Pager(1, 2).TotalPages);
            Assert.AreEqual(1, strings.AsQueryable().Pager(1, 2).CurrentPage);
            Assert.AreEqual(2, strings.AsQueryable().Pager(1, 2).Count);
        }

	    [TestMethod]
		public void HasPreviousPageShouldReturnTrueWhenNotOnFirstPage()
		{
			var strings = new List<string> { "First", "Second", "Third", "Fourth" };
		    Assert.IsTrue(strings.Pager(2, 2).HasPreviousPage);
            Assert.IsTrue(strings.AsQueryable().Pager(2, 2).HasPreviousPage);
		}

		[TestMethod]
		public void HasPreviousPageShouldReturnFalseWhenOnFirstPage()
		{
			var strings = new List<string> { "First", "Second", "Third", "Fourth" };
            Assert.IsFalse(strings.Pager(1, 2).HasPreviousPage);
            Assert.IsFalse(strings.AsQueryable().Pager(1, 2).HasPreviousPage);
		}

		[TestMethod]
		public void HasNextPageShouldReturnTrueWhenOnFirstPage()
		{
			var strings = new List<string> { "First", "Second", "Third", "Fourth" };
            Assert.IsTrue(strings.Pager(1, 2).HasNextPage);
            Assert.IsTrue(strings.AsQueryable().Pager(1, 2).HasNextPage);
		}

		[TestMethod]
		public void HasNextPageShouldReturnFalseWhenOnLastPage()
		{
			var strings = new List<string> { "First", "Second", "Third", "Fourth" };
            Assert.IsFalse(strings.Pager(4, 2).HasNextPage);
            Assert.IsFalse(strings.AsQueryable().Pager(4, 2).HasNextPage);
		}

		[TestMethod]
		public void ForCoverage()
		{
			var strings = new List<string> { "First", "Second", "Third", "Fourth" };
            Assert.IsNotNull(((IEnumerable)strings.Pager(4, 2)).GetEnumerator());
            Assert.IsNotNull(((IEnumerable)strings.AsQueryable().Pager(4, 2)).GetEnumerator());
		}
	}
}