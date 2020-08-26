using Microsoft.SqlServer.Server;
using OnlineShop.Data;
using OnlineShop.Models;
using System;

namespace OnlineShop
    //продажа сотовых телефонов
{
    class Program
    {
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
            var user = new User
            {
                Email = "asdkqjewk",
            Password = "adasdad"
            };

            var dataAccess = new UserDateAccess();
            dataAccess.Create(user);
        }
    }
}
