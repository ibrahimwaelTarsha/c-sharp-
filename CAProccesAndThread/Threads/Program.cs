using System.Runtime.CompilerServices;


//  thread direct deal with procesor
// thread ==> smalest unit of procces
//  each .net app when i ruun it take 1 procces And in the 1 procces take 1 thread by deafault


// by default All thread is foreground thread 


class Program
{

    class Wallet
    {
        public Wallet(string name, int bitcoin)
        {
            Name = name;
            this.bitcoin = bitcoin;
        }

        public string Name { get; set; }
        public int bitcoin { get; set; }


        public void Debit(int amount)
        {


            Thread.Sleep(1000);

            bitcoin -= amount;


            Console.WriteLine($"{Thread.CurrentThread.Name} ========>{Thread.CurrentThread.ManagedThreadId}------- proccesror id ======> {Thread.GetCurrentProcessorId()}   --  {amount} ");

        }



        public void credit(int amount)
        {
            if(Thread.CurrentThread.Name=="")

            Thread.Sleep(1000);

            bitcoin += amount;
            Console.WriteLine($"{Thread.CurrentThread.Name}========>{Thread.CurrentThread.ManagedThreadId}------- proccesror id ======> {Thread.GetCurrentProcessorId()}   --  {amount} ");


        }


        public void Randomtransaction()
        {

            int[] array = { 10, 20, -10, 30, -10, 10, -10 };



            foreach (int i in array)
            {
                var abslute = Math.Abs(i);

                if (i > 0)
                    credit(abslute);

                else Debit(abslute);



            }

        }




       

    }


  public  static void taskForMainThread()
    {

        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(1000);

            Console.WriteLine($"im {Thread.CurrentThread.Name} still working ");

        }
    }





    public static void taskForthread3()
    {

        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(1000);

            Console.WriteLine($"im {Thread.CurrentThread.Name} still working ");

        }
    }


    static void Main()
    {
        Thread.CurrentThread.Name = "main thread ";




        Console.WriteLine($"thread that running is ===> {Thread.CurrentThread.Name}");


        Wallet wallet = new Wallet("ibrahim", 50);



        Thread thread3 = new Thread(taskForthread3);


        Thread thread = new Thread(wallet.Randomtransaction);


        Thread thread2 = new Thread(wallet.Randomtransaction);


        thread.Name = "thread1";
        thread2.Name = "thread2";
        thread3.Name = "thread3";



        thread.Start();
      
        thread3.Start();
        thread3.Join();  ///  mean the next thread must wait the thread (that is meke it join) after end 

        thread2.Start();
        taskForMainThread();

        


        //main thread  still work with thread 1 in parallel

        //if i make taskForMainThread() execute before thread.Start()  thread 1 not work after main thread (that execute taskForMainThread ) is ended

        //    whlie if  i make taskForMainThread() execute after thread.Start()  thread 1 work and main tread did not stop and work in parallel
        //     with thread 1

        //  if i want to make main thread  work  after threa1 i make  {thread.Join()}
    }



}