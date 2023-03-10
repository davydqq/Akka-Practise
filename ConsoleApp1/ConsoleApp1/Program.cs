// See https://aka.ms/new-console-template for more information
using Akka.Actor;

var system = ActorSystem.Create("MySystem");
var greeter = system.ActorOf<GreetingActor>("greeter");
greeter.Tell(new Greet2("Hello World"));
Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
Console.Read();


public class Greet
{
    public Greet(string who)
    {
        Who = who;
    }
    public string Who { get; private set; }
}

public class Greet2
{
    public Greet2(string who)
    {
        Who = who;
    }
    public string Who { get; private set; }
}

public class GreetingActor : ReceiveActor
{
    public GreetingActor()
    {
        Receive<Greet>(greet =>
        {
            Console.WriteLine("[Thread {0}] Greeting {1}", Thread.CurrentThread.ManagedThreadId, greet.Who);
        });
    }
}