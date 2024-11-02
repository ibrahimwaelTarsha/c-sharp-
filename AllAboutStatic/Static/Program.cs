




//they most probably answer you that the static keyword is used in Factory
//Design Pattern, Singleton Design Pattern as well as used for data sharing,



static class Static
{

    public static int a = 0;

    public static int increasA()
    {
        return ++a;
    }

}


class B
{

   public int bMethod()
    {
        return Static.increasA();
    }


}



class Program
{

    int ProgramMethod()
    {
        return Static.increasA();
    }



















    static void Main()
    {
        Program program = new Program();

        B   b = new B();

       Console.WriteLine( program.ProgramMethod());
        Console.WriteLine(b.bMethod());

    }








}

