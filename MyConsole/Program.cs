
async Task MakeToast()
{
    Console.WriteLine("Make Toast");
    await Task.Delay(4000);
    Console.WriteLine("Toast Complete");
}

async Task MakeEgg()
{
    Console.WriteLine("Make Egg");
    await Task.Delay(2000);
    Console.WriteLine("Egg Complete");
}

async Task MakeCoffe()
{
    Console.WriteLine("Make Coffee");
    await Task.Delay(5000);
    Console.WriteLine("Coffee Complete");
}
MakeCoffe().GetAwaiter();
MakeEgg().GetAwaiter();
MakeToast().GetAwaiter();

Console.ReadKey();