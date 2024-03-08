using CustomExHandler;
using DataModels;
using Microsoft.AspNetCore.Mvc;


namespace MaterialMicroService
{
    internal class ExecutionClass
    {
        private readonly ILogger _logger;
        private ILogger logger;

        public ExecutionClass(ILogger logger)
        {
            this._logger = logger;
        }

        public async Task<ActionResult<MaterialsSearchResult>> SearchMaterials(MaterialsSearch searchParams)
        {
            _logger.LogDebug("Start Execution of SearchMaterials");
            //await _context.SaveChangesAsync();

            throw new Exception("Hey I just created this exception");

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return new MaterialsSearchResult { MaterialId = 12131, MaterialName = "some item", MaterialCode = "C", SourceSystem = "PW" };
        }
    }
}
