using CadPessoas.Models;

namespace CadPessoas.Services
{
    public interface IPessoaService
    {
        public void AddPessoa(Pessoa pessoa);
        public Pessoa RemovePessoa(int id);
        public List<Pessoa> GetPessoas(int pageNumber);

        public List<Pessoa> GetPessoasByName(string searchString, string searchStringCpf);
        public void EditPessoa(Pessoa pessoa);
    }
}
