using StreetFood.BusinessLogic.Interfaces;
using StreetFood.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessLogic.Implementations
{
    public class ReportsService : IReportsService
    {
        // сервис по работе с заказами
        private IOrdersService ordersService;
        
        // сервис по работе с блюдами
        private IDishesService dishesService;

        private IContentsService contentsService;

        private IStockProductsService stockProductsService;

        private IIngredientsService ingredientsService;

        public ReportsService(
            IOrdersService ordersService, 
            IDishesService dishesService,
            IIngredientsService ingredientsService,
            IContentsService contentsService,
            IStockProductsService stockProductsService
            )
        {
            this.ordersService = ordersService;
            this.dishesService = dishesService;
            this.contentsService = contentsService;
            this.stockProductsService = stockProductsService;
            this.ingredientsService = ingredientsService;
        }

        
        public List<OrderReportItemBO> GetOrders()
        {
            // Получаем список заказов
            List<OrderBO> orderBOs = ordersService.GetOrders();
            
            // созда1м результирующую переменную
            List<OrderReportItemBO> result = new List<OrderReportItemBO>();
            foreach (var orderBO in orderBOs)
            {
                // на каждом шаге находим Dish, чтобы взять из него наименование
                DishBO? dish = dishesService.GetById(orderBO.DishId);
                if (dish == null)
                {
                    throw new Exception("Dish not found");
                }

                // создаём новый объект и заполняем свойства объекта
                OrderReportItemBO item = new OrderReportItemBO();
                item.Date = orderBO.OpenDate.Date;
                item.Sum = orderBO.Sum;
                item.DishName = dish.Name;
                
                // добавляем в результирующую переменную
                result.Add(item);
            }

            return result;  
        }

        public List<OrderReportItemBO> GetOrders(DateTime from)
        {
            throw new NotImplementedException();
        }

        public List<OrderReportItemBO> GetOrders(DateTime from, DateTime to)
        {
            // Получаем список заказов с .. по ..
            List<OrderBO> orderBOs = ordersService.GetOrders(from, to);
            
            // созда1м результирующую переменную
            List<OrderReportItemBO> result = new List<OrderReportItemBO>();
            foreach (var orderBO in orderBOs)
            {
                
                // на каждом шаге находим Dish, чтобы взять из него наименование
                DishBO? dish = dishesService.GetById(orderBO.DishId);
                if (dish == null)
                {
                    throw new Exception("Dish not found");
                }

                // создаём новый объект и заполняем свойства объекта
                OrderReportItemBO item = new OrderReportItemBO();
                item.Date = orderBO.OpenDate.Date;
                item.Sum = orderBO.Sum;
                item.DishName = dish.Name;

                // добавляем в результирующую переменную
                result.Add(item);
            }

            return result;
        }
        public List<StockProductItemBO> GetPopularStockProducts(int take)
        {
            List<StockProductItemBO> result = new List<StockProductItemBO>();
            List<OrderBO>? orders = ordersService.GetOrders();
            List<ContentBO> allContents = new List<ContentBO>();
            foreach (var orderBO in orders)
            {
                List<ContentBO>? contents = contentsService.GetContentsByDishId(orderBO.DishId);
                allContents.AddRange(contents);
            }
            IEnumerable<IGrouping<int, ContentBO>>? groupByIngredientId = allContents.GroupBy(x => x.IngredientId);

            foreach (var groupItem in groupByIngredientId)
            {
                int ingredientid = groupItem.Key;
                IngredientBO? ingredient = ingredientsService.GetById(ingredientid);
                StockProductBO? product = stockProductsService.GetByIngredientId(ingredientid);
                int cont = groupItem.Sum(x => x.IngredientId);
                var reportItem = new StockProductItemBO()
                {
                    Count = cont,
                    IngredientName = ingredient.Name,
                    LastModifiedDate = product.LastRevisionDate
                };
                result.Add(reportItem);
            }
            return result.OrderBy(x => x.Count).Take(take).ToList();
        }
    }
}

