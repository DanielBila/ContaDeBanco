using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace ContaDeBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            //Incerção de Informacoes do Cliente 
            Console.WriteLine("Digite teu nome Completo:");
            string titular = Console.ReadLine();          
            Console.WriteLine($"Perfeito {titular.Split(' ').First()} agora Digite o seu CPF:");
            int cpf = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Perfeito Sua Conta Criado");
            string inicial = null;
            Conta conta = null;
            //Deposito Inicial
            do
            {   
                Console.Clear();
                Console.WriteLine("Haverá depósito inicial (s/n)?");
                inicial = Console.ReadLine();
                if(inicial != "s" &&  inicial != "S" && inicial != "n" && inicial != "N")
                {
                    Console.WriteLine("Celeção Invalida");
                    Task.Delay(500).Wait();
                }


            } while (inicial != "s" && inicial != "S" && inicial != "n" && inicial != "N");
            //Aceitou Deposito Inicial
            if(inicial == "s" || inicial == "S")
            {
                Console.Clear();
                Console.WriteLine("Perfeito Qual Seria o valor do deposito");
                double depositoInicial = double.Parse(Console.ReadLine());
                conta = new Conta(titular,cpf,depositoInicial);
            }
            else if(inicial == "n" || inicial == "N")
            {
                Console.Clear();
                conta = new Conta(titular,cpf);
            }
            Console.WriteLine("Dados da Conta:");
            Console.WriteLine(conta);
            Console.ReadLine();
            bool loop = true;
            while (loop) 
            {
                Console.Clear();
                Console.WriteLine("1-Dados da Conta");
                Console.WriteLine("2-Depositar");
                Console.WriteLine("3-Sacar");
                Console.WriteLine("4-Sair");
                int escolha = int.Parse(Console.ReadLine());
                //Dados da Conta 
                if (escolha == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Dados da Conta:");
                    Console.WriteLine(conta);
                    Console.ReadLine();
                }
                //Depositar
                else if (escolha == 2) 
                {
                    Console.Clear();
                    Console.WriteLine("Qual Seria o valor do deposito");
                    double deposito = double.Parse(Console.ReadLine());
                    conta.Depositar(deposito);
                }
                //Sacar
                else if(escolha == 3)
                {
                    double sacar;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine($"Saldo Atual R${conta.Saldo}");
                        Console.WriteLine("Qual Seria o valor do Sacado");
                        sacar = double.Parse(Console.ReadLine());
                        if(conta.Saldo < sacar)
                        {
                            Console.WriteLine("Valor invalido Saldo Indisponivel");
                            Task.Delay(1000).Wait();
                        }
                    } while (conta.Saldo < sacar);                                
                    conta.Sacar(sacar);
                                        
                }
                //sair
                else if (escolha == 4)
                {
                    Console.Clear();
                    loop = false;
                }
            }        
        }
    }
}