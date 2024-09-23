using API_Consultorio_Medico_APS.DataBase;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using Consultorio.Server.Base.Impl;
using Microsoft.EntityFrameworkCore;

namespace API_Consultorio_Medico_APS.Repositories.Impl
{
    public class Exp_PadRepository(AppDbContext context) : BaseRepository<Exp_Pad>(context), IExp_PadRepository
    {
        private readonly AppDbContext _context = context;
        public IEnumerable<Exp_PadDTO> ConsultarDTO()
        {
            IEnumerable<Exp_Pad> query = _context.Exp_Pad.ToList();
            return from ep in query
                   select new Exp_PadDTO
                   {
                       Id = ep.Id,
                       Expediente_Id = ep.Expediente_Id,
                       Padecimiento_Id = ep.Padecimiento_Id
                   };
        }

        public Exp_Pad ConsultarPorId(int id)
        {
            return _context.Exp_Pad.Find(id);
        }
    }
}
