using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDetail.DAL.Helpers.Messages
{
    public static class UnitOfWorkMessageHelper
    {
        public const string SAVE_ASYNC_ERROR_MESSAGE = "Ошибка при сохранении данных в БД";
        public const string ADD_ASYNC_ERROR_MESSAGE = "Ошибка при добавлении сущности в БД";
        public const string ADD_RANGE_ASYNC_ERROR_MESSAGE = "Ошибка при добавлении сущностей в БД";
        public const string UPDATE_ERROR_MESSAGE = "Ошибка при изменении сущности в БД";
        public const string UPDATE_RANGE_ERROR_MESSAGE = "Ошибка при изменении сущностей в БД";        
        public const string DELETE_ERROR_MESSAGE = "Ошибка при удалении сущности из БД";
        public const string DELETE_RANGE_ERROR_MESSAGE = "Ошибка при удалении сущностей из БД";
    }
}
