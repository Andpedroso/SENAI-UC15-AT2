namespace SENAI_UC14_AT2.Models
{
    public class Projeto
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }

        public int StatusProjeto { get; set; }

        public string DataInicio { get; set; }

        public string Requisitos { get; set; }

        public string Area { get; set; }
    }
}
