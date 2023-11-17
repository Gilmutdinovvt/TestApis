using WebApplication7.Context;
using WebApplication7.Models;

namespace TestApi.HingfireServices
{
    public interface IHangFireServiceManagment
    {
         Task UpdateDatabase(TASKS tASKS);
    }
}
