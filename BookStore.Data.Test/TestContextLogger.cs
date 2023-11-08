namespace BookStore.Data.Test;

internal class TestContextLogger(TestContext testContext) : ITestLogger
{
	private readonly TestContext _testContext = testContext;

	public void Log(string message)
	{
		_testContext.WriteLine(message);
	}
}