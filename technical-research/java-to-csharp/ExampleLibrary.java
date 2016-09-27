public class ExampleLibrary {
	private int n = 0;
	public ExampleLibrary()
	{
	}
	public String HelloWorld()
	{
		String s = "Helloworld: " + n;
		n++;
		return s;
	}
}