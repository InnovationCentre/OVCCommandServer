using Microsoft.Azure.Mobile.Server;
using OVCMobileService.DataObjects;
using OVCMobileService.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

namespace OVCMobileService.Controllers
{
    public class UnitTypeController : TableController<UnitType>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            OVCMobileContext context = new OVCMobileContext();
            DomainManager = new EntityDomainManager<UnitType>(context, Request);
        }

        // GET tables/TodoItem
        public IQueryable<UnitType> GetAllTodoItems()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UnitType> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UnitType> PatchTodoItem(string id, Delta<UnitType> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostTodoItem(UnitType item)
        {
            UnitType current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}
