//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using MongoDB.Driver;

//namespace SerwisSamochodowy.Mongo
//{
//    public abstract class BaseMongoExceptionFilter : IMongoExceptionFilter
//    {
//        public abstract Task<TResult> HandleRequest<TResult>(Func<Task<TResult>> action);

//        protected virtual void HandleException(MongoException e) 
//        {
//            Console.WriteLine(e.Message); //THERE SHOULD BE USED A PROPER LOGGER BUT FUCK IT!
//        }
//    }
//}
