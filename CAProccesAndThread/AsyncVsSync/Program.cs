using System;
using System.Diagnostics;
using System.Threading.Tasks;



using System;
using System.Threading.Tasks;

public class Program
{

    static async Task Main()
    {

        Console.WriteLine("background job is start");


        await controller();

        Console.WriteLine("background job is start");



    }



    public static async Task controller()
    {

        Console.WriteLine("controller job is start");

        await repository();
        Console.WriteLine("controller job is start");



    }



    static async Task yy()
    {

        await Task.Delay(3000);

        Console.WriteLine("yy is complete");
    }
  

  static async  void xx()
    {
        await yy();
    }


    static public async Task dataBase()
    {

        Console.WriteLine("dataBase job is start");

        xx();

        await Task.Delay(3000);

        Console.WriteLine("dataBase job is start");

    }



    static public async Task repository()
    {

        Console.WriteLine("repository job is start");
        await dataBase();
        Console.WriteLine("repository job is start");



    }



    





}








//class Program
//{






//    static async Task<string> task4()
//    {
//        await Task.Delay(3000);
//        Console.WriteLine("task 4 complete");

//        return "task";// 

//    }


//    static void xx()
//    {
//        Thread.Sleep(3000);
//        Console.WriteLine("im not async");
//    }



//    static void yy()
//    {
//        Thread.Sleep(2000);
//        Console.WriteLine("im not async");
//    }





//    static async  Task Main(string[] args)
//    {


//     // await  controller();
//       // await Task.Run(() => task2());


//    }
//}






//static void task1()
//{
//    Task.Delay(3000).Wait();
//    Console.WriteLine("task 1");
//}


//static void task2()
//{
//    Task.Delay(3000).Wait();
//    Console.WriteLine("task 2");
//}



//static void task3()
//{
//    Task.Delay(3000).Wait();
//    Console.WriteLine("task 3");
//}




//static async Task Main(string[] args)
//{

//    task3();
//    Console.WriteLine($"sese");
//    task2();
//    Console.WriteLine($"sese");

//    task1();
//    Console.WriteLine($"sese");






//}

