using AutoDetail.BLL.Interfaces;
using AutoDetail.Core.Interfaces;

namespace AutoDetail.BLL.Services
{
    public class CommonService<T> : ICommonService where T : class, IDatabaseEntity
    {

    }
}
