using System;

public class Deposit
{
    public string FIO { get; set; }
    public double DepositAmount { get; set; }
    public static double InterestRate { get; set; } = 0.05;

    public Deposit(string fio, double depositAmount)
    {
        FIO = fio;
        DepositAmount = depositAmount;
    }

    public static Deposit operator ++(Deposit deposit)
    {
        deposit.DepositAmount += deposit.DepositAmount * InterestRate;
        return deposit;
    }

    public static double GetInterestRate()
    {
        return InterestRate;
    }

    public override string ToString()
    {
        return $"ФИО: {FIO}, Сумма вклада: {DepositAmount:C}, Процентная ставка: {InterestRate:P}";
    }
}

public class Credit
{
    public string FIO { get; set; }
    public double PaymentAmount { get; set; }
    public static double InterestRate { get; set; } = 0.10;

    public Credit(string fio, double paymentAmount)
    {
        FIO = fio;
        PaymentAmount = paymentAmount;
    }

    public static double operator -(Deposit deposit, Credit credit)
    {
        if (deposit.FIO != credit.FIO)
        {
            Console.WriteLine("Вкладчик и получатель кредита не совпадают.");
            return deposit.DepositAmount;
        }
        return deposit.DepositAmount - credit.PaymentAmount;
    }

    public static double GetInterestRate()
    {
        return InterestRate;
    }

    public override string ToString()
    {
        return $"ФИО: {FIO}, Сумма платежа: {PaymentAmount:C}, Процентная ставка: {InterestRate:P}";
    }
}


public class Example
{
    public static void Main(string[] args)
    {
        Deposit deposit = new Deposit("Иванов И.И.", 1000);
        Console.WriteLine(deposit);
        deposit++;
        Console.WriteLine(deposit);
        Console.WriteLine($"Процентная ставка по вкладу: {Deposit.GetInterestRate():P}");

        Credit credit = new Credit("Иванов И.И.", 200);
        Console.WriteLine(credit);
        double remainingAmount = deposit - credit;
        Console.WriteLine($"Остаток на вкладе после вычета платежа: {remainingAmount:C}");
        Console.WriteLine($"Процентная ставка по кредиту: {Credit.GetInterestRate():P}");
    }
}