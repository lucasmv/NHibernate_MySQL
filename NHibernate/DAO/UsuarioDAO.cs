using NHibernate;
using NHibernate_Curso.Entidades;
using NHibernate_Curso.Infra;
using System.Linq;

namespace NHibernate_Curso.DAO
{
    public class UsuarioDAO
    {
        private ISession session;
        public UsuarioDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Usuario usuario)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(usuario);
            transacao.Commit();
        }

        public void Remover(Usuario usuario)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(usuario);
            transacao.Commit();
        }

        public Usuario BuscaPorId(int id)
        {
            return session.Get<Usuario>(id);
        }

        public Usuario BuscaPorNome(string nome)
        {
            return session.QueryOver<Usuario>().Where(x => x.Nome == nome).List().FirstOrDefault();
        }
    }
}
