using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class UsuarioController : Controller
    {
        private EFUsuario EFUsuario = new EFUsuario();
        // GET: Usuario
        public ActionResult Index()
        {
            
            return View(EFUsuario.Listar());
        }

        public ActionResult Criar()
        {
            EFGrupo EFGrupo = new EFGrupo();
            var selectList = new SelectList(EFGrupo.Listar(), "Id", "Nome", 1);
            ViewData["Grupos"] = selectList;
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Usuario _usuario)
        {
            EFUsuario.Criar(_usuario);
            return RedirectToAction("Index").Mensagem("Usuario "+ _usuario.Nome+" criado!", "Sucesso");
        }

        public ActionResult Alterar(int id)
        {
            EFGrupo EFGrupo = new EFGrupo();
            var selectList = new SelectList(EFGrupo.Listar(), "Id", "Nome", 1);
            ViewData["Grupos"] = selectList;
            return View(EFUsuario.Buscar(id));
        }

        [HttpPost]
        public ActionResult Alterar(Usuario _usuario)
        {
            EFUsuario.Alterar(_usuario);
            return RedirectToAction("Index").Mensagem("Usuario " + _usuario.Nome + " alterado!", "Sucesso");
        }

        public ActionResult Deletar(int id)
        {
            
            return View(EFUsuario.Buscar(id));
        }

        [HttpPost]
        public ActionResult Deletar(Usuario _usuario)
        {
            EFUsuario.Deletar(_usuario);
            return RedirectToAction("Index").Mensagem("Usuario " + _usuario.Nome + " deletado", "Sucesso");
        }
    }
}