using Microsoft.AspNetCore.Mvc;
using MyAquariumManager.Application.DTOs.Conta;
using MyAquariumManager.Application.DTOs.Usuario;
using MyAquariumManager.Web.Extensions;

namespace MyAquariumManager.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private UsuarioSessionDto _usuarioLogado;
        protected UsuarioSessionDto UsuarioLogado
        {
            get
            {
                if (_usuarioLogado == null)
                {
                    _usuarioLogado = HttpContext.Session.GetObjectFromJson<UsuarioSessionDto>("usuario");
                }
                return _usuarioLogado;
            }
        }

        private ContaSessionDto _contaLogada;
        protected ContaSessionDto ContaLogada
        {
            get
            {
                if (_contaLogada == null)
                {
                    _contaLogada = HttpContext.Session.GetObjectFromJson<ContaSessionDto>("conta");
                }
                return _contaLogada;
            }
        }
    }
}
