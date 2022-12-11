using DataStructures.AbstractDataTypes.Arrays;

//ArrayUsage();
//ArrayListUsage();
ListUsage();


void ArrayUsage()
{
    SimpleArray.Sort(new[] {7, 5, 3, 9});  
}

void ArrayListUsage()
{
    var arrayList = new NikArrayList();
    arrayList.Add("Item 1");
    arrayList.Add(2);
    var exists = arrayList.Contains(2);    
    Console.WriteLine($"Element 2 Exists: {exists}");
}

void ListUsage()
{
    var list = new NikList<int>
    {
        1,
        2,
        3,
        4
    };
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }
}