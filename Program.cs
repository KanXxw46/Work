using Microsoft.Extensions.Configuration;
using OnlineShop.Data;
using OnlineShop.Models;
using System.Linq;

namespace OnlineShop
//продажа сотовых телефонов
{
    class Program
    {
        private static User user;

        /*
* Онлайн магазин
* 1. Регистрация и вход на основе email и телефона (на выбор юзера)
* 2. Изменение профиля
* 3. Категории товаров
* 4. Товары с сортировкой (цены, количество, лайки и прочее)
* 5. Покупка (+2 балла на экзамен тому, кто реализует с помощью платёжной системы)
* 6. Лайки и коммментарии (цепочки комментариев)
* 7. Доставка товара
* 8. Бонус. Бот на телеграмме для отслеживания товаров (+1 балл на экзамен)
* Во всех указанных способах взаимодействия с БД (подключ. ур., EF, Dapper)
*/
        static void Main(string[] args)
        {

            var dataAccess = new UserDateAccess();
            dataAccess.Create(user);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration["connectionString"];

            using (var context = new ApplicationContext(connectionString))
            {
                User user = new User
                {
                    Phone = "+87708387482984",
                    Password = "12345",
                    Email = "1kan_andrei@mail.ru"
                };

                var isUser = bool.Parse(configuration["isUser"]);


            }
            using (var context = new ApplicationContext(connectionString))
            {
                var userCount = context.Users.Count();
                context.SaveChanges();

                const int USERS_PER_PAGE = 3;
                var usersFirstPage = context.Users.Take(USERS_PER_PAGE).ToList();
                var usersSecondPage = context.Users.Skip(USERS_PER_PAGE).Take(USERS_PER_PAGE).ToList();

            }
        }
    }
}
