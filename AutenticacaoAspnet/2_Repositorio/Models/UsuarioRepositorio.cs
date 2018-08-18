using AutenticacaoAspnet._1_Infra;
using AutenticacaoAspnet._2_Repositorio.Core;
using AutenticacaoAspnet.Models;
using AutenticacaoAspnet.Utils;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutenticacaoAspnet._2_Repositorio.Models
{
    public class UsuarioRepositorio : IRepositorio<Usuario>
    {
        IDb _Db;
        internal UsuarioRepositorio(IDb db)
        {
            _Db = db;
        }


        public void inserir(Usuario Item)
        {
            using (var db = _Db.connection())
            {
                db.Execute("INSERT INTO USUARIOS (NOME,LOGIN,SENHA,ConfirmacaoSenha) VALUES (@NOME,@LOGIN,@SENHA,@ConfirmacaoSenha)", Item);
            }
        }
        public IEnumerable<Usuario> Listar()
        {
            using (var db = _Db.connection())
            {
                return db.Query<Usuario>("SELECT * FROM USUARIO");
            }
        }
        public void Remover(Usuario Item)
        {
            using (var db = _Db.connection())
            {
                db.Execute("DELETE  FROM USUARIO WHERE ID=@ID", new { Item.ID });
            }
        }
        public void Atualizar(Usuario Item)
        {
            using (var db = _Db.connection())
            {
                db.Execute("UPDATE USUARIOS SET NOME=@NOME,LOGIN=@LOGIN,SENHA=@SENHA,ConfirmacaoSenha=@ConfirmacaoSenha WHERE ID=@ID", Item);
            }
        }

        public Usuario BuscarPorID(int ID)
        {
            using (var db = _Db.connection())
            {
                try
                {
                    return db.QueryFirstOrDefault<Usuario>("SELECT * FROM USUARIOS WHERE ID=@ID", new { ID });
                }
                catch(Exception err)
                {
                    return null;
                }
            }
        }
        public bool VerificarSeExiteNoBanco(Usuario Item)
        {
            using (var db = _Db.connection())
            {
                var count = db.ExecuteScalar("SELECT count(*) FROM USUARIOS WHERE LOGIN=@LOGIN", new { Item.Login });
                if ((int)count > 0)
                    return true;
                return false;
            }
        }
        public Usuario BuscarPorLogin(Usuario item)
        {
            using (var db = _Db.connection())
            {
                return db.QueryFirstOrDefault<Usuario>("SELECT * FROM USUARIOS WHERE LOGIN=@LOGIN", new { item.Login });

            }
        }
        public void AlterarSenha(Usuario Item)
        {
            using (var db = _Db.connection())
            {
                db.Execute("Update USUARIOS set Senha=@senha ", Item);
            }
        }

    }
}