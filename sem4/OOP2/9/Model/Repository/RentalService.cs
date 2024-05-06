using _9.Model.Interfaces;
using System;
using System.Threading.Tasks;


namespace _9.Model.Repository
{
    public class RentalService
    {
        private readonly ClubContext context;

        public RentalService(ClubContext context)
        {
            this.context = context;
        }

        public async void RentComputer(Computer computer)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // Проверка доступности компьютера для аренды
                    if (!computer.IsFree)
                    {
                        throw new Exception("Компьютер уже арендован.");
                    }

                    // Обновление статуса компьютера на "занят"
                    computer.IsFree = false;
                    await Task.Run(() => context.SaveChanges());

                    // Фиксация транзакции
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Откат транзакции в случае ошибки
                    transaction.Rollback();
                    Console.WriteLine("Ошибка при аренде компьютера: " + ex.Message);
                }
            }
        }

        public void ReturnComputer(Computer computer)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // Обновление статуса компьютера на "свободен"
                    computer.IsFree = true;
                    context.SaveChanges();

                    // Фиксация транзакции
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Откат транзакции в случае ошибки
                    transaction.Rollback();
                    Console.WriteLine("Ошибка при возврате компьютера: " + ex.Message);
                }
            }
        }
    }



}
