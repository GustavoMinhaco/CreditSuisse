using System.Globalization;
using CreditSuisse.Constant;
using CreditSuisse.Controller;
using CreditSuisse.Interface;
using CreditSuisse.Models;
using CreditSuisse.Objects;

namespace CreditSuisse
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (!DateTime.TryParseExact(
                Console.ReadLine(), "MM/dd/yyyy", new CultureInfo("en-US"),
                DateTimeStyles.None, out DateTime dataRef))
            {
                Console.WriteLine(ErrorConst.INVALID_DATA_REF);
            }
            else
            {
                bool isInt = int.TryParse(Console.ReadLine(), out int rowCount);
                if (!isInt || (isInt && (rowCount < 1)))
                {
                    Console.WriteLine(ErrorConst.INVALID_ROW_COUNT);
                }
                else
                {
                    List<Trade> listTrade = [];
                    OperationController operation = new(GetRules());
                    try
                    {
                        for (int i = 0; i < rowCount; i++)
                        {
                            string? row = Console.ReadLine();
                            if (!string.IsNullOrEmpty(row))
                            {
                                listTrade.Add(operation.AddTrade(row));
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(ErrorConst.INVALID_ROW_TRADES);
                    }

                    Console.WriteLine(); // blank line printing
                    operation.CategorizeTrades(dataRef, listTrade);
                }
            }

            Console.ReadKey();
        }

        // strategy design pattern rules configuration
        static List<IRuleTrade> GetRules()
        {
            List<IRuleTrade> listRules =
                    [
                       new EXPIRED(),
                       new HIGHRISK(),
                       new MEDIUMRISK()
                    ];

            return listRules;
        }
    }
}