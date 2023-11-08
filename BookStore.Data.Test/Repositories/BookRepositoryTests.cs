using System.Net;

using Microsoft.EntityFrameworkCore;

using BookStore.Data.Entities;
using BookStore.Data.Interfaces;
using BookStore.Data.Repositories;

using MockQueryable.Moq;

using Moq;
using FluentAssertions;

namespace BookStore.Data.Test.Repositories;

[TestClass]
public class BookRepositoryTests
{
	private static readonly List<Book> PopulatedList =
	[
		new Book("TestBook1") { Id = 1 },
		new Book("TestBook2") { Id = 2 },
		new Book("TestBook3") { Id = 3 },
	];
	private static readonly List<Book> EmptyList = [];
	public static IEnumerable<object[]> AddBookData =>
		new List<object[]>
		{
		new object[] { new Book("Test Book") { Id = 1  } },
		};

	private TestContext _testContext = null!;

	public TestContext TestContext
	{
		get { return _testContext; }
		set { _testContext = value; }
	}

	private ITestLogger _logger = null!;

	private Mock<IAppDbContext> _mockDbContext = null!;
	private BookRepository _bookRepository = null!;


	[TestInitialize]
	public void TestInitialize()
	{
		_logger = new TestContextLogger(TestContext);
		_mockDbContext = new Mock<IAppDbContext>();
		_bookRepository = new BookRepository(_mockDbContext.Object);
	}

	[TestMethod]
	[DataRow(1)]
	[DataRow(3)]
	public async Task GetAsync_ShouldReturnBook_IdIsInTable(int bookId)
	{
		// Arrange
		Mock<DbSet<Book>> mockSet = PopulatedList.AsQueryable().BuildMockDbSet();
		_mockDbContext.Setup(s => s.Set<Book, int>()).Returns(mockSet.Object);

		// Act
		Func<Task<Book?>> act = async () => await _bookRepository.GetAsync(bookId);

		// Assert
		(await act.Should().NotThrowAsync())
			 .Which.Should().BeEquivalentTo(PopulatedList[bookId - 1]);
	}

	[TestMethod]
	[DataRow(1)]
	[DataRow(3)]
	public async Task GetAsync_ShouldReturnNull_TableIsEmpty(int bookId)
	{
		// Arrange
		Mock<DbSet<Book>> mockSet = EmptyList.AsQueryable().BuildMockDbSet();
		_mockDbContext.Setup(s => s.Set<Book, int>()).Returns(mockSet.Object);

		// Act
		Book? result = await _bookRepository.GetAsync(bookId);

		// Assert
		Assert.IsNull(result);
	}

	[TestMethod]
	[DataRow(10)]
	[DataRow(-1)]
	public async Task GetAsync_ShouldReturnNull_IdIsNotInTable(int bookId)
	{
		// Arrange
		Mock<DbSet<Book>> mockSet = PopulatedList.AsQueryable().BuildMockDbSet();
		_mockDbContext.Setup(s => s.Set<Book, int>()).Returns(mockSet.Object);

		// Act
		Book? result = await _bookRepository.GetAsync(bookId);

		// Assert
		Assert.IsNull(result);
	}

	[TestMethod]
	[DynamicData(nameof(AddBookData))]
	public void Add_ShouldCallDbSetAdd1Time_AddingBookThatIsNotYetInTable(Book newBook)
	{
		// Arrange
		Mock<DbSet<Book>> mockSet = EmptyList.AsQueryable().BuildMockDbSet();
		_mockDbContext.Setup(s => s.Set<Book, int>()).Returns(mockSet.Object);

		// Act
		_bookRepository.Add(newBook);

		// Assert
		_mockDbContext.Verify(x => x.Set<Book, int>().Add(It.IsAny<Book>()), Times.Once);
	}

	[TestMethod]
	public void Update_ShouldCallDbUpdate1Time_UpdatingBookWhichIdIsInTable()
	{
		// Arrange
		Mock<DbSet<Book>> mockSet = PopulatedList.AsQueryable().BuildMockDbSet();
		_mockDbContext.Setup(s => s.Set<Book, int>()).Returns(mockSet.Object);

		// Act
		_logger.Log("Loading book data from file");
		try
		{
			Book updatedBook = BookTestData.TestBook;
			_bookRepository.Update(updatedBook);

		}
		catch (FormatException)
		{
			_logger.Log("Book data file format is invalid");
			Assert.Fail();
		}
		_logger.Log("Book data loaded successfully");

		// Assert
		_mockDbContext.Verify(x => x.Set<Book, int>().Update(It.IsAny<Book>()), Times.Once);
	}
}