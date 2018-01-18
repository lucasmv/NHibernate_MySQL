using NHibernate.Cfg;
using NHibernate_Curso.DAO;
using NHibernate_Curso.Entidades;
using NHibernate_Curso.Infra;
using System;

namespace NHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            //NHibernateHelper.GeraSchema();

            /*Configuration cfg = NHibernateHelper.RecuperaConfiguracao();
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();

            var usuario = new Usuario();
            usuario.Nome = "Magno";

            ITransaction transacao = session.BeginTransaction();
            session.Save(usuario);
            transacao.Commit();

            session.Close();*/

            ISession session = NHibernateHelper.AbreSession();
            UsuarioDAO dao = new UsuarioDAO(session);

            var usuario = new Usuario();
            usuario.Nome = "Magno";

            dao.Adiciona(usuario);

            var teste = dao.BuscaPorNome("Lucas");

            session.Close();

            Console.Read();
        }
    }
}
