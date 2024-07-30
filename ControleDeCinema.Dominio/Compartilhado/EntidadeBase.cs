namespace Controle_de_Cinema_Web.Dominio.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }

        public abstract void AtualizarInformacoes(EntidadeBase registroAtualizado);

        public abstract List<string> Validar();

    }
}
