﻿
namespace API_Consultorio_Medico_APS.Base
{
    public interface IBaseRepository<T>
    {
        T Agregar(T obj);

        void Eliminar(T obj);

        void Editar(T obj);
    }
}
