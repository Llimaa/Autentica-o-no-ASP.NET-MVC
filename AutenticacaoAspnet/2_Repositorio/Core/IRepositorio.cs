using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutenticacaoAspnet._2_Repositorio.Core
{
    interface IRepositorio<T>
    {
        void inserir(T Item);
        void Remover(T Item);
        void Atualizar(T Item);
        T BuscarPorID(int ID);
        IEnumerable<T> Listar();
    }
}
