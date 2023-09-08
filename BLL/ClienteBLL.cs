using Microsoft.EntityFrameworkCore;
using ClientesApp.DAL;
using ClientesApp.Models;
using System.Linq.Expressions;

namespace ClientesApp.BLL
{
    public class ClienteBLL
    {
        private Contexto contexto;
        public ClienteBLL(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public bool Existe(int clienteId)
        {
            return contexto.Cliente.Any(c => c.ClienteId == clienteId);
        }
        public bool Insertar(Cliente cliente)
        {
            contexto.Cliente.Add(cliente);
            return contexto.SaveChanges() > 0;
        }
        public bool Modificar(Cliente cliente)
        {
            var p = contexto.Cliente.Find(cliente.ClienteId);
            contexto.Entry(p!).State = EntityState.Detached;
            contexto.Entry(cliente).State = EntityState.Modified;
            return contexto.SaveChanges() > 0;
        }
        public bool Guardar(Cliente cliente)
        {
            if (!Existe(cliente.ClienteId))
                return this.Insertar(cliente);
            else
                return this.Modificar(cliente);
        }
        public bool Eliminar(Cliente cliente)
        {
            if (cliente != null)
            {
                var p = contexto.Cliente.Find(cliente.ClienteId);
                contexto.Entry(p!).State = EntityState.Detached;
                contexto.Entry(cliente).State = EntityState.Deleted;
                return contexto.SaveChanges() > 0;
            }
            return false;
        }

        public Cliente? Buscar(int ClienteId)
        {
            return contexto.Cliente
                    .AsNoTracking()
                    .SingleOrDefault(p => p.ClienteId == ClienteId);
        }
        public List<Cliente> Listar(Expression<Func<Cliente, bool>> Criterio)
        {
            return contexto.Cliente
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToList();
        }

        public Cliente? BuscarPorNombres(string? nombres)
        {
            return contexto.Cliente.AsNoTracking().SingleOrDefault(c => c.Nombres == nombres);
        }
        public Cliente? BuscarPorRnc(string? rnc)
        {
            return contexto.Cliente.AsNoTracking().SingleOrDefault(c => c.Rnc == rnc);
        }

    }
}
