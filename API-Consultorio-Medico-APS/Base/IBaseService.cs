namespace API_Consultorio_Medico_APS.Base
{
    public interface IBaseService<T,N> 
    {
        List<T> ConsultarDTO();
        T ConsultarPorId(int id);
        T Agregar(N dto);
        T Editar(T dto);
        T Eliminar(int id);
    }
}
