using SENAI_UC14_AT2.Contexts;
using SENAI_UC14_AT2.Models;

namespace SENAI_UC14_AT2.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoApiContext _context;

        public ProjetoRepository(ExoApiContext context)
        {
            _context = context;
        }

        public List<Projeto> Listar() 
        {
            return _context.Projetos.ToList();
        }

        public Projeto BuscarPorId(int id) 
        {
            return _context.Projetos.Find(id);
        }

        public void Cadastrar(Projeto projeto) 
        {
            _context.Projetos.Add(projeto);

            _context.SaveChanges();
        }

        public void Atualizar(int id, Projeto projeto)
        {
            Projeto projetoBuscado = _context.Projetos.Find(id);

            if(projetoBuscado != null)
            {
                projetoBuscado.Titulo = projeto.Titulo;

                projetoBuscado.StatusProjeto = projeto.StatusProjeto;

                projetoBuscado.DataInicio = projeto.DataInicio;

                projetoBuscado.Requisitos = projeto.Requisitos;

                projetoBuscado.Area = projeto.Area;

                _context.Projetos.Update(projetoBuscado);

                _context.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            Projeto projeto = _context.Projetos.Find(id);

            _context.Projetos.Remove(projeto);

            _context.SaveChanges();
        }
    }
}
