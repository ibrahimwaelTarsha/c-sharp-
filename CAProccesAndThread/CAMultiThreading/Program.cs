

class Program
{


    class Wallet
    {
        private readonly object  x=new object();


        public Wallet(string name, int bitcoin)
        {
            Name = name;
            this.bitcoin = bitcoin;
        }

        public string Name { get; set; }
        public int bitcoin { get; set; }


        public void Debit(int amount)
        {

         
                if (bitcoin >= amount)
                {
                    

                    bitcoin -= amount;



                }

            

           

         //   else Console.WriteLine("Illegal");


        }



        public void credit(int amount)
        {
            Thread.Sleep(1000);

            bitcoin += amount;


        }


        //public void Randomtransaction()
        //{

        //    int[] array = { 10, 20, -34, 44, -10, 66, -66 };



        //    foreach (int i in array)
        //    {
        //        var abslute = Math.Abs(i);

        //        if (i > 0)
        //            credit(abslute);

        //        else Debit(abslute);



        //    }

        //}




    }





    static void Main()
    {


        Wallet wallet = new Wallet("ibrahim", 50);
     //   wallet.Debit(40);
    //    wallet.Debit(30);


        Thread thread1 = new Thread(() => wallet.Debit(40));
        Thread thread2 = new Thread(() => wallet.Debit(30));



      
        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
       
        Console.WriteLine(wallet.bitcoin);

        //    Thread.CurrentThread.Name = "main thread ";





        //    Wallet wallet = new Wallet("ibrahim", 55);



        //    Thread thread = new Thread(wallet.Randomtransaction);
        //    thread.Name ="thread 1";

        //    wallet.Randomtransaction();

        //    Console.Write(wallet.bitcoin);


        //    wallet.Randomtransaction();

        //    Console.Write(wallet.bitcoin);










    }



}