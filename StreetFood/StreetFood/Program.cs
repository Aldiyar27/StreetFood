// See https://aka.ms/new-console-template for more information

using StreetFood.BusinessLogic.Interfaces;
using StreetFood.BusinessObjects;
using StreetFood.IoC;
using StreetFood.BusinessLogic.Interfaces;

IOrdersService ordersService = IoC.GetOrderService();

// скрипт на вставку в БД
/*
INSERT INTO Dishes (Name, Price) VALUES (N'Блины', 700.00)

INSERT INTO Ingredients (Name, Code, DimensionType) VALUES (N'Молоко', N'milk', 1)
INSERT INTO Ingredients (Name, Code, DimensionType) VALUES (N'Яицо', N'egg', 1)
INSERT INTO Ingredients (Name, Code, DimensionType) VALUES (N'Мука', N'Flour', 1)
INSERT INTO Ingredients (Name, Code, DimensionType) VALUES (N'Масло', N'Oil', 1)

INSERT INTO Contents (DishId, IngredientId, Count) VALUES (1, 1, 2)
INSERT INTO Contents (DishId, IngredientId, Count) VALUES (1, 2, 2)
INSERT INTO Contents (DishId, IngredientId, Count) VALUES (1, 3, 1)

INSERT INTO StockProducts (IngredientId, Count, LastRevisionDate) VALUES (1, 5, N'2022-11-21 16:26:16.0000000')
INSERT INTO StockProducts (IngredientId, Count, LastRevisionDate) VALUES (2, 5, N'2022-11-21 16:26:16.0000000')
INSERT INTO StockProducts (IngredientId, Count, LastRevisionDate) VALUES (3, 5, N'2022-11-21 16:26:16.0000000')
*/

// запускаем проверку, можем ли мы приготовить заказ с dishId = 1
//var result =  orderService.CheckOrder(new OrderBO() { DishId = 1 });

Console.ReadLine();