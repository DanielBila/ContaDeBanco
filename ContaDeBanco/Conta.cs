using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ContaDeBanco
{
    internal class Conta
    {   
        private string _titular;
        private string _numero;
        private int _cpf;
        public double Saldo { get; private set; }

        public Conta(string titular,int cpf)
        {
            Random random = new Random();
            _titular = titular ;
            _cpf = cpf;
            Saldo = 0.0;
            //Este metodos fazer que criam 5 numeros aleatorios que serão o numero da conta 
            _numero = $"{random.Next(1, 9)}{random.Next(1, 9)}{random.Next(1, 9)}{random.Next(1, 9)}{random.Next(1, 9)}";                                                                
        }
        public Conta(string titular, int cpf,double saldo) 
        {
            Random random = new Random();
            _titular = titular;
            _cpf = cpf;
            Saldo = saldo;
            //Este metodos fazer que criam 5 numeros aleatorios que serão o numero da conta 
            _numero = $"{random.Next(1, 9)}{random.Next(1, 9)}{random.Next(1, 9)}{random.Next(1, 9)}{random.Next(1, 9)}";
        }
        public void Sacar(double dinhero)
        {
            Saldo -= dinhero;
        }
        public void Depositar(double dinhero)
        {
            Saldo += dinhero;
        }
        public override string ToString()
        {
            return "Conta: " + _numero + 
                   "; Titular: " + _titular +
                   "; Saldo: R$" + Saldo;
        }
    }
}
