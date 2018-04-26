using ITUniver.TeleCalc.Web.Interfaces;
using System.Web.Mvc;

namespace ITUniver.TeleCalc.Web.Models
{
    public class OperationModel : IEntity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Owner { get; set; }
    }
}