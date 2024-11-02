


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
            bitcoin-=amount;


            Console.WriteLine($"thread ========>{Thread.CurrentThread.ManagedThreadId}------- proccesror id ======> {Thread.GetCurrentProcessorId()}   --  {amount} ");

        }



        public void credit(int amount)
        {
            bitcoin += amount;
            Console.WriteLine($"thread ========>{Thread.CurrentThread.ManagedThreadId}------- proccesror id ======> {Thread.GetCurrentProcessorId()}   --  {amount} ");


        }


        public void Randomtransaction()
        {

            int[] array = { 10, 20, -34, 44, -10, 66, -66 };



            foreach (int i in array)
            {
                var abslute =Math.Abs(i);

                if (i > 0)
                    credit(abslute);

                else Debit(abslute);



            }

        }




    }




    //class x
    //{
    //    public int count { get; set; }

    //    public void increse()
    //    {
    //        ++count;

    //        Console.WriteLine($"increate func  ,count ==> {count}");
    //    }


    //    public void decrese()
    //    {
    //        --count;

    //        Console.WriteLine($"decrease func  ,count ==> {count}");
    //    }


    //    public void increse2(int val)
    //    {
    //        count += val;

    //        Console.WriteLine($"increate2 func  ,count ==> {count}");
    //    }

    //}



    static void Main()
    {


        Wallet wallet = new Wallet("ibrahim",55);

        wallet.Randomtransaction();

        Console.Write(wallet.bitcoin);


        wallet.Randomtransaction();

        Console.Write(wallet.bitcoin);


      

        //x obj= new x();

        //obj.count = 12;

        //obj.increse();

        //obj.decrese();

        //obj.increse2(1);

        //Console.WriteLine(obj.count);





    }



}