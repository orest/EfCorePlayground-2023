// See https://aka.ms/new-console-template for more information

using EfCorePlayground.Data;
using EfCorePlayground.Processors;

//Console.WriteLine("Hello, World!");
//var context=new CustomerContext();
//context.Database.EnsureCreated();
//Console.WriteLine("DB Created");

var tester=new EfTester();
tester.Run();