//using System;
//using System.Threading.Tasks;
//using MongoDB.Driver;

//namespace SerwisSamochodowy.Mongo
//{
//    public class MongoCommandExceptionFilter : BaseMongoExceptionFilter
//    {
//        public override Task<TResult> HandleRequest<TResult>(Func<Task<TResult>> function)
//        {
//            try
//            {
//                return function.Invoke();
//            }
//            catch (MongoCommandException e)
//            {
//                HandleException(e);
//            }
//            throw new Exception("Error connecting database");
//        }
//    }
//}
