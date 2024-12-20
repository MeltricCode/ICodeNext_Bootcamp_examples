﻿// See https://aka.ms/new-console-template for more information

using Payment.Core;
using Payment.Infrastructure;

PaymentFactory factory = new PaymentFactory(paymens =>
{
    paymens.Add("1", typeof(CreditCard));
    paymens.Add("2", typeof(CryptoCurrencyWrapper));
});

Console.Write("Enter Price: ");
float price = float.Parse(Console.ReadLine());

Console.Write("PaymentType {1-CreditCard 2-CryptoCurrency} : ");
string paymentType = Console.ReadLine();

Console.WriteLine();
Console.WriteLine("******************************************");

IPaymentProcessor payment = factory.GetPayment(paymentType);
payment.Process(price);