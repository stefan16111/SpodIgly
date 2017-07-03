using MvcSiteMapProvider;
using SpodIgly.DAL;
using SpodIgly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpodIgly.Infrastructure
{
    public class ProductListDynamicNodeProvider : DynamicNodeProviderBase
    {
        private StoreContext db = new StoreContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Genre g in db.Genres)
            {
                DynamicNode n = new DynamicNode();
                n.Title = g.Name;
                n.Key = "Genre_" + g.GenreId;
                n.RouteValues.Add("genrename", g.Name);
                returnValue.Add(n);
            }

            return returnValue;
        }
    }
}