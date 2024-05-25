

Console.WriteLine(d(new[] { 1, 2, 3, 4, 5 }));

static int d(IEnumerable<int> values)
{
	object lock_obj = new object();
	int result = 0;
	Parallel.ForEach(values, () => 0,
		(item, state, local_value) => local_value + item,
		localValue =>
		{
			lock (lock_obj)
			{
				result += localValue;
			}
		});
	return result;	
}