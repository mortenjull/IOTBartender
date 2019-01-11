using IOTBartender.Domain.Entititeis;
using IOTBartender.Domain.UnitOfWorks;
using IOTBartender.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTBartender.API
{
    public static class DatabaseSeed
    {
        public static void Seed(ApplicationDbContext applicationDbContext, IUnitOfWork unitOfWork)
        {
            // Seed the database if no fluid is present.
            if (!applicationDbContext.Set<Fluid>().Any())
            {
                var fluid1 = unitOfWork.Repository.Add(new Fluid() { Name = "Vodka" });
                var fluid2 = unitOfWork.Repository.Add(new Fluid() { Name = "Rom" });
                var fluid3 = unitOfWork.Repository.Add(new Fluid() { Name = "Gin" });
                var fluid4 = unitOfWork.Repository.Add(new Fluid() { Name = "Cola" });
                var fluid5 = unitOfWork.Repository.Add(new Fluid() { Name = "Coffe" });

                var r1 = unitOfWork.Repository.Add(new Recipe()
                {
                    Name = "Vodka, Rom",
                    Components = new List<Component>()
                    {
                        new Component() { FluidId = fluid1.Id, Size = 1},
                        new Component() { FluidId = fluid2.Id, Size = 1},
                    }
                });

                var r2 = unitOfWork.Repository.Add(new Recipe()
                {
                    Name = "Gin, Cola",
                    Components = new List<Component>()
                    {
                        new Component() { FluidId = fluid3.Id, Size = 2},
                        new Component() { FluidId = fluid4.Id, Size = 2},
                    }
                });

                var r3 = unitOfWork.Repository.Add(new Recipe()
                {
                    Name = "Vodka, Cola",
                    Components = new List<Component>()
                    {
                        new Component() { FluidId = fluid1.Id, Size = 3},
                        new Component() { FluidId = fluid4.Id, Size = 3},
                    }
                });

                var r4 = unitOfWork.Repository.Add(new Recipe()
                {
                    Name = "Rom, Gin",
                    Components = new List<Component>()
                    {
                        new Component() { FluidId = fluid2.Id, Size = 4},
                        new Component() { FluidId = fluid3.Id, Size = 4},
                    }
                });


                var r5 = unitOfWork.Repository.Add(new Recipe()
                {
                    Name = "To much",
                    Components = new List<Component>()
                    {
                        new Component() { FluidId = fluid1.Id, Size = 1},
                        new Component() { FluidId = fluid5.Id, Size = 1},
                    }
                });


                unitOfWork.Repository.Add(new Order() { RecipeId = r1.Id, Events = new List<OrderEvent>() { new OrderEvent() { Time = DateTime.UtcNow, Type = OrderEvent.OrderEventType.Submitted } } });
                unitOfWork.Repository.Add(new Order() { RecipeId = r2.Id, Events = new List<OrderEvent>() { new OrderEvent() { Time = DateTime.UtcNow, Type = OrderEvent.OrderEventType.Submitted } } });
                unitOfWork.Repository.Add(new Order() { RecipeId = r3.Id, Events = new List<OrderEvent>() { new OrderEvent() { Time = DateTime.UtcNow, Type = OrderEvent.OrderEventType.Submitted } } });
                unitOfWork.Repository.Add(new Order() { RecipeId = r4.Id, Events = new List<OrderEvent>() { new OrderEvent() { Time = DateTime.UtcNow, Type = OrderEvent.OrderEventType.Submitted } } });
                unitOfWork.Repository.Add(new Order() { RecipeId = r5.Id, Events = new List<OrderEvent>() { new OrderEvent() { Time = DateTime.UtcNow, Type = OrderEvent.OrderEventType.Submitted } } });

                var result = unitOfWork.SaveChanges().Result;
            }
        }
    }
}
